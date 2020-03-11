using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLog.Handlers.Errors
{
    public interface IErrorHandler
    {
        void ShowErrorDialog(string title, string message);
    }
}
