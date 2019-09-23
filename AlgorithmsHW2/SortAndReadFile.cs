using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AlgorithmsHW2
{
    public class SortAndReadFile
    {
        GatherReadData gatherReadData;
        List<int> myBaseInts;
        List<Guid> myBaseGuids;
        List<double> myBaseDoubles;
        List<string> finalSortedData;
        string path = @"C:\Workspace\Algorithms\MyTest.csv";

        public SortAndReadFile()
        {
            myBaseInts = new List<int>();
            myBaseGuids = new List<Guid>();
            myBaseDoubles = new List<double>();
            gatherReadData = new GatherReadData();
        }

        public void ReadInValues()
        {
            foreach (string line in File.ReadLines(path))
            {
                string[] values = line.Split(',');

                gatherReadData.GatherData(Int32.Parse(values[0]), Guid.Parse(values[1]), Double.Parse(values[2]));
            }
        }
    }
}
