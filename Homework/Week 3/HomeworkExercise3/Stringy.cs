using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise3
{
    class Stringy
    {
        public string _input = "";

        public void SetString(string newInput)
        {
            _input = newInput;
        }

        // Question 16
        public string ReverseString()
        {
            string reverseString = ""; // intialize reverse string

            for (int i = 0; i <= _input?.Length - 1; i++)
            {
                reverseString += _input?[_input.Length - 1 - i];
            }
            return reverseString;
        }

        // Question 17
        public string StringToDigits()
        {
            string digits = string.Empty;
            for (int i = 0; i < _input?.Length; i++)
            {
                char c = Char.ToUpper(_input[i]);
                if (c == 'A' || c == 'C' || c == 'B')
                {
                    digits += 2;
                }
                else if (c == 'D' || c == 'E' || c == 'F')
                {
                    digits += 3;
                }
                else if (c == 'G' || c == 'H' || c == 'I')
                {
                    digits += 4;
                }
                else if (c == 'J' || c == 'K' || c == 'L')
                {
                    digits += 5;
                }
                else if (c == 'M' || c == 'N' || c == 'O')
                {
                    digits += 6;
                }
                else if (c == 'P' || c == 'Q' || c == 'R' || c == 'S')
                {
                    digits += 7;
                }
                else if (c == 'T' || c == 'U' || c == 'V')
                {
                    digits += 8;
                }
                else if (c == 'W' || c == 'X' || c == 'Y' || c == 'Z')
                {
                    digits += 9;
                }
                else
                {
                    digits += c; // Keep the same 
                }
            }

            return $"The Digital sequence to \"{_input}\" is {digits}";
        }

        public string GetCharToDigitMap()
        {

            string listFormat = "";   
            string[] charToDigitMap =
                        {
                            "2 => ABC",
                            "3 => DEF",
                            "4 => GHI",
                            "5 => JKL",
                            "6 => MNO",
                            "7 => PQRS",
                            "8 => TUV",
                            "9 => WXYZ"
                        };

            switch(_input)
            {
                case "1":

                    return (string.Join(", ", charToDigitMap));

                default:
                    foreach (string item in charToDigitMap)
                    {
                        listFormat += $"{item}\n";
                    }
                    return listFormat;
            }
        }

        // Question 18
        public string IsPalindrome()
        {
            // Remove Punctuation
            var strippedInput = new StringBuilder();
            for (int i = 0; i < _input?.Length; i++)
            {
                char c = _input[i];
                if (!char.IsPunctuation(c))
                    strippedInput.Append(c);
            }

            // Remove Spaces
            _input = strippedInput.ToString().Replace(" ", "");

            /*
            // Testing Output
            Console.WriteLine(_input?.ToLower() + " (Original input)");
            Console.WriteLine(ReverseString().ToLower() + " (Reversed String)");
            */

            // Check if string is Palindrome
            if (_input?.ToLower() == ReverseString().ToLower())
            {
                return "is";
            }

            return "is not";

        }

        // Question 19
        public static double GetAverageGrades(int Numstudents)
        {
            // Create An array of student Grades
            double[] grades = new double[Numstudents];
            double sum = 0.0;

            string stringGrade; // input text

            for (int i = 0; i <= grades.Length - 1; i++)
            {
                // Initial Input text 
                Console.Write($"Enter the grade for student {i + 1}: ");
                stringGrade = Console.ReadLine() ?? "";

                // Check if input is a number and between 0 and 100
                bool isNumber = double.TryParse(stringGrade, out double grade);
                while (!isNumber || !(grade >= 0 && grade <= 100))
                {
                    Console.WriteLine("Invalid grade, try again...");
                    Console.Write($"Enter the grade for student {i + 1}: ");
                    stringGrade = Console.ReadLine() ?? "";

                    isNumber = double.TryParse(stringGrade, out grade);
                }
                // Add Grade to sum if all Input passes all validities
                sum += grade;
            }

            return sum / grades.Length;
        }


    }
}
