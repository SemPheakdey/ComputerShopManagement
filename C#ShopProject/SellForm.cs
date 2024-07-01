using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace C_ShopProject
{
    public partial class SellForm : Form
    {
        private readonly Database _database;

        private string Price, Qtyold;

        public SellForm(string username)
        {
            InitializeComponent();
            _database = new Database();
            displayItemData();

            // Initialize dataGridView2 columns only once
            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.ColumnCount = 5;
                dataGridView2.Columns[0].Name = "ItemCode";
                dataGridView2.Columns[1].Name = "ItemName";
                dataGridView2.Columns[2].Name = "Quantity";
                dataGridView2.Columns[3].Name = "Price";
                dataGridView2.Columns[4].Name = "TotalPrice";
            }

            // Set read-only fields
            sellForm_SaleAssociate.Text = username;
            txtTotal.ReadOnly = true;
            txtItemname.ReadOnly = true;
            sellForm_SaleAssociate.ReadOnly = true;

            // Attach event handlers only once
            btnAdd.Click -= btnAdd_Click; // Detach the event handler if it's already attached
            btnAdd.Click += btnAdd_Click;

            btn_print.Click -= btn_print_Click; // Detach the event handler if it's already attached
            btn_print.Click += btn_print_Click;

            txtBooking.TextChanged += txtBooking_TextChanged;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
        }



        public void displayItemData(int? idcodeFilter = null)
        {
            ItemData cd = new ItemData();
            List<ItemData> listData = cd.ItemListData();

            if (idcodeFilter.HasValue)
            {
                listData = listData.Where(item => item.ItemCode == idcodeFilter.Value).ToList();
            }

            dataGridView1.DataSource = listData;

            dataGridView1.Columns["ID"].HeaderText = "ID";
            dataGridView1.Columns["ItemCode"].HeaderText = "Item code";
            dataGridView1.Columns["ItemName"].HeaderText = "Item Name";
            dataGridView1.Columns["Price"].HeaderText = "Price";
            dataGridView1.Columns["TotalQty"].HeaderText = "Total Quantity";

            dataGridView1.Columns["ID"].Visible = true;
            dataGridView1.Columns["ItemCode"].Visible = true;
            dataGridView1.Columns["ItemName"].Visible = true;
            dataGridView1.Columns["Price"].Visible = true;
            dataGridView1.Columns["TotalQty"].Visible = true;

            // Hide other columns if any
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "ID" && column.Name != "ItemCode" && column.Name != "ItemName" && column.Name != "Price" && column.Name != "TotalQty")
                {
                    column.Visible = false;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtItemCode.Text = row.Cells["ItemCode"].Value.ToString();
                txtItemname.Text = row.Cells["ItemName"].Value.ToString();
                Qtyold = row.Cells["TotalQty"].Value.ToString();
                Price = row.Cells["Price"].Value.ToString();
                txtItemCode.ReadOnly = true;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtItemCode.ReadOnly=false;
            string itemCode = txtItemCode.Text.Trim();
            string itemName = txtItemname.Text.Trim();
            string quantityText = txtQty.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemCode) || string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(quantityText))
            {
                MessageBox.Show("Please enter Item Code, Item Name & Qty first");
                return;
            }

            if (decimal.TryParse(Price, out decimal price) && int.TryParse(quantityText, out int quantity))
            {
                int qtyOld = int.Parse(Qtyold);

                // Check if requested quantity exceeds available stock
                if (quantity > qtyOld)
                {
                    MessageBox.Show("Qty cannot be greater than available Qty.");
                    return;
                }

                // Check if adding this quantity exceeds available stock in the current DataGridView
                int totalRequestedQuantity = dataGridView2.Rows
                    .OfType<DataGridViewRow>()
                    .Where(row => row.Cells["ItemCode"].Value != null && row.Cells["ItemCode"].Value.ToString() == itemCode)
                    .Sum(row => int.Parse(row.Cells["Quantity"].Value.ToString()) + quantity);

                if (totalRequestedQuantity > qtyOld)
                {
                    MessageBox.Show("Total quantity cannot exceed available stock.");
                    return;
                }

                bool itemFound = false;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["ItemCode"].Value != null && row.Cells["ItemCode"].Value.ToString() == itemCode)
                    {
                        int oldQty = int.Parse(row.Cells["Quantity"].Value.ToString());
                        int newQty = oldQty + quantity;
                        row.Cells["Quantity"].Value = newQty.ToString();

                        decimal totalPrice = price * newQty;
                        row.Cells["TotalPrice"].Value = totalPrice.ToString("0.00") + "$";

                        itemFound = true;
                        break;
                    }
                }

                if (!itemFound)
                {
                    decimal totalPrice = price * quantity;
                    string totalPriceFormatted = totalPrice.ToString("0.00") + "$";

                    string[] row = new string[] { itemCode, itemName, quantity.ToString(), price.ToString("0.00") + "$", totalPriceFormatted };
                    dataGridView2.Rows.Add(row);
                }

                txtItemCode.Clear();
                txtItemname.Clear();
                txtQty.Clear();
                txtTotal.Text = CalculateTotalPrice();
                displayItemData();
            }
            else
            {
                MessageBox.Show("Invalid price or quantity format.");
            }
        }



        private string CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            // Calculate the total price from the DataGridView2
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow && decimal.TryParse(row.Cells["TotalPrice"].Value?.ToString().TrimEnd('$'), out decimal rowTotalPrice))
                {
                    totalPrice += rowTotalPrice;
                }
            }

            // Apply the discount percentage if any
            if (decimal.TryParse(txtDiscount.Text, out decimal discountPercentage))
            {
                decimal discountAmount = totalPrice * (discountPercentage / 100);
                totalPrice -= discountAmount;
            }

            // Subtract the booking amount if any
            if (decimal.TryParse(txtBooking.Text, out decimal booking))
            {
                totalPrice -= booking;
            }

            // Ensure total price does not go negative
            totalPrice = Math.Max(totalPrice, 0);

            return totalPrice.ToString("0.00") + "$";
        }

        private void txtBooking_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = CalculateTotalPrice();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = CalculateTotalPrice();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate required fields
            var fields = new (string Value, string Message)[]
            {
        (dateTimePicker1.Text, "Please select a date."),
        (sellForm_SaleAssociate.Text, "Please enter the sales associate's name."),
        (txtCusName.Text, "Please enter the customer's name."),
        (txtPhone.Text, "Please enter the customer's phone number."),
        (Paidby.SelectedItem?.ToString(), "Please select a payment method."),
        (CustomerType.SelectedItem?.ToString(), "Please select a customer type.")
            };

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Value))
                {
                    MessageBox.Show(field.Message, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Validate items in the DataGridView
            List<ItemData> itemList = new List<ItemData>();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                var columns = new (string ColumnName, string Message)[]
                {
            ("ItemName", "Please enter the item name for all items."),
            ("Quantity", "Please enter the quantity for all items."),
            ("Price", "Please enter the price for all items."),
            ("TotalPrice", "Please enter the total price for all items.")
                };

                foreach (var column in columns)
                {
                    if (row.Cells[column.ColumnName].Value == null)
                    {
                        MessageBox.Show(column.Message, $"Missing {column.ColumnName}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string itemCode = row.Cells["ItemCode"].Value.ToString();
                string itemName = row.Cells["ItemName"].Value.ToString();
                int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                decimal price = decimal.Parse(row.Cells["Price"].Value.ToString().TrimEnd('$'));
                decimal totalPrice = decimal.Parse(row.Cells["TotalPrice"].Value.ToString().TrimEnd('$'));

                // Calculate Qtyup and Total_Import based on individual item old quantity
                int qtyOld = int.Parse(dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["ItemCode"].Value.ToString() == itemCode)
                    .Select(r => r.Cells["TotalQty"].Value.ToString())
                    .FirstOrDefault());

                int qtyup = qtyOld - quantity;
                int totalImport = (int)(qtyup * price);

                // Add item data to list
                itemList.Add(new ItemData
                {
                    ItemName = itemName,
                    Quantity = quantity,
                    Price = (float)price,
                    TotalPrice = totalPrice,
                    QtyUpdate = qtyup,
                    Total_import = totalImport,
                });
            }

            if (itemList.Count == 0)
            {
                MessageBox.Show("Please add at least one item to the sale.", "No Items Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for confirmation
            DialogResult result = MessageBox.Show("Do you want to printed the receipt?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Activate print button
                btn_print.PerformClick();

                // Save sale data to database
                _database.SaveSale(
                    dateTimePicker1.Text,
                    sellForm_SaleAssociate.Text,
                    txtCusName.Text,
                    txtPhone.Text,
                    itemList,
                    Paidby.SelectedItem?.ToString(),
                    CustomerType.SelectedItem?.ToString(),
                    txtDiscount.Text,
                    txtBooking.Text
                );

                MessageBox.Show("Sale data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear all fields
                btn_refresh_Click(sender, e);
            }
            if (result == DialogResult.No)
            {

                // Save sale data to database
                _database.SaveSale(
                    dateTimePicker1.Text,
                    sellForm_SaleAssociate.Text,
                    txtCusName.Text,
                    txtPhone.Text,
                    itemList,
                    Paidby.SelectedItem?.ToString(),
                    CustomerType.SelectedItem?.ToString(),
                    txtDiscount.Text,
                    txtBooking.Text
                );

                MessageBox.Show("Sale data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear all fields
                btn_refresh_Click(sender, e);
            }
        }



        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            txtCusName.Clear();
            txtItemCode.Clear();
            txtPhone.Clear();
            dataGridView2.Rows.Clear();
            displayItemData();
            txtItemname.Clear();
            txtQty.Clear();
            Paidby.SelectedItem = null;
            txtBooking.Clear();
            CustomerType.SelectedItem = null;
            txtDiscount.Clear();
            txtItemCode.ReadOnly = false;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
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
            graphics.DrawString($"ឈ្មោះអ្នកគិតប្រាក់: {sellForm_SaleAssociate.Text}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 5;
            graphics.DrawString($"កាលបរិច្ឆេទ: {todayDate}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 20;

            // Customer details
            graphics.DrawString("វិក្កយបត្រសម្រាប់អតិថិជន:", subHeaderFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)subHeaderHeight + 10;
            graphics.DrawString($"ឈ្មោះអតិថិជន: {txtCusName.Text}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 5;
            graphics.DrawString($"លេខទូរស័ព្ទ: {txtPhone.Text}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 5;


            graphics.DrawString($"PAID BY: {Paidby.Text}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 5;
            graphics.DrawString($"អតិថិជន: {CustomerType.Text}", contentFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)contentHeight + 20;


            // Item details header
            int tableStartY = startY + offset;
            graphics.DrawRectangle(Pens.Black, startX, tableStartY, 500, 30);
            graphics.FillRectangle(new SolidBrush(Color.LightBlue), startX, tableStartY, 500, 30);

            graphics.DrawString("ល.រ", itemHeaderFont, new SolidBrush(Color.Red), startX + 5, tableStartY );
            graphics.DrawString("ឈ្មោះទំនិញ", itemHeaderFont, new SolidBrush(Color.Blue), startX + 50, tableStartY );
            graphics.DrawString("បរិមាណ", itemHeaderFont, new SolidBrush(Color.Blue), startX + 220, tableStartY );
            graphics.DrawString("តម្លៃ", itemHeaderFont, new SolidBrush(Color.Blue), startX + 300, tableStartY );
            graphics.DrawString("ចំនួនទឹកប្រាក់", itemHeaderFont, new SolidBrush(Color.Blue), startX + 400, tableStartY );

            offset += 30;

            // Item details
            int itemNumber = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                string itemName = row.Cells["ItemName"].Value.ToString();
                string quantity = row.Cells["Quantity"].Value.ToString();
                string price = row.Cells["Price"].Value.ToString();
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

            int column2X = startX + 250; // X-coordinate for the second column (QTY)
            int column3X = startX + 300; // X-coordinate for the third column (RATE)
            int column4X = startX + 350; // X-coordinate for the fourth column (AMOUNT)
            int column5X = startX + 400; // X-coordinate for the fifth column (TOTAL)

            decimal subtotal = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                subtotal += decimal.Parse(row.Cells["TotalPrice"].Value.ToString().TrimEnd('$'));
            }

            // Display subtotal
            graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
            graphics.DrawString("សរុប", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
            graphics.DrawString(subtotal.ToString("0.00") + "$", itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

            offset += 30; // Increase offset
            // Booking
            graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
            graphics.DrawString("កក់", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
            graphics.DrawString(txtBooking.Text + "$" , itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

            offset += 30;

            // Booking
            graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
            graphics.DrawString("បញ្ចុះតម្លៃ", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
            graphics.DrawString(txtDiscount.Text + "%", itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

            offset += 30;

            // Sub Total
            // Calculate Subtotal before discount and booking

            // Tax
            graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
            graphics.DrawString("ពន្ធ", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
            graphics.DrawString("0%", itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

            offset += 30;

            // Total
            graphics.DrawRectangle(Pens.Black, startX + 290, startY + offset, 210, 30);
            graphics.DrawString("តម្លៃសរុប", itemHeaderFont, new SolidBrush(Color.Black), column3X, startY + offset + 5);
            graphics.DrawString(txtTotal.Text, itemHeaderFont, new SolidBrush(Color.Black), column5X, startY + offset + 5);

            offset += 50;

            // Thank you note
            graphics.DrawString("សូមអរគុណសម្រាប់ការទុកចិត្តហាងយើងខុំ!", subHeaderFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)subHeaderHeight + 10;
            graphics.DrawString("អាសយដ្ឋានបច្ចុប្បន្ន:", subHeaderFont, new SolidBrush(Color.Black), startX, startY + offset);
            offset += (int)subHeaderHeight + 5;
            graphics.DrawString(termsConditions, contentFont, new SolidBrush(Color.Black), new RectangleF(startX, startY + offset, 500, 100));
        }
        private string termsConditions = "524E0 មហាវិថី កម្ពុជាក្រោម (១២៨), រាជធានីភ្នំពេញ 12153";

        private void OldInfo_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the OldInfo form
            OldInfo oldInfoForm = new OldInfo();

            // Show the OldInfo form
            oldInfoForm.Show();
        }
        private void find_btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtItemCode.Text, out int ItemCode))
            {
                displayItemData(ItemCode);
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
