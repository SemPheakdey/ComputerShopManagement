using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class ReportImportForm : Form
    {
        private readonly Database _database = new Database();
        private DataTable dataTable;

        public ReportImportForm()
        {
            InitializeComponent();
            LoadReportData();
        }

        private void LoadReportData()
        {
            using (SqlConnection conn = _database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CONVERT(date, date) AS date, supplier, contact, item_code, item_name, price, qty, total, action FROM Report";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        dataTable = dt; // Store data table for printing later
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            // Show the custom date input dialog
            using (DateInputDialogForm dateInputDialog = new DateInputDialogForm())
            {
                if (dateInputDialog.ShowDialog() == DialogResult.OK)
                {
                    DateTime selectedDate = dateInputDialog.SelectedDate;

                    // Filter data based on selected date
                    DataTable filteredTable = FilterDataByDate(dataTable, selectedDate);

                    // Check if there are rows matching the filter
                    if (filteredTable.Rows.Count == 0)
                    {
                        MessageBox.Show($"No data found for date: {selectedDate.ToString("yyyy-MM-dd")}", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Start printing
                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += (s, ev) => PrintPage(ev, filteredTable);

                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = printDocument;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }
            }
        }

        private DataTable FilterDataByDate(DataTable table, DateTime selectedDate)
        {
            DataTable filteredTable = table.Clone(); // Clone the structure of the original table

            foreach (DataRow row in table.Rows)
            {
                // Convert date to match the format in the database
                DateTime rowDate = Convert.ToDateTime(row["date"]).Date;

                if (rowDate == selectedDate.Date)
                {
                    filteredTable.ImportRow(row); // Import matching rows to the filtered table
                }
            }

            return filteredTable;
        }

        private void PrintPage(PrintPageEventArgs ev, DataTable dt)
        {
            int xPos = ev.MarginBounds.Left;
            int yPos = ev.MarginBounds.Top;
            int headerHeight = 40;
            int cellHeight = 30;
            int cellWidth = (ev.MarginBounds.Width / dt.Columns.Count) + 17;

            // Set up fonts and brushes
            Font titleFont = new Font("Khmer os Siemreap", 16, FontStyle.Bold);
            Font headerFont = new Font("khmer os siemreap", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 8);
            Brush brush = Brushes.Black;

            // Draw title
            string title = "របាយការណ៍នាំចូលទំនិញ";
            ev.Graphics.DrawString(title, titleFont, brush, new RectangleF(xPos, yPos, ev.MarginBounds.Width, headerHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            yPos += headerHeight;

            // Draw date
            string dateString = $"កាលបរិច្ឆេទ: {DateTime.Now.ToString("yyyy-MM-dd")}";
            ev.Graphics.DrawString(dateString, headerFont, brush, new RectangleF(xPos, yPos, ev.MarginBounds.Width, headerHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            yPos += headerHeight;

            // Draw headers
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ev.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(xPos/4 + (i * cellWidth), yPos, cellWidth, headerHeight));
                ev.Graphics.DrawRectangle(Pens.Black, new Rectangle(xPos/4 + (i * cellWidth), yPos, cellWidth, headerHeight));
                ev.Graphics.DrawString(dt.Columns[i].ColumnName, headerFont, brush, new RectangleF(xPos/4 + (i * cellWidth), yPos, cellWidth, headerHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }

            yPos += headerHeight;

            // Draw rows
            int rowCount = ev.MarginBounds.Height / cellHeight;

            for (int row = 0; row < dt.Rows.Count && row < rowCount; row++)
            {
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    object cellValue = dt.Rows[row][col];
                    string valueStr = string.Empty;

                    // Format date column
                    if (dt.Columns[col].ColumnName == "date" && cellValue != DBNull.Value)
                    {
                        valueStr = Convert.ToDateTime(cellValue).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        valueStr = cellValue != DBNull.Value ? cellValue.ToString() : string.Empty;
                    }

                    ev.Graphics.DrawRectangle(Pens.Black, new Rectangle(xPos/4 + (col * cellWidth), yPos, cellWidth, cellHeight));
                    ev.Graphics.DrawString(valueStr, cellFont, brush, new RectangleF(xPos/4 + (col * cellWidth), yPos, cellWidth, cellHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                yPos += cellHeight;
            }

            // Indicate whether there are more pages to print
            ev.HasMorePages = false;
        }


        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
