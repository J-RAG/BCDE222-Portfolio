using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise1
{
    class Loops
    {
        public int Result;
        protected int Min = 0;
        protected int Max = 100;

        public int CalcSum()
        {
            Result = 0;
            for (int i = Min;  i <= Max; i++)
            {
                Result += i;
            }
            return Result;
        }

        public int CalcSumWhileDo()
        {
            Result = 0;
            int num = 0;
            while (num < Max)
            {
                num++;
                Result += num;
            }
            return Result;
        }

        public int CalcSumDoWhile()
        {
            Result = 0;
            int num = 0;

            do
            {
                num++;
                Result += num;
            }

            while (num < Max);

            return Result;
        }

        public int CalcSumAverage(int min, int max)
        {
            int count = 0;
            int sum = 0;

            for (int i = min; i <= max; i++)
            {
                count++;
                sum += i;
            }

            return sum / count;
        }

        public int CalcSumAverageOddsOnly(int min, int max)
        {
            int count = 0;
            Result = 0;

            // check minimum number is odd
            if (min % 2 == 0) 
            {
                min++; 
            }
            
            for (int i = min; i <= max; i+=2)
            {
                Result += i;
                count++;
            }

            return Result / count;
        }

        public int CalcSumAverageDivSeven(int min, int max)
        {
            int count = 0;
            Result = 0;

            // check minimum number is divisible by 7
            while (min % 7 != 0)
            {
                min++;
            }

            for (int i = min; i <= max; i += 7)
            {
                Result += i;
                count++;
            }

            return Result / count;
        }

        public int CalcSumOfSquares(int min, int max)
        {
            Result = 0;
            for (int i = min; i <=max; i++)
            {
                Result += i*i;
            }

            return Result;
        }



    }
}
