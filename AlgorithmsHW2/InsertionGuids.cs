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
    class InsertionGuids
    {
        private List<Guid> guidsList;
        private Int64[] firstSectionGuids;
        private Int64[] secondSectionGuids;

        public InsertionGuids(List<Guid> sortGuids)
        {
            guidsList = new List<Guid>(sortGuids);
            firstSectionGuids = new Int64[sortGuids.Count];
            secondSectionGuids = new Int64[sortGuids.Count];
        }

        public void changeGuidsToInt64()
        {

            for (int i = 0; i < guidsList.Count; i++)
            {
                string[] values = guidsList[i].ToString().Split('-');
                firstSectionGuids[i] = (Int64.Parse(values[0].ToString(), System.Globalization.NumberStyles.HexNumber));
                secondSectionGuids[i] = ((Int64.Parse(values[1].ToString(), System.Globalization.NumberStyles.HexNumber)));

            }

        }

        /// <summary>
        /// Reads Guids and turns them into Int64 first and then sorts them into a different file using the Insertion Method
        /// </summary>
        public void Insertion()
        {
            for (int i = 0; i < firstSectionGuids.LongLength - 1; i++)
            {              
                for (int j = i + 1; j > 0; j--)
                {

                    if (firstSectionGuids[j - 1] > firstSectionGuids[j])
                    {
                        Int64 keyTemp = firstSectionGuids[j - 1];
                        firstSectionGuids[j - 1] = firstSectionGuids[j];
                        firstSectionGuids[j] = keyTemp;
                    }
                }
            }
        }

        public Int64[] GetGuidInsertion()
        {
            return firstSectionGuids;
        }
    }
}

