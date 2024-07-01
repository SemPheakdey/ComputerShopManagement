using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class DeliveryForm : Form
    {
        private readonly Database _database;
        private DataGridViewRow selectedRow;

        public DeliveryForm()
        {
            InitializeComponent();
            _database = new Database();
            LoadData();
        }

        private void LoadData()
        {
            // Load customer sales data
            LoadCustomerSalesData();
        }

        private void LoadCustomerSalesData()
        {
            using (SqlConnection conn = _database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Customer WHERE CustomerType = 'Online'  AND Delivery IS NULL";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string SaleID = row.Cells["SaleID"].Value.ToString();
                LoadSaleItemsForCustomer(SaleID);

                selectedRow = dataGridView1.Rows[e.RowIndex]; // Store the selected row
            }
        }

        private void LoadSaleItemsForCustomer(string SaleID)
        {
            using (SqlConnection conn = _database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ItemName, Quantity, Price, PaidBy, CustomerType, Discount, Booking, TotalPrice FROM SaleItems WHERE SaleID = @SaleID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@SaleID", SaleID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PickUp_btn_Click(object sender, EventArgs e)
        {
            string deliveryName = DeliveryName.Text.Trim();
            string phoneNumber = PhoneNumber.Text.Trim();
            string address = Address.Text.Trim();

            // Check if all required fields are filled
            if (string.IsNullOrEmpty(deliveryName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill in all required fields (Delivery Name, Phone Number, Address).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if any field is empty
            }

            if (selectedRow != null)
            {
                // Check if there is a selected SaleID
                if (selectedRow.Cells["SaleID"].Value == null)
                {
                    MessageBox.Show("Please select a customer with a valid SaleID from the list before picking up.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string saleID = selectedRow.Cells["SaleID"].Value.ToString();

                // Check if there are rows in dataGridView2
                if (dataGridView2.Rows.Count == 0)
                {
                    MessageBox.Show("There are no sale items to pick up for this customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if no sale items are present
                }

                DateTime pickupTime = DateTime.Now; // Assuming pickup time is current time
                string status = "On the Way"; // Initial status could be pending

                // Insert into Delivery table
                using (SqlConnection conn = _database.GetConnection())
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        // Insert into Delivery table
                        string insertDeliveryQuery = "INSERT INTO Delivery (DeliveryName, PhoneNumber, Address, PickupTime, Status, SaleID) " +
                                                     "VALUES (@DeliveryName, @PhoneNumber, @Address, @PickupTime, @Status, @SaleID); SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdInsert = new SqlCommand(insertDeliveryQuery, conn, transaction);
                        cmdInsert.Parameters.AddWithValue("@DeliveryName", deliveryName);
                        cmdInsert.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmdInsert.Parameters.AddWithValue("@Address", address);
                        cmdInsert.Parameters.AddWithValue("@PickupTime", pickupTime);
                        cmdInsert.Parameters.AddWithValue("@Status", status);
                        cmdInsert.Parameters.AddWithValue("@SaleID", saleID); // Use SaleID here

                        // Execute insert and get the inserted delivery ID
                        int deliveryID = Convert.ToInt32(cmdInsert.ExecuteScalar());

                        // Update Customer table
                        string updateCustomerQuery = "UPDATE Customer SET Delivery = @DeliveryID WHERE SaleID = @SaleID";
                        SqlCommand cmdUpdate = new SqlCommand(updateCustomerQuery, conn, transaction);
                        cmdUpdate.Parameters.AddWithValue("@DeliveryID", deliveryID);
                        cmdUpdate.Parameters.AddWithValue("@SaleID", saleID);
                        cmdUpdate.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Delivery details successfully added and customer updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh both DataGridViews
                        dataGridView1.DataSource = null; // Clear the current data source
                        LoadCustomerSalesData(); // Reload dataGridView1

                        // Clear dataGridView2 again to ensure it's empty
                        dataGridView2.DataSource = null;

                        // Clear input fields
                        DeliveryName.Text = "";
                        PhoneNumber.Text = "";
                        Address.Text = "";
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer from the list before picking up.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Status_btn_Click(object sender, EventArgs e)
        {
            StatusForm statusForm = new StatusForm();
            statusForm.Show();
        }

        private void History_btn_Click(object sender, EventArgs e)
        {
            History History = new History();
            History.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null && dataGridView2.Rows.Count > 0)
            {
                string saleID = selectedRow.Cells["SaleID"].Value.ToString();

                // Ask for confirmation before proceeding
                DialogResult result = MessageBox.Show($"Are you sure you want to cancel the order for Customer '{selectedRow.Cells["CustomerName"].Value}' and return items to stock?",
                                                      "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Iterate through each item in dataGridView2 and update the Items table with returned quantities
                        using (SqlConnection conn = _database.GetConnection())
                        {
                            conn.Open();
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                string itemName = row.Cells["ItemName"].Value.ToString();
                                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                                // Update Items table to add back quantity
                                string updateItemsQuery = "UPDATE Computer SET qty = qty + @quantity WHERE item_name = @itemName";
                                SqlCommand cmdUpdateItems = new SqlCommand(updateItemsQuery, conn);
                                cmdUpdateItems.Parameters.AddWithValue("@quantity", quantity);
                                cmdUpdateItems.Parameters.AddWithValue("@itemName", itemName);
                                cmdUpdateItems.ExecuteNonQuery();
                            }

                            // Delete customer's order from the database
                            string deleteDeliveryQuery = "DELETE FROM Delivery WHERE SaleID = @saleID";
                            SqlCommand cmdDeleteDelivery = new SqlCommand(deleteDeliveryQuery, conn);
                            cmdDeleteDelivery.Parameters.AddWithValue("@saleID", saleID);
                            cmdDeleteDelivery.ExecuteNonQuery();

                            // Update Customer table to set CustomerType to 'Cancel'
                            string updateCustomerTypeQuery = "UPDATE Customer SET CustomerType = 'Cancel' WHERE SaleID = @saleID";
                            SqlCommand cmdUpdateCustomerType = new SqlCommand(updateCustomerTypeQuery, conn);
                            cmdUpdateCustomerType.Parameters.AddWithValue("@saleID", saleID);
                            cmdUpdateCustomerType.ExecuteNonQuery();
                        }

                        // Remove selected customer from dataGridView1
                        dataGridView1.Rows.Remove(selectedRow);

                        MessageBox.Show("Order cancelled, items returned to stock, and customer status updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear and refresh both DataGridViews
                        dataGridView1.DataSource = null;
                        LoadCustomerSalesData(); // Reload dataGridView1

                        dataGridView2.DataSource = null; // Clear dataGridView2
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error cancelling order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // If user selects No, do nothing
            }
            else
            {
                MessageBox.Show("Please select a customer and ensure there are items to cancel before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
