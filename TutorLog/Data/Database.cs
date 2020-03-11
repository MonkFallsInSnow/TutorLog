using System;
using System.Data.SQLite;
using TutorLog.Handlers;
using TutorLog.Handlers.Errors;

namespace TutorLog.Data
{
    class Database : IDatabase
    {
        private SQLiteConnection connection;
        private string databaseName;
        private IErrorHandler errorHandler;

        public SQLiteConnection Connection
        {
            get
            {
                if(this.connection == null)
                {
                    string dbPath = System.IO.Path.Combine(Environment.CurrentDirectory, databaseName);
                    string connectionString = string.Format("Data Source={0}", dbPath);
                    connection = new SQLiteConnection(connectionString);
                }

                return connection;
            }
        }


        public Database(string databaseName, IErrorHandler errorHandler)
        {
            this.databaseName = databaseName;
            this.errorHandler = errorHandler;

            if (!System.IO.File.Exists(databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
                this.CreateTables();
            }  
        }

        private void CreateTables()
        {
            using (this.connection)
            {
                this.connection.Open();

                try
                {
                    SQLiteCommand command = new SQLiteCommand(this.Connection);
                    command.CommandText = System.IO.File.ReadAllText(@"../../Data/SQL/createTables.sql");
                    command.ExecuteNonQuery();
                }
                catch (System.IO.FileNotFoundException)
                {
                    this.errorHandler.ShowErrorDialog("Failed to create database tables.", "Database Error");
                }
            }
        }

        public void Dispose()
        {
            if(this.connection != null)
                this.connection.Dispose();
        }
    }
}
