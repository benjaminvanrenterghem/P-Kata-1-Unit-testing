using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if(numbers.Length > 0)
            {
                Char separator = ',';
                Char separatorII = '\n';

                if (numbers.EndsWith(separator)) { numbers = numbers.Substring(0, numbers.Length - 1); } // verwijder trailing komma indien deze bestaat 
                if (numbers.EndsWith(separatorII)) { numbers = numbers.Substring(0, numbers.Length - 2); }

                string[] concatNumbers = numbers.Split(separator, separatorII);

                int total = 0;
                List<int> negatives = new List<int>();

                foreach(string aspNumber in concatNumbers)
                {
                    int parsedNum = int.Parse(aspNumber);
                    if (parsedNum < 0)
                    {
                        negatives.Add(parsedNum);
                    } else if(parsedNum <= 1000) // verwaarlozing >1000
                    {
                        total += parsedNum;
                    }
                }

                if(negatives.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Negatives not allowed.\nRemove the following numbers: ");
                    foreach(int i in negatives) { sb.Append($"{i}, "); }
                    sb.Length = sb.Length - 2; // verwijder trailing komma en spatie 
                    throw new NotSupportedException(sb.ToString());
                }

                return total;
            } else
            {
                return 0;
            }
        }
    }
}
