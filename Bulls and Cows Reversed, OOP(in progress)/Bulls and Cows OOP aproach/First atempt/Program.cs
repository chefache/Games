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

             var numWithLessBullsAndCows = FindNumberWithLessBullsAndCows(firstNumToWork, secondNumToWork);

        }
         public static object FindNumberWithLessBullsAndCows(FirstNumber firstNumber, SecondNumber secondNumber)
        {
            if (firstNumber.Total > secondNumber.Total)
            {
                return secondNumber;
            }
            return firstNumber;
        }
    }
}
