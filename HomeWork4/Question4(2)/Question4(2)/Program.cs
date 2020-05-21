using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Question4_2_
{
    public delegate void ClockEvent();
    public class Clock
    {
        public event ClockEvent Tick;
        public event ClockEvent Alarm;
        public void Run(int x)
        {
            if (x % 5 == 0)
                Alarm();
            else
                Tick();
        }
    }
    public class Reality
    {
        public Clock clock1 = new Clock();
        public Reality()
        {
            clock1.Tick += clock_Tick;
            clock1.Alarm += clock_Alarm;
        }
        void clock_Tick()
        {
            Console.WriteLine("闹钟正在走时。");
        }
        void clock_Alarm()
        {
            Console.WriteLine("闹钟正在响铃。");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Reality reality = new Reality();
            for(int i=1;i<31;i++)
            {
                reality.clock1.Run(i);
                Thread.Sleep(1000);
            }
        }
    }
}
