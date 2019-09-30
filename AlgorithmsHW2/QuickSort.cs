using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AlgorithmsHW2
{
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
