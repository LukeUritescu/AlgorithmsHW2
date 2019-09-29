using System;
using System.Diagnostics;
using System.Threading;

namespace AlgorithmsHW2
{


    /// <summary>
    /// BIG TO DO!!!!! 
    /// CREEAATE  READ FILE CLASS TO KEEP CODE DRY!! 
    /// CREEATE QUICKSORT CLASS TO KEEP DRY
    /// CREEATE RADIX SORT CLASS TO KEEP DRY
    /// </summary>


    class Program
    {
        static ReadFileAndSort readFile;
        static PersonalStopWatch stopWatch;
        static void Main(string[] args)
        {
            readFile = new ReadFileAndSort();
            readFile.QuickSortDoubleData();
            readFile.RadixSortDoubleData();
        }
    }
}
