using EAGetMail;
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
    public partial class Retrieve : Form
    {
        public Retrieve()
        {
            InitializeComponent();
        }

        private void Retrieve_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
            textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Send.IsValidEmail(textBox1.Text))
            {
                MessageBox.Show("Invalid email format! Please introduce email orrectly!", "Warning !"); return;
            }
            textBox3.Visible = true;
            textBox3.Text = string.Empty;
            try
            {


                MailServer oServer = new MailServer("pop.gmail.com", textBox1.Text, textBox2.Text, EAGetMail.ServerProtocol.Imap4);

                oServer.Port = 993;
                oServer.SSLConnection = true;

                MailClient oClient = new MailClient("TryIt");
                oClient.Connect(oServer);

                MailInfo[] infos = oClient.GetMailInfos();
                textBox3.Text += "Total ";
                textBox3.Text += infos.Length;
                textBox3.Text += " email(s)\r\n";


                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];

                    textBox3.Text += info.Index;
                    textBox3.Text += ". ";
                    // Receive email from POP3 server
                    Mail oMail = oClient.GetMail(info);

                    textBox3.AppendText(Environment.NewLine);
                    textBox3.Text += "\nFrom: ";
                    textBox3.Text += oMail.From.ToString();
                    textBox3.AppendText(Environment.NewLine);
                    textBox3.Text += "\nSubject: ";
                    textBox3.Text += oMail.Subject;

                    textBox3.Text += "\r\n";

                }

                oClient.Quit();
                
            }
            catch (Exception ep)
            {
                textBox3.Visible = false;
                MessageBox.Show("Email or password incorrect","Warning!");
            }
        }

        private void Retrieve_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
