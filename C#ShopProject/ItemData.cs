using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace C_ShopProject
{
    internal class ItemData
    {
        public int ID { get; set; } // 0
        public int ItemCode { get; set; } // 1
        public string ItemName { get; set; } // 2
        public float Price { get; set; } // 3
        public int TotalQty { get; set; } // 4
        public int Paidby { get; set; } //5
        public int QtyUpdate { get; set; } //6
        // Properties for sales data
        public int Quantity { get; set; }
        public int Total_import { get; set; }
        public decimal TotalPrice { get; set; }

        private readonly Database database = new Database();

        public List<ItemData> ItemListData()
        {
            List<ItemData> ItemListData = new List<ItemData>();

            using (SqlConnection conn = database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();
                        string selectData = "SELECT * FROM Computer";

                        using (SqlCommand cmd = new SqlCommand(selectData, conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                ItemData cd = new ItemData
                                {
                                    ID = (int)reader["id"],
                                    ItemCode = (int)reader["item_code"],
                                    ItemName = reader["item_name"].ToString(),
                                    Price = (reader["price"] != DBNull.Value ? Convert.ToSingle(reader["price"]) : 0.0f),
                                    TotalQty = (int)reader["qty"],
                                };

                                ItemListData.Add(cd);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error listing data: " + ex.Message);
                    }
                }
            }

            return ItemListData;
        }
    }
}
