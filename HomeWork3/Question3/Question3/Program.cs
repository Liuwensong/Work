using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    interface Shape
    {
        bool Isright();
        double Getarea();
    }
    class Rectangle : Shape
    {
        private double length;
        private double width;
        public Rectangle(double length,double width)
        {
            this.length = length;
            this.width = width;
        }
        public bool Isright()
        {
            return (length>0&&width>0&&length != width);
        }
        public double Getarea()
        {
            if (this.Isright())
                return (length * width);
            else
                Console.WriteLine("该形状不合法。");
                return 0;
        }
    }
    class Square : Shape
    {
        private double side;
        public Square(double side)
        {
            this.side = side;
        }
        public bool Isright()
        {
            return (side > 0);
        }
        public double Getarea ()
        {
            if (this.Isright())
                return (side * side);
            else
                Console.WriteLine("该形状不合法。");
                return 0;
        }
    }
    class Triangle : Shape
    {
        private double side1, side2, side3;
        public Triangle(double side1,double side2,double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public bool Isright()
        {
            return (side1>0&&side2>0&&side3>0&&side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1);
        }
        public double Getarea()
        {
            double a = (side1 + side2 + side3) / 3;
            if (this.Isright())
                return (Math.Sqrt(a * (a - side1) * (a - side2) * (a - side3)));
            else
                Console.WriteLine("该形状不合法。");
                return 0;
        }
    }
    class ShapeFactory
    {
        public static Shape getShape(int type)
        {
            Shape shape = null;
            if(type==0)
            {
                shape = new Rectangle(4,3);
            }
            else if (type==1)
            {
                shape = new Square(3);
            }
            else if(type==2)
            {
                shape = new Triangle(3, 4, 5);
            }
            return shape;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            for(int i=0;i<10;i++)
            {
                Shape shape;
                Random ran = new Random();
                int RandKey = ran.Next(0, 2);
                shape = ShapeFactory.getShape(RandKey);
                sum = sum + shape.Getarea();
            }
            Console.WriteLine("面积总和为：{0}", sum);
        }
    }
}
