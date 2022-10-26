using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;

namespace Odev
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source = UTKU\\SQLEXPRESS;Initial Catalog = LoginPage; Integrated Security = True");

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            string userName = textBox1.Text;
            string password = textBox2.Text;

            bool isRegistered = false;

            connection.Open();

            SqlCommand cmd = new SqlCommand("Select * from Users", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                if (userName == reader["username"].ToString() && password == reader["password"].ToString())
                {
                    isRegistered = true;
                }
                else isRegistered = false;
            }
            connection.Close();
            if (isRegistered == true) MessageBox.Show("Login successful!", "Welcome!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("username and password combination is wrong!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register _register = new register();
            _register.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgetPassword _forgetPassword = new forgetPassword();
            _forgetPassword.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
