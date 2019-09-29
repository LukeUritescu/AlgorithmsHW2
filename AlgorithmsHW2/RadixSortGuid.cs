using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    public class RadixSortGuid
    {
        List<Guid> sortGuidList;

        Int64[] finalSortedArray;

        private Int64[] firstSectionGuids;
        private Int64[] secondSectionGuids;

        public RadixSortGuid(List<Guid> sortListBase)
        {
            finalSortedArray = new Int64[sortListBase.Count];

            sortGuidList = new List<Guid>(sortListBase);
            firstSectionGuids = new Int64[sortGuidList.Count];
            secondSectionGuids = new Int64[sortGuidList.Count];
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

        public void radixSort()
        {
            long[] tempList = new long[firstSectionGuids.Length];
            long[] convertedListDoubles = new long[firstSectionGuids.LongLength];


            for (int i = 0; i < firstSectionGuids.LongLength; i++)
            {
                convertedListDoubles[i] = BitConverter.ToInt64(BitConverter.GetBytes(firstSectionGuids[i]));
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
                for (int j = 0; j < count.Length; j++)
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
                for (int i = 1; i < count.LongLength; i++)
                {
                    prefixArray[i] = prefixArray[i - 1] + count[i - 1];
                }

                for (int i = 0; i < convertedListDoubles.Length; i++)
                {
                    long index = prefixArray[(convertedListDoubles[i] >> shift) & mask]++;
                    if (c == groups - 1)
                    {
                        if (convertedListDoubles[i] < 0)
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




            finalSortedArray = new Int64[firstSectionGuids.LongLength];

            for (int i = 0; i < convertedListDoubles.LongLength; i++)
            {
                finalSortedArray[i] = BitConverter.ToInt64(BitConverter.GetBytes(convertedListDoubles[i]), 0);
            }

            //return finalSortedList;

        }

        public Int64[] GetRadixSort()
        {
            return finalSortedArray;
        }

    }
}

