using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DbscanImplementation
{
    class Program
    {
        //public static Int64 attributes_num;
        static void Main(string[] args)
        {        
            MyCustomDatasetItem[] featureData = { };
            List<MyCustomDatasetItem> testPoints = new List<MyCustomDatasetItem>();            
            //Dictionary<string, List<Tuple<string, double>>> testPoints = new Dictionary<string, List<Tuple<string, double>>>();

            StreamReader lines = new StreamReader(@"B:\TrendQuery\output.txt");//Source\tTarget\tWeight
            string line;
            Int64 row = 22;
            List<Int64> columns = new List<Int64>();
            List<double> data = new List<double>();
            //attributes_num = 0;

            //set points
            //List<string> nodes = new List<string>();
            while ((line = lines.ReadLine()) != null)
            {
                string[] tmp = line.Split('\t');
                int indx = contains_MDS(testPoints, tmp[0]);
                if (indx == -1)
                    testPoints.Add(new MyCustomDatasetItem(tmp[0]));
                else
                    testPoints[indx].Columns.Add(tmp[1], double.Parse(tmp[2]));
                indx = contains_MDS(testPoints, tmp[1]);
                if (indx == -1)
                    testPoints.Add(new MyCustomDatasetItem(tmp[1]));
                else
                    testPoints[indx].Columns.Add(tmp[0], double.Parse(tmp[2]));

            }
            

            featureData = testPoints.ToArray();
            HashSet<MyCustomDatasetItem[]> clusters;

            var dbs = new DbscanAlgorithm<MyCustomDatasetItem>(((x, y) => Distances.dist(x, y)));//Math.Sqrt(((x.X - y.X) * (x.X - y.X)) + ((x.Y - y.Y) * (x.Y - y.Y))));
            dbs.ComputeClusterDbscan(allPoints: featureData, epsilon: 200, minPts: 10, clusters: out clusters);

            List<string> cluster_points = new List<string>();
            int k = 1;
            foreach (var cluster in clusters)
            {                
                for (int i = 0; i < cluster.Length; i++)
                    cluster_points.Add(cluster[i].Row.ToString() + "\t" + k.ToString());
                k++;
            }
            File.WriteAllLines(@"B:\TrendQuery\DBSClusters.txt", cluster_points.ToArray<string>());
        }
        
        static int contains_MDS(List<MyCustomDatasetItem> testPoints,string p)
        {
            ////foreach (var item in testPoints)
            ////{
            ////    if (item.Row == p) return true;
            ////}

            for (int i = 0, j = testPoints.Count - 1; i <= j; i++, j--)
            {
                if (testPoints[i].Row == p) return i;
                if (testPoints[j].Row == p) return j;
            }
            return -1;
        }
        static void add_MDS(List<MyCustomDatasetItem> testPoints, string p,double value)
        {

        }
    }
}
