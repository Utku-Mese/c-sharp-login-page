using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Odev
{
    public partial class forgetPassword : Form
    {
        public forgetPassword()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source = UTKU\\SQLEXPRESS;Initial Catalog = LoginPage; Integrated Security = True");

        public bool sendMail(string subject, string body, string who)
        {

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("mutkumese@gmail.com");
            
            ePosta.To.Add(who);
            
            ePosta.Subject = subject;
            
            ePosta.Body = body;
            
            SmtpClient smtp = new SmtpClient();
            
            smtp.Credentials = new System.Net.NetworkCredential("mutkumese@gmail.com", "iamettlvllfrffnb");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;
        }






        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.Open();

            SqlCommand cmd = new SqlCommand("Select * from Users", connection);
            SqlDataReader reader = cmd.ExecuteReader();


            sendMail("Come back to us!", "Your password: ", textBox2.Text);
        }

        private void forgetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
