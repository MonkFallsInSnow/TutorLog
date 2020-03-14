using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using TutorLog.Handlers.Database;
using TutorLog.Data.Models;
using System.Collections.Generic;
using TutorLog.Handlers.Errors;

namespace TutorLog
{
    public partial class TutorLogForm : Form
    {
        private struct WorkerResult
        {
            public readonly BindingList<SignInData> SignInData;
            public readonly int SelectedRowIndex;

            public WorkerResult(BindingList<SignInData> data, int index)
            {
                this.SignInData = data;
                this.SelectedRowIndex = index;
            }
        }

        private IDataHandler dataHandler;
        private IErrorHandler errorHandler;
        private Timer eventTimer;

        public static int UnloggedSessionCount { get; private set; }
        public string SessionCookie { get; private set; }
        public Campus SessionCampus { get; private set; }

        public TutorLogForm(IDataHandler dataHandler, IErrorHandler errorHandler, string sessionCookie, Campus sessionCampus)
        {
            InitializeComponent();

            this.errorHandler = errorHandler;

            this.SessionCookie = sessionCookie;
            this.SessionCampus = sessionCampus;
            sessionCampusLabel.Text = this.SessionCampus.Name;

            BindingSource source;
            this.dataHandler = dataHandler;

            BindingList<SignInData> signInData = (BindingList<SignInData>)dataHandler.GetSignInData(sessionCookie, sessionCampus);
            BindingList<Tutor> tutors = (BindingList<Tutor>)dataHandler.GetTutors(this.SessionCampus.ID);

            source = new BindingSource(signInData, null);
            logGrid.DataSource = source;

            source = new BindingSource(tutors, null);
            tutorComboBox.DataSource = source;

            eventTimer = new Timer();
            eventTimer.Interval = Constants.DataRequestInterval;
            eventTimer.Tick += GetSignInData;
            eventTimer.Start();
        }

        private void GetSignInData(Object obj, EventArgs e)
        {
            eventTimer.Stop();
            getSignInDataWorker.RunWorkerAsync();
        }

        private void getSignInDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = new WorkerResult(
                (BindingList<SignInData>)dataHandler.GetSignInData(this.SessionCookie, this.SessionCampus),
                logGrid.CurrentRow.Index
            );
        }

        private void getSignInDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UnloggedSessionCount = 0;

            if (e.Result != null)
            {
                WorkerResult result = (WorkerResult)e.Result;

                List<SignInData> loggedRecords = ((System.Collections.IList)logGrid.DataSource).OfType<SignInData>()
                    .Where(d => d.IsLogged)
                    .ToList();

                foreach (var datum in result.SignInData)
                {
                    if (!((BindingSource)logGrid.DataSource).Contains(datum))
                    {
                        ((BindingSource)logGrid.DataSource).Add(datum);
                    }
                }

                foreach (var row in logGrid.Rows)
                {
                    SignInData rowElement = (SignInData)((DataGridViewRow)row).DataBoundItem;
                    if (!result.SignInData.Contains(rowElement) && rowElement.IsLogged)
                    {
                        logGrid.Rows.Remove((DataGridViewRow)row);
                    }
                }

                logGrid.Refresh();

                if (result.SelectedRowIndex < logGrid.Rows.Count)
                {
                    logGrid.Rows[result.SelectedRowIndex].Selected = true;
                }
            }

            foreach(var row in logGrid.Rows)
            {
                if(((SignInData)row).IsLogged == false)
                {
                    UnloggedSessionCount++;
                }
            }

            eventTimer.Start();
        }

        //TODO: test logging session
        private void logSessionBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (topicsListBox.SelectedIndices.Count > 0)
            {
                DialogResult confirmation = MessageBox.Show(
                    "Are you sure you want to log this session?",
                    "Log Session",
                    MessageBoxButtons.YesNo
                );

                if (confirmation == DialogResult.Yes)
                {
                    SignInData data = (SignInData)logGrid.CurrentRow.DataBoundItem;
                    List<Topic> topics = new List<Topic>();

                    foreach (var item in topicsListBox.SelectedItems)
                    {
                        Topic topic = (Topic)item;
                        topics.Add(topic);
                    }

                    LogEntry logEntry = new LogEntry(
                        this.dataHandler.GetCenterID(data.Center),
                        this.SessionCampus.ID,
                        data.StudentID,
                        data.StudentName.Split(',')[0],
                        data.StudentName.Split(',')[1],
                        this.dataHandler.GetCourseID(data.Course),
                        ((Tutor)tutorComboBox.SelectedValue).ID
                    );

                    bool isLogged = this.dataHandler.InsertLogEntry(logEntry, topics);

                    if (isLogged)
                    {
                        ((SignInData)logGrid.CurrentRow.DataBoundItem).IsLogged = true;
                    }
                    else
                    {
                        this.errorHandler.ShowErrorDialog("Logging Error", "Unable to log session.");
                    }
                }

                this.Enabled = true;
            }
        }

        private void logGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.CurrentRow.Selected)
            {
                SignInData data = (SignInData)dgv.CurrentRow.DataBoundItem;
                int currentCourseID = this.dataHandler.GetCourseID(data.Course);

                if (currentCourseID > 0)
                {
                    noTopicsPictureBox.Visible = false;

                    BindingList<Topic> topics = (BindingList<Topic>)dataHandler.GetTopics(this.SessionCampus.ID, currentCourseID);
                    BindingSource source = new BindingSource(topics, null);
                    topicsListBox.DataSource = source;
                }
                else
                {
                    topicsListBox.DataSource = null;

                    noTopicsPictureBox.Image = System.Drawing.SystemIcons.Warning.ToBitmap();
                    tutorLogFormToolTip.SetToolTip(noTopicsPictureBox, "There are no topics associated with the selected course");
                    noTopicsPictureBox.Visible = true;
                }
            }
        }

        //TODO: finish add tutor button click event
        private void addTutorButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            AddTutorForm addTutorForm = new AddTutorForm();

            if (addTutorForm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        //TODO: finish add topic button click event
        private void addTopicButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            AddTopicForm addTopicForm = new AddTopicForm();

            if (addTopicForm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        //TODO: insert unlogged sessions into a backup table in the database
        private void TutorLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(UnloggedSessionCount > 0)
            {
                this.errorHandler.ShowErrorDialog(
                    "Warning!", 
                    "Not all sessions have been logged. The affected items will be saved, appearing the next time the application is started.",
                    MessageBoxIcon.Warning
                 );
            }
        }
    }
}
