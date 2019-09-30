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

            readFile.SortTheAlgorithms();

            Console.ReadLine();

        }
    }
}
