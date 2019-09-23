using System;

namespace AlgorithmsHW2
{
    class Program
    {
        static SortAndReadFile sortAndReadFile;
        static void Main(string[] args)
        {
            sortAndReadFile = new SortAndReadFile();
            sortAndReadFile.ReadInValues();
            Console.ReadLine();
        }
    }
}
