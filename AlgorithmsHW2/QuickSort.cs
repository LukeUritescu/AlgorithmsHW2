using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AlgorithmsHW2
{
    /// <summary>
    /// References: 
    /// https://github.com/bephrem1/backtobackswe/blob/master/Sorting%2C%20Searching%2C%20%26%20Heaps/Quicksort/Quicksort.java
    /// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php
    /// https://www.youtube.com/watch?v=uXBnyYuwPe8 This one was a great lesson on understanding Quicksort
    /// </summary>


    public class QuickSort : ISorts
    {

        private List<double> sortList;
       

        public QuickSort(List<double> sortListBase)
        {
            sortList = new List<double>(sortListBase);
           
        }


        public List<Double> GetQuickSortDoubleList()
        {
            return sortList;
        }
     

        public void QuickSortData(int positionLeft, int positionRight)
        {
            
            if (positionLeft < positionRight)
            {
                var pivot = Partition(sortList, positionLeft, positionRight);
                QuickSortData(positionLeft, pivot - 1);
    
                QuickSortData(pivot + 1, positionRight);
                
            }
        }

        //
        public int Partition(List<double> sortList, int positionLeft, int positionRight)
        {

            var pivot = sortList[positionRight];
            int i = positionLeft - 1;

            for (int j = positionLeft; j < positionRight; j++)
            {
                if (sortList[j] <= pivot)
                {
                    i++;
                    Swap(sortList, i, j);
                }
            }
            Swap(sortList, i + 1, positionRight);
            return i + 1;
        }

        public void Swap(List<double> sortList, int positionLeft, int positionRight)
        {
            double tempValue = sortList[positionLeft];
            sortList[positionLeft] = sortList[positionRight];
            sortList[positionRight] = tempValue;

        }

        public void Sort()
        {
            QuickSortData(0, sortList.Count - 1);
        }

        public void WriteSortList()
        {
            string path = @"c:\Workspace\Algorithms\DoubleQuickSortDry.csv";
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < sortList.Count; i++)
                    {
                        file.WriteLine(GetQuickSortDoubleList()[i].ToString());
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
