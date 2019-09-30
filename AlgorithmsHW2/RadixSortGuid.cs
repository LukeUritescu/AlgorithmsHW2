using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    public class RadixSortGuid
    {
        //This is to take in the  
        List<Guid> sortGuidList;

        /// We are using Arrays for this sort because I wasn't able to get Lists to work
        Int64[] finalSortedArray;

        private Int64[] firstSectionGuids;
        private Int64[] secondSectionGuids;

        /// <summary>
        /// Constructor to get the List of Guids from the class ReadFileAndSort
        /// </summary>
        /// <param name="sortListBase"></param>
        public RadixSortGuid(List<Guid> sortListBase)
        {
            finalSortedArray = new Int64[sortListBase.Count];

            sortGuidList = new List<Guid>(sortListBase);
            firstSectionGuids = new Int64[sortGuidList.Count];
            secondSectionGuids = new Int64[sortGuidList.Count];
        }

        /// <summary>
        /// We treat the Guid elements as strings, split them by '-' then parse them as hexnumbers into an Int64 array
        /// </summary>
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
            ///Temporary array and array of converted Int64 to Longs
            long[] tempArray = new long[firstSectionGuids.Length];
            long[] convertedArrayGuids = new long[firstSectionGuids.LongLength];

            ///BitConverter.GetBytes converts the specified array into an array of bytes
            ///BitConverterr.ToInt64 converts that array of bytes into a 64-bit signed integer
            ///This helps convert our doubles to longs
            ///In this instance the arrays are both Int64 so we don't need to convert which saves a little bit of time
            for (int i = 0; i < firstSectionGuids.LongLength; i++)
            {
                convertedArrayGuids[i] = firstSectionGuids[i];
                //convertedArrayGuids[i] = BitConverter.ToInt64(BitConverter.GetBytes(firstSectionGuids[i]));
            }

            int groupLength = 4;
            int bitLength = 64;
            /* This <<  operator shifts the lefthand operand by the number of bits specified by groupLength*/
            int[] count = new int[1 << groupLength];
            int[] prefixArray = new int[1 << groupLength];
            long groups = bitLength / groupLength;
            long mask = (1 << groupLength) - 1;
            long negatives = 0, positives = 0;


            for (int c = 0, shift = 0; c < groups; c++, shift += groupLength)
            {
                //this resets the count array
                for (int j = 0; j < count.Length; j++)
                {
                    count[j] = 0;
                }
                //counts elements of the c-th group
                for (int i = 0; i < convertedArrayGuids.LongLength; i++)
                {
                    count[(convertedArrayGuids[i] >> shift) & mask]++;
                    //checks ofr negative values
                    if (c == 0 && convertedArrayGuids[i] < 0)
                        negatives++;
                }
                if (c == 0)
                {
                    positives = convertedArrayGuids.LongLength - negatives;
                }
                //calculates prefixes
                prefixArray[0] = 0;
                for (int i = 1; i < count.LongLength; i++)
                {
                    prefixArray[i] = prefixArray[i - 1] + count[i - 1];
                }
                //from convertedArrayGuids to tempArray ordered by the c-th group
                for (int i = 0; i < convertedArrayGuids.Length; i++)
                {
                    long index = prefixArray[(convertedArrayGuids[i] >> shift) & mask]++;
                    if (c == groups - 1)
                    {
                        //This is the last and most important group, if there is a negative
                        //number we put them in the front of theh array and push the positivese back
                        if (convertedArrayGuids[i] < 0)
                        {
                            index = positives - (index - negatives) - 1;
                        }
                        else
                        {
                            index += negatives;
                        }
                    }
                    tempArray[index] = convertedArrayGuids[i];
                }
                    //This repeats the process until the last group of sorting
                tempArray.CopyTo(convertedArrayGuids, 0);
            }



            //Converts backk the longs to Int64
            finalSortedArray = new Int64[firstSectionGuids.LongLength];
            for (int i = 0; i < convertedArrayGuids.LongLength; i++)
            {
                finalSortedArray[i] = convertedArrayGuids[i];
                //finalSortedArray[i] = BitConverter.ToInt64(BitConverter.GetBytes(convertedArrayGuids[i]), 0);
            }

        }

        public Int64[] GetRadixSort()
        {
            return finalSortedArray;
        }

    }
}

