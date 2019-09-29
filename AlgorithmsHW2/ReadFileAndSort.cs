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

        private List<int> myBaseInts;
        private List<Guid> myBaseGuids;
        private List<double> myBaseDoubles;
        private List<string> finalSortedData;

        private string path = @"C:\Workspace\Algorithms\MyTest.csv";

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
            WriteSortedList(@"c:\WOrkspace\Algorithms\DoubleQuickSort.csv");
            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed("Quick Sort");
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
