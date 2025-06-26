namespace NoteApp1
{
    partial class LoginNew
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
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 33);
            label1.Name = "label1";
            label1.Size = new Size(249, 30);
            label1.TabIndex = 0;
            label1.Text = "Hello! This is a Note App!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 98);
            label2.Name = "label2";
            label2.Size = new Size(165, 25);
            label2.TabIndex = 1;
            label2.Text = "Enter your name : ";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(30, 138);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(315, 23);
            txtUsername.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(30, 221);
            button1.Name = "button1";
            button1.Size = new Size(126, 29);
            button1.TabIndex = 3;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(219, 221);
            button2.Name = "button2";
            button2.Size = new Size(126, 29);
            button2.TabIndex = 4;
            button2.Text = "CANCEL";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LoginNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 329);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginNew";
            Text = "LoginNew";
            Load += LoginNew_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private Button button1;
        private Button button2;
    }
}