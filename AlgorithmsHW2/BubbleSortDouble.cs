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
