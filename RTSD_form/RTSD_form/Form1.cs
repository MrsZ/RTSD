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

using LiblinphonedotNET;

namespace RTSD_form
{
    public partial class Form1 : Form
    {
        string current_combobox_selection = "";
        bool logged_in = false;

        public delegate void changeControlAvailability(bool isAvailable);
        public delegate void changeLabelText(string text);
        public delegate void changeRichTextboxText(string text);
        public delegate void appendComboboxItems(string text);
        public delegate void changeButtonAvailability(bool isAvailable);
        public delegate void changeButtonText(string text);

        Phone phone;
		Account account;

        public Form1()
        {
            InitializeComponent();
            tabPage_calls.Enabled = false;
            tabPage_chats.Enabled = false;
        }

        #region Event definitions
        private void connectedEvent()
        {
            logged_in = true;
            tabPage_calls.Invoke(new changeControlAvailability(updateTabPageCallsAvailability), new object[] { true });
            tabPage_chats.Invoke(new changeControlAvailability(updateTabPageChatsAvailability), new object[] { true });
            label_login.Invoke(new changeLabelText(changeLoginText), new object[] { "Logged in as " + account.Username });
            button_login_logout.Invoke(new changeControlAvailability(updateLoginAvailability), new object[] { true });
            button_login_logout.Invoke(new changeButtonText(changeLoginButtonText), new object[] { "Logout" });
        }
        private void disconnectedEvent()
        {
            logged_in = false;
            label_login.Invoke(new changeLabelText(changeLoginText), new object[] { "Not logged in." });
            button_login_logout.Invoke(new changeControlAvailability(updateLoginAvailability), new object[] { true });
            button_login_logout.Invoke(new changeButtonText(changeLoginButtonText), new object[] { "Login" });
        }
        private void failedLoginEvent(Phone.RegisterError error_type, string message)
        {
            disconnectedEvent();
        }
        //Chat
        private void chatMessageReceived(ChatRoom chat_room, LinphoneMessage message)
        {
            //Init combobox to the first sender if none present yet
            if (current_combobox_selection == "")
                current_combobox_selection = message.sender;

            comboBox_chat_selection.Invoke(new appendComboboxItems(addToComboBoxIfNew), new object[] { message.sender });
            if (chat_room.getPeer().Equals(phone.getCurrentChatRoom("sip:" + current_combobox_selection + "@sip.linphone.org").getPeer()))
                richTextBox_chat_log.Invoke(new changeRichTextboxText(changeLogText), new object[] { chat_room.getTextLog() });
        }
        //Calls
        private void CallIncoming(Call call)
        {
            label_status_message.Invoke(new changeLabelText(changeStatusMessage), new object[] { "Incoming call from " + call.from });
            button_answer.Invoke(new changeButtonAvailability(changeAnswerAvailability), new object[] { true });
            button_hangup.Invoke(new changeButtonAvailability(changeHangupAvailability), new object[] { true });
        }
        private void CallProgress(Call call)
        {
            if (call.call_type == Call.CallType.Incoming)
                label_status_message.Invoke(new changeLabelText(changeStatusMessage), new object[] { "Speaking with " + call.from });
            else
                label_status_message.Invoke(new changeLabelText(changeStatusMessage), new object[] { "Speaking with " + call.to });

            button_answer.Invoke(new changeButtonAvailability(changeAnswerAvailability), new object[] { false });
            button_hangup.Invoke(new changeButtonAvailability(changeHangupAvailability), new object[] { true });
        }
        private void CallEnded(Call call)
        {
            label_status_message.Invoke(new changeLabelText(changeStatusMessage), new object[] { "Idle" });
            button_answer.Invoke(new changeButtonAvailability(changeAnswerAvailability), new object[] { false });
            button_hangup.Invoke(new changeButtonAvailability(changeHangupAvailability), new object[] { false });
        }
        private void Calling(Call call)
        {
            label_status_message.Invoke(new changeLabelText(changeStatusMessage), new object[] { "Calling " + call.to });
            button_answer.Invoke(new changeButtonAvailability(changeAnswerAvailability), new object[] { false });
            button_hangup.Invoke(new changeButtonAvailability(changeHangupAvailability), new object[] { true });
        }
        #endregion

        #region Widget events
        private void button_login_logout_Click(object sender, EventArgs e)
        {
            if (logged_in)
                logout();
            else
                login();      
        }
        private void login()
        {
            LoginDialog login_dialog = new LoginDialog();
            if (login_dialog.ShowDialog() == DialogResult.OK)
            {

                //Escape if neither one of the textfields is empty
                if (login_dialog.textBox_username.Text.Length == 0)
                    return;
                if (login_dialog.textBox_password.Text.Length == 0)
                    return;

                label_login.Text = "Connecting...";
                button_login_logout.Text = "Logging in...";
                button_login_logout.Enabled = false;

                //Create account with the provided credentials
                this.account = new Account(login_dialog.textBox_username.Text,
                                                            login_dialog.textBox_password.Text,
                                                            "sip.linphone.org");

                this.phone = new Phone(this.account);

                //Link callbacks
                phone.connectedEvent += connectedEvent;
                phone.disconnectedEvent += disconnectedEvent;
                phone.loginErrorEvent += failedLoginEvent;
                phone.MessageReceivedEvent += chatMessageReceived;

                phone.IncomingRingingEvent += CallIncoming;
                phone.StreamsRunningEvent += CallProgress;
                phone.EndedEvent += CallEnded;
                phone.OutgoingRingingEvent += Calling;

                this.phone.Connect();
            }
        }
        private void logout()
        {
            tabPage_calls.Enabled = false;
            tabPage_chats.Enabled = false;
            label_login.Text = "Logging out...";
            button_login_logout.Text = "Login";
            button_login_logout.Enabled = false;
            phone.Disconnect();
        }

        private void button_call_Click(object sender, EventArgs e)
        {
            phone.makeCall(textBox_call_address.Text);
        }
        private void button_hangup_Click(object sender, EventArgs e)
        {
            phone.hangupCall();
        }
        private void button_answer_Click(object sender, EventArgs e)
        {
            phone.answerCall();
        }

        private void comboBox_chat_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboBox_chat_selection.SelectedItem == "")
                return;

            current_combobox_selection = (string)comboBox_chat_selection.SelectedItem;
            ChatRoom current_room = phone.getCurrentChatRoom("sip:" + current_combobox_selection + "@sip.linphone.org");
            if (current_room == null)
                richTextBox_chat_log.Text = "";
            else
                richTextBox_chat_log.Text = current_room.getTextLog(); 
        }
        private void button_message_send_Click(object sender, EventArgs e)
        {
            addToComboBoxIfNew(comboBox_chat_selection.Text);
            int selection_index = findFromComboBox(comboBox_chat_selection.Text);
            if (selection_index != -1)
                comboBox_chat_selection.SelectedIndex = selection_index;

            string target_username = (string)comboBox_chat_selection.SelectedItem;
            //byte[] message_bytes = Encoding.Default.GetBytes(richTextBox_compose_field.Text);
            //string message_to_send = Encoding.UTF8.GetString(message_bytes);
            string message_to_send = richTextBox_compose_field.Text;
            richTextBox_compose_field.Text = "";

            if (string.IsNullOrEmpty(target_username))
                throw new ArgumentNullException("target username");

            phone.sendMessage("sip:" + target_username + "@sip.linphone.org", message_to_send);
            comboBox_chat_selection_SelectedIndexChanged(null, null);
        }
        private int findFromComboBox(string name)
        {
            for (int iterator = 0; iterator < comboBox_chat_selection.Items.Count; iterator++)
            {
                if (comboBox_chat_selection.Items[iterator].Equals(name))
                    return iterator;
            }
            return -1;
        }
        #endregion

        #region widget access delegate functions
        private void addToComboBoxIfNew(string text)
        {
            if (!comboBox_chat_selection.Items.Contains(text))
                comboBox_chat_selection.Items.Add(text);
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
        private void updateStatusLabel(string text)
        {
            label_status_message.Text = text;
        }
        private void changeLogText(string text)
        {
            richTextBox_chat_log.Text = text;
        }
        private void changeAnswerAvailability(bool isAvailable)
        {
            button_answer.Enabled = isAvailable;
        }
        private void changeHangupAvailability(bool isAvailable)
        {
            button_hangup.Enabled = isAvailable;
        }
        private void changeStatusMessage(string message)
        {
            label_status_message.Text = message;
        }
        private void changeLoginButtonText(string message)
        {
            button_login_logout.Text = message;
        }
        #endregion


    }
}
