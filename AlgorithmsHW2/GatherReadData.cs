using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    public class GatherReadData
    {
        public List<int> myInts;
        public List<Guid> myGuids;
        public List<double> myDoubles;

        public GatherReadData()
        {
            myInts = new List<int>();
            myGuids = new List<Guid>();
            myDoubles = new List<double>();
        }

        public void GatherData(Int32 readInt, Guid readGuid, double readDouble)
        {
            myInts.Add(readInt);
            myGuids.Add(readGuid);
            myDoubles.Add(readDouble);
        }

    }
}
