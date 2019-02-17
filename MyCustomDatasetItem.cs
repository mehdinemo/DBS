using System;
using System.Collections.Generic;

namespace DbscanImplementation
{
    public class MyCustomDatasetItem : DatasetItemBase
    {
        //public double X;
        //public double Y;

        /// <summary>
        ///   Gets the sparse row index vector.
        /// </summary>
        /// 
        public string Row { get; private set; }
        /// <summary>
        ///   Gets the sparse column index vector.
        /// </summary>
        /// 
        public Dictionary<string,double> Columns { get; private set; }
        /// <summary>
        ///   Gets the values vector.
        /// </summary>
        /// 
        //public double[] Values { get; private set; }

        public MyCustomDatasetItem(string row/*, Dictionary<string,double> Columns*/)//double x, double y)
        {
            //X = x;
            //Y = y;
            Row = row;
            Columns = new Dictionary<string, double>();
        }
    }
}