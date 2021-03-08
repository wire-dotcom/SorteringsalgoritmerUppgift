using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();
            List<int> tallistaSorterad;

            Console.WriteLine("QuickSort Test! Hur lång ska listan vara?");
            string svar = Console.ReadLine();
            Random random = new Random();
            for (int i = 0; i < Convert.ToInt32(svar); i++)
            {
                tallista.Add(random.Next(0, 1000000));

            }

            Stopwatch QuickTime = new Stopwatch();
            QuickTime.Start();

            tallistaSorterad = QuickSort(tallista);

            QuickTime.Stop();
            TimeSpan tsQuick = QuickTime.Elapsed;
            string elapsedTimeQuick = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           tsQuick.Hours, tsQuick.Minutes, tsQuick.Seconds,
           tsQuick.Milliseconds / 10);
            Console.WriteLine("QuickTime tid: " + elapsedTimeQuick);

            foreach(int x in tallistaSorterad)
            {
                Console.WriteLine(x);
            }
        }
        static List<int> QuickSort(List<int> lst)
        {
            if (lst.Count <= 1)
                return lst;
            int pivotIndex = lst.Count / 2;
            int pivot = lst[pivotIndex];
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < lst.Count; i++)
            {
                if (i == pivotIndex) continue;

                if (lst[i] <= pivot)
                {
                    left.Add(lst[i]);
                }
                else
                {
                    right.Add(lst[i]);
                }
            }

            List<int> sorted = QuickSort(left);
            sorted.Add(pivot);
            sorted.AddRange(QuickSort(right));
            return sorted;
        }
    }
}
