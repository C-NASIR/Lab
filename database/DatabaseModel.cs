using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Lab2.Model;
using Lab2.Helpers;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;


namespace Lab2.database
{
    /// <summary>
    /// This method handles the database manipulation
    /// </summary>
    public class DatabaseModel
    {
        private String filePath = "data.json";
        private List<Crossword> Crosswords = new List<Crossword>();
        private MySqlConnection connection;

        public DatabaseModel(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
            setUpList();
        }


        /// <summary>
        /// This method gets data from a file
        /// </summary>
        private void setUpList()
        {
            connection.Open();
            string sql = "SELECT * FROM crossword";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader.GetValue(0).ToString());
                    Crossword crossword = new Crossword(id);
                    crossword.Clue = reader.GetValue(1).ToString();
                    crossword.Answer = reader.GetValue(2).ToString();
                    int difficultyNumber = int.Parse(reader.GetValue(3).ToString());
                    crossword.Difficulty = DifficultyHelper.GetDifficulty(difficultyNumber);
                    string dateString = reader.GetValue(4).ToString();
                    string[] st = dateString.Split('/', ' ', ':');
                    int year = int.Parse(st[2]);
                    int day = int.Parse(st[1]);
                    int month = int.Parse(st[0]);
                    int hour = int.Parse(st[3]);
                    int minutes = int.Parse(st[4]);
                    int seconds = int.Parse(st[5]);
                    crossword.Date = new DateTime(year, month, day, hour, minutes, seconds);
                    Console.WriteLine(crossword);
                    Crosswords.Add(crossword);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// This method returns the length of words we have
        /// </summary>
        /// <returns> int </returns>
        public int NumberOfWords()
        {
            return Crosswords.Count;
        }

        /// <summary>
        /// This method gets all the crosswords in the list
        /// </summary>
        /// <returns> List<Crossword></Crossword></returns>
        public List<Crossword> GetAllCrosswords()
        {
            return Crosswords;
        }

        /// <summary>
        /// This method adds a given crossword to our local list
        /// </summary>
        /// <param name="Crossword"></param>
        public void AddCrossword(Crossword crossword)
        {
            connection.Open();
            DateTime date = crossword.Date;
            String dateString = date.Year.ToString() + "/" + date.Month + "/" + date.Day + " " + date.TimeOfDay;
            string sql = String.Format("INSERT INTO crossword(id, clue, answer, difficulty, date)" +
                                        "VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\")",
                                        crossword.Id, crossword.Clue, crossword.Answer, DifficultyHelper.GetDifficultyIndex(crossword.Difficulty), dateString);
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                Crosswords.Add(crossword);

            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// This method updates a given crossword
        /// </summary>
        /// <param name="crossword"></param>
        public void UpdateCrossword(Crossword crossword)
        {
            var word = GetCrossword(crossword.Id);
            if (word != null)
            {
                connection.Open();
                string sql = String.Format("UPDATE crossword " +
                            "SET clue = \"{0}\", answer = \"{1}\", difficulty = \"{2}\" " +
                            "WHERE id = \"{3}\" ",
                            crossword.Clue, crossword.Answer, DifficultyHelper.GetDifficultyIndex(crossword.Difficulty), crossword.Id);

                MySqlCommand command = new MySqlCommand(sql, connection);
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    Crossword Cword = Crosswords.Find(w => w.Id == crossword.Id);
                    int indexOfCword = Crosswords.IndexOf(Cword);
                    Crosswords[indexOfCword] = crossword;
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        /// <summary>
        /// This method gets the crossword by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Crossword GetCrossword(int id)
        {
            foreach (var word in Crosswords)
            {
                if (word.Id == id)
                {
                    return word;
                }
            }
            return null;
        }

        /// <summary>
        /// This method deletes a crossword given the crossword ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCrossword(int id)
        {
            Crossword word = GetCrossword(id);
            if (word != null)
            {
                connection.Open();
                string sql = "DELETE FROM crossword WHERE id= " + id;

                MySqlCommand command = new MySqlCommand(sql, connection);
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    Crosswords.Remove(word);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
