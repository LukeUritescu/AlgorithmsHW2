using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    public class BubbleSortDouble
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
        /// </reference>
        /// 
        public void BubbleSort()
        {
            double keyTemp;

            for (int x = 0; x <= doublesArray1.Length - 2; x++)
            {
                for (int y = 0; y <= doublesArray1.Length - 2; y++)
                {
                    if (doublesArray1[y] > doublesArray1[y + 1])
                    {
                        keyTemp = doublesArray1[y + 1];
                        doublesArray1[y + 1] = doublesArray1[y];
                        doublesArray1[y] = keyTemp;
                    }
                }
            }

        }

        public double[] GetBubbleSortDouble()
        {
            return doublesArray1;

        }


    }
}
