namespace TutorLog
{
    partial class AddTutorForm
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
            this.tutorFNameLabel = new System.Windows.Forms.Label();
            this.saveTutorBtn = new System.Windows.Forms.Button();
            this.tutorCancelBtn = new System.Windows.Forms.Button();
            this.campusListBox = new System.Windows.Forms.ListBox();
            this.tutorFNameTextbox = new System.Windows.Forms.TextBox();
            this.tutorLastNameTextbox = new System.Windows.Forms.TextBox();
            this.tutorCampusLabel = new System.Windows.Forms.Label();
            this.tutorLNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tutorFNameLabel
            // 
            this.tutorFNameLabel.AutoSize = true;
            this.tutorFNameLabel.Location = new System.Drawing.Point(77, 19);
            this.tutorFNameLabel.Name = "tutorFNameLabel";
            this.tutorFNameLabel.Size = new System.Drawing.Size(76, 17);
            this.tutorFNameLabel.TabIndex = 0;
            this.tutorFNameLabel.Text = "First Name";
            // 
            // saveTutorBtn
            // 
            this.saveTutorBtn.Location = new System.Drawing.Point(72, 339);
            this.saveTutorBtn.Name = "saveTutorBtn";
            this.saveTutorBtn.Size = new System.Drawing.Size(75, 23);
            this.saveTutorBtn.TabIndex = 1;
            this.saveTutorBtn.Text = "Save";
            this.saveTutorBtn.UseVisualStyleBackColor = true;
            this.saveTutorBtn.Click += new System.EventHandler(this.saveTutorBtn_Click);
            // 
            // tutorCancelBtn
            // 
            this.tutorCancelBtn.Location = new System.Drawing.Point(199, 339);
            this.tutorCancelBtn.Name = "tutorCancelBtn";
            this.tutorCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.tutorCancelBtn.TabIndex = 2;
            this.tutorCancelBtn.Text = "Cancel";
            this.tutorCancelBtn.UseVisualStyleBackColor = true;
            this.tutorCancelBtn.Click += new System.EventHandler(this.tutorCancelBtn_Click);
            // 
            // campusListBox
            // 
            this.campusListBox.FormattingEnabled = true;
            this.campusListBox.ItemHeight = 16;
            this.campusListBox.Location = new System.Drawing.Point(72, 178);
            this.campusListBox.Name = "campusListBox";
            this.campusListBox.Size = new System.Drawing.Size(202, 132);
            this.campusListBox.TabIndex = 3;
            // 
            // tutorFNameTextbox
            // 
            this.tutorFNameTextbox.Location = new System.Drawing.Point(80, 39);
            this.tutorFNameTextbox.Name = "tutorFNameTextbox";
            this.tutorFNameTextbox.Size = new System.Drawing.Size(194, 22);
            this.tutorFNameTextbox.TabIndex = 4;
            // 
            // tutorLastNameTextbox
            // 
            this.tutorLastNameTextbox.Location = new System.Drawing.Point(80, 107);
            this.tutorLastNameTextbox.Name = "tutorLastNameTextbox";
            this.tutorLastNameTextbox.Size = new System.Drawing.Size(194, 22);
            this.tutorLastNameTextbox.TabIndex = 5;
            // 
            // tutorCampusLabel
            // 
            this.tutorCampusLabel.AutoSize = true;
            this.tutorCampusLabel.Location = new System.Drawing.Point(77, 158);
            this.tutorCampusLabel.Name = "tutorCampusLabel";
            this.tutorCampusLabel.Size = new System.Drawing.Size(59, 17);
            this.tutorCampusLabel.TabIndex = 6;
            this.tutorCampusLabel.Text = "Campus";
            // 
            // tutorLNameLabel
            // 
            this.tutorLNameLabel.AutoSize = true;
            this.tutorLNameLabel.Location = new System.Drawing.Point(77, 87);
            this.tutorLNameLabel.Name = "tutorLNameLabel";
            this.tutorLNameLabel.Size = new System.Drawing.Size(76, 17);
            this.tutorLNameLabel.TabIndex = 7;
            this.tutorLNameLabel.Text = "Last Name";
            // 
            // AddTutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 382);
            this.Controls.Add(this.tutorLNameLabel);
            this.Controls.Add(this.tutorCampusLabel);
            this.Controls.Add(this.tutorLastNameTextbox);
            this.Controls.Add(this.tutorFNameTextbox);
            this.Controls.Add(this.campusListBox);
            this.Controls.Add(this.tutorCancelBtn);
            this.Controls.Add(this.saveTutorBtn);
            this.Controls.Add(this.tutorFNameLabel);
            this.Name = "AddTutorForm";
            this.Text = "Add Tutor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tutorFNameLabel;
        private System.Windows.Forms.Button saveTutorBtn;
        private System.Windows.Forms.Button tutorCancelBtn;
        private System.Windows.Forms.ListBox campusListBox;
        private System.Windows.Forms.TextBox tutorFNameTextbox;
        private System.Windows.Forms.TextBox tutorLastNameTextbox;
        private System.Windows.Forms.Label tutorCampusLabel;
        private System.Windows.Forms.Label tutorLNameLabel;
    }
}