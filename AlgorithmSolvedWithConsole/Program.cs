using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        public static string StringChallenge(int num)
        {
            var hours = (int)Math.Floor((double)num / 60);
            var minutes = num % 60;
            return hours.ToString() + ":" + minutes.ToString();
        }
        public static string SearchingChallenge(string str)
        {
            bool isBeforeNumber = false;
            List<int> lstNumbers = new List<int>();
            List<int> lstTemporary = new List<int>();
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9')
                {
                    lstTemporary.Add(Convert.ToInt32(c.ToString()));
                    isBeforeNumber = true;
                }
                else
                {
                    if (isBeforeNumber)
                    {
                        lstNumbers.Add(TemporaryToNumbers(lstTemporary));
                        lstTemporary.Clear();
                    }
                    isBeforeNumber = false;
                }
            }
            if(lstTemporary.Count > 1)
            {
                lstNumbers.Add(TemporaryToNumbers(lstTemporary));
                lstTemporary.Clear();
            }
            
            int sum = 0;
            foreach (var item in lstNumbers)
            {
                sum += item;
            }
            lstNumbers.Clear();
            return sum.ToString();
        }

        static int TemporaryToNumbers (List<int> lstTemporary)
        {
            int tempLength = lstTemporary.Count;
            int sum = 0;
            for (int i = 0; i < tempLength; i++)
            {
                sum += lstTemporary[i] * (int)Math.Pow((double)10, (double)(tempLength - i - 1));
            }
            return sum;
        }

        public static int ArrayChallenge(int[] arr)
        {
            List<int> differentNumbers = new List<int>();
            List<int> differentCounter = new List<int> ();
            int mode = -1;
            int firstValue = arr[0];
            List<int> lstArray = arr.ToList();
            lstArray.Sort();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!differentNumbers.Contains(arr[i]))
                {
                    differentNumbers.Add(arr[i]);
                    differentCounter.Add(1);
                }
                else
                {
                    int index = differentNumbers.IndexOf(arr[i]);
                    differentCounter[index] += 1; 
                }
            }
            int counter = 1;
            for (int i = 0; i < differentNumbers.Count; i++)
            {
                if (differentCounter[i] > counter)
                {
                    counter = differentCounter[i];
                    mode = differentNumbers[i];
                }
            }
            return mode;
        }
        static void Main(string[] args)
        {
            int choice = 0;
            while (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Wrong input! Enter choice number again:");
            }
            Console.WriteLine(StringChallenge(choice));
            Console.WriteLine(SearchingChallenge(Console.ReadLine()));
            Console.WriteLine(ArrayChallenge(new int[] {3,4,5,6,2,1}));
        }
    }
}
