using First_atempt.NumberGenerators;
using System;
using System.Collections.Generic;

namespace First_atempt
{
    public class Program
    {
        public static void Main()
        {
            var firstNum = FirstNumberGenerator.Generate();
            var secondNum = SecondNumberGenerator.Generate(firstNum);
            var missingNum = SingleNumberGenerator.Generate(firstNum, secondNum);

            Console.WriteLine(string.Join("", firstNum));
            int firstNumBulls = int.Parse(Console.ReadLine());
            int firstNumCows = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join("", secondNum));
            int secondNumBulls = int.Parse(Console.ReadLine());
            int secondNumCows = int.Parse(Console.ReadLine());

            var firstNumToWork = new FirstNumber(firstNum, firstNumBulls, firstNumCows, firstNumBulls + firstNumCows);
            var secondNumToWork = new SecondNumber(secondNum, secondNumBulls, secondNumCows, secondNumBulls + secondNumCows);

            if (firstNumToWork.Total >= secondNumToWork.Total)
            {
                AddMissingNum(secondNumToWork.Digits, missingNum, secondNumBulls, secondNumCows);
                missingNum = SingleNumberGenerator.Generate(firstNumToWork.Digits, secondNumToWork.Digits);
            }
            if (firstNumToWork.Total <= secondNumToWork.Total)
            {
                AddMissingNum(firstNumToWork.Digits, missingNum, secondNumBulls, secondNumCows);
                missingNum = SingleNumberGenerator.Generate(firstNumToWork.Digits, secondNumToWork.Digits);
            }

            var firstNumBullsAndCows = FindAllBullsAndCows(firstNumToWork.Digits, missingNum, firstNumBulls, firstNumCows);
            var secondNumBullsAndCows = FindAllBullsAndCows(secondNumToWork.Digits, missingNum, secondNumBulls, secondNumCows);


        }

        public static List<int[]> FindAllBullsAndCows(List<int> number, int missingnum, int bulls, int cows)
        {
            var result = new List<int[]>();
            var bullsArray = new int[4];
            var cowsArray = new int[4];

            for (int i = 0; i < number.Count; i++)
            {
                int temp = number[i];
                number[i] = missingnum;
                Console.WriteLine(string.Join("", number));
                int currentBulls = int.Parse(Console.ReadLine());
                int currentCows = int.Parse(Console.ReadLine());
                if (currentBulls < bulls)
                {
                    bullsArray[i] = temp;
                }
                if (currentCows < cows)
                {
                    cowsArray[i] = temp;
                }
                number[i] = temp;
            }
            result.Add(bullsArray);
            result.Add(cowsArray);
            return result;
        }

        public static List<int> AddMissingNum(List<int> number, int missingNumber, int bulls, int cows)
        {
            for (int i = 0; i < number.Count; i++)
            {
                int temp = number[i];
                number[i] = missingNumber;
                Console.WriteLine(string.Join("", number));
                int currentBylls = int.Parse(Console.ReadLine());
                int currentCows = int.Parse(Console.ReadLine());
                if (currentBylls > bulls || currentCows > cows)
                {
                    return number;
                }
                number[i] = temp;
            }
            return number;
        }       
    }
}
