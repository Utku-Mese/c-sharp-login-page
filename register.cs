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

namespace Odev
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source = UTKU\\SQLEXPRESS;Initial Catalog = LoginPage; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == textBox3.Text)
            {
                connection.Open();
                string registered = "insert into Users (username, password, email) values(@username, @password, @email)";
                SqlCommand cmd = new SqlCommand(registered, connection);

                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);

                cmd.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("You can now login!", "Registration Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("passwords do not match!", "oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void register_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            pictureBox7.Visible = true;
            pictureBox6.Visible = false;
        }
    }
}
