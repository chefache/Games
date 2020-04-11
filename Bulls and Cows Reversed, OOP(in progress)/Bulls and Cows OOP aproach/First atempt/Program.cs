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
