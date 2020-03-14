using System.Windows.Forms;

namespace TutorLog.Handlers.Errors
{
    public interface IErrorHandler
    {
        void ShowErrorDialog(string title, string message, MessageBoxIcon type = MessageBoxIcon.Error);
    }
}
