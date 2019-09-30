using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    /// <summary>
    /// References: 
    /// https://www.cs.usfca.edu/~galles/visualization/RadixSort.html
    /// https://stackoverflow.com/questions/2685035/is-there-a-good-radixsort-implementation-for-floats-in-c-sharp
    /// </summary>
    public class RadixSort
    {
        double[] finalSortedArray;
        double[] sortList;
        public RadixSort(List<double> sortListBase)
        {
            finalSortedArray = new double[sortListBase.Count];
            sortList = new double[sortListBase.Count];
            sortList = sortListBase.ToArray();
        }

        public void radixSort()
        {
            long[] tempList = new long[sortList.LongLength];
            long[] convertedListDoubles = new long[sortList.LongLength];

            ///BitConverter.GetBytes converts the specified array into an array of bytes
            ///BitConverterr.ToInt64 converts that array of bytes into a 64-bit signed integer
            ///This helps convert our doubles to longs
            ///In this instance the arrays are both Int64 so we don't need to convert which saves a little bit of time
            for (int i = 0; i < sortList.LongLength; i++)
            {
                convertedListDoubles[i] = BitConverter.ToInt64(BitConverter.GetBytes(sortList[i]));
            }

            int groupLength = 4;
            int bitLength = 64;

            int[] count = new int[1 << groupLength];
            int[] prefixArray = new int[1 << groupLength];
            long groups = bitLength / groupLength;
            long mask = (1 << groupLength) - 1;
            long negatives = 0, positives = 0;


            for (int c = 0, shift = 0; c < groups; c++, shift += groupLength)
            {
                for(int j = 0; j < count.Length; j++)
                {
                    count[j] = 0;
                }

                for (int i = 0; i < convertedListDoubles.LongLength; i++)
                {
                    count[(convertedListDoubles[i] >> shift) & mask]++;

                    if (c == 0 && convertedListDoubles[i] < 0)
                        negatives++;
                }
                if (c == 0)
                {
                    positives = convertedListDoubles.LongLength - negatives;
                }

                prefixArray[0] = 0;
                for(int i = 1; i < count.LongLength; i++)
                {
                    prefixArray[i] = prefixArray[i - 1] + count[i - 1];
                }

                for (int i = 0; i < convertedListDoubles.Length; i++)
                {
                    long index = prefixArray[(convertedListDoubles[i] >> shift) & mask]++;
                    if(c == groups - 1)
                    {
                        if(convertedListDoubles[i] < 0)
                        {
                            index = positives - (index - negatives) - 1;
                        }
                        else
                        {
                             index += negatives;
                        }
                    }
                    tempList[index] = convertedListDoubles[i];
                }
                tempList.CopyTo(convertedListDoubles, 0);
            }




            finalSortedArray = new double[sortList.LongLength];

            for (int i = 0; i < convertedListDoubles.LongLength; i++)
            {
                finalSortedArray[i] = BitConverter.ToDouble(BitConverter.GetBytes(convertedListDoubles[i]), 0);
            }

            //return finalSortedList;

        }

        public double[] GetRadixSort()
        {
            return finalSortedArray;
        }

    }
}
