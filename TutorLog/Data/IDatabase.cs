using System;
using System.Data.SQLite;

namespace TutorLog
{
    public interface IDatabase : IDisposable
    {
        SQLiteConnection Connection { get; }
    }
}
