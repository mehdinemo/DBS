using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbscanImplementation
{
    public class Distances
    {
        //(0-1)
        public static double dist(MyCustomDatasetItem p1, MyCustomDatasetItem p2)
        {
            if (p1.Columns.ContainsKey(p2.Row))
                return p1.Columns[p2.Row];
            else if (p2.Columns.ContainsKey(p1.Row))
                return p2.Columns[p1.Row];
            else
                return double.PositiveInfinity;

        }
    }
}
