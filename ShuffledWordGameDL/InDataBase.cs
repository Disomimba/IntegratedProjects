using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ShuffledWordGameDL
{
    public class InDataBase : IDataLogic
    {
        static string connectionString = "Data Source =Disomimba\\SQLEXPRESS; Initial Catalog = DB_Game ; Integrated Security=true;TrustServerCertificate=True;";
        static SqlConnection sqlConnection;
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<
        Leaderboards> leaderboards = new List<Leaderboards>();
        public List<AdminData> admin = new List<AdminData>();
        public InDataBase()
        {
            sqlConnection = new SqlConnection(connectionString);
            GetDataFromDB();
        }
        public void StoreLeaderboards()
        {
            sqlConnection.Open();
            string delete = "Delete From tbl_leaderboards";
            SqlCommand deleteCommand = new SqlCommand(delete, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            foreach (var leaderboard in leaderboards)
            {
                string insert = "Insert into tbl_leaderboards (Username, Score) values (@username, @score)";
                SqlCommand insertCommand = new SqlCommand(insert, sqlConnection);
                insertCommand.Parameters.AddWithValue("@username", leaderboard.Username);
                insertCommand.Parameters.AddWithValue("@score", leaderboard.Score);
                insertCommand.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }
        private void GetDataFromDB()
        {
            GameAccountsFromDB();
            ScoresErrorHistoryFromDB();
            AdminDataFromDB();
            GetWordsFromDB();
            GetLeaderboardFromDB();
        }
        public void GameAccountsFromDB()
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
                    Email = reader["Email"].ToString(),
                    Username = reader["Username"].ToString(),
                    Password = reader["Password"].ToString()
                });
            }
            sqlConnection.Close();
        }
        public void ScoresErrorHistoryFromDB()
        {
            sqlConnection.Open();
            string selectScores = "SELECT * FROM tbl_scores";
            SqlCommand selectScoresCommand = new SqlCommand(selectScores, sqlConnection);
            SqlDataReader scoresReader = selectScoresCommand.ExecuteReader();
            while (scoresReader.Read())
            {
                string username = scoresReader["Username"].ToString();
                int score = Convert.ToInt32(scoresReader["Score"]);
                int error = Convert.ToInt32(scoresReader["Error"]);
                int index = FindPlayerIndex(username);
                if (index != -1)
                {
                    account[index].Score.Add(score);
                    account[index].History.Add($"Score : {score} | Error : {error}\n");
                }
            }
            sqlConnection.Close();
        }
        public void AdminDataFromDB()
        {

            sqlConnection.Open();
            string selectAdmin = "Select Username, Password from tbl_admin";
            SqlCommand selectCommand = new SqlCommand(selectAdmin, sqlConnection);
            SqlDataReader reader = selectCommand.ExecuteReader();


            var adminData = new List<AdminData>();
            while (reader.Read())
            {
                admin.Add(new AdminData
                {
                    Username = reader["Username"].ToString(),
                    Password = reader["Password"].ToString()
                });
            }


            sqlConnection.Close();
        }
        public void GetWordsFromDB()
        {
            sqlConnection.Open();
            string selectWords = "Select Words from tbl_words";
            SqlCommand selectCommand = new SqlCommand(selectWords, sqlConnection);
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                admin[0].ArrangedWord.Add(reader["Words"].ToString());

            }
            sqlConnection.Close();
        }
        public void GetLeaderboardFromDB()
        {
            sqlConnection.Open();
            string selectLeaderboards = "Select Username, Score from tbl_leaderboards";
            SqlCommand selectCommand = new SqlCommand(selectLeaderboards, sqlConnection);
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                leaderboards.Add(new Leaderboards
                {
                    Username = reader["Username"].ToString(),
                    Score = Convert.ToInt32(reader["Score"])
                });
            }
            sqlConnection.Close();
        }
        public bool RemoveWord(int index)
        {
            string word = admin[0].ArrangedWord[index];

            if (admin[0].ArrangedWord.Contains(word))
            {
                sqlConnection.Open();
                string removeWord = "Delete From tbl_words where Words = @Words";
                SqlCommand removeCommand = new SqlCommand(removeWord, sqlConnection);
                removeCommand.Parameters.AddWithValue("@Words", word);
                removeCommand.ExecuteNonQuery();
                sqlConnection.Close();
                admin[0].ArrangedWord.RemoveAt(index);
                admin[0].ShuffledWord.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<GameAccounts> GetPlayerAccounts()
        {
            return account;
        }
        public int FindPlayerIndex(string username)
        {
            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    return account.IndexOf(accounts);
                }
            }
            return -1;
        }
        public void AddScoreList(string username, int score, int error)
        {
            sqlConnection.Open();
            string insertScore = "INSERT INTO tbl_scores (Username, Score, Error) VALUES (@username, @score, @error)";
            SqlCommand insertCommand = new SqlCommand(insertScore, sqlConnection);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@score", score);
            insertCommand.Parameters.AddWithValue("@error", error);
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
            int index = FindPlayerIndex(username);
            account[index].Score.Add(score);
            AddHistory(username, score, error);
        }
        public void AddHistory(string username, int score, int error)
        {
            sqlConnection.Open();
            string insertHistory = "INSERT INTO tbl_history (Username, History) VALUES (@username, @history)";
            SqlCommand insertCommand = new SqlCommand(insertHistory, sqlConnection);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@history", $"Score : {score} | Error : {error}");
            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
            int index = FindPlayerIndex(username);
            account[index].History.Add($"Score : {score} | Error : {error}");
        }
        public bool ChangePassword(string username, string old_password, string new_password)
        {
            sqlConnection.Open();
            string select = "Select * from GameAccounts where Username = @username and Password = @old_password";
            SqlCommand selectCommand = new SqlCommand(select, sqlConnection);
            selectCommand.Parameters.AddWithValue("@username", username);
            selectCommand.Parameters.AddWithValue("@old_password", old_password);
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                string update = "Update GameAccounts set Password = @new_password where Username = @username";
                SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
                updateCommand.Parameters.AddWithValue("@new_password", new_password);
                updateCommand.Parameters.AddWithValue("@username", username);
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            else
            {
                reader.Close();
                sqlConnection.Close();
                return false;
            }
        }
        public void ClearLeaderboard()
        {
            leaderboards.Clear();
            foreach (var accounts in account)
            {
                accounts.Score.Clear();
                accounts.History.Clear();
            }
            sqlConnection.Open();
            string deleteLeaderboards = "Delete From tbl_leaderboards";
            SqlCommand deleteCommand = new SqlCommand(deleteLeaderboards, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            string deleteScores = "Delete From tbl_scores";
            SqlCommand deleteScoresCommand = new SqlCommand(deleteScores, sqlConnection);
            deleteScoresCommand.ExecuteNonQuery();
            string deleteHistory = "Delete From tbl_history";
            SqlCommand deleteHistoryCommand = new SqlCommand(deleteHistory, sqlConnection);
            deleteHistoryCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void CreateAccount(string name, string userEmail, string username, string password)
        {
            string insert = "Insert into GameAccounts (Name, Email, Username, Password) values (@name, @email, @username, @password)";
            sqlConnection.Open();
            SqlCommand insertCommand = new SqlCommand(insert, sqlConnection);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@email", userEmail);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
            GetDataFromDB();
        }
        public List<Leaderboards> GetLeaderboardAccounts()
        {
            return leaderboards;
        }
        public bool ChangeAdminPassword(string oldPassword, string newPassword)
        {
            sqlConnection.Open();
            string select = "Select * from tbl_admin where Username = 'ADMIN' and Password = @old_password";
            SqlCommand selectCommand = new SqlCommand(select, sqlConnection);
            selectCommand.Parameters.AddWithValue("@old_password", oldPassword);
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                string update = "Update tbl_admin set Password = @new_password where Username = 'ADMIN'";
                SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
                updateCommand.Parameters.AddWithValue("@new_password", newPassword);
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
                admin[0].Password = newPassword;
                return true;
            }
            else
            {
                reader.Close();
                sqlConnection.Close();
                return false;
            }
        }
        public List<AdminData> GetAdminAccounts()
        {
            return admin;
        }
        public bool InsertNewWords(string arrangedWord)
        {
            if (!admin[0].ArrangedWord.Contains(arrangedWord))
            {
                sqlConnection.Open();
                string insert = "Insert into tbl_words (Words)  Values(@arrangedWord)";
                SqlCommand insertCommand = new SqlCommand(insert, sqlConnection);
                insertCommand.Parameters.AddWithValue("@arrangedWord", arrangedWord);
                insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
                admin[0].ArrangedWord.Add(arrangedWord);
                return true;
            }
            return false;
        }
        public bool InsertShuffledWord(string shuffledWord)
        {
            if (!admin[0].ShuffledWord.Contains(shuffledWord))
            {
                admin[0].ShuffledWord.Add(shuffledWord);
                return true;
            }
            return false;
        }
        public void AddToLeaderboard(Leaderboards accountData)
        {
            bool playerExist = false;
            foreach (var leaderboard in leaderboards)
            {
                if (leaderboard.Username == accountData.Username)
                {
                    playerExist = true;
                    sqlConnection.Open();
                    string update = "Update tbl_leaderboards set Score = @score where Username = @username";
                    SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
                    updateCommand.Parameters.AddWithValue("@score", accountData.Score);
                    updateCommand.Parameters.AddWithValue("@username", accountData.Username);
                    updateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    leaderboard.Score = accountData.Score; 
                }
            }
            if (!playerExist)
            {
                sqlConnection.Open();
                string insert = "Insert into tbl_leaderboards (Username, Score) values (@username, @score)";
                SqlCommand insertCommand = new SqlCommand(insert, sqlConnection);
                insertCommand.Parameters.AddWithValue("@username", accountData.Username);
                insertCommand.Parameters.AddWithValue("@score", accountData.Score);
                insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
                leaderboards.Add(accountData);

            }
        }
        public bool ForgotPassword(string newPassword, string userEmail)
        {
            sqlConnection.Open();
            string select = "Select * from GameAccounts where Email = @email";
            SqlCommand selectCommand = new SqlCommand(select, sqlConnection);
            selectCommand.Parameters.AddWithValue("@email", userEmail);
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                string update = "Update GameAccounts set Password = @new_password where Email = @email";
                SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
                updateCommand.Parameters.AddWithValue("@new_password", newPassword);
                updateCommand.Parameters.AddWithValue("@email", userEmail);
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            else
            {
                reader.Close();
                sqlConnection.Close();
                return false;
            }
        }
    }
}
