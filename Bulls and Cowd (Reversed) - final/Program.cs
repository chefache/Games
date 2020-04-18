using System;
using System.Collections.Generic;
using System.Linq;

namespace Bulls_and_Cowd__Reversed____final
{
    class Program
    {
        static void Main(string[] args)
        {
            // Създаваме лист от всички учстващи числа от 1 до 9 (включително);
            var listOfAllNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Декларираме големината на числото за игра;
            const int answerSize = 4;

            // Създаваме пермутация, генерираща всички възможни комбинации от 4 числа в масив от 9 числа(3024 на брой);
            var listOfPermutations = Permutator.GetPermutations(listOfAllNumbers, answerSize).ToList();

            // Разбъркваме създаденият лист от пермутации;
            Suffler.Shuffle(listOfPermutations, new Random());

            // Конвертираме от List<IEnumerable<int>> в List<int>;
            var outputList = listOfPermutations.SelectMany(x => x).ToList();

            // Конвертираме от List<int> в List<string>;
            var resultList = Converter(listOfPermutations);

            int guessCounter = 1;

            /*   
             *   Започваме да премахваме от листа с пермутации всички варианти чиито 
             *   брой бикове и крави не са като на първоначалното предположение.
             *   След това продължаваме същото с вече подрязаният лист.
             *   Повтаряме докато остане само вярната, ако не я намерим преди това.
            */
            while (resultList.Count > 1)
            {
                var computerGuess = string.Join("", resultList[0]);

                if (guessCounter == 1)
                {
                    Console.WriteLine($"My firs guess is: {computerGuess}");
                }

                Console.WriteLine($"My {guessCounter} guess is: {computerGuess}");
                

                Console.Write("Enter bulls: ");
                int bulls = int.Parse(Console.ReadLine());

                Console.Write("Enter cows: ");
                int cows = int.Parse(Console.ReadLine());

                // Обикаляме всяка една пермутация
                for (int answer = resultList.Count - 1; answer >= 0; answer--)
                {
                    // Създаваме бикове и крави сетнати на нула, за проверка с първоначално въведените;
                    int currentBulls = 0;
                    int currentCows = 0;

                    // Сравняваме всяко число от текущата 4 цифрена пермутация със всяко число от първото предположение на компютъра;
                    for (int currentNumber = 0; currentNumber < answerSize; currentNumber++)
                    {

                        // Ако позицията на числото в пермутацията съвпадне с позицията на числото в първото предположение на компютъра;
                        if (resultList[answer][currentNumber] == computerGuess[currentNumber])
                        {
                            // Увеличаваме текущите бикове;
                            currentBulls++;
                        }

                        // Ако пермутацията само съдържа числото от предположението на компютъра; 
                        else if (resultList[answer].Contains(computerGuess[currentNumber]))
                        {
                           // Увеличаваме текущите кравите;
                            currentCows++;
                        }

                    }

                    /*
                     *  Проверяваме ако текущият брой бикове или крави се различава от първоначалните, ако има разлика 
                     *  означава че текущото число не е еквивалентно на последното предположение затова го премахваме от листа с пермутации;
                     */
                    if ((currentBulls != bulls) || (currentCows != cows))
                    {
                        resultList.RemoveAt(answer);
                    }
                }
                guessCounter++;
            }
           
            if (resultList.Count != 1)
            {
                Console.WriteLine("You have mistake!");
            }

            Console.WriteLine($"I guessed it, your number is: {resultList[0]}!");
            Console.WriteLine($"It took me {guessCounter} attempts to guess the number!");                   
        }

        public static List<string> Converter(List<IEnumerable<int>> list)
        {
            var resultList = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                var currentIEnumerableListOfInt = list[i];
                var arrOfFourDigits = currentIEnumerableListOfInt as int[]
                    ?? currentIEnumerableListOfInt.ToArray();
                var currentString = string.Join("", arrOfFourDigits);
                resultList.Add(currentString);
            }           
            return resultList;
        }
    }
}
