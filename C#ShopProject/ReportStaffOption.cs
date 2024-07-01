using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class ReportStaffOption : Form
    {
        private readonly Database database = new Database();
        private PrintDocument printDocument1 = new PrintDocument();
        private DataTable dataTable;
        private string reportTitle;

        public ReportStaffOption()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        private void ReportAllStaff_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Staffs";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    reportTitle = "បុគ្គលិកធ្លាប់បម្រើការ​ និងកំពុងបម្រើការ";
                    // Print the report
                    PrintReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int xPos = e.MarginBounds.Left;
            int yPos = e.MarginBounds.Top;
            int headerHeight = 40;
            int cellHeight = 100; // Increased cell height to accommodate images

            // Filter out the ID, insert_date, update_date, and delete_date columns
            DataColumn[] columnsToPrint = dataTable.Columns.Cast<DataColumn>()
                .Where(c => c.ColumnName.ToLower() != "id" && c.ColumnName.ToLower() != "insert_date" && c.ColumnName.ToLower() != "update_date" && c.ColumnName.ToLower() != "delete_date")
                .ToArray();

            int cellWidth = (e.MarginBounds.Width / columnsToPrint.Length) + 18;

            // Set up fonts and brushes
            Font titleFont = new Font("Khmer OS Siemreap", 16, FontStyle.Bold);
            Font headerfont = new Font("Khmer OS Siemreap", 12, FontStyle.Bold);
            Font headerFont = new Font("Khmer OS Siemreap", 7, FontStyle.Bold);
            Font cellFont = new Font("Khmer OS Siemreap", 10);
            Brush brush = Brushes.Black;

            string title = reportTitle;

            yPos += (headerHeight - (int)e.Graphics.MeasureString(title, titleFont).Height) / 2;
            e.Graphics.DrawString(title, titleFont, brush, new RectangleF(xPos, yPos, e.MarginBounds.Width, headerHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            yPos += headerHeight;

            string dateString = $"កាលបរិច្ឆេទ: {DateTime.Now.ToString("yyyy-MM-dd")}";
            yPos += (headerHeight - (int)e.Graphics.MeasureString(dateString, headerfont).Height) / 2;
            e.Graphics.DrawString(dateString, headerfont, brush, new RectangleF(xPos, yPos, e.MarginBounds.Width, headerHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            yPos += headerHeight;

            // Draw headers
            for (int i = 0; i < columnsToPrint.Length; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(xPos/5 + (i * cellWidth), yPos, cellWidth, headerHeight));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(xPos/5 + (i * cellWidth), yPos, cellWidth, headerHeight));
                e.Graphics.DrawString(columnsToPrint[i].ColumnName, headerFont, brush, new RectangleF(xPos/5 + (i * cellWidth), yPos, cellWidth, headerHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }

            yPos += headerHeight;

            // Draw rows
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < columnsToPrint.Length; i++)
                {
                    string cellValue = row[columnsToPrint[i]].ToString();

                    // Format DateOfBirth column to show only date without time
                    if (columnsToPrint[i].ColumnName == "date_of_birth" && row[columnsToPrint[i]] != DBNull.Value)
                    {
                        DateTime dateOfBirth = Convert.ToDateTime(row[columnsToPrint[i]]);
                        cellValue = dateOfBirth.ToString("yyyy/MM/dd");
                    }

                    if (columnsToPrint[i].ColumnName == "image" && !string.IsNullOrEmpty(cellValue))
                    {
                        // Load the image from file
                        Image img = Image.FromFile(cellValue);

                        // Draw the image centered within the cell
                        Rectangle rect = new Rectangle(xPos / 5 + (i * cellWidth), yPos, cellWidth, cellHeight);
                        e.Graphics.DrawImage(img, rect);
                    }
                    else
                    {
                        // Draw text data centered within the cell
                        Rectangle cellRect = new Rectangle(xPos / 5 + (i * cellWidth), yPos, cellWidth, cellHeight);
                        e.Graphics.DrawRectangle(Pens.Black, cellRect);
                        e.Graphics.DrawString(cellValue, cellFont, brush, cellRect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                }
                yPos += cellHeight;
            }
        }



        private void PrintReport()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void ReportActiveStaff_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Staffs WHERE status = 'Active'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    reportTitle = "របាយការណ៍បុគ្គលិកដែលនៅធ្វើការ";
                    // Print the report
                    PrintReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}