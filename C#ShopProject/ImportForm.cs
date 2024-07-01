using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class importForm : Form
    {
        private readonly Database _database;

        public importForm()
        {
            InitializeComponent();
            _database = new Database();
            displayComputerData();

            // Add event handlers for Price_import and Qty_import TextChanged events
            Price_import.TextChanged += new EventHandler(CalculateTotal);
            Qty_import.TextChanged += new EventHandler(CalculateTotal);

            Total_import.ReadOnly = true;
            Itemcode_import.ReadOnly = true;

            using (SqlConnection conn = _database.GetConnection())
            {
                conn.Open();
                Itemcode_import.Text = GetNextItemCode().ToString();
            }

        }

        public void displayComputerData()
        {
            ComputerData cd = new ComputerData();
            List<ComputerData> listData = cd.ComputerListData();

            dataGridView1.DataSource = listData;
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            if (decimal.TryParse(Price_import.Text.Trim(), out decimal price) &&
                int.TryParse(Qty_import.Text.Trim(), out int qty))
            {
                Total_import.Text = (price * qty).ToString("0.00");
            }
            else
            {
                Total_import.Text = "0.00";
            }
        }

        private void add_importform_btn_Click(object sender, EventArgs e)
        {
            if (Date_import.Value == DateTimePicker.MinimumDateTime
                || string.IsNullOrWhiteSpace(Supplier_import.Text)
                || string.IsNullOrWhiteSpace(Contact_import.Text)
                || string.IsNullOrWhiteSpace(Itemname_import.Text)
                || string.IsNullOrWhiteSpace(Price_import.Text)
                || string.IsNullOrWhiteSpace(Qty_import.Text)
                || string.IsNullOrWhiteSpace(Total_import.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = _database.GetConnection())
                    {
                        conn.Open(); // Ensure connection is open

                        string checkItemNameQuery = "SELECT qty FROM Computer WHERE item_name = @item_name";
                        using (SqlCommand checkItemNameCmd = new SqlCommand(checkItemNameQuery, conn))
                        {
                            checkItemNameCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                            object result = checkItemNameCmd.ExecuteScalar();

                            if (result != null)
                            {
                                // Item exists, ask for confirmation to update
                                DialogResult confirmResult = MessageBox.Show("The item already exists. Do you want to update it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (confirmResult == DialogResult.Yes)
                                {
                                    // Update existing item
                                    int existingQty = Convert.ToInt32(result);
                                    int newQty = existingQty + Convert.ToInt32(Qty_import.Text.Trim());
                                    DateTime today = DateTime.Today;

                                    string updateComputerQuery = "UPDATE Computer SET date = @date, supplier = @supplier, contact = @contact, " +
                                        "price = @price, qty = @qty, update_date = @update_date WHERE item_name = @item_name";

                                    using (SqlCommand updateComputerCmd = new SqlCommand(updateComputerQuery, conn))
                                    {
                                        updateComputerCmd.Parameters.AddWithValue("@date", Date_import.Value);
                                        updateComputerCmd.Parameters.AddWithValue("@supplier", Supplier_import.Text.Trim());
                                        updateComputerCmd.Parameters.AddWithValue("@contact", Contact_import.Text.Trim());
                                        updateComputerCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                                        updateComputerCmd.Parameters.AddWithValue("@qty", newQty);
                                        updateComputerCmd.Parameters.AddWithValue("@price", Price_import.Text.Trim());
                                        updateComputerCmd.Parameters.AddWithValue("@update_date", today);

                                        updateComputerCmd.ExecuteNonQuery();
                                    }
                                    string insertReportQuery = "INSERT INTO Report (date, supplier, contact, item_code, item_name, price, qty, total, action) " +
                                       "VALUES (@date, @supplier, @contact, @item_code, @item_name, @price, @qty, @total, @action)";

                                    using (SqlCommand insertReportCmd = new SqlCommand(insertReportQuery, conn))
                                    {
                                        insertReportCmd.Parameters.AddWithValue("@date", today);
                                        insertReportCmd.Parameters.AddWithValue("@supplier", Supplier_import.Text.Trim());
                                        insertReportCmd.Parameters.AddWithValue("@contact", Contact_import.Text.Trim());
                                        insertReportCmd.Parameters.AddWithValue("@item_code", Itemcode_import.Text.Trim());
                                        insertReportCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                                        insertReportCmd.Parameters.AddWithValue("@qty", Qty_import.Text.Trim());
                                        insertReportCmd.Parameters.AddWithValue("@price", Price_import.Text.Trim());
                                        insertReportCmd.Parameters.AddWithValue("@total", Total_import.Text.Trim());
                                        insertReportCmd.Parameters.AddWithValue("@action", "ADD");

                                        insertReportCmd.ExecuteNonQuery();
                                    }
                                    displayComputerData();
                                    MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearFields();
                                }
                            }
                            else
                            {
                                // Item does not exist, insert new record
                                DateTime today = DateTime.Today;
                                string insertComputerQuery = "INSERT INTO Computer (date, supplier, contact, item_name, price, qty, insert_date, item_code) " +
                                    "VALUES (@date, @supplier, @contact, @item_name, @price, @qty, @insert_date, @item_code); SELECT SCOPE_IDENTITY();";

                                int newItemCode = GetNextItemCode();
                                using (SqlCommand insertComputerCmd = new SqlCommand(insertComputerQuery, conn))
                                {
                                    insertComputerCmd.Parameters.AddWithValue("@date", Date_import.Value);
                                    insertComputerCmd.Parameters.AddWithValue("@supplier", Supplier_import.Text.Trim());
                                    insertComputerCmd.Parameters.AddWithValue("@contact", Contact_import.Text.Trim());
                                    insertComputerCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                                    insertComputerCmd.Parameters.AddWithValue("@qty", Qty_import.Text.Trim());
                                    insertComputerCmd.Parameters.AddWithValue("@price", Price_import.Text.Trim());
                                    insertComputerCmd.Parameters.AddWithValue("@insert_date", today);
                                    insertComputerCmd.Parameters.AddWithValue("@item_code", newItemCode);

                                    insertComputerCmd.ExecuteNonQuery();
                                }

                                string insertReportQuery = "INSERT INTO Report (date, supplier, contact, item_code, item_name, price, qty, total, action) " +
                                    "VALUES (@date, @supplier, @contact, @item_code, @item_name, @price, @qty, @total, @action)";

                                using (SqlCommand insertReportCmd = new SqlCommand(insertReportQuery, conn))
                                {
                                    insertReportCmd.Parameters.AddWithValue("@date", today);
                                    insertReportCmd.Parameters.AddWithValue("@supplier", Supplier_import.Text.Trim());
                                    insertReportCmd.Parameters.AddWithValue("@contact", Contact_import.Text.Trim());
                                    insertReportCmd.Parameters.AddWithValue("@item_code", newItemCode);
                                    insertReportCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                                    insertReportCmd.Parameters.AddWithValue("@qty", Qty_import.Text.Trim());
                                    insertReportCmd.Parameters.AddWithValue("@price", Price_import.Text.Trim());
                                    insertReportCmd.Parameters.AddWithValue("@total", Total_import.Text.Trim());
                                    insertReportCmd.Parameters.AddWithValue("@action", "ADD");

                                    insertReportCmd.ExecuteNonQuery();
                                }

                                displayComputerData();
                                MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetNextItemCode()
        {
            int nextItemCode = 1000;
            string query = "SELECT MAX(item_code) FROM Computer";

            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        nextItemCode = Math.Max(nextItemCode, Convert.ToInt32(result)) + 1;
                    }
                }
            }

            return nextItemCode;
        }



        public void clearFields()
        {
            Date_import.Value = DateTimePicker.MinimumDateTime;
            Supplier_import.Text = "";
            Contact_import.Text = "";
            Itemcode_import.Text = GetNextItemCode().ToString(); // Refresh the item code
            Itemname_import.Text = "";
            Price_import.Text = "";
            Qty_import.Text = "";
            Total_import.Text = "";
        }

        private void update_importform_btn_Click(object sender, EventArgs e)
        {
            if (Date_import.Value == DateTimePicker.MinimumDateTime
                || Supplier_import.Text == ""
                || Contact_import.Text == ""
                || Itemcode_import.Text == ""
                || Itemname_import.Text == ""
                || Price_import.Text == ""
                || Qty_import.Text == ""
                || Total_import.Text == ""
                )
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE " +
                    "Item Name: " + Itemname_import.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    using (SqlConnection conn = _database.GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            DateTime today = DateTime.Today;

                            string updateComputerQuery = "UPDATE Computer SET date = @date, supplier = @supplier, contact = @contact, item_code = @itemcode, " +
                                "price = @price, qty = @qty, update_date = @update_date WHERE item_name = @item_name";

                            using (SqlCommand updateComputerCmd = new SqlCommand(updateComputerQuery, conn))
                            {
                                updateComputerCmd.Parameters.AddWithValue("@date", Date_import.Value);
                                updateComputerCmd.Parameters.AddWithValue("@supplier", Supplier_import.Text.Trim());
                                updateComputerCmd.Parameters.AddWithValue("@contact", Contact_import.Text.Trim());
                                updateComputerCmd.Parameters.AddWithValue("@item_code", Itemcode_import.Text.Trim());
                                updateComputerCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                                updateComputerCmd.Parameters.AddWithValue("@qty", Qty_import.Text.Trim());
                                updateComputerCmd.Parameters.AddWithValue("@price", Price_import.Text.Trim());
                                //updateComputerCmd.Parameters.AddWithValue("@total", Total_import.Text.Trim());
                                updateComputerCmd.Parameters.AddWithValue("@update_date", today);

                                updateComputerCmd.ExecuteNonQuery();
                            }

                            string insertReportQuery = "INSERT INTO Report (date, supplier, contact,item_code, item_name, price, qty,total, action) " +
                                    "VALUES (@date, @supplier, @contact,@item_code, @item_name, @price, @qty,@total , @action)";

                            using (SqlCommand updateReportCmd = new SqlCommand(insertReportQuery, conn))
                            {
                                updateReportCmd.Parameters.AddWithValue("@date", today);
                                updateReportCmd.Parameters.AddWithValue("@supplier", Supplier_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@contact", Contact_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@item_code", Itemcode_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@qty", Qty_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@price", Price_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@total", Total_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@action", "UPDATE");

                                updateReportCmd.ExecuteNonQuery();
                            }

                            displayComputerData();
                            MessageBox.Show("Update successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Assuming the column indices are correct
                Date_import.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                Supplier_import.Text = row.Cells[2].Value.ToString();
                Contact_import.Text = row.Cells[3].Value.ToString();
                Itemcode_import.Text = row.Cells[4].Value.ToString();
                Itemname_import.Text = row.Cells[5].Value.ToString();
                Qty_import.Text = row.Cells[6].Value.ToString();
                Price_import.Text = row.Cells[7].Value.ToString();
                Total_import.Text = row.Cells[8].Value.ToString();
            }
        }

        private void search_import_btn_Click(object sender, EventArgs e)
        {
            string searchItemName = Itemname_import.Text.Trim();
            if (!string.IsNullOrEmpty(searchItemName))
            {
                using (SqlConnection conn = _database.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string searchQuery = "SELECT id, date, supplier, contact,item_code,  item_name, price, qty, total FROM Computer WHERE item_name = @item_name";

                        using (SqlCommand cmd = new SqlCommand(searchQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@item_name", searchItemName);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter an item name to search.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void report_importform_btn_Click(object sender, EventArgs e)
        {
            ReportImportForm reportForm = new ReportImportForm();
            reportForm.Show();
        }

        private void delete_import_form_Click(object sender, EventArgs e)
        {
            string itemNameToDelete = Itemname_import.Text.Trim();
            if (!string.IsNullOrEmpty(itemNameToDelete))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the item with the name '" + itemNameToDelete + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = _database.GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            DateTime today = DateTime.Today;
                            // Retrieve the data before deletion for inserting into the report
                            string insertReportQuery = "INSERT INTO Report (date, supplier, contact, item_code, item_name, price, qty, total, action) " +
                                                       "VALUES (@date, @supplier, @contact,@item_code, @item_name, @price, @qty, @total, @action)";

                            using (SqlCommand updateReportCmd = new SqlCommand(insertReportQuery, conn))
                            {
                                updateReportCmd.Parameters.AddWithValue("@date", today);
                                updateReportCmd.Parameters.AddWithValue("@supplier", Supplier_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@contact", Contact_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@item_code", Itemcode_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@item_name", Itemname_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@qty", Qty_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@price", Price_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@total", Total_import.Text.Trim());
                                updateReportCmd.Parameters.AddWithValue("@action", "DELETE");

                                updateReportCmd.ExecuteNonQuery();
                            }
                            // Delete the item from the Computer table
                            string deleteQuery = "DELETE FROM Computer WHERE item_name = @item_name";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@item_name", itemNameToDelete);
                                int rowsAffected = deleteCmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Item '" + itemNameToDelete + "' deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    displayComputerData(); // Refresh the DataGridView after deletion
                                    clearFields(); // Clear the input fields
                                }
                                else
                                {
                                    MessageBox.Show("No item found with the name '" + itemNameToDelete + "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter an item name to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreash_btn_Click(object sender, EventArgs e)
        {
            displayComputerData(); // Refresh the DataGridView
            Date_import.Value = DateTime.Now.Date;
            Supplier_import.Text = "";
            Contact_import.Text = "";
            Itemcode_import.Text = GetNextItemCode().ToString(); // Refresh the item code
            Itemname_import.Text = "";
            Price_import.Text = "";
            Qty_import.Text = "";
            Total_import.Text = "";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Price_import_TextChanged(object sender, EventArgs e)
        {

        }

        private void importForm_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
