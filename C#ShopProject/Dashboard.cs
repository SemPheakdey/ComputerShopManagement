using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class Dashboard : Form
    {
        private readonly Database _database;

        public Dashboard()
        {
            InitializeComponent();
            _database = new Database();
            DisplayTotalStaff();
            DisplayTotalActiveStaff();
            DisplayTotalComputers();
        }

        private void DisplayTotalStaff()
        {
            try
            {
                using (SqlConnection connection = _database.GetConnection())
                {
                    connection.Open();

                    // Query to count the number of active staff in the Staffs table
                    string query = "SELECT COUNT(*) FROM Staffs WHERE delete_date IS NULL";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int totalStaff = (int)command.ExecuteScalar();

                        // Display the total active staff count in the label
                        total_staff.Text = totalStaff.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DisplayTotalActiveStaff()
        {
            try
            {
                using (SqlConnection connection = _database.GetConnection())
                {
                    connection.Open();

                    // Query to count the number of active staff in the Staffs table
                    string query = "SELECT COUNT(*) FROM Staffs WHERE [status] = 'Active' AND delete_date IS NULL";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int totalActiveStaff = (int)command.ExecuteScalar();

                        // Display the total active staff count in the label
                        active_staff.Text = totalActiveStaff.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DisplayTotalComputers()
        {
            try
            {
                using (SqlConnection connection = _database.GetConnection())
                {
                    connection.Open();

                    // Query to sum up the quantity of all computers
                    string query = "SELECT SUM(qty) FROM Computer";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result (sum of all quantities)
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            int totalQuantity = Convert.ToInt32(result);

                            // Display the total quantity of computers
                            Totalcomputer.Text = totalQuantity.ToString();
                        }
                        else
                        {
                            // If there are no records or all quantities are NULL
                            Totalcomputer.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
