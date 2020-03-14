using System.Windows.Forms;

namespace TutorLog.Handlers.Errors
{
    public class ErrorHandler : IErrorHandler
    {
        public void ShowErrorDialog(string title, string message, MessageBoxIcon type = MessageBoxIcon.Error)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                type
            );
        }
    }
}
