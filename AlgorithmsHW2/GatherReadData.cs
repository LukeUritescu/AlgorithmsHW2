using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHW2
{
    public class GatherReadData
    {
        protected List<int> myInts;
        protected List<Guid> myGuids;
        protected List<double> myDoubles;

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

        public int GetMyInts(int i)
        {
           return this.myInts[i];
        }

        public Guid GetMyGuid(int i)
        {
            return this.myGuids[i];
        }

        public double GetMyDouble(int i)
        {
            return this.myDoubles[i];
        }
    }
}
