using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bulls_and_Cowd__Reversed____final
{
    public class Permutator
    {
        public List<int> NumbersToShuffle { get; set; }
        public int SizeOfResult { get; set; }

        public Permutator(List<int> numbersToShuffle, int sizeOfResult)
        {
            this.NumbersToShuffle = numbersToShuffle;
            this.SizeOfResult = sizeOfResult;
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(o => !t.Contains(o)),
            (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
