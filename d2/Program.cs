using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            double sum = 0;
            int[] arr = new int[100];
            Random random = new Random();
            for (i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1000) + 1;
            }
            double[] arr_sqrt = arr.Select(x => Math.Sqrt(x)).OrderByDescending(x => x).ToArray();
            for (i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0:0.0000}", arr_sqrt[i]);
                sum += arr_sqrt[i];
            }
            Console.WriteLine("求和：{0:0.0000}", sum);
            Console.WriteLine("平均值：{0:0.0000}", sum / 100);
        }
    }
}
