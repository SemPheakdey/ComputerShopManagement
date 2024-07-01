using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class RegisterForm : Form
    {
        private readonly Database _database = new Database();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void Register_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = Register_showpassword.Checked ? '\0' : '*';
        }

        private void SignUp_login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(signup_user.Text) || string.IsNullOrEmpty(signup_password.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = _database.GetConnection())
                {
                    try
                    {
                        conn.Open();

                        // Check if user already exists
                        string selectUsername = "SELECT COUNT(id) FROM users WHERE username = @user";
                        using (SqlCommand CheckUser = new SqlCommand(selectUsername, conn))
                        {
                            CheckUser.Parameters.AddWithValue("@user", signup_user.Text.Trim());
                            int count = (int)CheckUser.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(signup_user.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime Today = DateTime.Today;
                                string insertData = "INSERT INTO users (username, password, date_register) VALUES (@username, @password, @dateReg)";
                                using (SqlCommand cmd = new SqlCommand(insertData, conn))
                                {
                                    cmd.Parameters.AddWithValue("@username", signup_user.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dateReg", Today);

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Registered Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Form1 loginForm = new Form1();
                                    loginForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            signup_user.Text = "";
            signup_password.Text = "";
        }
    }
}
