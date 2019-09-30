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
                //double keyTemp = doublesArray1[i];
                //int j = i - 1;

                //while (j >= 0 && doublesArray1[j] > keyTemp)
                //{
                //    doublesArray1[j + 1] = doublesArray1[j];
                //    j = j - 1;
                //}
                //doublesArray1[j + 1] = keyTemp;
                for (int j = i + 1; j > 0; j--)
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
