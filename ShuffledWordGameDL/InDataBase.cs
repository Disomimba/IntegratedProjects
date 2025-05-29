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
        static string connectionString = "Data Source =DESKTOP-S1ATCN7\\SQLEXPRESS; Initial Catalog = DB_Game ; Integrated Security=true;TrustServerCertificate=True;";
        static SqlConnection sqlConnection;
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<Leaderboards> leaderboards = new List<Leaderboards>();
        public List<AdminData> admin = new List<AdminData>();
        public InDataBase()
        {
            sqlConnection = new SqlConnection(connectionString);
            GetDataFromDB();
        }
        private void GetDataFromDB()
        {
            GameAccountsFromDB();
            ScoresErrorHistoryFromDB();
            AdminDataFromDB();
            GetWordsFromDB();
            FindPlayerHighScore();
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
                    Username = reader["Username"].ToString(),
                    Password = reader["Password"].ToString()
                });
            }
            sqlConnection.Close();
        }
        public void ScoresErrorHistoryFromDB()
        {
            sqlConnection.Open();
            string selectScores = "SELECT * FROM Scores";
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
                Shuffle(reader["Words"].ToString());

            }
            sqlConnection.Close();
        }
        public void Shuffle(string word)
        {
            char[] wordToChar = word.ToCharArray();
            List<char> lettersChar = new List<char>(wordToChar);
            Random numberRandom = new Random();
            string wordShuffled = "";

            while (0 < lettersChar.Count)
            {
                int randomIndex = numberRandom.Next(lettersChar.Count);
                wordShuffled += lettersChar[randomIndex];
                lettersChar.RemoveAt(randomIndex);
            }

            admin[0].ShuffledWord.Add(wordShuffled);

        }
        public string DisplayWord(int index)
        {
            return index + 1 + ". " + admin[0].ArrangedWord[index];
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

                return false;
        }
        public int TotalWords()
        {
            return admin[0].ArrangedWord.Count();
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
            string insertScore = "INSERT INTO Scores (Username, Score, Error) VALUES (@username, @score, @error)";
            using (SqlCommand insertCommand = new SqlCommand(insertScore, sqlConnection))
            {
                insertCommand.Parameters.AddWithValue("@username", username);
                insertCommand.Parameters.AddWithValue("@score", score);
                insertCommand.Parameters.AddWithValue("@error", error);
                insertCommand.ExecuteNonQuery();
            }
            sqlConnection.Close();
            int index = FindPlayerIndex(username);
            account[index].Score.Add(score);
            FindPlayerHighScore();
            AddHistory(username, score, error);
        }
        public void AddHistory(string username, int score, int error)
        {
            sqlConnection.Open();
            string insertHistory = "INSERT INTO History (Username, History) VALUES (@username, @history)";
            using (SqlCommand insertCommand = new SqlCommand(insertHistory, sqlConnection))
            {
                insertCommand.Parameters.AddWithValue("@username", username);
                insertCommand.Parameters.AddWithValue("@history", $"Score : {score} | Error : {error}");
                insertCommand.ExecuteNonQuery();
            }
            sqlConnection.Close();
            int index = FindPlayerIndex(username);
            account[index].History.Add($"Score : {score} | Error : {error}");
        }
        public void FindPlayerHighScore()
        {
            foreach (var accounts in account)
            {
                string username = accounts.Username;
                if (accounts.Score.Any())
                {
                    int playerHighScore = accounts.Score.Max();
                    TopPlayers(username, playerHighScore);
                }
            }
        }
        public void TopPlayers(string username, int score)
        {
            if (score > 0)
            {
                bool playerExists = false;
                for (int i = 0; i < leaderboards.Count; i++)
                {
                    if (leaderboards[i].Username == username)
                    {
                        playerExists = true;
                        if (score > leaderboards[i].Score)
                        {
                            leaderboards[i].Score = score;
                        }
                        break;
                    }
                }

                if (!playerExists)
                {
                    Leaderboards newEntry = new Leaderboards();
                    newEntry.Username = username;
                    newEntry.Score = score;
                    leaderboards.Add(newEntry);
                }
                BubbleSort(leaderboards.Count);
            }
        }
        public void BubbleSort(int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (leaderboards[j].Score < leaderboards[j + 1].Score)
                    {
                        var temp = leaderboards[j];
                        leaderboards[j] = leaderboards[j + 1];
                        leaderboards[j + 1] = temp;
                    }
                }
            }
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
            GetDataFromDB();
        }
        public string DisplayLeaderboard()
        {
            string username_scores = string.Empty;

            foreach (var displayLeaderboards in leaderboards)
            {
                username_scores += $"{displayLeaderboards.Username}\t{displayLeaderboards.Score}\n";
            }

            return username_scores;
        }
        public string DisplayPlayerHistory(string username)
        {
            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    string playerHistory = "";
                    for (int i = 0; i <= accounts.History.Count - 1; i++)
                    {
                        playerHistory += accounts.History[i] + "\n";
                    }
                    return playerHistory;

                }
            }
            return null;
        }
        public string GetPlayerName(string username)
        {

            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    return accounts.Name;
                }
            }
            return null;

        }
        public string GetPlayerUsername(string name)
        {

            foreach (var accounts in account)
            {
                if (accounts.Name == name)
                {
                    return accounts.Username;
                }
            }
            return null;

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
                Console.WriteLine("ADMIN USERNAME : " + admin[0].Username);
                admin[0].ArrangedWord.Add(arrangedWord);
                Shuffle(arrangedWord);
                return true;
            }
            return false;
        }
        public string ShuffledWord(int index)
        {
            return admin[0].ShuffledWord[index];
        }
        public string ArrangedWord(int index)
        {
            return admin[0].ArrangedWord[index];
        }
    }
}
