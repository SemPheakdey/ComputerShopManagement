using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class OldInfo : Form
    {
        private readonly Database _database;

        public OldInfo()
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
                    string query = "SELECT SaleID,Date,SaleAssociate,CustomerName,PhoneNumber,CustomerType FROM Customer ORDER BY SaleID DESC"; // Adjust ORDER BY clause as per your database schema
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


        private void Printforinvoice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("No data available to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Define fonts with Khmer OS Battambang
            Font headerFont = new Font("Khmer OS Muol", 18, FontStyle.Bold);
            Font subHeaderFont = new Font("Khmer OS Muol", 14, FontStyle.Bold);
            Font contentFont = new Font("Khmer OS Battambang", 11, FontStyle.Bold);
            Font itemHeaderFont = new Font("Khmer OS Battambang", 9, FontStyle.Bold);

            float headerHeight = headerFont.GetHeight();
            float subHeaderHeight = subHeaderFont.GetHeight();
            float contentHeight = contentFont.GetHeight();

            int startX = 50;
            int startY = 50;
            int offset = 40;

            string todayDate = DateTime.Now.ToString("MM/dd/yyyy");

            // Company logo and details
            graphics.DrawString("ហាងកុំព្យូទ័រ", headerFont, new SolidBrush(Color.BlueViolet), startX, startY);
            graphics.DrawString("សូមស្វាគមន៍មកកាន់ហាងរបស់យើង!", subHeaderFont, new SolidBrush(Color.BlueViolet), startX, startY + offset);
            offset += (int)subHeaderHeight + 20;

            // Invoice title and details
            //graphics.DrawString("វិក", headerFont, new SolidBrush(Color.Black), startX, startY + offset);
            //offset += (int)headerHeight + 20;
            //graphics.DrawString($"ឈ្មោះអ្នកគិតប្រាក់: {sellForm_SaleAssociate.Text}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            string saleAssociate = selectedRow.Cells["SaleAssociate"].Value.ToString();
            graphics.DrawString($"ឈ្មោះអ្នកគិតប្រាក់: {saleAssociate}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 5;

            graphics.DrawString($"កាលបរិច្ឆេទ: {todayDate}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 20;




            // Customer details
            graphics.DrawString("វិក្កយបត្រសម្រាប់អតិថិជន:", subHeaderFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)subHeaderHeight + 10;


            if (selectedRow != null)
            {
                string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
                string phoneNumber = selectedRow.Cells["PhoneNumber"].Value.ToString();

                graphics.DrawString($"ឈ្មោះអតិថិជន: {customerName}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)contentHeight + 5;
                graphics.DrawString($"លេខទូរស័ព្ទ: {phoneNumber}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)contentHeight + 5;
            }

            if (dataGridView2.Rows.Count > 0)
            {
                string paidby = dataGridView2.Rows[0].Cells["PaidBy"].Value.ToString();
                string CustomerType = dataGridView2.Rows[0].Cells["CustomerType"].Value.ToString();

                graphics.DrawString($"PAID BY: {paidby}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)contentHeight + 5;
                graphics.DrawString($"អតិថិជន: {CustomerType}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)contentHeight + 20;
            }
            /////////////////////////////////////////////
            int tableStartY = startY + offset;
            graphics.DrawRectangle(Pens.Black, startX, tableStartY, 500, 30);
            graphics.FillRectangle(new SolidBrush(Color.LightBlue), startX, tableStartY, 500, 30);

            graphics.DrawString("ល.រ", itemHeaderFont, new SolidBrush(Color.Red), startX + 5, tableStartY);
            graphics.DrawString("ឈ្មោះទំនិញ", itemHeaderFont, new SolidBrush(Color.Blue), startX + 50, tableStartY);
            graphics.DrawString("បរិមាណ", itemHeaderFont, new SolidBrush(Color.Blue), startX + 220, tableStartY);
            graphics.DrawString("តម្លៃ", itemHeaderFont, new SolidBrush(Color.Blue), startX + 300, tableStartY);
            graphics.DrawString("ចំនួនទឹកប្រាក់", itemHeaderFont, new SolidBrush(Color.Blue), startX + 400, tableStartY);

            offset += 30;

            // Item details
            //int itemNumber = 1;
            int itemNumber = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                string itemName = row.Cells["ItemName"].Value.ToString();
                string quantity = row.Cells["Quantity"].Value.ToString();
                string price = row.Cells["Price"].Value.ToString();
                string paidby = row.Cells["PaidBy"].Value.ToString();
                string totalPrice = row.Cells["TotalPrice"].Value.ToString();

                graphics.DrawRectangle(Pens.Black, startX, startY + offset, 500, 30);
                graphics.DrawString(itemNumber.ToString("00"), contentFont, new SolidBrush(Color.Black), startX + 5, startY + offset + 5);
                graphics.DrawString(itemName, contentFont, new SolidBrush(Color.Black), startX + 50, startY + offset + 5);
                graphics.DrawString(quantity, contentFont, new SolidBrush(Color.Black), startX + 230, startY + offset + 5);
                graphics.DrawString(price, contentFont, new SolidBrush(Color.Black), startX + 300, startY + offset + 5);
                graphics.DrawString(totalPrice, contentFont, new SolidBrush(Color.Black), startX + 400, startY + offset + 5);


                offset += 30;
                itemNumber++;
            }

            // Sub Total
            int column2X = startX + 250; // X-coordinate for the second column (QTY)
            int column3X = startX + 300; // X-coordinate for the third column (RATE)
            int column4X = startX + 350; // X-coordinate for the fourth column (AMOUNT)
            int column5X = startX + 400; // X-coordinate for the fifth column (TOTAL)

            // Calculate and display discount
            if (dataGridView2.Rows.Count > 0)
            {
                // Fetch discount and booking values from the first row
                string discountStr = dataGridView2.Rows[0].Cells["Discount"].Value.ToString().Trim('%');
                string bookingStr = dataGridView2.Rows[0].Cells["Booking"].Value.ToString();

                // Parse discount and booking fee values
                decimal discountPercentage = 0;
                decimal bookingFee = 0;
                if (!string.IsNullOrEmpty(discountStr))
                {
                    discountPercentage = Convert.ToDecimal(discountStr);
                }
                if (!string.IsNullOrEmpty(bookingStr))
                {
                    bookingFee = Convert.ToDecimal(bookingStr);
                }
                decimal totalPrice1 = CalculateTotalPriceFromDataGridView();
                graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
                graphics.DrawString("សរុប", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
                graphics.DrawString(totalPrice1.ToString("C"), itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

                offset += 30;

                // Display discount and booking
                graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
                graphics.DrawString("បញ្ចុះតម្លៃ", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
                graphics.DrawString(discountPercentage + "%", contentFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

                offset += 30;
                graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
                graphics.DrawString("កក់", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
                graphics.DrawString(bookingFee.ToString("C"), contentFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

                offset += 30;


                // Tax
                graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
                graphics.DrawString("ពន្ធ", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
                graphics.DrawString("0%", itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

                offset += 30;

                // Total
                decimal totalPriceWithDiscountAndBooking = CalculateTotalPriceWithDiscountAndBooking();

                graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
                graphics.DrawString("តម្លៃសរុប", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
                graphics.DrawString(totalPriceWithDiscountAndBooking.ToString("C"), itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

                offset += 50;

                // Thank you note
                graphics.DrawString("សូមអរគុណសម្រាប់ការទុកចិត្តហាងយើងខុំ!", subHeaderFont, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)subHeaderHeight + 10;
                graphics.DrawString("អាសយដ្ឋានបច្ចុប្បន្ន:", subHeaderFont, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)subHeaderHeight + 5;
                graphics.DrawString(termsConditions, contentFont, new SolidBrush(Color.Black), new RectangleF(startX, startY + offset, 500, 100));
            }
        }
        private string termsConditions = "524E0 មហាវិថី កម្ពុជាក្រោម (១២៨), រាជធានីភ្នំពេញ 12153";


        private DataGridViewRow selectedRow;
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);

                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDocument
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            PrintPage(sender, e);
        }

        private decimal CalculateTotalPriceFromDataGridView()
        {
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                // Calculate total price per item and accumulate
                decimal totalPricePerItem = price * quantity;
                totalPrice += totalPricePerItem;
            }

            return totalPrice;
        }
        private decimal CalculateTotalPriceWithDiscountAndBooking()
        {
            decimal totalPrice = 0;
            decimal totalBookingFee = 0; // Total booking fee for all items

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal discount = 0;

                // Parse discount percentage from the cell, assuming it's in format like "10%"
                string discountStr = row.Cells["Discount"].Value.ToString().Trim('%');
                if (!string.IsNullOrEmpty(discountStr))
                {
                    decimal discountPercentage = Convert.ToDecimal(discountStr) / 100;
                    discount = price * discountPercentage * quantity; // Apply discount per item
                }

                // Accumulate the total booking fee (only once)
                if (totalBookingFee == 0)
                {
                    string bookingStr = row.Cells["Booking"].Value.ToString();
                    if (!string.IsNullOrEmpty(bookingStr))
                    {
                        totalBookingFee = Convert.ToDecimal(bookingStr);
                    }
                }

                // Calculate total price per item after discount
                decimal totalPricePerItem = (price * quantity - discount);

                totalPrice += totalPricePerItem;
            }

            // Subtract the total booking fee from the total price
            totalPrice -= totalBookingFee;

            return totalPrice;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
//CREATE TABLE Invoice (
//    SaleID INT,
//    Date DATE,
//    SaleAssociate NVARCHAR(100),
//    CustomerName NVARCHAR(100),
//    PhoneNumber NVARCHAR(15),
//    ItemName NVARCHAR(100),
//    Quantity INT,
//    Price DECIMAL(10, 2),
//    TotalPrice DECIMAL(10, 2),
//    Paidby NVARCHAR(100)
//    CustomerType NVARCHAR(100),
//    Discount NVARCHAR(100),
//    Booking NVARCHAR(100)
//);
//