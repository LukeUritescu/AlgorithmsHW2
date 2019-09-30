using System;
using System.Diagnostics;
using System.Threading;

namespace AlgorithmsHW2
{


    /// <summary>
    /// BIG TO DO!!!!! 
    /// </summary>


    class Program
    {
        static ReadFileAndSort readFile;
        static PersonalStopWatch stopWatch;
        static void Main(string[] args)
        {

            readFile = new ReadFileAndSort();

            readFile.BubbleSortDouble();
            readFile.BubbleSortGuid();

            readFile.InsertionSortGuids();
            readFile.InsertionSortDouble();

            readFile.QuickSortGuidData();
            readFile.QuickSortDoubleData();

            readFile.RadixSortGuidData();
            readFile.RadixSortDoubleData();

            Console.ReadLine();

        }
    }
}
