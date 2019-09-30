using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    /// <summary>
    /// Referernces:
    /// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-6.php
    /// https://www.geeksforgeeks.org/insertion-sort/
    /// </summary>
    public class InsertionDouble : ISorts
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

        public void Sort()
        {
            Insertion();
        }

        public void WriteSortList()
        {
            string path = @"c:\Workspace\Algorithms\DoubleInsertionSortDry.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < GetDoubleInsertion().LongLength; i++)
                    {
                        file.WriteLine(GetDoubleInsertion()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void ChangeGuidsToInt64()
        {
            throw new NotImplementedException();
        }
    }
}
