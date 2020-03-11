using System.Collections.Generic;

namespace TutorLog.Handlers.Database
{
    public interface IDatabaseCommand<T>
    {
        T Execute();
    }
}