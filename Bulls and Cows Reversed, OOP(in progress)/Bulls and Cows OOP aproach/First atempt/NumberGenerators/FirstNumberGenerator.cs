using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First_atempt
{
    public class FirstNumberGenerator
    {
        public static List<int> Generate()
        {
            var rnd = new Random();

            var firstNumber = new HashSet<int>();

            while (firstNumber.Count < 4)
            {
                int currentNum = rnd.Next(1, 10);
                firstNumber.Add(currentNum);
            }          

            return firstNumber.ToList();
        }
    }
}
