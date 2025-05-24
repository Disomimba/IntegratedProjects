using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ShuffledWordGameDL
{
    public class InDataBase : IDataLogic
    {
        static string connectionString = "Data Source =DESKTOP-SQLEXPRESS; Initial Catalog = GameDB ; Integrated Security=true;TrustServerCertificate=True;";
        static SqlConnection sqlConnection;
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<Leaderboards> leaderboards = new List<Leaderboards>();
        public InDataBase()
        {
            sqlConnection = new SqlConnection(connectionString);
            GetDataFromDB();
        }
        private void GetDataFromDB()
        {
            sqlConnection.Open();
            string select = "Select * from GameAccounts";
            SqlCommand selectCommand = new SqlCommand(select, sqlConnection);
            SqlDataReader reader = selectCommand.ExecuteReader();

            var accounts = new List<GameAccounts>();
            while (reader.Read())
            {
                account.Add(new GameAccounts
                {
                    Name = reader["Name"].ToString(),
                    Username = reader["Username"].ToString(),
                    Password = reader["Password"].ToString()
                });
            }
            sqlConnection.Close();
        }
        public List<GameAccounts> Accounts()
        {
            return account;
        }

        public void AddScoreList(string username, int score, int error)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string username, string old_password, string new_password)
        {
            throw new NotImplementedException();
        }

        public void ClearLeaderboard()
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(string name, string username, string password)
        {
            string insert = "Insert into GameAccounts (Name, Username, Password) values (@name, @username, @password)";
            sqlConnection.Open();
            SqlCommand insertCommand = new SqlCommand(insert, sqlConnection);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public string DisplayLeaderboard()
        {
            throw new NotImplementedException();
        }

        public string DisplayPlayerHistory(string username)
        {
            throw new NotImplementedException();
        }

        public string GetPlayerName(string username)
        {
            throw new NotImplementedException();
        }

        public string GetPlayerUsername(string name)
        {
            throw new NotImplementedException();
        }
    }
}
