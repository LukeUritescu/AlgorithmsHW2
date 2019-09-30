using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlgorithmsHW2
{
    public class ReadFileAndSort
    {
        PersonalStopWatch stopWatch;
        QuickSort quickSort;
        RadixSort radixSort;
        QuickSortGuid quickGuidSort;
        RadixSortGuid radixGuidSort;
        InsertionDouble insertionDouble;
        InsertionGuids insertionGuids;
        BubbleSortDouble bubbleDouble;
        BubbleSortGuids bubbleGuid;

        private List<int> myBaseInts;
        private List<Guid> myBaseGuids;
        private List<double> myBaseDoubles;
        private List<string> finalSortedData;

        private string path = @"C:\Workspace\Algorithms\SixK.csv";


        public ReadFileAndSort()
        {
            stopWatch = new PersonalStopWatch();
            myBaseInts = new List<int>();
            myBaseGuids = new List<Guid>();
            myBaseDoubles = new List<double>();
            finalSortedData = new List<string>();
            ReadInValues();

            quickSort = new QuickSort(GetMyDoubles());
            radixSort = new RadixSort(GetMyDoubles());
            quickGuidSort = new QuickSortGuid(GetMyGuids());
            radixGuidSort = new RadixSortGuid(GetMyGuids());
            insertionDouble = new InsertionDouble(GetMyDoubles());
            insertionGuids = new InsertionGuids(GetMyGuids());
            bubbleDouble = new BubbleSortDouble(GetMyDoubles());
            bubbleGuid = new BubbleSortGuids(GetMyGuids());

        }

        public void BubbleSortDouble()
        {
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            bubbleDouble.BubbleSort();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Bubble Sort");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedListBubbleDouble(@"c:\Workspace\Algorithms\DoubleBubbleSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Bubble Sort");
            Console.ReadLine();
        }

        public void BubbleSortGuid()
        {
            bubbleGuid.changeGuidsToInt64();
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            bubbleGuid.BubbleSort();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Bubble Sort Guid");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedListBubbleGuid(@"c:\Workspace\Algorithms\GuidBubbleSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Bubble Sort");
            Console.ReadLine();
        }

        public void InsertionSortDouble()
        {
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            insertionDouble.Insertion();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Insertion Sort");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedListInsertionDouble(@"c:\Workspace\Algorithms\DoubleInsertionSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Insertion Sort");
            Console.ReadLine();
        }

        public void InsertionSortGuids()
        {
            insertionGuids.changeGuidsToInt64();
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            insertionGuids.Insertion();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Insertion Sort");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedListInsertionGuids(@"c:\Workspace\Algorithms\GuidInsertionSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Insertion Sort");
            Console.ReadLine();
        }

        public void QuickSortGuidData()
        {
            quickGuidSort.changeGuidsToInt64();
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            quickGuidSort.QuickSortData(0, GetMyGuids().Count - 1);
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Quick Sort Guid");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedGuidQuickSortList(@"c:\Workspace\Algorithms\GuidQuickSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Quick Sort Guid");
            Console.ReadLine();
        }

        public void QuickSortDoubleData()
        {
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            quickSort.QuickSortData(0, GetMyDoubles().Count - 1);
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Quick Sort");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedList(@"c:\Workspace\Algorithms\DoubleQuickSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Quick Sort");
            Console.ReadLine();
        }

        public void RadixSortGuidData()
        {
            radixGuidSort.changeGuidsToInt64();
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            radixGuidSort.radixSort();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Radix Sort Guid");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedListGuidRadix(@"c:\Workspace\Algorithms\GuidRadixSortWithBit.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Radix Sort Guid");
            Console.ReadLine();
        }

        public void RadixSortDoubleData()
        {
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            radixSort.radixSort();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("Radix Sort");
            Console.ReadLine();

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            WriteSortedListRadix(@"c:\Workspace\Algorithms\DoubleRadixSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Radix Sort");
            Console.ReadLine();
        }


        public List<double> GetMyDoubles()
        {
            return myBaseDoubles;
        }

        public List<Guid> GetMyGuids()
        {
            return myBaseGuids;
        }

        public void ReadInValues()
        {
            foreach (string line in File.ReadLines(path))
            {
                string[] values = line.Split(',');


                myBaseInts.Add(Int32.Parse(values[0]));
                myBaseGuids.Add(Guid.Parse(values[1]));
                myBaseDoubles.Add(Double.Parse(values[2]));
            }
        }

        public void WriteSortedListBubbleDouble(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < myBaseDoubles.Count; i++)
                    {
                        file.WriteLine(bubbleDouble.GetBubbleSortDouble()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void WriteSortedListBubbleGuid(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < myBaseDoubles.Count; i++)
                    {
                        file.WriteLine(bubbleGuid.GetBubbleSortDouble()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void WriteSortedListInsertionDouble(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < myBaseDoubles.Count; i++)
                    {
                        file.WriteLine(insertionDouble.GetDoubleInsertion()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void WriteSortedListInsertionGuids(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < myBaseDoubles.Count; i++)
                    {
                        file.WriteLine(insertionGuids.GetGuidInsertion()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void WriteSortedList(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < myBaseDoubles.Count; i++)
                    {
                        file.WriteLine(quickSort.GetQuickSortDoubleList()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void WriteSortedGuidQuickSortList(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < myBaseDoubles.Count; i++)
                    {
                        file.WriteLine(quickGuidSort.GetQuickSortGuidList()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void WriteSortedListGuidRadix(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < radixSort.GetRadixSort().Length; i++)
                    {
                        file.WriteLine(radixGuidSort.GetRadixSort()[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }
        }

        public void WriteSortedListRadix(string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    for (int i = 0; i < radixSort.GetRadixSort().Length; i++)
                    {
                        file.WriteLine(radixSort.GetRadixSort()[i].ToString());
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
