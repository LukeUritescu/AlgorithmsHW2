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
        private List<Guid> sortGuidsList;
        private Int64[] firstSectionGuids;
        private Int64[] secondSectionGuids;

        public InsertionGuids(List<Guid> sortGuids)
        {
            sortGuidsList = new List<Guid>(sortGuids);
            firstSectionGuids = new Int64[sortGuids.Count];
            secondSectionGuids = new Int64[sortGuids.Count];
        }

        public void changeGuidsToInt64()
        {

            for (int i = 0; i < sortGuidsList.Count; i++)
            {
                string[] values = sortGuidsList[i].ToString().Split('-');
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
                Int64 keyTemp = 0;
                Int64 p = firstSectionGuids[i];
                for (int j = i; j > 0 && firstSectionGuids[j-1] > p; j--)
                {

                    if (firstSectionGuids[j - 1] > firstSectionGuids[j])
                    {
                        Swap(keyTemp , j);
                        SwapGuid(j);
                    }
                }
            }
        }

        public void Swap(Int64 keyTemp, int j)
        {
            keyTemp = firstSectionGuids[j - 1];
            firstSectionGuids[j - 1] = firstSectionGuids[j];
            firstSectionGuids[j] = keyTemp;
        }

        public void SwapGuid(int j)
        {
            Guid keyTemp = sortGuidsList[j - 1];
            sortGuidsList[j - 1] = sortGuidsList[j];
            sortGuidsList[j] = keyTemp;
        }


        //public Int64[] GetGuidInsertion()
        //{
        //    return firstSectionGuids;
        //}

        public List<Guid> GetGuidInsertion()
        {
            return sortGuidsList;
        }
    }
}

