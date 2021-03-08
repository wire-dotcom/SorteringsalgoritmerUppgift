using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();
            Console.WriteLine("SelectionSort! Hur många element vill du skapa?");
            string answer = Console.ReadLine();
            SkapaSlumpLista(tallista, Convert.ToInt32(answer));

            Stopwatch SelectionTime = new Stopwatch();
            SelectionTime.Start();
            SelectionSort(tallista);
            SelectionTime.Stop();
            TimeSpan tsSelection = SelectionTime.Elapsed;
            string elapsedTimeSelection = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           tsSelection.Hours, tsSelection.Minutes, tsSelection.Seconds,
           tsSelection.Milliseconds / 10);
            Console.WriteLine("SelectionSort tid: " + elapsedTimeSelection);
        }
        static void SkapaSlumpLista(List<int> myList, int size)
        {
            Random slump = new Random();

            for (int i = 0; i < size; i++) //skapar ett stort antal slumpt
            {
                myList.Add(slump.Next(10000));
            }
        }
        static void SelectionSort(List<int> myList)
        {
            int temp, smallest;
            for (int i = 0; i < myList.Count - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < myList.Count; j++)
                {
                    if (myList[j] < myList[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = myList[smallest];
                myList[smallest] = myList[i];
                myList[i] = temp;

            }
        }
    }
}
