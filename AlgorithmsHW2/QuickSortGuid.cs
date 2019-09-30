﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    /// <summary>
    /// References: 
    /// https://github.com/bephrem1/backtobackswe/blob/master/Sorting%2C%20Searching%2C%20%26%20Heaps/Quicksort/Quicksort.java
    /// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php
    /// </summary>
    public class QuickSortGuid : ISorts
    {
        private List<Guid> sortGuidList;
        private List<Int64> firstSectionGuids;
        private List<Int64> secondSectionGuids;

        public QuickSortGuid(List<Guid> sortListBase)
        {
            sortGuidList = new List<Guid>(sortListBase);
            firstSectionGuids = new List<Int64>();
            secondSectionGuids = new List<Int64>();

        }

        public void ChangeGuidsToInt64()
        {

            for (int i = 0; i < sortGuidList.Count; i++)
            {
                string[] values = sortGuidList[i].ToString().Split('-');
                firstSectionGuids.Add((Int64.Parse(values[0].ToString(), System.Globalization.NumberStyles.HexNumber)));
                secondSectionGuids.Add((Int64.Parse(values[1].ToString(), System.Globalization.NumberStyles.HexNumber)));

            }
        }

        //public List<Int64> GetQuickSortGuidList()
        //{
        //    return firstSectionGuids;
        //}


        public void QuickSortData(int positionLeft, int positionRight)
        {

            if (positionLeft < positionRight)
            {
                var pivot = Partition(firstSectionGuids, positionLeft, positionRight);
                QuickSortData(positionLeft, pivot - 1);

                QuickSortData(pivot + 1, positionRight);

            }
        }

        public int Partition(List<Int64> sortList, int positionLeft, int positionRight)
        {

            var pivot = FindingPivot(firstSectionGuids, positionLeft, positionRight);

            return pivot;
        }


        private int FindingPivot(List<Int64> sortList, int positionLeft, int positionRight)
        {
            var pivot = sortList[positionRight];
            int i = positionLeft - 1;

            for (int j = positionLeft; j < positionRight; j++)
            {
                if (sortList[j] <= pivot)
                {
                    i++;
                    Swap(firstSectionGuids, i, j);
                    SwapGuids(sortGuidList, i, j);
                }
            }
            Swap(firstSectionGuids, i + 1, positionRight);
            SwapGuids(sortGuidList, i + 1, positionRight);
            return i + 1;
        }

        public void Swap(List<Int64> sortList, int positionLeft, int positionRight)
        {
            Int64 tempValue = sortList[positionLeft];
            sortList[positionLeft] = sortList[positionRight];
            sortList[positionRight] = tempValue;

        }
        public void SwapGuids(List<Guid> sortGuidList, int positionLeft, int positionRight)
        {
            Guid tempGuidValue = sortGuidList[positionLeft];
            sortGuidList[positionLeft] = sortGuidList[positionRight];
            sortGuidList[positionRight] = tempGuidValue;
        }

        public void Sort()
        {
            QuickSortData(0, sortGuidList.Count - 1);
        }

        public List<Guid> GetQuickSortGuidList()
        {
            return sortGuidList;
        }

        public void WriteSortList()
        {
            string path = @"c:\Workspace\Algorithms\GuidQuickSortDry.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < GetQuickSortGuidList().Count; i++)
                    {
                        file.WriteLine(GetQuickSortGuidList()[i].ToString());
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
