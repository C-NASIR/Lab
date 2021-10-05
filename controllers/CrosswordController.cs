using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Model;
using Lab2.database;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    /// <summary>
    /// This class is a controller to the database. it connects UI to Data
    /// </summary>
    public class CrosswordController
    {
        private DatabaseModel databaseModel;
        public CrosswordController(DatabaseModel model)
        {
            this.databaseModel = model;
        }

        /// <summary>
        /// This method returns all the data we have in a file
        /// </summary>
        /// <returns> List<Crossword></returns>
        public List<Crossword> GetAllWords()
        {
            return databaseModel.GetAllCrosswords();
        }

        /// <summary>
        /// This method creates a crossword from a given properties
        /// </summary>
        /// <param name="clue"></param>
        /// <param name="answer"></param>
        /// <param name="difficulty"></param>
        public void AddCrossword(string clue, string answer, Difficulty difficulty)
        {
            int id = databaseModel.NumberOfWords() + 1;

            Crossword Crossword = new Crossword(id);
            Crossword.Clue = clue;
            Crossword.Answer = answer;
            Crossword.Difficulty = difficulty;

            databaseModel.AddCrossword(Crossword);
        }

        /// <summary>
        /// This method updates a given crossword
        /// </summary>
        /// <param name="crossword"></param>
        public void UpdateCrossword(Crossword crossword )
        {
            databaseModel.UpdateCrossword(crossword);
        }

        /// <summary>
        /// This method gets a crossword from a given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Crossword </returns>
        public Crossword GetCrossword(int id)
        {
           return databaseModel.GetCrossword(id);
        }

        /// <summary>
        /// This method deletes a crossword of a given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCrossword(int id)
        {
            databaseModel.DeleteCrossword(id);
        }

    }
}
