using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using TutorLog.Data;
using TutorLog.Handlers.Database;
using TutorLog.Handlers.Errors;
using TutorLog.Handlers.Requests;

namespace TutorLog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IErrorHandler errorHandler = new ErrorHandler();
            IRequestHandler<string, NameValueCollection> loginRequestHandler = new LoginRequest(errorHandler);
            IRequestHandler<BindingList<SignInData>, RecordRequestData> dataRequestHandler = new RecordRequest(errorHandler);

            using (IDatabase database = new Database("database.sqlite", errorHandler))
            using (database.Connection)
            {
                database.Connection.Open();

                IDataHandler dataHandler = new DataHandler(database.Connection, dataRequestHandler);
                LoginForm loginForm = new LoginForm(loginRequestHandler, dataHandler, errorHandler);

                DialogResult result = loginForm.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else if(result == DialogResult.OK)
                {
                    loginForm.Close();
                    TutorLogForm tutorLogForm = new TutorLogForm(dataHandler, errorHandler, loginForm.SessionCookie, loginForm.SessionCampus);
                    Application.Run(tutorLogForm);
                         
                }
                else
                {
                    loginForm.Refresh();
                }
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
