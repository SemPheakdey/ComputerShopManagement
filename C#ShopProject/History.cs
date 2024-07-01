using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class History : Form
    {
        private Database _database;

        public History()
        {
            InitializeComponent();
            _database = new Database(); // Assuming Database class handles database operations
            LoadDeliveryData();
        }

        private void LoadDeliveryData()
        {
            try
            {
                using (SqlConnection conn = _database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    DeliveryID, 
                    DeliveryName, 
                    PhoneNumber, 
                    Address, 
                    PickupTime, 
                    FinishTime
                FROM Delivery
                ORDER BY DeliveryID DESC"; // Sort by DeliveryID ascending
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


        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
