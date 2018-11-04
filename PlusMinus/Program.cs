using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusMinus
{
    class Program
    {
        /*
         * https://www.hackerrank.com/challenges/plus-minus/problem
         */

        static void Main(string[] args)
        {
            plusMinus(new int[] { -4, 3, -9, 0, 4, 1 });
            plusMinus1(new int[] { -4, 3, -9, 0, 4, 1 });

            Console.WriteLine("Hello World!");
        }

        static void plusMinus(int[] arr)
        {
            int arrCount = arr.Count();

            var positive = new List<int>();
            var negative = new List<int>();
            var zeros = new List<int>();

            foreach (var number in arr)
            {
                if (number > 0)
                {
                    positive.Add(number);
                }
                else if (number < 0)
                {
                    negative.Add(number);
                }
                else
                {
                    zeros.Add(number);
                }
            }

            Console.WriteLine((float)positive.Count() / arrCount);
            Console.WriteLine((float)negative.Count() / arrCount);
            Console.WriteLine((float)zeros.Count() / arrCount);
        }

        static void plusMinus1(int[] arr)
        {
            int arrCount = arr.Count();

            var positive = arr.GetPositives();
            var negative = arr.GetNegatives();
            var zeros = arr.GetZeros();

            new Divide(positive.Count(), arrCount).Calculate();
            new Divide(negative.Count(), arrCount).Calculate();
            new Divide(zeros.Count(), arrCount).Calculate();
        }
    }

    public struct Divide
    {
        private int ArrayCount { get; set; }
        private int ListCount { get; set; }

        public Divide(int listCount, int arrayCount)
        {
            this.ArrayCount = arrayCount;
            this.ListCount = listCount;
        }

        public void Calculate()
        {
            Console.WriteLine((float)ListCount / ArrayCount);
        }
    }

    public static class Helper
    {
        public static IEnumerable<int> GetPositives(this int[] arr)
        {
            return arr.Where(c => c > 0);
        }

        public static IEnumerable<int> GetNegatives(this int[] arr)
        {
            return arr.Where(c => c < 0);
        }

        public static IEnumerable<int> GetZeros(this int[] arr)
        {
            return arr.Where(c => c == 0);
        }
    }
}
