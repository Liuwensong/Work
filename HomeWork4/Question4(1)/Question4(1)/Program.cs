﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4_1_
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            for(Node<T> x=head;x!=null;x=x.Next)
            {
                action(x.Data);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intList=new GenericList<int>();
            for (int x = 0; x < 10; x++)
                intList.Add(x);
            int sum = 0, max = 0, min = 0;
            intList.ForEach(x => sum += x);
            intList.ForEach(x => { if (max < x) max = x; });
            intList.ForEach(x => { if (min > x) min = x; });
            Console.WriteLine("和为：{0}",sum);
            Console.WriteLine("最大值为：{0}",max);
            Console.WriteLine("最小值为：{0}", min);
        }
    }
}
