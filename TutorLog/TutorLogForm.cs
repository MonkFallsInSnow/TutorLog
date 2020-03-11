using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using TutorLog.Handlers.Database;
using TutorLog.Data.Models;
using System.Collections.Generic;

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
        private Timer eventTimer;

        public string SessionCookie { get; private set; }
        public Campus SessionCampus { get; private set; }

        public TutorLogForm(IDataHandler dataHandler, string sessionCookie, Campus sessionCampus)
        {
            InitializeComponent();

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

                if(result.SelectedRowIndex < logGrid.Rows.Count)
                {
                    logGrid.Rows[result.SelectedRowIndex].Selected = true;
                }
            }

            eventTimer.Start();
        }

        private void logSessionBtn_Click(object sender, EventArgs e)
        {
            if(topicsListBox.SelectedIndices.Count > 0)
            {
                SignInData data = (SignInData)logGrid.CurrentRow.DataBoundItem;
                List<Topic> topics = new List<Topic>();
                
                foreach(var item in topicsListBox.SelectedItems)
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

                ((SignInData)logGrid.CurrentRow.DataBoundItem).IsLogged = true;
            }
            

            //TODO: send data to the database
        }

        private void logGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if(dgv.CurrentRow.Selected)
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

        private void addTutorButton_Click(object sender, EventArgs e)
        {

        }

        private void addTopicButton_Click(object sender, EventArgs e)
        {

        }
    }
}
