using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Model;
namespace Lab2.Helpers
{
    /// <summary>
    /// This is a helper class which helps other classes do difficulty conversion
    /// </summary>
    public static class DifficultyHelper
    {
        /// <summary>
        /// This is a method that converts difficulty to a selected id
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns> int </returns>
        public static int GetDifficultyIndex(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.BEGINNER:
                    return 0;
                case Difficulty.EASY:
                    return 1;
                case Difficulty.MEDIUM:
                    return 2;
                case Difficulty.HARD:
                    return 3;
                case Difficulty.ADVANCED:
                    return 4;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// This is a private method that ges the chosen difficult
        /// </summary>
        /// <returns> Difficulty</returns>
        public static Difficulty GetDifficulty(int number)
        {
            switch (number)
            {
                case 0:
                    return Difficulty.BEGINNER;
                case 1:
                    return Difficulty.EASY;
                case 2:
                    return Difficulty.MEDIUM;
                case 3:
                    return Difficulty.HARD;
                case 4:
                    return Difficulty.ADVANCED;
                default:
                    return Difficulty.EASY;
            }
        }
    }
}
