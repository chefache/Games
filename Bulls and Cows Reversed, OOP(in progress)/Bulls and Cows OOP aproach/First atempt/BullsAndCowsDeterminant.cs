using System;
using System.Collections.Generic;
using System.Text;

namespace First_atempt
{
    public class BullsAndCowsDeterminant
    {
        public BullsAndCowsDeterminant(List<int> computerGuess, int numBulls, int numCows)
        {
            this.ComputerGuess = computerGuess;
            this.numBulls = numBulls;
            this.numCows = numCows;
        }

        public List<int> ComputerGuess { get; set; }
        public int numBulls { get; set; }
        public int numCows { get; set; }

    }
}
