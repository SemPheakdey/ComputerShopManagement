using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace C_ShopProject
{
    class StaffData
    {
        public int ID { get; set; }
        public string StaffID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Contact { get; set; }
        public string Position { get; set; }
        public string ImagePath { get; set; } // Store the image path
        public float Salary { get; set; }
        public string Status { get; set; }

        private readonly Database database = new Database();

        public List<StaffData> StaffListData()
        {
            List<StaffData> listdata = new List<StaffData>();
            using (SqlConnection conn = database.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();

                        string selectData = "SELECT * FROM Staffs WHERE delete_date IS NULL";

                        using (SqlCommand cmd = new SqlCommand(selectData, conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                StaffData sd = new StaffData();
                                sd.ID = (int)reader["id"];
                                sd.StaffID = reader["staff_id"].ToString();
                                sd.Name = reader["full_name"].ToString();
                                sd.Gender = reader["gender"].ToString();
                                sd.DateOfBirth = reader["date_of_birth"].ToString();
                                sd.Contact = reader["contact_number"].ToString();
                                sd.Position = reader["position"].ToString();
                                sd.ImagePath = reader["image"].ToString(); // Store the image path
                                sd.Salary = reader["salary"] != DBNull.Value ? Convert.ToSingle(reader["salary"]) : 0.0f;
                                sd.Status = reader["status"].ToString();

                                listdata.Add(sd);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error list data" + ex);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return listdata;
        }
    }

}
