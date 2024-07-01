using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using C_ShopProject;

namespace EmployeeManagementSystem
{
    public partial class AddStaff : Form
    {
        private readonly Database database = new Database();

        public AddStaff()
        {
            InitializeComponent();
            // TO DISPLAY THE DATA FROM DATABASE TO YOUR DATA GRID VIEW
            displayStaffData();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayStaffData();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DateOfBirth")
    {
        if (e.Value != null)
        {
            e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd"); // Or use "MM/dd/yyyy" for different format
            e.FormattingApplied = true;
        }
    }
        }
        public void displayStaffData()
        {
            StaffData sd = new StaffData();
            List<StaffData> listData = sd.StaffListData();

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID", HeaderText = "ID", DataPropertyName = "ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "StaffID", HeaderText = "StaffID", DataPropertyName = "StaffID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Name", DataPropertyName = "Name" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Gender", HeaderText = "Gender", DataPropertyName = "Gender" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DateOfBirth", HeaderText = "DateOfBirth", DataPropertyName = "DateOfBirth" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Contact", HeaderText = "Contact", DataPropertyName = "Contact" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Position", HeaderText = "Position", DataPropertyName = "Position" });

            // Create and add an image column
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.Name = "Image";
            imgCol.HeaderText = "Image";
            imgCol.DataPropertyName = "ImagePath";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgCol);

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Salary", HeaderText = "Salary", DataPropertyName = "Salary" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Status", HeaderText = "Status", DataPropertyName = "Status" });

            dataGridView1.Rows.Clear();

            foreach (var data in listData)
            {
                Image img = null;
                if (!string.IsNullOrEmpty(data.ImagePath) && File.Exists(data.ImagePath))
                {
                    img = Image.FromFile(data.ImagePath);
                }

                dataGridView1.Rows.Add(data.ID, data.StaffID, data.Name, data.Gender, data.DateOfBirth, data.Contact, data.Position, img, data.Salary, data.Status);
            }
        }



        private void addStaff_btn_Click(object sender, EventArgs e)
        {
            if (AddStaff_ID.Text == ""
                || AddStaff_FullName.Text == ""
                || (!rdo_Male.Checked && !rdo_Female.Checked)
                || AddStaff_PhoneNum.Text == ""
                || AddStaff_Dob.Value == DateTimePicker.MinimumDateTime
                || AddStaff_Picture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = database.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                            string checkStaffID = "SELECT COUNT(*) FROM Staffs WHERE staff_id = @staffID";

                            using (SqlCommand checkStaff = new SqlCommand(checkStaffID, conn))
                            {
                                checkStaff.Parameters.AddWithValue("@staffID", AddStaff_ID.Text.Trim());
                                int count = (int)checkStaff.ExecuteScalar();

                                if (count >= 1)
                                {
                                    MessageBox.Show(AddStaff_ID.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    DateTime today = DateTime.Today;
                                    string insertData = "INSERT INTO Staffs (staff_id, full_name, gender, date_of_birth, contact_number, position, image, salary, insert_date, status) VALUES (@staffID, @fullName, @gender, @dob, @contactNum, @position, @image, @salary, @insertDate, @status)";

                                    string path = Path.Combine(@"D:\ISAD\C#ShopProject\C#ShopProject\Resources\" + AddStaff_ID.Text.Trim() + ".jpg");
                                    string directoryPath = Path.GetDirectoryName(path);

                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    File.Copy(AddStaff_Picture.ImageLocation, path, true);

                                    using (SqlCommand cmd = new SqlCommand(insertData, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@staffID", AddStaff_ID.Text.Trim());
                                        cmd.Parameters.AddWithValue("@fullName", AddStaff_FullName.Text.Trim());
                                        cmd.Parameters.AddWithValue("@dob", AddStaff_Dob.Value.Date);
                                        cmd.Parameters.AddWithValue("@contactNum", AddStaff_PhoneNum.Text.Trim());
                                        cmd.Parameters.AddWithValue("@position", AddStaff_Position.Text.Trim());
                                        cmd.Parameters.AddWithValue("@salary", AddStaff_Salary.Text.Trim());
                                        cmd.Parameters.AddWithValue("@image", path);
                                        cmd.Parameters.AddWithValue("@insertDate", today);
                                        cmd.Parameters.AddWithValue("@status", AddStaff_Status.Checked ? "Active" : "Inactive");

                                        if (rdo_Male.Checked)
                                        {
                                            cmd.Parameters.AddWithValue("@gender", "Male");
                                        }
                                        else if (rdo_Female.Checked)
                                        {
                                            cmd.Parameters.AddWithValue("@gender", "Female");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please select a gender.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        cmd.ExecuteNonQuery();

                                        displayStaffData();

                                        MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        clearFields();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void AddStaff_Import_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "D:\\c#projectdemo\\C#Shop\\C#ShopProject\\Resources\\";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    AddStaff_Picture.ImageLocation = imagePath;
                }
                else
                {
                    AddStaff_Picture.ImageLocation = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                AddStaff_ID.Text = row.Cells["StaffID"].Value.ToString();
                AddStaff_FullName.Text = row.Cells["Name"].Value.ToString();

                string gender = row.Cells["Gender"].Value.ToString();
                if (gender == "Male")
                {
                    rdo_Male.Checked = true;
                }
                else if (gender == "Female")
                {
                    rdo_Female.Checked = true;
                }
                else
                {
                    rdo_Male.Checked = false;
                    rdo_Female.Checked = false;
                }

                AddStaff_Dob.Value = DateTime.Parse(row.Cells["DateOfBirth"].Value.ToString());
                AddStaff_PhoneNum.Text = row.Cells["Contact"].Value.ToString();
                AddStaff_Position.Text = row.Cells["Position"].Value.ToString();

                string directoryPath = @"D:\ISAD\C#ShopProject\C#ShopProject\Resources\";
                string fileName = row.Cells["StaffID"].Value.ToString() + ".jpg"; // Adjust file extension if needed
                string imagePath = Path.Combine(directoryPath, fileName);

                if (File.Exists(imagePath))
                {
                    try
                    {
                        AddStaff_Picture.Image = Image.FromFile(imagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddStaff_Picture.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Image file not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddStaff_Picture.Image = null;
                }

                AddStaff_Salary.Text = row.Cells["Salary"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();
                AddStaff_Status.Checked = status == "Active";
            }
        }


        public void clearFields()
        {
            AddStaff_ID.Text = "";
            AddStaff_FullName.Text = "";
            rdo_Male.Checked = false;
            rdo_Female.Checked = false;
            AddStaff_Dob.Value = DateTimePicker.MinimumDateTime;
            AddStaff_PhoneNum.Text = "";
            AddStaff_Salary.Text = "";
            AddStaff_Position.Text = "";
            AddStaff_Status.Checked = false;
            AddStaff_Picture.Image = null;
        }

        private void updataStaff_btn_Click(object sender, EventArgs e)
        {
            if (AddStaff_ID.Text == ""
                || AddStaff_FullName.Text == ""
                || (!rdo_Male.Checked && !rdo_Female.Checked)
                || AddStaff_Dob.Value.Date == DateTimePicker.MinimumDateTime
                || AddStaff_PhoneNum.Text == ""
                || AddStaff_Position.Text == ""
                || AddStaff_Picture.Image == null
                || AddStaff_Salary.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Staff ID: " + AddStaff_ID.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    using (SqlConnection conn = database.GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            DateTime today = DateTime.Today;

                            string updateData = "UPDATE Staffs SET full_name = @fullName, gender = @gender, date_of_birth = @dob, contact_number = @contactNum, position = @position, salary = @salary, update_date = @updateDate, status = @status WHERE staff_id = @staffID";

                            using (SqlCommand cmd = new SqlCommand(updateData, conn))
                            {
                                cmd.Parameters.AddWithValue("@fullName", AddStaff_FullName.Text.Trim());
                                cmd.Parameters.AddWithValue("@contactNum", AddStaff_PhoneNum.Text.Trim());
                                cmd.Parameters.AddWithValue("@dob", AddStaff_Dob.Value.Date);
                                cmd.Parameters.AddWithValue("@position", AddStaff_Position.Text.Trim());
                                cmd.Parameters.AddWithValue("@salary", AddStaff_Salary.Text.Trim());
                                cmd.Parameters.AddWithValue("@updateDate", today);
                                cmd.Parameters.AddWithValue("@status", AddStaff_Status.Checked ? "Active" : "Inactive");
                                cmd.Parameters.AddWithValue("@staffID", AddStaff_ID.Text.Trim());

                                if (rdo_Male.Checked)
                                {
                                    cmd.Parameters.AddWithValue("@gender", "Male");
                                }
                                else if (rdo_Female.Checked)
                                {
                                    cmd.Parameters.AddWithValue("@gender", "Female");
                                }
                                else
                                {
                                    MessageBox.Show("Please select a gender.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                cmd.ExecuteNonQuery();
                                displayStaffData();
                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            
            clearFields();
            displayStaffData();
        }

        private void deleteStaff_btn_Click(object sender, EventArgs e)
        {
            if (AddStaff_ID.Text == ""
                || AddStaff_FullName.Text == ""
                || (!rdo_Male.Checked && !rdo_Female.Checked)
                || AddStaff_Dob.Value.Date == DateTimePicker.MinimumDateTime
                || AddStaff_PhoneNum.Text == ""
                || AddStaff_Position.Text == ""
                || AddStaff_Picture.Image == null
                || AddStaff_Salary.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to DELETE Staff ID: " + AddStaff_ID.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    using (SqlConnection conn = database.GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            DateTime today = DateTime.Today;

                            string updateData = "UPDATE Staffs SET delete_date = @deleteDate WHERE staff_id = @staffID";

                            using (SqlCommand cmd = new SqlCommand(updateData, conn))
                            {
                                cmd.Parameters.AddWithValue("@deleteDate", today);
                                cmd.Parameters.AddWithValue("@staffID", AddStaff_ID.Text.Trim());
                                cmd.ExecuteNonQuery();
                                displayStaffData();
                                MessageBox.Show("Deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AddStaff_Search_btn_Click(object sender, EventArgs e)
        {
            string searchStaffID = AddStaff_ID.Text.Trim();

            if (string.IsNullOrEmpty(searchStaffID))
            {
                MessageBox.Show("Please enter Staff ID to search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool found = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["StaffID"].Value.ToString() == searchStaffID)
                {
                    // Clear existing rows
                    dataGridView1.Rows.Clear();

                    // Add the matching row to the DataGridView
                    DataGridViewRow newRow = (DataGridViewRow)row.Clone();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        newRow.Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                    dataGridView1.Rows.Add(newRow);

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show($"No records found matching Staff ID: {searchStaffID}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear(); // Clear DataGridView if no match found
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_staff_btn_Click(object sender, EventArgs e)
        {
            ReportStaffOption form = new ReportStaffOption();
            form.Show();
        }

        
    }
}
