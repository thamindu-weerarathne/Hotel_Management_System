using System;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class FormLogin : Form
    {
        DbConnector db;

        public FormLogin()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void pictureBoxMinimize_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill out all fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool isValid = db.IsValidNamePass(username, password);

            if (isValid)
            {
                FormDashboard fd = new FormDashboard();
                fd.Show();
                this.Hide();  // Hide the login form instead of closing it to avoid disposing of it if you need to return to it
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}