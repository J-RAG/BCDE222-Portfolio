using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise4
{
    class Methods
    {
        public string _input = "";

        public void SetString(string newInput)
        {
            _input = newInput;
        }

        // Question 20
        public static string GetGradeStats(int numstudents)
        {
            // Create An array of student Grades
            double[] grades = gradeArrayBuilder(numstudents);

            string output = "";

            output += $"The average is {GetAverageGrade(grades)}\n";
            output += $"The minimum is {GetMinGrade(grades)}\n";
            output += $"The maximum is {GetMaxGrade(grades)}\n";
            output += $"The standard deviation is {GetStdevGrade(grades, GetAverageGrade(grades))}\n";


            return output;
        }

        /*
         * Returns a Double array of grades based 
         * on the number of students inputed
         */
        private static double[] gradeArrayBuilder(int numStudents)
        {
            double[] grades = new double[numStudents];
            for (int i = 0; i<=numStudents - 1; i++)
            {
                string stringGrade = GetGrade(i + 1);

                double grade = InputChecker(stringGrade, i);

                // Add grade to grades Array 
                grades[i] = grade;
            }

            return grades;
        }

        // Returns Average grade
        private static double GetAverageGrade(double[] grades)
        {
            double sum = 0.0;
            foreach (double grade in grades)
            {
                sum += grade;
            }
            return grades.Average();
        }

        // Returns Minimum grade
        private static double GetMinGrade(double[] grades)
        {
            return grades.Min();
        }

        // Returns Maximum grade
        private static double GetMaxGrade(double[] grades)
        {
            return grades.Max();
        }
        
        // Returns Standard Deviation of the Grades
        private static double GetStdevGrade(double[] grades, double average)
        {
            double sumOfDerivation = 0.0;
            double variance;
            foreach (double grade in grades) 
            {
                sumOfDerivation += (grade - average) * (grade - average); 
            }
            variance = sumOfDerivation / (grades.Length);

            return Math.Sqrt(variance);
        }

        /*
         * Returns grade if the input is valid
         * Validity is confirmed if the input 
         * can be converted to a double
         */
        private static double InputChecker(string input, int index)
        {
            bool isNumber = double.TryParse(input, out double convertedOutput);
            while (!isNumber)
            { 
                Console.WriteLine("Invalid grade, try again...");
                
                // re-enter input
                isNumber = double.TryParse(GetGrade(index + 1), out convertedOutput);

            }
            return convertedOutput;
        }

        /*
        * Returns User input text
        */
        private static string GetGrade(int index)
        {
            Console.Write($"Enter the grade for student {index}: ");
            return Console.ReadLine() ?? "";

        }
        /// //////////////////////////////////////////////
        /// //////////////////////////////////////////////

        // Quation 21
        /*
        
        public static int[] ReverseMyArray(int[] myArray)
        {
            for (int i = 0; i < (double)myArray.Length / 2; i++)
            {
                int buffer = myArray[i]; 
                myArray[i] = myArray[myArray.Length - 1 - i];
                myArray[myArray.Length - 1 - i] = buffer;
            }

            return myArray;
        }*/

        // This uses the Box and Unbox method
        public static int[] ReverseMyArray(int[] myArray)
        {
            for (int i = 0; i < (double)myArray.Length / 2; i++)
            {
                object buffer = myArray[i]; // box data
                myArray[i] = myArray[myArray.Length - 1 - i];
                myArray[myArray.Length - 1 - i] = (int)buffer; // unbox data
            }

            return myArray;
        }

        /// //////////////////////////////////////////////
        /// //////////////////////////////////////////////

        // Question 22
        public static string NumberGuess()
        {
            bool game_state = true; // Loop Flag
            int num_guesses = 0; // guess count
            Random random = new(); 
            int goal = random.Next(0, 100); // random generated number to find
            // Console.WriteLine($"The number is: {goal}"); // Cheat here
            bool isHIgh = false; // check if guess is higher than goal 

            Console.WriteLine($"\x1b[1m> NumberGuess\x1b[0m");

            string inputGuess = GetGuess(isHIgh, true); // initial guess
            int guess = InputValidCheck(inputGuess);

            while (game_state)
            {
                num_guesses++;
                // Check if guess is correct
                game_state = GuessChecker(guess, goal);
                if (game_state) // if the guess is incorrect
                {
                    // Check if guess is more/less than goal
                    isHIgh = HigherOrLower(guess, goal);
                    inputGuess = GetGuess(isHIgh); // input guess
                    guess = InputValidCheck(inputGuess);

                }

            }
            return $"\"\nYou got it in {num_guesses} trails!";
        }

         /*
         * Returns user input
         * Prompt message will be given depending 
         * on state of the game 
         */
        private static string GetGuess(bool goHigh, bool firstGuess=false)
        {
            if (firstGuess) // triggered in first guess or invalid input
            {
                Console.WriteLine("Key in your guess: ");
                
            }
            else if (goHigh) // if guess is higher than goal
            {
                Console.WriteLine("Try lower");
            }
            else // guess is less than goal
            {
                Console.WriteLine("Try higher");
            }
            return Console.ReadLine() ?? "";
        }

        /*
         *  Checks input Validity. If invalid it will ask the 
         *  user to re-input their guess. Once Valid, returns True
         *  if the user's guess is correct. Else returns False
         */
        private static bool GuessChecker(int guess, int goal)
        {
            // check if guess is correct
            if (guess == goal)
            {
                return false;
            }
            return true;
        }

        /*
         * returns input as int if 
         * it can be converted. Otherwise will
         * ask the user to re-input a valid number
         */
        private static int InputValidCheck(string input)
        {
            // Check input validity
            bool isNumber = int.TryParse(input, out int guess);
            while (!isNumber)
            {
                Console.WriteLine("Invalid Input (this will not count as a guess)");
                isNumber = int.TryParse(GetGuess(false, true), out guess);
            }
            return guess;
        }

        /*
         * Returns false if guess is higher than goal.
         * else returns true.
         */
        private static bool HigherOrLower(int input, int goal) 
        {
            if (input > goal)
            {
                return true;
            }
            return false;
        }

        /// //////////////////////////////////////////////
        /// //////////////////////////////////////////////
        // Question 23
        public static string WordGuess(string theWord)
        {
            bool gameState = true;
            int count = 0; // Number of Trials 

            Console.WriteLine($"\x1b[1m WordGuess \x1b[0m"); // Bolded Title
            string myGuess = GetGuess().ToLower(); // First initial Guess

            // Create a series of underscores equal to theWord Length.
            string hint = CreateHint(theWord); 


            while (gameState) 
            {
                count++;
                gameState = GuessChecker(myGuess, theWord.ToLower());
                if (gameState) // Guess is incorrect or Input is a char
                {
                    hint = UpdateHint(myGuess, theWord.ToLower(), hint); 
                    Console.WriteLine($"Trial {count}: {hint}"); // Display Trial count and Hint
                    myGuess = GetGuess().ToLower(); // Guess again
                }
            }
            Console.WriteLine($"Trial {count}: Congratulations!"); // Game Over Messsage

            return $"\nYou got it in {count} trails!";

        }

        /*
         * returns user input
         */
        private static string GetGuess()
        {
            Console.Write("Key in one character or your guess word: ");
            return Console.ReadLine() ?? "";
        }

        /*
         * returns a string of underscores "_"
         * equal to the length of the word to guess
         */

        private static string CreateHint(string word)
        {
            string hint = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    hint += word[i]; // remove white spaces
                }
                else
                {
                    hint += '_';
                }
            }
            return hint;
        }

        /*
         *  returns and updates new hint.
         *  if the input character is in the word,
         *  reveal  all of the matching characters 
         *  in the word.
         */
        private static string UpdateHint(string input,string theWord, string currentHint)
        {
            string newHint = "";
            if (input.Length != 1) // it is not a char input
            { 
                return currentHint; // Terminates empty inputs 
            }

            for (int i = 0; i < theWord.Length; i++)
            {
                if (input[0] == theWord[i]) // the char contains the word
                {
                    newHint += input; 
                }
                else if (currentHint[i] != '_') // Keep already revealed chars
                {
                    newHint += currentHint[i]; 
                }
                else
                {
                    newHint += "_"; // remain blank
                }
            }
            return newHint;

        }
        /*
         * returns false if the input matches the word.
         * Ends the Game.
         */
        private static bool GuessChecker(string input, string theWord)
        {

            if (input == theWord)
            {
                return false;
            }
            return true;
        }
    }
}
