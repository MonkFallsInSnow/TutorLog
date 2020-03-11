using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Web;
using System.Windows.Forms;
using TutorLog.Data.Models;
using TutorLog.Handlers.Database;
using TutorLog.Handlers.Errors;
using TutorLog.Handlers.Requests;

namespace TutorLog
{
    public partial class LoginForm : Form
    {
        private NameValueCollection loginData;
        private IRequestHandler<string, NameValueCollection> requestHandler;
        private IDataHandler dataHandler;
        private IErrorHandler errorHandler;

        public string SessionCookie { get; private set; }
        public Campus SessionCampus { get; private set; }

        public LoginForm(IRequestHandler<string, NameValueCollection> requestHandler, IDataHandler dataHandler, IErrorHandler errorHandler)
        {
            InitializeComponent();

            this.requestHandler = requestHandler;
            this.dataHandler = dataHandler;
            this.errorHandler = errorHandler;

            loginData = HttpUtility.ParseQueryString(String.Empty);

            BindingList<Campus> campuses = (BindingList<Campus>)this.dataHandler.GetCampuses();
            BindingSource source = new BindingSource(campuses, null);
            campusComboBox.DataSource = source;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            loginData.Add("username", usernameTextbox.Text);
            loginData.Add("password", passwordTextbox.Text);
            loginData.Add("submit", Constants.LoginToken);

            string response = this.requestHandler.MakeRequest(Constants.LoginURL, loginData);

            if(!string.IsNullOrEmpty(response))
            {
                this.DialogResult = DialogResult.OK;
                this.SessionCookie = response;
                this.SessionCampus = ((Campus)campusComboBox.Items[campusComboBox.SelectedIndex]);
            }
        }

    }
}