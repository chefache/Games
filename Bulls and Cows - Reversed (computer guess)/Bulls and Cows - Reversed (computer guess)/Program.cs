namespace Project_Four
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var resultList = new List<int>();

            var firstGroup = new HashSet<int>();

            var secondGroop = new HashSet<int>();

            var rnd = new Random();

            while (firstGroup.Count < 4)
            {
                int currentNum = rnd.Next(1, 10);

                firstGroup.Add(currentNum);
            }

            var firstGroopToWork = firstGroup.ToList();

            while (secondGroop.Count < 4)
            {
                int currentNum = rnd.Next(1, 10);

                if (!firstGroup.Contains(currentNum))
                {
                    secondGroop.Add(currentNum);
                }
            }
            var secondGroopToWork = secondGroop.ToList();

            int missingNumber = FindMissingNumber(firstGroopToWork, secondGroopToWork);

            Console.WriteLine(string.Join("", firstGroopToWork));
            Console.Write("Enter bulls:");
            int firstGroupBulls = int.Parse(Console.ReadLine());
            Console.Write("Enter cows:");
            int firstGroupCows = int.Parse(Console.ReadLine());

            int firstGroupTotal = firstGroupBulls + firstGroupCows;

            Console.WriteLine($"My number is: {string.Join("", secondGroopToWork)}");
            Console.Write("Enter bulls:");
            int secondGroupBulls = int.Parse(Console.ReadLine());
            Console.Write("Enter cows:");
            int secondGroupCows = int.Parse(Console.ReadLine());

            int secondGroupTotal = secondGroupBulls + secondGroupCows;

            if (firstGroupTotal == secondGroupTotal)
            {
                int missingNumberToWork = FindMissingNumber(firstGroopToWork, secondGroopToWork);

                var firstGroupResult = ExtractBullsAndCows(missingNumberToWork, firstGroopToWork);

                var secondGroupResult = ExtractBullsAndCows(missingNumberToWork, secondGroopToWork);

                resultList = CombineTwoLists(firstGroupResult, secondGroupResult);
            }

            if (firstGroupTotal == 2 && secondGroupTotal == 1)
            {
                AddMissingNumber(secondGroopToWork, missingNumber, firstGroupTotal);

                Console.WriteLine($"My number is: { string.Join("", secondGroopToWork)}");
                Console.Write("Enter bulls:");
                int currentBulls = int.Parse(Console.ReadLine());
                Console.Write("Enter cows:");
                int currentCows = int.Parse(Console.ReadLine());

                secondGroupTotal = currentBulls + currentCows;

                if (firstGroupTotal == secondGroupTotal)
                {
                    int missingNumberToWork = FindMissingNumber(firstGroopToWork, secondGroopToWork);

                    var firstGroupResult = ExtractBullsAndCows(missingNumberToWork, firstGroopToWork);

                    var secondGroupResult = ExtractBullsAndCows(missingNumberToWork, secondGroopToWork);

                    resultList = CombineTwoLists(firstGroupResult, secondGroupResult);
                }
            }

            if (firstGroupTotal == 1 && secondGroupTotal == 2)
            {
                AddMissingNumber(firstGroopToWork, missingNumber, secondGroupTotal);

                Console.WriteLine($"My number is: {string.Join("", firstGroopToWork)}");
                Console.Write("Enter bulls:");
                int currentBulls = int.Parse(Console.ReadLine());
                Console.Write("Enter cows:");
                int currentCows = int.Parse(Console.ReadLine());

                firstGroupTotal = currentBulls + currentCows;

                if (firstGroupTotal == secondGroupTotal)
                {
                    int missingNumberToWork = FindMissingNumber(firstGroopToWork, secondGroopToWork);

                    var firstGroupResult = ExtractBullsAndCows(missingNumberToWork, firstGroopToWork);

                    var secondGroupResult = ExtractBullsAndCows(missingNumberToWork, secondGroopToWork);

                    resultList = CombineTwoLists(firstGroupResult, secondGroupResult);
                }
            }

            if (firstGroupTotal == 3 && secondGroupTotal == 1)
            {
                var singleNum = FindSingleNum(secondGroopToWork, missingNumber);
                resultList = AddSingleNumToList(singleNum, firstGroopToWork);
            }

            if (firstGroupTotal == 1 && secondGroupTotal == 3)
            {
                var singleNum = FindSingleNum(firstGroopToWork, missingNumber);
                resultList = AddSingleNumToList(singleNum, secondGroopToWork);
            }

            if (firstGroupTotal == 3 && secondGroupTotal == 0)
            {
                resultList = AddSingleNumToList(missingNumber, firstGroopToWork);
            }

            if (firstGroupTotal == 0 && secondGroupTotal == 3)
            {
                resultList = AddSingleNumToList(missingNumber, secondGroopToWork);
            }

            if (firstGroupTotal == 4 && secondGroupTotal == 0)
            {
                resultList = firstGroopToWork;
            }

            if (firstGroupTotal == 0 && secondGroupTotal == 4)
            {
                resultList = secondGroopToWork;
            }

            var finalList = ReturnListWithAtleastOneBull(resultList);

            int numNotInList = FindNumNotInResult(resultList);

            var bullDigitAndPosition = FindBullPosition(finalList, numNotInList);


            int bullDigit = bullDigitAndPosition[0];

            int bullIndex = bullDigitAndPosition[1];

            var workList = finalList.ToArray();

            var result = new List<List<int>>();

            foreach (var item in Permute(workList))
            {
                if (item[bullIndex] == bullDigit)
                {
                    result.Add(item);
                }
            }

            while (result.Count > 1)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"My number is: { string.Join("", result[i])}");
                    Console.Write("Enter bulls: ");
                    int bulls = int.Parse(Console.ReadLine());
                    Console.Write("Enter cows: ");
                    int cows = int.Parse(Console.ReadLine());

                    if (bulls == 4)
                    {
                        Console.WriteLine($"Your number is: {string.Join("", result[i])}");
                        return;
                    }

                    if (bulls < 4)
                    {
                        result.Remove(result[i]);
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"Your number is: {string.Join("", item)}");
            }

        }

        static List<List<int>> Permute(int[] nums)
        {
            var list = new List<List<int>>();
            return DoPermute(nums, 0, nums.Length - 1, list);
        }

        static List<List<int>> DoPermute(int[] nums, int start, int end, List<List<int>> list)
        {
            if (start == end)
            {
                list.Add(new List<int>(nums));
            }

            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap(ref nums[start], ref nums[i]);
                    DoPermute(nums, start + 1, end, list);
                    Swap(ref nums[start], ref nums[i]);
                }
            }

            return list;
        }

        static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public static List<int> FindBullPosition(List<int> list, int missingNum)
        {
            var resultList = new List<int>();

            Console.WriteLine($"Your number is: { string.Join("", list)}");
            Console.Write("Enter bulls: ");
            int bulls = int.Parse(Console.ReadLine());
            Console.Write("Enter cows: ");
            int cows = int.Parse(Console.ReadLine());

            for (int i = 0; i < list.Count; i++)
            {
                int temp = list[i];
                list[i] = missingNum;

                Console.WriteLine($"Your number is: { string.Join("", list)}");
                Console.Write("Enter bulls: ");
                int CurrentBulls = int.Parse(Console.ReadLine());
                Console.Write("Enter cows:");
                int CurrentCows = int.Parse(Console.ReadLine());

                if (CurrentBulls == 4)
                {
                    Console.WriteLine($"Your number is: {string.Join("", list)}");
                }

                if (CurrentBulls < bulls)
                {
                    list[i] = temp;
                    resultList.Add(list[i]);
                    resultList.Add(i);
                    break;
                }

                list[i] = temp;
            }

            return resultList;
        }

        private static List<int> ReturnListWithAtleastOneBull(List<int> nums)
        {

            int[][] jaggedArr =
            {
                new int[] { nums[0], nums[1], nums[2], nums[3] },
                new int[] { nums[1], nums[2], nums[3], nums[0] },
                new int[] { nums[2], nums[3], nums[0], nums[1] },
                new int[] { nums[3], nums[0], nums[1], nums[2] }
            };

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.WriteLine($"My number is: {string.Join("", jaggedArr[j])}");
                    Console.Write("Enter bulls: ");
                    int bulls = int.Parse(Console.ReadLine());
                    Console.Write("Enter cows: ");
                    int cows = int.Parse(Console.ReadLine());

                    if (bulls == 4)
                    {
                        Console.WriteLine($"Your number is: {string.Join("", jaggedArr[j])}");
                    }

                    if (bulls > 0)
                    {
                        return jaggedArr[j].ToList();
                    }
                }
            }
            return null;
        }

        private static List<int> AddSingleNumToList(int singleNum, List<int> list)
        {
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < list.Count; i++)
            {
                int temp = list[i];
                list[i] = singleNum;

                Console.WriteLine($"My number is: {string.Join("", list)}");
                Console.Write("Enter bulls:");
                bulls = int.Parse(Console.ReadLine());
                Console.Write("Enter cows:");
                cows = int.Parse(Console.ReadLine());

                if (bulls + cows == 4)
                {
                    return list;
                }

                list[i] = temp;
            }

            return list;
        }

        private static int FindSingleNum(List<int> nums, int missingNumber)
        {
            int[][] jaggedArr =
            {
                new int[] { nums[0], nums[1], nums[2], nums[3] },
                new int[] { nums[1], nums[2], nums[3], nums[0] },
                new int[] { nums[2], nums[3], nums[0], nums[1] },
                new int[] { nums[3], nums[0], nums[1], nums[2] }
            };

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.WriteLine($"My number is: { string.Join("", jaggedArr[j])}");
                    Console.Write("Enter bulls:");
                    int bulls = int.Parse(Console.ReadLine());
                    Console.Write("Enter cows:");
                    int cows = int.Parse(Console.ReadLine());

                    if (bulls == 1 && cows == 0)
                    {
                        var workList = new List<int>(jaggedArr[j]);

                        for (int n = 0; n < workList.Count; n++)
                        {
                            int temp = workList[n];
                            workList[n] = missingNumber;
                            Console.WriteLine($"My number is: { string.Join("", workList)}");
                            Console.Write("Enter bulls:");
                            bulls = int.Parse(Console.ReadLine());
                            Console.Write("Enter cows:");
                            cows = int.Parse(Console.ReadLine());
                            if (bulls == 0 && cows == 0)
                            {
                                return temp;
                            }
                            workList[n] = temp;
                        }
                    }
                }
            }
            return 0;
        }

        private static List<int> CombineTwoLists(List<int> firstList, List<int> secondList)
        {
            var resultList = new List<int>();

            foreach (var number in firstList)
            {
                resultList.Add(number);
            }

            foreach (var number in secondList)
            {
                resultList.Add(number);
            }

            return resultList;
        }

        private static List<int> ExtractBullsAndCows(int missingNumber, List<int> groupToWork)
        {
            var resultList = new List<int>();
            int inputTotal = 2;

            for (int i = 0; i < groupToWork.Count; i++)
            {
                int temp = groupToWork[i];
                groupToWork[i] = missingNumber;

                Console.WriteLine($"My number is: { string.Join("", groupToWork)}");
                Console.Write("Enter bulls:");
                int currentBulls = int.Parse(Console.ReadLine());
                Console.Write("Enter cows:");
                int currentCows = int.Parse(Console.ReadLine());

                groupToWork[i] = temp;

                int currentTotal = currentBulls + currentCows;

                if (inputTotal != currentTotal)
                {
                    resultList.Add(groupToWork[i]);
                }
            }

            return resultList;
        }

        private static List<int> AddMissingNumber(List<int> group, int missingNumber, int otherGroupTotal)
        {
            for (int i = 0; i < group.Count; i++)
            {
                int temp = group[i];
                group[i] = missingNumber;
                Console.WriteLine($"My number is: { string.Join("", group)}");
                Console.Write("Enter bulls:");
                int bulls = int.Parse(Console.ReadLine());
                Console.Write("Enter cows:");
                int cows = int.Parse(Console.ReadLine());
                int secondGroupTotal = bulls + cows;
                if (secondGroupTotal >= otherGroupTotal)
                {
                    break;
                }
                group[i] = temp;
            }
            return group;
        }

        private static int FindNumNotInResult(List<int> result)
        {
            var newResult = result.ToHashSet();
            for (int i = 0; i < 9; i++)
            {
                newResult.Add(i);
            }

            int numNotInList = newResult.Reverse().FirstOrDefault();
            return numNotInList;
        }

        private static int FindMissingNumber(List<int> firstList, List<int> secondList)
        {
            var allNumbersList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var set = new HashSet<int>();
            foreach (var number in firstList)
            {
                set.Add(number);
            }
            foreach (var number in secondList)
            {
                set.Add(number);
            }
            foreach (var number in allNumbersList)
            {
                set.Add(number);
            }
            int missingNumber = set.Reverse().FirstOrDefault();
            return missingNumber;
        }
    }
}
