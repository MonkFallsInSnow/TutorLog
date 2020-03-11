namespace TutorLog
{
    partial class TutorLogForm
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
            this.components = new System.ComponentModel.Container();
            this.logTabs = new System.Windows.Forms.TabControl();
            this.logDataTabPage = new System.Windows.Forms.TabPage();
            this.sessionCampusLabel = new System.Windows.Forms.Label();
            this.recordsGroupBox = new System.Windows.Forms.GroupBox();
            this.logGrid = new System.Windows.Forms.DataGridView();
            this.sessionInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.noTopicsPictureBox = new System.Windows.Forms.PictureBox();
            this.addTopicButton = new System.Windows.Forms.Button();
            this.addTutorButton = new System.Windows.Forms.Button();
            this.logSessionBtn = new System.Windows.Forms.Button();
            this.topicsLabel = new System.Windows.Forms.Label();
            this.tutorNameLabel = new System.Windows.Forms.Label();
            this.topicsListBox = new System.Windows.Forms.ListBox();
            this.tutorComboBox = new System.Windows.Forms.ComboBox();
            this.logEditTab = new System.Windows.Forms.TabPage();
            this.reportsTabPage = new System.Windows.Forms.TabPage();
            this.adminTabPage = new System.Windows.Forms.TabPage();
            this.getSignInDataWorker = new System.ComponentModel.BackgroundWorker();
            this.tutorLogFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.logTabs.SuspendLayout();
            this.logDataTabPage.SuspendLayout();
            this.recordsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            this.sessionInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noTopicsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logTabs
            // 
            this.logTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTabs.Controls.Add(this.logDataTabPage);
            this.logTabs.Controls.Add(this.logEditTab);
            this.logTabs.Controls.Add(this.reportsTabPage);
            this.logTabs.Controls.Add(this.adminTabPage);
            this.logTabs.Location = new System.Drawing.Point(12, 12);
            this.logTabs.Name = "logTabs";
            this.logTabs.SelectedIndex = 0;
            this.logTabs.Size = new System.Drawing.Size(1271, 440);
            this.logTabs.TabIndex = 0;
            // 
            // logDataTabPage
            // 
            this.logDataTabPage.BackColor = System.Drawing.Color.Transparent;
            this.logDataTabPage.Controls.Add(this.sessionCampusLabel);
            this.logDataTabPage.Controls.Add(this.recordsGroupBox);
            this.logDataTabPage.Controls.Add(this.sessionInfoGroupBox);
            this.logDataTabPage.Location = new System.Drawing.Point(4, 25);
            this.logDataTabPage.Name = "logDataTabPage";
            this.logDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.logDataTabPage.Size = new System.Drawing.Size(1263, 411);
            this.logDataTabPage.TabIndex = 0;
            this.logDataTabPage.Text = "Log";
            // 
            // sessionCampusLabel
            // 
            this.sessionCampusLabel.AutoSize = true;
            this.sessionCampusLabel.Location = new System.Drawing.Point(9, 21);
            this.sessionCampusLabel.Name = "sessionCampusLabel";
            this.sessionCampusLabel.Size = new System.Drawing.Size(46, 17);
            this.sessionCampusLabel.TabIndex = 1;
            this.sessionCampusLabel.Text = "label1";
            // 
            // recordsGroupBox
            // 
            this.recordsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsGroupBox.Controls.Add(this.logGrid);
            this.recordsGroupBox.Location = new System.Drawing.Point(6, 52);
            this.recordsGroupBox.Name = "recordsGroupBox";
            this.recordsGroupBox.Size = new System.Drawing.Size(746, 338);
            this.recordsGroupBox.TabIndex = 0;
            this.recordsGroupBox.TabStop = false;
            this.recordsGroupBox.Text = "Records";
            // 
            // logGrid
            // 
            this.logGrid.AllowUserToAddRows = false;
            this.logGrid.AllowUserToDeleteRows = false;
            this.logGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.logGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.logGrid.Location = new System.Drawing.Point(6, 21);
            this.logGrid.MultiSelect = false;
            this.logGrid.Name = "logGrid";
            this.logGrid.RowTemplate.Height = 24;
            this.logGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.logGrid.Size = new System.Drawing.Size(734, 311);
            this.logGrid.TabIndex = 0;
            this.logGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logGrid_CellClick);
            // 
            // sessionInfoGroupBox
            // 
            this.sessionInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sessionInfoGroupBox.Controls.Add(this.noTopicsPictureBox);
            this.sessionInfoGroupBox.Controls.Add(this.addTopicButton);
            this.sessionInfoGroupBox.Controls.Add(this.addTutorButton);
            this.sessionInfoGroupBox.Controls.Add(this.logSessionBtn);
            this.sessionInfoGroupBox.Controls.Add(this.topicsLabel);
            this.sessionInfoGroupBox.Controls.Add(this.tutorNameLabel);
            this.sessionInfoGroupBox.Controls.Add(this.topicsListBox);
            this.sessionInfoGroupBox.Controls.Add(this.tutorComboBox);
            this.sessionInfoGroupBox.Location = new System.Drawing.Point(774, 11);
            this.sessionInfoGroupBox.Name = "sessionInfoGroupBox";
            this.sessionInfoGroupBox.Size = new System.Drawing.Size(483, 394);
            this.sessionInfoGroupBox.TabIndex = 3;
            this.sessionInfoGroupBox.TabStop = false;
            this.sessionInfoGroupBox.Text = "Session Info";
            // 
            // noTopicsPictureBox
            // 
            this.noTopicsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.noTopicsPictureBox.Location = new System.Drawing.Point(64, 85);
            this.noTopicsPictureBox.Name = "noTopicsPictureBox";
            this.noTopicsPictureBox.Size = new System.Drawing.Size(21, 17);
            this.noTopicsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.noTopicsPictureBox.TabIndex = 7;
            this.noTopicsPictureBox.TabStop = false;
            this.noTopicsPictureBox.Visible = false;
            // 
            // addTopicButton
            // 
            this.addTopicButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addTopicButton.Location = new System.Drawing.Point(336, 106);
            this.addTopicButton.Name = "addTopicButton";
            this.addTopicButton.Size = new System.Drawing.Size(141, 23);
            this.addTopicButton.TabIndex = 5;
            this.addTopicButton.Text = "Add Topic";
            this.addTopicButton.UseVisualStyleBackColor = true;
            this.addTopicButton.Click += new System.EventHandler(this.addTopicButton_Click);
            // 
            // addTutorButton
            // 
            this.addTutorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addTutorButton.Location = new System.Drawing.Point(336, 41);
            this.addTutorButton.Name = "addTutorButton";
            this.addTutorButton.Size = new System.Drawing.Size(141, 24);
            this.addTutorButton.TabIndex = 1;
            this.addTutorButton.Text = "Add Tutor";
            this.addTutorButton.UseVisualStyleBackColor = true;
            this.addTutorButton.Click += new System.EventHandler(this.addTutorButton_Click);
            // 
            // logSessionBtn
            // 
            this.logSessionBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logSessionBtn.Location = new System.Drawing.Point(188, 350);
            this.logSessionBtn.Name = "logSessionBtn";
            this.logSessionBtn.Size = new System.Drawing.Size(115, 29);
            this.logSessionBtn.TabIndex = 4;
            this.logSessionBtn.Text = "Log Session";
            this.logSessionBtn.UseVisualStyleBackColor = true;
            this.logSessionBtn.Click += new System.EventHandler(this.logSessionBtn_Click);
            // 
            // topicsLabel
            // 
            this.topicsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topicsLabel.AutoSize = true;
            this.topicsLabel.Location = new System.Drawing.Point(7, 85);
            this.topicsLabel.Name = "topicsLabel";
            this.topicsLabel.Size = new System.Drawing.Size(50, 17);
            this.topicsLabel.TabIndex = 3;
            this.topicsLabel.Text = "Topics";
            // 
            // tutorNameLabel
            // 
            this.tutorNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tutorNameLabel.AutoSize = true;
            this.tutorNameLabel.Location = new System.Drawing.Point(7, 21);
            this.tutorNameLabel.Name = "tutorNameLabel";
            this.tutorNameLabel.Size = new System.Drawing.Size(42, 17);
            this.tutorNameLabel.TabIndex = 2;
            this.tutorNameLabel.Text = "Tutor";
            // 
            // topicsListBox
            // 
            this.topicsListBox.FormattingEnabled = true;
            this.topicsListBox.ItemHeight = 16;
            this.topicsListBox.Location = new System.Drawing.Point(6, 105);
            this.topicsListBox.Name = "topicsListBox";
            this.topicsListBox.Size = new System.Drawing.Size(297, 212);
            this.topicsListBox.TabIndex = 1;
            // 
            // tutorComboBox
            // 
            this.tutorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tutorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tutorComboBox.FormattingEnabled = true;
            this.tutorComboBox.Location = new System.Drawing.Point(6, 41);
            this.tutorComboBox.Name = "tutorComboBox";
            this.tutorComboBox.Size = new System.Drawing.Size(297, 24);
            this.tutorComboBox.TabIndex = 0;
            // 
            // logEditTab
            // 
            this.logEditTab.Location = new System.Drawing.Point(4, 25);
            this.logEditTab.Name = "logEditTab";
            this.logEditTab.Padding = new System.Windows.Forms.Padding(3);
            this.logEditTab.Size = new System.Drawing.Size(1263, 411);
            this.logEditTab.TabIndex = 3;
            this.logEditTab.Text = "Edit";
            this.logEditTab.UseVisualStyleBackColor = true;
            // 
            // reportsTabPage
            // 
            this.reportsTabPage.Location = new System.Drawing.Point(4, 25);
            this.reportsTabPage.Name = "reportsTabPage";
            this.reportsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.reportsTabPage.Size = new System.Drawing.Size(1263, 411);
            this.reportsTabPage.TabIndex = 1;
            this.reportsTabPage.Text = "Report";
            this.reportsTabPage.UseVisualStyleBackColor = true;
            // 
            // adminTabPage
            // 
            this.adminTabPage.Location = new System.Drawing.Point(4, 25);
            this.adminTabPage.Name = "adminTabPage";
            this.adminTabPage.Size = new System.Drawing.Size(1263, 411);
            this.adminTabPage.TabIndex = 2;
            this.adminTabPage.Text = "Admin";
            this.adminTabPage.UseVisualStyleBackColor = true;
            // 
            // getSignInDataWorker
            // 
            this.getSignInDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getSignInDataWorker_DoWork);
            this.getSignInDataWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getSignInDataWorker_RunWorkerCompleted);
            // 
            // TutorLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1295, 464);
            this.Controls.Add(this.logTabs);
            this.Name = "TutorLogForm";
            this.Text = "Tutoring Log";
            this.logTabs.ResumeLayout(false);
            this.logDataTabPage.ResumeLayout(false);
            this.logDataTabPage.PerformLayout();
            this.recordsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            this.sessionInfoGroupBox.ResumeLayout(false);
            this.sessionInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noTopicsPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl logTabs;
        private System.Windows.Forms.TabPage logDataTabPage;
        private System.Windows.Forms.TabPage reportsTabPage;
        private System.Windows.Forms.TabPage adminTabPage;
        private System.Windows.Forms.TabPage logEditTab;
        private System.Windows.Forms.GroupBox recordsGroupBox;
        private System.Windows.Forms.DataGridView logGrid;
        private System.Windows.Forms.GroupBox sessionInfoGroupBox;
        private System.Windows.Forms.Button logSessionBtn;
        private System.Windows.Forms.Label topicsLabel;
        private System.Windows.Forms.Label tutorNameLabel;
        private System.Windows.Forms.ListBox topicsListBox;
        private System.Windows.Forms.ComboBox tutorComboBox;
        private System.Windows.Forms.Button addTopicButton;
        private System.Windows.Forms.Button addTutorButton;
        private System.ComponentModel.BackgroundWorker getSignInDataWorker;
        private System.Windows.Forms.Label sessionCampusLabel;
        private System.Windows.Forms.PictureBox noTopicsPictureBox;
        private System.Windows.Forms.ToolTip tutorLogFormToolTip;
    }
}