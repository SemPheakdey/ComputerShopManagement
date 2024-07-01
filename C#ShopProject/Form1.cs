using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class Form1 : Form
    {
        private readonly Database _database;

        public Form1()
        {
            InitializeComponent();
            _database = new Database();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            RegisterForm RegForm = new RegisterForm();
            RegForm.Show();
            this.Hide();
        }

        private void login_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showpassword.Checked ? '\0' : '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(login_user.Text) || string.IsNullOrEmpty(login_password.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = _database.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                            string selectData = "SELECT * FROM users WHERE username = @username AND password = @password";
                            using (SqlCommand cmd = new SqlCommand(selectData, conn))
                            {
                                cmd.Parameters.AddWithValue("@username", login_user.Text.Trim());
                                cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataTable table = new DataTable();
                                adapter.Fill(table);

                                if (table.Rows.Count >= 1)
                                {
                                    string username = login_user.Text.Trim();

                                    // Pass the username to MianForm
                                    MianForm mForm = new MianForm(username);
                                    mForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            login_user.Text = "";
            login_password.Text = "";
        }
    }
}
