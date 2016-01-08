using System;
using System.Diagnostics;
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
        public delegate void changeControlAvailability(bool boolean);
        public delegate void changeLabelText(string text);

        Phone phone;
		Account account;

        public Form1()
        {
            InitializeComponent();
            tabPage_calls.Enabled = false;
            tabPage_chats.Enabled = false;
        }

        private void connectedEvent()
        {
            tabPage_calls.Invoke(new changeControlAvailability(updateTabPageCallsAvailability), new object[] { true });
            tabPage_chats.Invoke(new changeControlAvailability(updateTabPageChatsAvailability), new object[] { true });
            label_login.Invoke(new changeLabelText(changeLoginText), new object[] { "Logged in as " + account.Username});
            button_login_logout.Invoke(new changeControlAvailability(updateLoginAvailability), new object[] { true });
        }
        private void disconnectedEvent()
        {
            label_login.Invoke(new changeLabelText(changeLoginText), new object[] { "Not logged in." + button_login_logout.Text });
            button_login_logout.Invoke(new changeControlAvailability(updateLoginAvailability), new object[] { true });
        }

        private void button_login_logout_Click(object sender, EventArgs e)
        {
            if (button_login_logout.Text == "Logout")
            {
                tabPage_calls.Enabled = false;
                tabPage_chats.Enabled = false;
                label_login.Text = "Logging out...";
                button_login_logout.Text = "Login";
                button_login_logout.Enabled = false;
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
                            this.account = new LinphoneAccount.Account(login_dialog.textBox1.Text,
                                                                       login_dialog.textBox2.Text,
                                                                       "sip.linphone.org");

                            this.phone = new Phone(this.account);
                            phone.ConnectedEvent += delegate () { connectedEvent(); };
                            phone.ConnectedEvent += delegate () { connectedEvent(); };
                            this.phone.Connect();

                            label_login.Text = "Connecting...";
                            button_login_logout.Text = "Logout";
                            button_login_logout.Enabled = false;
                        }
                        break;
                    }
            }
        }
        private void updateTabPageCallsAvailability(bool isAvailable)
        {
            tabPage_calls.Enabled = isAvailable;
        }
        private void updateTabPageChatsAvailability(bool isAvailable)
        {
            tabPage_chats.Enabled = isAvailable;
        }
        private void updateLoginAvailability(bool isAvailable)
        {
            button_login_logout.Enabled = isAvailable;
        }
        private void changeLoginText(string text)
        {
            label_login.Text = text;
        }

        private void button_call_Click(object sender, EventArgs e)
        {
            phone.MakeCall(textBox_call_address.Text);
        }
        private void updateStatusLabel(string text)
        {
            label_status_message.Text = text;
        }



    }
}
