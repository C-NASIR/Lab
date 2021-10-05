using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    /// <summary>
    /// This enum handles difficulty
    /// </summary>
    public enum Difficulty { BEGINNER, EASY, MEDIUM, HARD, ADVANCED }

    /// <summary>
    /// This class is a model of what a crossword looks like
    /// </summary>
    public class Crossword
    {
        public int Id { get; set; }
        public String Clue { get; set; }
        public String Answer { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime Date { get; set; }

        public Crossword(int id)
        {
            this.Id = id;
            this.Date = DateTime.Now;
        }

        /// <summary>
        /// This overrides the parent object string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"id: {Id} Clue: {Clue} Answer: {Answer} Difficulty: {Difficulty} Date: {Date}";
        }
    }
}
