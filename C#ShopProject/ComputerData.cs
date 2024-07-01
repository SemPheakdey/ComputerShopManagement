using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_ShopProject
{
    class ComputerData
    {
        public int ID { get; set; } // 0
        public string Date { get; set; } // 1
        public string Supplier { get; set; } // 2
        public string Contact { get; set; } // 3
        public string ItemCode { get; set; } // 4
        public string ItemName { get; set; } // 5
        public int Qty { get; set; } // 6
        public float Price { get; set; } // 7
        public float Total_Price{ get; set; } // 8
       //public string Insert_date { get; set; } // 8
       // public string Update_date { get; set; } // 9

        private readonly Database database = new Database();

        public List<ComputerData> ComputerListData()
        {
            List<ComputerData> computerListData = new List<ComputerData>();

            using (SqlConnection conn = database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();
                        string selectData = "SELECT * FROM Computer ORDER BY qty DESC"; // Order by qty in descending order

                        using (SqlCommand cmd = new SqlCommand(selectData, conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                ComputerData cd = new ComputerData
                                {
                                    ID = (int)reader["id"],
                                    Date = reader["date"].ToString(),
                                    Supplier = reader["supplier"].ToString(),
                                    Contact = reader["contact"].ToString(),
                                    ItemCode = reader["item_code"].ToString(),
                                    ItemName = reader["item_name"].ToString(),
                                    Qty = (int)reader["qty"],
                                    Price = reader["price"] != DBNull.Value ? Convert.ToSingle(reader["price"]) : 0.0f,
                                    Total_Price = reader["total"] != DBNull.Value ? Convert.ToSingle(reader["total"]) : 0.0f
                                };

                                computerListData.Add(cd);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error listing data: " + ex.Message);
                    }
                }
            }

            return computerListData;
        }
    }
}

//CREATE TABLE Computer (
//    id INT PRIMARY KEY IDENTITY(1,1),
//    date DATE NULL,
//    supplier NVARCHAR(100) NULL,
//    contact NVARCHAR(100) NULL,
//    item_name NVARCHAR(100) NULL,
//    qty INT NULL,
//    price FLOAT(50) NULL
//);
