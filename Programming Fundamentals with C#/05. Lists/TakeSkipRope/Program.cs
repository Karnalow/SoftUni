using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            List<int> numbersList = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            StringBuilder result = new StringBuilder();
            List<string> nonNumbersList = new List<string>();

            foreach (char numberOrNotNumber in word)
            {
                if (char.IsDigit(numberOrNotNumber))
                {
                    numbersList.Add(int.Parse(numberOrNotNumber.ToString()));
                }
                else
                {
                    nonNumbersList.Add(numberOrNotNumber.ToString());
                }
            }

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                    skipList.Add(numbersList[i]);
                }
            }

            int indexForSkip = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(nonNumbersList);

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();

                result.Append(string.Join("", temp));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
        }
    }
}
