using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class StatusForm : Form
    {
        private Database _database;
        private DataTable _saleItemsTable;
        private int _selectedDeliveryID;

        public StatusForm()
        {
            InitializeComponent();
            _database = new Database(); // Assuming Database class handles database operations
            StatusForm_Load();
            SetupDataGridViewEvents(); // Attach event handlers
            AttachButtonEventHandlers(); // Attach click event handler for the button
        }

        private void StatusForm_Load()
        {
            LoadDeliveryData();
        }

        private void LoadDeliveryData()
        {
            try
            {
                using (SqlConnection conn = _database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DeliveryID, DeliveryName, PhoneNumber, Address, PickupTime, Status, SaleID FROM Delivery WHERE FinishTime IS NULL";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No data found in the Delivery table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridViewEvents()
        {
            dataGridView1.CellClick += DataGridView1_CellClick_1;
        }

        private void AttachButtonEventHandlers()
        {
            Finish_btn.Click -= Finish_btn_Click; // Ensure the handler is not attached multiple times
            Finish_btn.Click += Finish_btn_Click;
        }

        private void DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                _selectedDeliveryID = Convert.ToInt32(selectedRow.Cells["DeliveryID"].Value); // Store the selected DeliveryID
                int saleID = Convert.ToInt32(selectedRow.Cells["SaleID"].Value); // Assuming SaleID is the column name in dataGridView1

                // Load sale items based on SaleID into dataGridView2
                LoadSaleItems(saleID);
            }
        }

        private void LoadSaleItems(int saleID)
        {
            try
            {
                using (SqlConnection conn = _database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM SaleItems WHERE SaleID = @SaleID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@SaleID", saleID);
                    _saleItemsTable = new DataTable();
                    da.Fill(_saleItemsTable);

                    if (_saleItemsTable.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = _saleItemsTable;
                    }
                    else
                    {
                        dataGridView2.DataSource = null;
                        MessageBox.Show("No items found for SaleID: " + saleID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Finish_btn_Click(object sender, EventArgs e)
        {
            if (_selectedDeliveryID != 0)
            {
                try
                {
                    using (SqlConnection conn = _database.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE Delivery SET FinishTime = @FinishTime WHERE DeliveryID = @DeliveryID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@FinishTime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@DeliveryID", _selectedDeliveryID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Delivery updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDeliveryData(); // Refresh the dataGridView1 data
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a delivery to finish.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            if (_selectedDeliveryID != 0 && dataGridView2.Rows.Count > 0)
            {
                // Ask for confirmation before proceeding
                DialogResult result = MessageBox.Show($"Are you sure you want to cancel the delivery and return items to stock?",
                                                      "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = _database.GetConnection())
                        {
                            conn.Open();
                            SqlTransaction transaction = conn.BeginTransaction();

                            try
                            {
                                // Iterate through each item in dataGridView2 and update the Computer table with returned quantities
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    string itemName = row.Cells["ItemName"].Value.ToString();
                                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                                    // Update Computer table to add back quantity
                                    string updateItemsQuery = "UPDATE Computer SET qty = qty + @quantity WHERE item_name = @itemName";
                                    SqlCommand cmdUpdateItems = new SqlCommand(updateItemsQuery, conn, transaction);
                                    cmdUpdateItems.Parameters.AddWithValue("@quantity", quantity);
                                    cmdUpdateItems.Parameters.AddWithValue("@itemName", itemName);
                                    cmdUpdateItems.ExecuteNonQuery();
                                }

                                // Get the SaleID associated with the selected DeliveryID
                                string getSaleIDQuery = "SELECT SaleID FROM Delivery WHERE DeliveryID = @DeliveryID";
                                SqlCommand cmdGetSaleID = new SqlCommand(getSaleIDQuery, conn, transaction);
                                cmdGetSaleID.Parameters.AddWithValue("@DeliveryID", _selectedDeliveryID);
                                int saleID = Convert.ToInt32(cmdGetSaleID.ExecuteScalar());

                                // Delete the delivery from the database
                                string deleteDeliveryQuery = "DELETE FROM Delivery WHERE DeliveryID = @DeliveryID";
                                SqlCommand cmdDeleteDelivery = new SqlCommand(deleteDeliveryQuery, conn, transaction);
                                cmdDeleteDelivery.Parameters.AddWithValue("@DeliveryID", _selectedDeliveryID);
                                cmdDeleteDelivery.ExecuteNonQuery();

                                // Update Customer table to set CustomerType to 'Cancel'
                                string updateCustomerTypeQuery = "UPDATE Customer SET CustomerType = 'Cancel' WHERE SaleID = @SaleID";
                                SqlCommand cmdUpdateCustomerType = new SqlCommand(updateCustomerTypeQuery, conn, transaction);
                                cmdUpdateCustomerType.Parameters.AddWithValue("@SaleID", saleID);
                                cmdUpdateCustomerType.ExecuteNonQuery();

                                transaction.Commit();

                                MessageBox.Show("Delivery cancelled, items returned to stock, and customer status updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Clear and refresh both DataGridViews
                                dataGridView1.DataSource = null;
                                LoadDeliveryData(); // Reload dataGridView1

                                dataGridView2.DataSource = null; // Clear dataGridView2
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error cancelling delivery: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // If user selects No, do nothing
            }
            else
            {
                MessageBox.Show("Please select a delivery and ensure there are items to cancel before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
