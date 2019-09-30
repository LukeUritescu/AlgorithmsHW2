﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    class BubbleSortGuids
    {
        private List<Guid> sortGuidList;
        private Int64[] firstSectionGuids;
        private Int64[] secondSectionGuids;

        public BubbleSortGuids(List<Guid> sortGuids)
        {
            sortGuidList = new List<Guid>(sortGuids);
            firstSectionGuids = new Int64[sortGuids.Count];
            secondSectionGuids = new Int64[sortGuids.Count];
        }

        public void changeGuidsToInt64()
        {

            for (int i = 0; i < sortGuidList.Count; i++)
            {
                string[] values = sortGuidList[i].ToString().Split('-');
                firstSectionGuids[i] = (Int64.Parse(values[0].ToString(), System.Globalization.NumberStyles.HexNumber));
                secondSectionGuids[i] = ((Int64.Parse(values[1].ToString(), System.Globalization.NumberStyles.HexNumber)));

            }

        }
        /// <summary>
        /// Reads Guids and turns them into Int64 first and then sorts them into a different file using the Bubble Method
        /// </summary>
        public void BubbleSort()
        {
            Int64 keyTemp = 0;
            int lastSwap = firstSectionGuids.Length - 1;

            for (int x = 0; x <= firstSectionGuids.Length - 2; x++)
            {
                int currentSwap = -1;
                for (int y = 0; y < lastSwap; y++)
                {
                    if (firstSectionGuids[y] > firstSectionGuids[y + 1])
                    {
                        Swap(keyTemp, y);
                        SwapGuids(y);
                        currentSwap = y;
                    }
                }
                lastSwap = currentSwap;
            }

        }

        public void Swap(Int64 keyTemp, int y)
        {
            keyTemp = firstSectionGuids[y + 1];
            firstSectionGuids[y + 1] = firstSectionGuids[y];
            firstSectionGuids[y] = keyTemp;
        }

        public void SwapGuids(int y)
        {
            Guid keyTempGuid = sortGuidList[y + 1];
            sortGuidList[y + 1] = sortGuidList[y];
            sortGuidList[y] = keyTempGuid;
        }

        //public Int64[] GetBubbleSortDouble()
        //{
        //    return firstSectionGuids;
        //}

        public List<Guid> GetBubbleSortDouble()
        {
            return sortGuidList;
        }
    }
}
