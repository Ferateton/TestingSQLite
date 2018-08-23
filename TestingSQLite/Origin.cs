using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TestingSQLite
{
    class Origin
    {
        SQLiteConnection m_dbConnection;
        SQLiteCommand sqlcmd;
        SQLiteDataReader sqlread;
        public Form1 formone;


        public void createNewDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

        // Creates a connection with our database file.
        public void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
        }
    }
}
