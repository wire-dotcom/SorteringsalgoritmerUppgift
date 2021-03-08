using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();
            List<int> tallistaSorterad;

            Console.WriteLine("MergeSort Test! Hur lång ska listan vara?");
            string svar = Console.ReadLine();
            Random random = new Random();
            for (int i = 0; i < Convert.ToInt32(svar); i++)
            {
                tallista.Add(random.Next(0, 1000000));
                
            }
            
            Stopwatch MergeTime = new Stopwatch();
            MergeTime.Start();

            tallistaSorterad = MergeSort(tallista);

            MergeTime.Stop();
            TimeSpan tsMerge = MergeTime.Elapsed;
            string elapsedTimeMerge = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           tsMerge.Hours, tsMerge.Minutes, tsMerge.Seconds,
           tsMerge.Milliseconds / 10);
            Console.WriteLine("MergeTime tid: " + elapsedTimeMerge);
        }
        private static List<int> MergeSort(List<int> tallista)
        {
            if (tallista.Count <= 1)
                return tallista;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = tallista.Count / 2;
            for (int i = 0; i < middle; i++)  
            {
                left.Add(tallista[i]);
            }
            for (int i = middle; i < tallista.Count; i++)
            {
                right.Add(tallista[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
        }
}
