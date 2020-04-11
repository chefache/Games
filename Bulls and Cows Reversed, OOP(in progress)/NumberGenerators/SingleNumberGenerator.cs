using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First_atempt.NumberGenerators
{
    public class SingleNumberGenerator
    {
        public static int Generate(List<int> firstNum, List<int> secondNum)
        {
            var numbersSet = new HashSet<int>();

            foreach (var number in firstNum)
            {
                numbersSet.Add(number);
            }

            foreach (var number in secondNum)
            {
                numbersSet.Add(number);
            }

            for (int i = 1; i < 10; i++)
            {
                numbersSet.Add(i);
            }

            int missingNumber = numbersSet.Reverse().FirstOrDefault();

            return missingNumber;
        }
    }
}
