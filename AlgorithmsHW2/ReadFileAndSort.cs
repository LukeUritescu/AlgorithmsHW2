using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlgorithmsHW2
{
    /// <summary>
    /// This whole class is a lot of similar functions and their only difference is for the type of sort
    /// </summary>
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

        //IN the folder there is three csv, one for 6k values, one for 100k values, and one for 1million values
        //Just choose the path as the one you want to use
        //WARNING! OneMillion value will take Bubble and Insertion sort a lot of time to do. Recommend doing 100k or 6k
        private string path = @"C:\Workspace\Algorithms\AlgorithmsHW2\OneHundredThousandValues.csv";


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
        /// <summary>
        /// Can comment out any of the algorithms in SortTheAlgorithms to see individual performance
        /// </summary>
        public void SortTheAlgorithms()
        {
           
            //Quick Sort
            Console.WriteLine("============Quick Sort============");
            SortGuidData(quickGuidSort, "Quick Sort Guid");
            SortDoubleData(quickSort, "Quick Sort Double");
            //Radix Sort
            Console.WriteLine("============Radix Sort============");
            SortGuidData(radixGuidSort, "Radix Sort Guid");
            SortDoubleData(radixSort, "Radix Sort Double");
            //Bubble Sort
            Console.WriteLine("============Bubble Sort============");
            SortGuidData(bubbleGuid, "Bubble Sort Guid");
            SortDoubleData(bubbleDouble, "Bubble Sort Double");
            //Insertion Sort
            Console.WriteLine("============Insertion Sort============");
            SortGuidData(insertionGuids, "Insertion Sort Guid");
            SortDoubleData(insertionDouble, "Insertion Sort Double");
        }

        //I have two methods one for the guids and the other for Doubles
        public void SortGuidData(ISorts sortingMethod, string nameOfSort)
        {
            sortingMethod.ChangeGuidsToInt64();
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            
            sortingMethod.Sort();

            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed(nameOfSort);

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();

            sortingMethod.WriteSortList();
            stopWatch.StartStopWatch();

            stopWatch.GetTimeElapsed(nameOfSort + " To Write To File");
        }
        public void SortDoubleData(ISorts sortingMethod, string nameOfSort)
        {
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();

            sortingMethod.Sort();

            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed(nameOfSort);

            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();

            sortingMethod.WriteSortList();

            stopWatch.StartStopWatch();
            stopWatch.GetTimeElapsed(nameOfSort + "To Write To File");
            
        }


        
    }
}
