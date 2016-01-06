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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_chats = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_login_logout = new System.Windows.Forms.Button();
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
            this.tabControl.Size = new System.Drawing.Size(553, 554);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_calls
            // 
            this.tabPage_calls.Controls.Add(this.groupBox1);
            this.tabPage_calls.Controls.Add(this.button1);
            this.tabPage_calls.Controls.Add(this.textBox1);
            this.tabPage_calls.Controls.Add(this.label1);
            this.tabPage_calls.Location = new System.Drawing.Point(4, 44);
            this.tabPage_calls.Name = "tabPage_calls";
            this.tabPage_calls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_calls.Size = new System.Drawing.Size(545, 506);
            this.tabPage_calls.TabIndex = 2;
            this.tabPage_calls.Text = "Call";
            this.tabPage_calls.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_status);
            this.groupBox1.Controls.Add(this.label_status_message);
            this.groupBox1.Location = new System.Drawing.Point(17, 118);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(14, 14, 14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 363);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label_status
            // 
            this.label_status.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(7, 22);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(495, 50);
            this.label_status.TabIndex = 3;
            this.label_status.Text = "Current Status";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_status_message
            // 
            this.label_status_message.BackColor = System.Drawing.Color.Transparent;
            this.label_status_message.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status_message.ForeColor = System.Drawing.Color.OliveDrab;
            this.label_status_message.Location = new System.Drawing.Point(7, 72);
            this.label_status_message.Name = "label_status_message";
            this.label_status_message.Size = new System.Drawing.Size(495, 288);
            this.label_status_message.TabIndex = 4;
            this.label_status_message.Text = "Trolling";
            this.label_status_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_status_message.Click += new System.EventHandler(this.label_status_message_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(10, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Call";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 22);
            this.textBox1.TabIndex = 1;
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
            this.tabPage_chats.Controls.Add(this.button2);
            this.tabPage_chats.Controls.Add(this.textBox2);
            this.tabPage_chats.Controls.Add(this.label3);
            this.tabPage_chats.Location = new System.Drawing.Point(4, 44);
            this.tabPage_chats.Name = "tabPage_chats";
            this.tabPage_chats.Size = new System.Drawing.Size(545, 506);
            this.tabPage_chats.TabIndex = 3;
            this.tabPage_chats.Text = "Chat";
            this.tabPage_chats.UseVisualStyleBackColor = true;
            this.tabPage_chats.Click += new System.EventHandler(this.tabPage_chats_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(14, 118);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(14, 14, 14, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 367);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(339, 294);
            this.button3.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 58);
            this.button3.TabIndex = 7;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(7, 286);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(317, 73);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(7, 75);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(501, 204);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(495, 50);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chat Room";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(10, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Chat";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(10, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(275, 22);
            this.textBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "TARGET SIP ADDRESS";
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
            // richTextBox_log
            // 
            this.richTextBox_log.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_log.Location = new System.Drawing.Point(574, 83);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(279, 484);
            this.richTextBox_log.TabIndex = 3;
            this.richTextBox_log.Text = "";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(574, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Event Log";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(868, 582);
            this.Controls.Add(this.button_login_logout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_log);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabPage_calls.ResumeLayout(false);
            this.tabPage_calls.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage_chats.ResumeLayout(false);
            this.tabPage_chats.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_calls;
        private System.Windows.Forms.TabPage tabPage_chats;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_status_message;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_login_logout;
    }
}

