using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LinphoneAccount;
using LinphonePhone;

namespace RTSD_form
{
    public partial class Form1 : Form
    {
        Phone phone;
		Account account;

        public Form1()
        {
            InitializeComponent();
            tabPage_calls.Enabled = false;
            tabPage_chats.Enabled = false;
        }

        private void tabPage_chats_Click(object sender, EventArgs e)
        {

        }

        private void label_login_Click(object sender, EventArgs e)
        {

        }

        private void button_login_logout_Click(object sender, EventArgs e)
        {
            if (button_login_logout.Text == "Logout")
            {
                tabPage_calls.Enabled = false;
                tabPage_chats.Enabled = false;
                label_login.Text = "Not logged in";
                button_login_logout.Text = "Login";
                return;
            }

            //TODO add login functionality from login.dll
            LoginDialog login_dialog = new LoginDialog();
            switch (login_dialog.ShowDialog())
            {
                case DialogResult.OK:
                {
					if (login_dialog.textBox1.Text.Length != 0)
					{
						this.account = new LinphoneAccount.Account(
							login_dialog.textBox1.Text,
							login_dialog.textBox2.Text,
							"sip.linphone.org");

						this.phone = new Phone();
						this.phone.Connect();

						tabPage_calls.Enabled = true;
						tabPage_chats.Enabled = true;
						label_login.Text = "Logged in as " + login_dialog.textBox1.Text;
						button_login_logout.Text = "Logout";
					}
					break;
                }
            }
        }

        private void label_status_message_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
