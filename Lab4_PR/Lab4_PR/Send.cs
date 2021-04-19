using EASendMail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_PR
{
    public partial class Send : Form
    {
        public Send()
        {
            InitializeComponent();
        }


        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidEmail(textBox1.Text) || !IsValidEmail(textBox2.Text))
                {
                    MessageBox.Show("Invalid email format! Please introduce email orrectly!", "Warning !"); return;
                }

                SmtpMail oMail = new SmtpMail("TryIt");


                oMail.From = textBox1.Text;

                oMail.To = textBox2.Text;


                oMail.Subject = textBox3.Text;

                oMail.TextBody = textBox4.Text;


                SmtpServer oServer = new SmtpServer("smtp.gmail.com");


                oServer.User = textBox1.Text;
                oServer.Password = textBox5.Text;

                oServer.Port = 465;

                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;



                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);


                MessageBox.Show("Email was sent successfully! ", "Success! ");
            }
            catch (Exception ep)
            {
                MessageBox.Show("Failed to send email. Please make sure everything was introduced correct !", "Warning !");
                Console.WriteLine(ep.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }

        private void Send_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
