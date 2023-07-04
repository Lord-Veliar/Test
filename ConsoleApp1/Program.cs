using System;
using System.ComponentModel;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void read(string path, List<int[]> L)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    int[] arr = new int[2];
                    arr[0] = int.Parse(line[0]);
                    arr[1] = int.Parse(line[1]);
                    L.Add(arr);
                }
            }
        }
        static void outPut(List<int[]> L)
        {
            foreach (int[] arr in L)
            {
                Console.WriteLine("{0,5} - {1,-5}", arr[0], arr[1]);
            }
        }
        static void sort(List<int[]> L)
        {
            int max = 0;
            foreach (int[] arr in L)
            {
                if (arr[0] > max)
                {
                    max = arr[0];
                }
                if (arr[1] > max)
                {
                    max = arr[1];
                }
            }
            int countStart = 0;
            int countEnd = L.Count;
            for (int i = 0; i < max; i++)
            {
                if (countStart < countEnd)
                {
                    for (int j = 0; j < countEnd; j++)
                    {
                        if (L[j][0] == i && j >= countStart)
                        {
                            int[] arr = new int[] { L[j][0], L[j][1] };
                            L.Remove(L[j]);
                            L.Insert(countStart, arr);
                            countStart++;
                        }
                        else if (L[j][1] == i && j >= countStart && j < countEnd)
                        {
                            int[] arr = new int[] { L[j][0], L[j][1] };
                            L.Remove(L[j]);
                            L.Insert(countEnd - 1, arr);
                            countEnd--;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

        }

        static int findPath(List<int[]> L)
        {
            int[] arr = new int[L.Count];
            arr[0] = L[0][0];
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + L[i][0] - L[i - 1][1];
            }
            return arr.Max();
        }
        static void Main(string[] args)
        {
            string path = "матрица.txt";
            List<int[]> L = new List<int[]>();
            read(path, L);
            sort(L);
            outPut(L);
            Console.WriteLine(findPath(L));
        }
    }
}