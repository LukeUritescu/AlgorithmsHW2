using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    public class InsertionDouble
    {
        double[] doublesArray1;
        public InsertionDouble(List<double> sortDouble)
        {
            doublesArray1 = new double[sortDouble.Count];
            doublesArray1 = sortDouble.ToArray();
        }


        /// <summary>
        /// Reads the file where the doubles are stored and sorts them in a different file using Insertion method.
        /// </summary>
        public void Insertion()
        {
            for(int i = 0; i < doublesArray1.LongLength -1; i++)
            {
                //Little more optomize by reducing the shifts that are larger than P as they are already sorted
                //https://stackoverflow.com/questions/43363071/why-is-my-selection-sort-algorithm-consistently-faster-than-my-insertion-sort
                double p = doublesArray1[i];
                for (int j = i; j > 0 && doublesArray1[j-1] > p; j--)
                {

                    if (doublesArray1[j - 1] > doublesArray1[j])
                    {
                        double keyTemp = doublesArray1[j - 1];
                        doublesArray1[j - 1] = doublesArray1[j];
                        doublesArray1[j] = keyTemp;
                    }
                }
            }
        }

        public double[] GetDoubleInsertion()
        {
            return doublesArray1;
        }
    }
}
