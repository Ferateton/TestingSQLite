using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace TestingSQLite
{
     class Database
    {
        
        SQLiteCommand sqlcmd;
        SQLiteDataReader sqlread;
       

        public Database()
        {
            createNewDatabase();
            
            
        }
        
        public void createNewDatabase()
        {
            if (!File.Exists("MyDatabase.sqlite"))
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }
        public SQLiteConnection getConnection()
        {
            return new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        }

        
        public void fillTable()
        {
            SQLiteConnection m_dbConnection = getConnection();
            m_dbConnection.Open();
            string sql = "insert into highscores (name, score) values (1, 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values (2, 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values (3, 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            

        }

        public int Count(string col, string table)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            int number;
            string str_number  = "";
            string sql = "SELECT COUNT("+ col +") AS Numbers FROM "+table;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                str_number = read[0].ToString();   
            }
            number = Convert.ToInt32(str_number);
            return number+1;
            
            m_dbConnection.Close();
        }
        public int CountID(string col, string table,string where)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            int number;
            string str_number = "";
            string sql = "SELECT COUNT(" + col + ") AS Numbers FROM " + table+" where Name = '"+where+"'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                str_number = read[0].ToString();
            }
            number = Convert.ToInt32(str_number);
            return number + 1;

            
        }

        public String Worker( int i)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            string sql = "select * from Worker";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            List<string> worker = new List<string>();
            while (read.Read())
            {
                worker.Add(read["Name"].ToString());
            }
            return worker[i];
            m_dbConnection.Close();
        }
        public String FillcomboB(int i,string from,string where)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            string sql = "select * from "+from;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            List<string> send = new List<string>();
            while (read.Read())
            {
                send.Add(read[where].ToString());
            }
            return send[i];
            m_dbConnection.Close();
        }
        public String GetWorkerID(string Name, int i)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            string sql = "select * from Worker where Name='"+Name+"'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            List<string> worker = new List<string>();
            while (read.Read())
            {
                worker.Add(read["ID"].ToString());
            }
            return worker[i];
            m_dbConnection.Close();
        }
        public void insertBandScene(string LScene, string SceneID, string Name)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();

            string sql = "INSERT INTO Scene (LocationScene, SceneID, Security) values ('" + LScene + "', '" + SceneID + "','" + Name + "');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
        public void insertScedual(string Date, string Scene, string Time, string Band)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();

            string sql = "INSERT INTO Scedual (Date, Scene, Time, Band) values ('" + Date + "', '" + Scene + "','" + Time + "','" + Band + "');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        } 
        public void insertBand(string band,string music,string origin,string manager)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();

            string sql = "INSERT INTO Band (BandName, MusicStyle, Origin, Manager, BandID) values ('"+ band+ "', '" + music + "','"+ origin +"','"+ manager +"',"+ Count("bandName","Band") +");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
        public void insertWorker(string Name, int ID)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();

            string sql = "INSERT INTO Worker (Name, ID, Manager) values ('" +Name+"',"+ID+",'Yes');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
        public void insertManager(string Name, int ID, string Band)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();

            string sql = "INSERT INTO Manager (Name, ID, Band) values ('" + Name + "'," + ID + ",'" + Band + "');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
        public void UpdateWorker(string Name, int ID)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();

            string sql = "UPDATE Worker SET Name ='" + Name + "', ID = " + ID + ", Manager = 'Yes' WHERE Name ='" + Name + "'," + ID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
        public void printHighscores()
        {
            SQLiteConnection m_dbConnection = getConnection();
            m_dbConnection.Open();
            string sql = "select * from highscores,Band";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader["Bandname"].ToString()+ reader["Score"].ToString());
            }
            m_dbConnection.Close();

        }
        public String[] Member(string name, int i)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            string sql = "select * from Member  Where Name = '"+ name +"' ";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            List<string[]> back = new List<string[]>();
            while (read.Read())
            {
                back.Add(new string[] { read[0].ToString(), read[2].ToString(), read[3].ToString() });
            }
            return back[i];
            m_dbConnection.Close();
        }
        public String[] Scene(string scene,int i)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            string sql = "select * from Scedual Where Scene = '" + scene+"'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            List<string[]> sCene = new List<string[]>();
            while (read.Read())
            {
                sCene.Add(new string[] { read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString() });
            }
            return sCene[i];
            m_dbConnection.Close();
        }
        public String[] Playing(string band, int i)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            string sql = "select * from Scedual Where Band = '" + band+"'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            List<string[]> sCedual = new List<string[]>();
            while (read.Read())
            {
                sCedual.Add(new string[] { read[0].ToString(), read[1].ToString(), read[2].ToString() });
            }
            return sCedual[i];
            m_dbConnection.Close();
        }
        public String[] Band(string bandN, int i)
        {
            SQLiteConnection m_dbConnection = getConnection();

            m_dbConnection.Open();
            string sql = "select * from Member, Band  where Band.BandName = Member.BandName and Band.BandName =  '" + bandN + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();
            List<string[]> band = new List<string[]>();
            while (read.Read())
            {
                band.Add(new string[] { read["Name"].ToString(), read["Origin"].ToString(), read["MusicStyle"].ToString(), read["BandName"].ToString() });
            }
            return band[i];
            m_dbConnection.Close();
        }
        public DataView LoadTable() 
        {
            try
            {
                SQLiteConnection m_dbConnection = getConnection();
                m_dbConnection.Open();
                string sql = "select * from Band;";
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, m_dbConnection);
                da.Fill(ds);
                m_dbConnection.Close();
                return ds.Tables[0].DefaultView;
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
