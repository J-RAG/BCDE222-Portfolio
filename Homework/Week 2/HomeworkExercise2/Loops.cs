using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise2
{
    class Loops
    {
        // Question 11
        public int Result;
        public decimal HarmonicSum;
        public int CalcProduct(int min, int max)
        {
            Result = min; // initial start
            for (int i = min; i <= max; i++)
            {
                Result *= i;
            }
            return Result;
        }

        // Question 12
        public decimal CalcHarmonicSeriesLeft(int goal)
        {
            HarmonicSum = 0;
            decimal i = 1m;
            int count = 0;
            while (count <= goal)
            {
                HarmonicSum += (1 / i);
                i++;
                count++;

            }
            return HarmonicSum;
        }

        public decimal CalcHarmonicSeriesRight(int goal)
        {
            int count = goal;
            HarmonicSum = 0;
            while (count <= 0)
            {
                HarmonicSum += 1 / count;
                count--;
            }

            return HarmonicSum;
        }

        // Question 13
        public double PiCalculator(int magnitude)
        {
            double denominator = 1.0;
            double sumSeries = 0.0;
            for (int i = 0; i < magnitude; i++)
            {
                if (denominator % 4 == 1)
                {
                    sumSeries += (1 / denominator);
                }
                else if (denominator % 4 == 3)
                {
                    sumSeries -= (1 / denominator);
                }
                denominator += 2.0;
            }
            return 4 * sumSeries;
        }

        // Question 14
        public  int[] FibonacciSeries(int numTerms)
        {
            int[] fibSeries = new int[numTerms];

            // Initialise First 2 numbers in the fibonacci Sequence
            fibSeries[0] = 1;
            fibSeries[1] = 1;
            // Console.WriteLine(fibSeries.Length); // Test Code

            // Start at 3rd item which we will be appended to the fibSeries List
            for (int i = 2; i < numTerms; i++)
            {
                // The new Fibonacci Number to be added
                fibSeries[i] = fibSeries[i - 1] + fibSeries[i - 2];
            }
            return fibSeries;
        }

        public double SeriesAverage(int[] Series)
        {
            int sum = 0;
            
            foreach (int num in Series)
            {
                sum += num;
            }     
            double seriesAverage = sum / Series.Length;
            return seriesAverage;
        }

        // Question 15
        public int[] TribonacciSeries(int numTerms)
        {
            int[] triSeries = new int[numTerms];

            // Initialise First 2 numbers in the Tribonacci Sequence
            triSeries[0] = 1;
            triSeries[1] = 1;
            triSeries[2] = 2;
            // Console.WriteLine(triSeries.Length); // Test Code

            // Start at 3rd item which we will be appended to the fibSeries List
            for (int i = 3; i < numTerms; i++)
            {
                // The new Fibonacci Number to be added
                triSeries[i] = triSeries[i - 1] + triSeries[i - 2] + triSeries[i - 3];
            }
            return triSeries;
        }

    }
}
