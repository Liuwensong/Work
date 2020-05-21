using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] flag = new bool[101];
            for (int i = 0; i < 101; i++)
                flag[i] = true;
            for (int j = 2; j < 51; j++)
                for (int k = 2; k < 101; k++)
                    if (k % j == 0 && k / j != 1)
                        flag[k] = false;
            Console.WriteLine("所有素数如下：");
            for (int i = 2; i < 101; i++)
                if (flag[i])
                    Console.Write("{0} ", i);
        }
    }
}
