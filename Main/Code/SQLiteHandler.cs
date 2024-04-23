using System;
using System.Data;
using System.Data.SQLite;
using System.IO;


namespace Main.Libraries
{

    public class SQLiteHandler
    {
        private string connectionString;
        public SQLiteConnection connection;


        public SQLiteHandler()
        {
            connectionString = @"Data Source=" + GetDatabasePath() + ";Version=3;";
            connection = new SQLiteConnection(connectionString);
            Console.WriteLine("Connected");
        }

        private string GetDatabasePath()
        {
            // Get the base directory of the current application domain
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Combine the base directory with the "Data" folder and the filename "Database.db"
            string databasePath = Path.Combine(baseDirectory, "Data", "sqliteDatabase.db");
            return databasePath;
        }

        public DataTable GetDatatableFromSQLite(string tableName)
        {
            connection.Open();
            string commandString = ($"SELECT * FROM {tableName}");
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();
            return dataTable;


        }





    }
}
