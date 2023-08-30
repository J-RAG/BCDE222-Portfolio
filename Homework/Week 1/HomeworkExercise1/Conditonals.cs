using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise1
{
    class Conditonals
    {
        public string? Result;

        private const int MinGradePass = 50;

        public string CheckMark(double grade)
        {
            Result = "FAIL"; // Initial Value set
            if (grade >= MinGradePass)
            {
                Result = "PASS";
            }
            return Result;
        }

        public string IsOddNumber(int number)
        {
            Result = "Even Number";
            if (number % 2 != 0)
            {
                Result = "Odd Number";
            }
            return Result;
        }

        public static string NumberName(int number)
        {
            return number switch
            {
                0 => "ZERO",
                1 => "ONE",
                2 => "TWO",
                3 => "THREE",
                4 => "FOUR",
                5 => "FIVE",
                6 => "SIX",
                7 => "SEVEN",
                8 => "EIGHT",
                9 => "NINE",
                _ => "OTHER",
            };
        }



    }
}
