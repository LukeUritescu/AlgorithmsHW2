using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    class BubbleSortGuids
    {
        private List<Guid> guidsList;
        private Int64[] firstSectionGuids;
        private Int64[] secondSectionGuids;

        public BubbleSortGuids(List<Guid> sortGuids)
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
        /// Reads Guids and turns them into Int64 first and then sorts them into a different file using the Bubble Method
        /// </summary>
        public void BubbleSort()
        {
            Int64 keyTemp;

            for (int x = 0; x <= firstSectionGuids.Length - 2; x++)
            {
                for (int y = 0; y <= firstSectionGuids.Length - 2; y++)
                {
                    if (firstSectionGuids[y] > firstSectionGuids[y + 1])
                    {
                        keyTemp = firstSectionGuids[y + 1];
                        firstSectionGuids[y + 1] = firstSectionGuids[y];
                        firstSectionGuids[y] = keyTemp;
                    }
                }
            }

        }

        public Int64[] GetBubbleSortDouble()
        {
            return firstSectionGuids;

        }
    }
}
