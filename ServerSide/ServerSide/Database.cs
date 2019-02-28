using MySql.Data.MySqlClient;
using System;

namespace ServerSide
{

    class Database
    {
        private MySqlConnection DB_Connection;
        private string Host_Name;
        private string Port;
        private string User_Name;
        private string Password;
        private string Database_Name;

        public Database()
        {           
        }


        public void init()
        {
            Host_Name = "localhost";
            Port = "3306";
            User_Name = "root";
            Password = "";
            Database_Name = "RFIDUIDs";

            string connectionString;
            connectionString = "SERVER=" + Host_Name + ";" + "DATABASE=" +
            Database_Name + ";" + "UID=" + User_Name + ";" + "PASSWORD=" + Password + ";";

            DB_Connection = new MySqlConnection(connectionString);
        }

        public bool Connect_Database()
        {
            Console.WriteLine("Attempting to Connect to Database!");
            try
            {
                DB_Connection.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Database Connected");
                Console.WriteLine();
                return true;
            }
            catch (MySqlException) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Cannot Open Connection"); return false; }
        }

        public bool Disconnect_Database()
        {
            Console.WriteLine("Attempting to Disconnect from Database!");
            try
            {
                DB_Connection.Close();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Connection Closed");
                return true;
            }
            catch (MySqlException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Problem Closing Connection");
                return false;
            }
        }

        public void Insert_Query(string uid, string name_on_card)
        {
            string query = "INSERT INTO rids (id, uid_value, name_on_card) VALUES(NULL, '"+uid+"', '"+name_on_card+"')";
            if (this.Connect_Database() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, DB_Connection);
                cmd.ExecuteNonQuery();
                this.Disconnect_Database();
            }
        }

        public void Delete_Query()
        {
            string query = "DELETE FROM rids WHERE id=1";
            if (this.Connect_Database() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, DB_Connection);
                cmd.ExecuteNonQuery();
                this.Disconnect_Database();
            }
        }

    }
}
