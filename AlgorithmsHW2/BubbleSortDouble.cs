using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    public class BubbleSortDouble : ISorts
    {
        double[] doublesArray1;
        public BubbleSortDouble(List<double> sortDouble)
        {
            doublesArray1 = new double[sortDouble.Count];
            doublesArray1 = sortDouble.ToArray();
        }

        /// <summary>
        /// Reads the file where the doubles are stored and sorts them in a different file using the bubble method.
        /// </summary>
        /// 
        /// <reference>
        /// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-3.php 
        /// https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash
        /// https://stackoverflow.com/questions/16195092/optimized-bubble-sort-java
        /// </reference>
        /// 
        public void BubbleSort()
        {
            double keyTemp;
            int lastSwap = doublesArray1.Length - 1;
            for (int x = 0; x <= doublesArray1.Length - 1; x++)
            {
                int currentSwap = -1;
                for (int y = 0; y < lastSwap; y++)
                {
                    if (doublesArray1[y] > doublesArray1[y + 1])
                    {
                        keyTemp = doublesArray1[y + 1];
                        doublesArray1[y + 1] = doublesArray1[y];
                        doublesArray1[y] = keyTemp;
                        currentSwap = y;
                    }
                }
                lastSwap = currentSwap;
            }

        }

        public void ChangeGuidsToInt64()
        {
            throw new NotImplementedException();
        }

        public double[] GetBubbleSortDouble()
        {
            return doublesArray1;

        }


        public void Sort()
        {
            BubbleSort();
        }

        public void WriteSortList()
        {
            string path = @"c:\Workspace\Algorithms\DoubleBubbleSortDry.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < GetBubbleSortDouble().LongLength; i++)
                    {
                        file.WriteLine(GetBubbleSortDouble()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }
    }
}
