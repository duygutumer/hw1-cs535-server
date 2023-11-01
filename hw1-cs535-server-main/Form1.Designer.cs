
namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button3 = new Button();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            rekey_button = new Button();
            messageBox = new TextBox();
            server = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(22, 166);
            button3.Margin = new Padding(1);
            button3.Name = "button3";
            button3.Size = new Size(68, 26);
            button3.TabIndex = 21;
            button3.Text = "Start\r\n\r\n\r\n";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 95);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 20;
            label4.Text = "Host:\r\n";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 127);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 19;
            label3.Text = "Port:";
            label3.Click += label3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(66, 127);
            textBox3.Margin = new Padding(1);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(115, 27);
            textBox3.TabIndex = 18;
            textBox3.Text = "8090";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(66, 92);
            textBox2.Margin = new Padding(1);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(115, 27);
            textBox2.TabIndex = 17;
            textBox2.Text = "127.0.0.1";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 209);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 16;
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 108);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 15;
            label1.Click += label1_Click;
            // 
            // rekey_button
            // 
            rekey_button.BackColor = SystemColors.ActiveCaption;
            rekey_button.Location = new Point(312, 24);
            rekey_button.Margin = new Padding(1);
            rekey_button.Name = "rekey_button";
            rekey_button.Size = new Size(73, 34);
            rekey_button.TabIndex = 14;
            rekey_button.Text = "Rekey\r\n";
            rekey_button.UseVisualStyleBackColor = false;
            rekey_button.Click += rekey_button_Click;
            // 
            // messageBox
            // 
            messageBox.Location = new Point(22, 237);
            messageBox.Margin = new Padding(1);
            messageBox.Multiline = true;
            messageBox.Name = "messageBox";
            messageBox.Size = new Size(365, 125);
            messageBox.TabIndex = 12;
            messageBox.TextChanged += (sender, e) => messageBox_TextChanged(sender, e);
            // 
            // server
            // 
            server.AutoSize = true;
            server.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            server.ForeColor = SystemColors.HotTrack;
            server.Location = new Point(15, 24);
            server.Margin = new Padding(1, 0, 1, 0);
            server.Name = "server";
            server.Size = new Size(100, 41);
            server.TabIndex = 11;
            server.Text = "Server";
            server.Click += client_Click;
            // 
            // button4
            // 
            button4.Location = new Point(110, 166);
            button4.Margin = new Padding(1);
            button4.Name = "button4";
            button4.Size = new Size(68, 26);
            button4.TabIndex = 22;
            button4.Text = "Stop";
            button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 376);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rekey_button);
            Controls.Add(messageBox);
            Controls.Add(server);
            Margin = new Padding(1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private Button rekey_button;
        private TextBox messageBox;
        private Label server;
        private Button button4;
    }
}

