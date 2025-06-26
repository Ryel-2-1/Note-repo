namespace NoteApp1
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
            lblLoggedInUser = new Label();
            btnSwitchUser = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lstNotes = new ListBox();
            label2 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnAddNote = new Button();
            btnUpdateNote = new Button();
            btnDeleteNote = new Button();
            btnViewAll = new Button();
            btnExit = new Button();
            label3 = new Label();
            label4 = new Label();
            lblStatus = new Label();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblLoggedInUser
            // 
            lblLoggedInUser.AutoSize = true;
            lblLoggedInUser.FlatStyle = FlatStyle.Popup;
            lblLoggedInUser.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoggedInUser.Location = new Point(34, 38);
            lblLoggedInUser.Name = "lblLoggedInUser";
            lblLoggedInUser.Size = new Size(237, 32);
            lblLoggedInUser.TabIndex = 0;
            lblLoggedInUser.Text = "Welcome,[username]";
            // 
            // btnSwitchUser
            // 
            btnSwitchUser.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSwitchUser.Location = new Point(437, 56);
            btnSwitchUser.Name = "btnSwitchUser";
            btnSwitchUser.Size = new Size(113, 32);
            btnSwitchUser.TabIndex = 1;
            btnSwitchUser.Text = "Switch Account";
            btnSwitchUser.UseVisualStyleBackColor = true;
            btnSwitchUser.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lstNotes);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(lblStatus);
            flowLayoutPanel1.Location = new Point(34, 112);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(324, 274);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // lstNotes
            // 
            lstNotes.FormattingEnabled = true;
            lstNotes.ItemHeight = 15;
            lstNotes.Location = new Point(12, 25);
            lstNotes.Margin = new Padding(12, 25, 12, 12);
            lstNotes.Name = "lstNotes";
            lstNotes.Size = new Size(300, 199);
            lstNotes.TabIndex = 0;
            lstNotes.SelectedIndexChanged += lstNotes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(47, 104);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 3;
            label2.Text = "Your Notes";
            label2.Click += label2_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnAddNote);
            flowLayoutPanel2.Controls.Add(btnUpdateNote);
            flowLayoutPanel2.Controls.Add(btnDeleteNote);
            flowLayoutPanel2.Controls.Add(btnViewAll);
            flowLayoutPanel2.Controls.Add(btnExit);
            flowLayoutPanel2.Location = new Point(376, 112);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(203, 274);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // btnAddNote
            // 
            btnAddNote.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNote.Location = new Point(12, 25);
            btnAddNote.Margin = new Padding(12, 25, 3, 3);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(182, 35);
            btnAddNote.TabIndex = 0;
            btnAddNote.Text = "Add Note";
            btnAddNote.UseVisualStyleBackColor = true;
            btnAddNote.Click += btnAddNote_Click;
            // 
            // btnUpdateNote
            // 
            btnUpdateNote.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateNote.Location = new Point(12, 66);
            btnUpdateNote.Margin = new Padding(12, 3, 3, 3);
            btnUpdateNote.Name = "btnUpdateNote";
            btnUpdateNote.Size = new Size(182, 35);
            btnUpdateNote.TabIndex = 1;
            btnUpdateNote.Text = "Update Note";
            btnUpdateNote.UseVisualStyleBackColor = true;
            btnUpdateNote.Click += btnUpdateNote_Click;
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteNote.Location = new Point(12, 107);
            btnDeleteNote.Margin = new Padding(12, 3, 3, 3);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(182, 35);
            btnDeleteNote.TabIndex = 2;
            btnDeleteNote.Text = "Delete Note";
            btnDeleteNote.UseVisualStyleBackColor = true;
            btnDeleteNote.Click += btnDeleteNote_Click;
            // 
            // btnViewAll
            // 
            btnViewAll.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewAll.Location = new Point(12, 148);
            btnViewAll.Margin = new Padding(12, 3, 3, 3);
            btnViewAll.Name = "btnViewAll";
            btnViewAll.Size = new Size(182, 35);
            btnViewAll.TabIndex = 3;
            btnViewAll.Text = "View All Notes";
            btnViewAll.UseVisualStyleBackColor = true;
            btnViewAll.Click += btnViewAll_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(12, 189);
            btnExit.Margin = new Padding(12, 3, 3, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(182, 35);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(388, 104);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 4;
            label3.Text = "Actions";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 236);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 5;
            label4.Text = "Status :";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = SystemColors.AppWorkspace;
            lblStatus.Location = new Point(65, 236);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 21);
            lblStatus.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 460);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnSwitchUser);
            Controls.Add(lblLoggedInUser);
            Name = "Form1";
            Text = "Note Application";
            Load += Form1_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoggedInUser;
        private Button btnSwitchUser;
        private FlowLayoutPanel flowLayoutPanel1;
        private ListBox lstNotes;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnAddNote;
        private Label label3;
        private Button btnUpdateNote;
        private Button btnDeleteNote;
        private Button btnViewAll;
        private Button btnExit;
        private Label label4;
        private Label lblStatus;
    }
}
