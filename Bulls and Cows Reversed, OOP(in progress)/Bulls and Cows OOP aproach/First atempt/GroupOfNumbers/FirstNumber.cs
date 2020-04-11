using System;
using System.Collections.Generic;
using System.Text;

namespace First_atempt
{
    public class FirstNumber
    {
        public FirstNumber(List<int> digits, int bullsCount, int cowsCount, int total)
        {
            this.Digits = digits;
            this.BullsCount = bullsCount;
            this.CowsCount = cowsCount;
            this.Total = total;
        }

        public List<int> Digits { get; set; }
        public int BullsCount { get; set; }
        public int CowsCount { get; set; }
        public int Total { get; set; }
    }
}
