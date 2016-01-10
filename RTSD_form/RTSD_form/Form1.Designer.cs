namespace RTSD_form
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_calls = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_status = new System.Windows.Forms.Label();
            this.label_status_message = new System.Windows.Forms.Label();
            this.button_call = new System.Windows.Forms.Button();
            this.textBox_call_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_chats = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_chat_selection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.send_chat_message_button = new System.Windows.Forms.Button();
            this.richTextBox_compose_field = new System.Windows.Forms.RichTextBox();
            this.richTextBox_chat_log = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.button_login_logout = new System.Windows.Forms.Button();
            this.button_answer = new System.Windows.Forms.Button();
            this.button_hangup = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage_calls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_chats.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_calls);
            this.tabControl.Controls.Add(this.tabPage_chats);
            this.tabControl.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(120, 40);
            this.tabControl.Location = new System.Drawing.Point(14, 14);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(842, 554);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_calls
            // 
            this.tabPage_calls.Controls.Add(this.groupBox1);
            this.tabPage_calls.Controls.Add(this.button_call);
            this.tabPage_calls.Controls.Add(this.textBox_call_address);
            this.tabPage_calls.Controls.Add(this.label1);
            this.tabPage_calls.Location = new System.Drawing.Point(4, 44);
            this.tabPage_calls.Name = "tabPage_calls";
            this.tabPage_calls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_calls.Size = new System.Drawing.Size(834, 506);
            this.tabPage_calls.TabIndex = 2;
            this.tabPage_calls.Text = "Call";
            this.tabPage_calls.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_hangup);
            this.groupBox1.Controls.Add(this.button_answer);
            this.groupBox1.Controls.Add(this.label_status);
            this.groupBox1.Controls.Add(this.label_status_message);
            this.groupBox1.Location = new System.Drawing.Point(17, 118);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 363);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label_status
            // 
            this.label_status.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(6, 19);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(788, 50);
            this.label_status.TabIndex = 3;
            this.label_status.Text = "Current Status";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_status_message
            // 
            this.label_status_message.AllowDrop = true;
            this.label_status_message.BackColor = System.Drawing.Color.Transparent;
            this.label_status_message.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status_message.ForeColor = System.Drawing.Color.OliveDrab;
            this.label_status_message.Location = new System.Drawing.Point(7, 72);
            this.label_status_message.Name = "label_status_message";
            this.label_status_message.Size = new System.Drawing.Size(787, 218);
            this.label_status_message.TabIndex = 4;
            this.label_status_message.Text = "Idle";
            this.label_status_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_call
            // 
            this.button_call.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_call.Location = new System.Drawing.Point(10, 59);
            this.button_call.Name = "button_call";
            this.button_call.Size = new System.Drawing.Size(131, 36);
            this.button_call.TabIndex = 2;
            this.button_call.Text = "Call";
            this.button_call.UseVisualStyleBackColor = true;
            this.button_call.Click += new System.EventHandler(this.button_call_Click);
            // 
            // textBox_call_address
            // 
            this.textBox_call_address.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_call_address.Location = new System.Drawing.Point(10, 31);
            this.textBox_call_address.Name = "textBox_call_address";
            this.textBox_call_address.Size = new System.Drawing.Size(275, 22);
            this.textBox_call_address.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "TARGET SIP ADDRESS";
            // 
            // tabPage_chats
            // 
            this.tabPage_chats.Controls.Add(this.groupBox2);
            this.tabPage_chats.Location = new System.Drawing.Point(4, 44);
            this.tabPage_chats.Name = "tabPage_chats";
            this.tabPage_chats.Size = new System.Drawing.Size(834, 506);
            this.tabPage_chats.TabIndex = 3;
            this.tabPage_chats.Text = "Chat";
            this.tabPage_chats.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.comboBox_chat_selection);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.send_chat_message_button);
            this.groupBox2.Controls.Add(this.richTextBox_compose_field);
            this.groupBox2.Controls.Add(this.richTextBox_chat_log);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(14, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(806, 471);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // comboBox_chat_selection
            // 
            this.comboBox_chat_selection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_chat_selection.FormattingEnabled = true;
            this.comboBox_chat_selection.Location = new System.Drawing.Point(469, 43);
            this.comboBox_chat_selection.Name = "comboBox_chat_selection";
            this.comboBox_chat_selection.Size = new System.Drawing.Size(324, 27);
            this.comboBox_chat_selection.TabIndex = 8;
            this.comboBox_chat_selection.SelectedIndexChanged += new System.EventHandler(this.comboBox_chat_selection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(466, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Target Username";
            // 
            // send_chat_message_button
            // 
            this.send_chat_message_button.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send_chat_message_button.Location = new System.Drawing.Point(635, 408);
            this.send_chat_message_button.Margin = new System.Windows.Forms.Padding(10, 15, 20, 20);
            this.send_chat_message_button.Name = "send_chat_message_button";
            this.send_chat_message_button.Size = new System.Drawing.Size(148, 40);
            this.send_chat_message_button.TabIndex = 7;
            this.send_chat_message_button.Text = "Send";
            this.send_chat_message_button.UseVisualStyleBackColor = true;
            this.send_chat_message_button.Click += new System.EventHandler(this.button_message_send_Click);
            // 
            // richTextBox_compose_field
            // 
            this.richTextBox_compose_field.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_compose_field.Location = new System.Drawing.Point(13, 398);
            this.richTextBox_compose_field.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.richTextBox_compose_field.Name = "richTextBox_compose_field";
            this.richTextBox_compose_field.Size = new System.Drawing.Size(602, 60);
            this.richTextBox_compose_field.TabIndex = 5;
            this.richTextBox_compose_field.Text = "";
            // 
            // richTextBox_chat_log
            // 
            this.richTextBox_chat_log.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_chat_log.Location = new System.Drawing.Point(13, 83);
            this.richTextBox_chat_log.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.richTextBox_chat_log.Name = "richTextBox_chat_log";
            this.richTextBox_chat_log.Size = new System.Drawing.Size(780, 305);
            this.richTextBox_chat_log.TabIndex = 4;
            this.richTextBox_chat_log.Text = "";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(451, 54);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chat Room";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_login
            // 
            this.label_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login.Location = new System.Drawing.Point(465, 17);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(288, 24);
            this.label_login.TabIndex = 3;
            this.label_login.Text = "Not logged in";
            this.label_login.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_login_logout
            // 
            this.button_login_logout.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login_logout.Location = new System.Drawing.Point(761, 14);
            this.button_login_logout.Name = "button_login_logout";
            this.button_login_logout.Size = new System.Drawing.Size(93, 28);
            this.button_login_logout.TabIndex = 5;
            this.button_login_logout.Text = "Login";
            this.button_login_logout.UseVisualStyleBackColor = true;
            this.button_login_logout.Click += new System.EventHandler(this.button_login_logout_Click);
            // 
            // button_answer
            // 
            this.button_answer.Enabled = false;
            this.button_answer.Location = new System.Drawing.Point(13, 300);
            this.button_answer.Margin = new System.Windows.Forms.Padding(10);
            this.button_answer.Name = "button_answer";
            this.button_answer.Size = new System.Drawing.Size(160, 50);
            this.button_answer.TabIndex = 5;
            this.button_answer.Text = "Answer";
            this.button_answer.UseVisualStyleBackColor = true;
            this.button_answer.Click += new System.EventHandler(this.button_answer_Click);
            // 
            // button_hangup
            // 
            this.button_hangup.Enabled = false;
            this.button_hangup.Location = new System.Drawing.Point(627, 300);
            this.button_hangup.Margin = new System.Windows.Forms.Padding(10);
            this.button_hangup.Name = "button_hangup";
            this.button_hangup.Size = new System.Drawing.Size(160, 50);
            this.button_hangup.TabIndex = 6;
            this.button_hangup.Text = "Hang up";
            this.button_hangup.UseVisualStyleBackColor = true;
            this.button_hangup.Click += new System.EventHandler(this.button_hangup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(868, 582);
            this.Controls.Add(this.button_login_logout);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Sip <2015> Softphone";
            this.tabControl.ResumeLayout(false);
            this.tabPage_calls.ResumeLayout(false);
            this.tabPage_calls.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage_chats.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_calls;
        private System.Windows.Forms.TabPage tabPage_chats;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.TextBox textBox_call_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_call;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_status_message;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button send_chat_message_button;
        private System.Windows.Forms.RichTextBox richTextBox_compose_field;
        private System.Windows.Forms.RichTextBox richTextBox_chat_log;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_login_logout;
        private System.Windows.Forms.ComboBox comboBox_chat_selection;
        private System.Windows.Forms.Button button_answer;
        private System.Windows.Forms.Button button_hangup;
    }
}

