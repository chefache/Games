using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First_atempt
{
    public class SecondNumberGenerator
    {
        public static List<int> Generate(List<int> firstGroup)
        {
            var rnd = new Random();

            var secondNumber = new HashSet<int>();

            while (secondNumber.Count < 4)
            {
                int currentNum = rnd.Next(1, 10);

                if (!firstGroup.Contains(currentNum))
                {
                    secondNumber.Add(currentNum);
                }
            }
            return secondNumber.ToList();
        }
    }
}
