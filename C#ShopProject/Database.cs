using Aspose.Pdf.Operators;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;

namespace C_ShopProject
{
    internal class Database
    {
        private readonly string connectionString = "Data Source=PHEAKDEY-SEM-IC\\SQLEXPRESS01 ;Initial Catalog=COMPUTER; Integrated Security=True";

        public SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating SQL connection: " + ex.Message);
            }
        }
        public void SaveSale(string date, string saleAssociate, string customerName, string phoneNumber, List<ItemData> itemList, string paidby, string CustomerType, string Discount, String Booking)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DateTime parsedDate = DateTime.Parse(date);
                        string insertSaleQuery = @"
                    INSERT INTO Customer (Date, SaleAssociate, CustomerName, PhoneNumber,CustomerType) 
                    VALUES (@Date, @SaleAssociate, @CustomerName, @PhoneNumber,@CustomerType);
                    SELECT SCOPE_IDENTITY();";

                        long saleId;

                        using (var command = new SqlCommand(insertSaleQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Date", parsedDate);
                            command.Parameters.AddWithValue("@SaleAssociate", saleAssociate);
                            command.Parameters.AddWithValue("@CustomerName", customerName);
                            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            command.Parameters.AddWithValue("@CustomerType", CustomerType);

                            saleId = Convert.ToInt64(command.ExecuteScalar());
                        }

                        string insertSaleItemQuery = @"
                    INSERT INTO SaleItems (SaleID, ItemName, Quantity, Price, PaidBy, TotalPrice ,CustomerType, Discount, Booking) 
                    VALUES (@SaleID, @ItemName, @Quantity, @Price, @PaidBy, @TotalPrice , @CustomerType, @Discount, @Booking);";

                        DateTime today = DateTime.Today;
                        foreach (var item in itemList)
                        {
                            using (var command = new SqlCommand(insertSaleItemQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@SaleID", saleId);
                                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                command.Parameters.AddWithValue("@Price", item.Price);
                                command.Parameters.AddWithValue("@PaidBy", paidby);
                                command.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);
                                command.Parameters.AddWithValue("@CustomerType", CustomerType);
                                command.Parameters.AddWithValue("@Discount", Discount);
                                command.Parameters.AddWithValue("@Booking", Booking);


                                command.ExecuteNonQuery();
                            }

                            string insertInvoiceQuery = @"
                    INSERT INTO Invoice (SaleID, Date, SaleAssociate, CustomerName, PhoneNumber, ItemName, Quantity, Price, Paidby,CustomerType, Discount, Booking, TotalPrice) 
                    VALUES (@SaleID, @Date, @SaleAssociate, @CustomerName, @PhoneNumber, @ItemName, @Quantity, @Price, @Paidby, @CustomerType, @Discount, @Booking, @TotalPrice );";
                            using (var command = new SqlCommand(insertInvoiceQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@SaleID", saleId);
                                command.Parameters.AddWithValue("@Date", parsedDate);
                                command.Parameters.AddWithValue("@SaleAssociate", saleAssociate);
                                command.Parameters.AddWithValue("@CustomerName", customerName);
                                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                command.Parameters.AddWithValue("@Price", item.Price);
                                command.Parameters.AddWithValue("@Paidby", paidby);
                                command.Parameters.AddWithValue("@CustomerType", CustomerType);
                                command.Parameters.AddWithValue("@Discount", Discount);
                                command.Parameters.AddWithValue("@Booking", Booking);
                                command.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);

                                command.ExecuteNonQuery();
                            }

                            string updateComputerQuery = @"
                        UPDATE Computer 
                        SET qty = @qty, update_date = @update_date
                        WHERE item_name = @itemName";

                            using (SqlCommand updateComputerCmd = new SqlCommand(updateComputerQuery, connection, transaction))
                            {
                                updateComputerCmd.Parameters.AddWithValue("@qty", item.QtyUpdate);
                                updateComputerCmd.Parameters.AddWithValue("@update_date", today);
                                updateComputerCmd.Parameters.AddWithValue("@itemName", item.ItemName);

                                updateComputerCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}