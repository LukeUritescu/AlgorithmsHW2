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
    /// </summary>


    public class QuickSort
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
    }
}
