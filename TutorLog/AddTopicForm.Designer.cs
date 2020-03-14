namespace TutorLog
{
    partial class AddTopicForm
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
            this.topicDescriptionLabel = new System.Windows.Forms.Label();
            this.topicCampusLabel = new System.Windows.Forms.Label();
            this.topicCourseComboBox = new System.Windows.Forms.ComboBox();
            this.topicCampusListBox = new System.Windows.Forms.ListBox();
            this.saveTopicBtn = new System.Windows.Forms.Button();
            this.cancelTopicBtn = new System.Windows.Forms.Button();
            this.topicCourseLabel = new System.Windows.Forms.Label();
            this.topicDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // topicDescriptionLabel
            // 
            this.topicDescriptionLabel.AutoSize = true;
            this.topicDescriptionLabel.Location = new System.Drawing.Point(58, 49);
            this.topicDescriptionLabel.Name = "topicDescriptionLabel";
            this.topicDescriptionLabel.Size = new System.Drawing.Size(79, 17);
            this.topicDescriptionLabel.TabIndex = 0;
            this.topicDescriptionLabel.Text = "Description";
            // 
            // topicCampusLabel
            // 
            this.topicCampusLabel.AutoSize = true;
            this.topicCampusLabel.Location = new System.Drawing.Point(58, 211);
            this.topicCampusLabel.Name = "topicCampusLabel";
            this.topicCampusLabel.Size = new System.Drawing.Size(59, 17);
            this.topicCampusLabel.TabIndex = 1;
            this.topicCampusLabel.Text = "Campus";
            // 
            // topicCourseComboBox
            // 
            this.topicCourseComboBox.FormattingEnabled = true;
            this.topicCourseComboBox.Location = new System.Drawing.Point(58, 146);
            this.topicCourseComboBox.Name = "topicCourseComboBox";
            this.topicCourseComboBox.Size = new System.Drawing.Size(249, 24);
            this.topicCourseComboBox.TabIndex = 2;
            // 
            // topicCampusListBox
            // 
            this.topicCampusListBox.FormattingEnabled = true;
            this.topicCampusListBox.ItemHeight = 16;
            this.topicCampusListBox.Location = new System.Drawing.Point(58, 231);
            this.topicCampusListBox.Name = "topicCampusListBox";
            this.topicCampusListBox.Size = new System.Drawing.Size(249, 84);
            this.topicCampusListBox.TabIndex = 3;
            // 
            // saveTopicBtn
            // 
            this.saveTopicBtn.Location = new System.Drawing.Point(58, 349);
            this.saveTopicBtn.Name = "saveTopicBtn";
            this.saveTopicBtn.Size = new System.Drawing.Size(75, 23);
            this.saveTopicBtn.TabIndex = 4;
            this.saveTopicBtn.Text = "Save";
            this.saveTopicBtn.UseVisualStyleBackColor = true;
            this.saveTopicBtn.Click += new System.EventHandler(this.saveTopicBtn_Click);
            // 
            // cancelTopicBtn
            // 
            this.cancelTopicBtn.Location = new System.Drawing.Point(232, 349);
            this.cancelTopicBtn.Name = "cancelTopicBtn";
            this.cancelTopicBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelTopicBtn.TabIndex = 5;
            this.cancelTopicBtn.Text = "Cancel";
            this.cancelTopicBtn.UseVisualStyleBackColor = true;
            this.cancelTopicBtn.Click += new System.EventHandler(this.cancelTopicBtn_Click);
            // 
            // topicCourseLabel
            // 
            this.topicCourseLabel.AutoSize = true;
            this.topicCourseLabel.Location = new System.Drawing.Point(55, 126);
            this.topicCourseLabel.Name = "topicCourseLabel";
            this.topicCourseLabel.Size = new System.Drawing.Size(53, 17);
            this.topicCourseLabel.TabIndex = 6;
            this.topicCourseLabel.Text = "Course";
            // 
            // topicDescriptionTextBox
            // 
            this.topicDescriptionTextBox.Location = new System.Drawing.Point(58, 69);
            this.topicDescriptionTextBox.Name = "topicDescriptionTextBox";
            this.topicDescriptionTextBox.Size = new System.Drawing.Size(249, 22);
            this.topicDescriptionTextBox.TabIndex = 8;
            // 
            // AddTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 450);
            this.Controls.Add(this.topicDescriptionTextBox);
            this.Controls.Add(this.topicCourseLabel);
            this.Controls.Add(this.cancelTopicBtn);
            this.Controls.Add(this.saveTopicBtn);
            this.Controls.Add(this.topicCampusListBox);
            this.Controls.Add(this.topicCourseComboBox);
            this.Controls.Add(this.topicCampusLabel);
            this.Controls.Add(this.topicDescriptionLabel);
            this.Name = "AddTopic";
            this.Text = "Add Topic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topicDescriptionLabel;
        private System.Windows.Forms.Label topicCampusLabel;
        private System.Windows.Forms.ComboBox topicCourseComboBox;
        private System.Windows.Forms.ListBox topicCampusListBox;
        private System.Windows.Forms.Button saveTopicBtn;
        private System.Windows.Forms.Button cancelTopicBtn;
        private System.Windows.Forms.Label topicCourseLabel;
        private System.Windows.Forms.TextBox topicDescriptionTextBox;
    }
}