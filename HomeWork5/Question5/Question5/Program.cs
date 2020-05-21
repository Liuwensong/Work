using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    class Order
    {
        public int id { set; get; }
        public string customer { set; get; }
        public List<OrderItem> orderItems = new List<OrderItem>();
        public override string ToString()
        {
            int i = 0;
            if (orderItems == null)
                return "订单为空。";
            else
            {
                Console.WriteLine("订单：" + id + "：");
                foreach (OrderItem x in orderItems)
                {
                    i = i + 1;
                    Console.WriteLine("明细" + i + ": " + x.ToString());
                }
                return "";
            }
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m != null && m.id == id;
        }
    }
    class OrderItem
    {
        public string goodname { set; get; }
        public int price { set; get; }
        public int goodnum { set; get; }
        public int totalprice { set; get; }
        public override string ToString()
        {
            return "商品名：" + goodname + " 商品单价：" + price + " 数目：" + goodnum + " 总价：" + (price * goodnum);
        }
        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.goodname == goodname && m.price == price && m.goodnum == goodnum;
        }
    }
    class OrderService
    {
        public static List<Order> orders = new List<Order>();
        public static void Add()
        {
            Order order = new Order();
            Console.WriteLine("请输入订单号。");
            order.id = int.Parse(Console.ReadLine());
            int flag1 = 0;
            foreach (Order x in orders)
            {
                if (x.Equals(order))
                {
                    flag1 = 1;
                    Console.WriteLine("已有该订单。");
                    break;
                }
            }
            if (flag1 == 0)
            {
                Console.WriteLine("请输入订单明细数。");
                int n = int.Parse(Console.ReadLine());
                for (int i = 1; i < n + 1; i++)
                {
                    OrderItem orderItem = new OrderItem();
                    Console.WriteLine("请输入明细" + i + "的商品名：");
                    orderItem.goodname = Console.ReadLine();
                    Console.WriteLine("请输入明细" + i + "的商品单价：");
                    orderItem.price = int.Parse(Console.ReadLine());
                    Console.WriteLine("请输入明细" + i + "的商品数目：");
                    orderItem.goodnum = int.Parse(Console.ReadLine());
                    int flag2 = 0;
                    foreach (OrderItem x in order.orderItems)
                    {
                        if (x.Equals(orderItem))
                        {
                            flag2 = 1;
                            Console.WriteLine("已有该明细。");
                        }
                    }
                    if (flag2 == 0)
                    {
                        order.orderItems.Add(orderItem);
                    }

                }
                Console.WriteLine("订单明细输入完成，成功添加该订单。");
                orders.Add(order);
            }
        }
        public static void Delete()
        {
            Order order = new Order();
            Console.WriteLine("请输入要删除的订单号。");
            order.id = int.Parse(Console.ReadLine());
            int flag3 = 0;
            foreach (Order x in orders)
            {
                if (x.Equals(order))
                {
                    flag3 = 1;
                    orders.Remove(x);
                    Console.WriteLine("成功删除该订单。");
                    break;
                }
            }
            if (flag3 == 0)
            {
                Console.WriteLine("未找到该订单，删除失败。");
            }
        }
        public static void Change()
        {
            Order order = new Order();
            Console.WriteLine("请输入要修改的订单号。");
            order.id = int.Parse(Console.ReadLine());
            int flag4 = 0;
            foreach (Order x in orders)
            {
                if (x.Equals(order))
                {
                    OrderItem orderItem = new OrderItem();
                    Console.WriteLine("请输入要修改的明细的商品名：");
                    orderItem.goodname = Console.ReadLine();
                    Console.WriteLine("请输入要修改的明细的商品单价：");
                    orderItem.price = int.Parse(Console.ReadLine());
                    Console.WriteLine("请输入要修改的明细的商品数目：");
                    orderItem.goodnum = int.Parse(Console.ReadLine());
                    int flag5 = 0;
                    foreach (OrderItem y in x.orderItems)
                    {
                        if (y.Equals(orderItem))
                        {
                            Console.WriteLine("请输入对应数字以完成对应操作：1、修改明细商品名。2、修改明细商品单价。3、修改明细商品数目。");
                            switch (int.Parse(Console.ReadLine()))
                            {
                                case 1:
                                    Console.WriteLine("请输入修改后的明细商品名称。");
                                    y.goodname = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("请输入修改后的明细商品单价。");
                                    y.price = int.Parse(Console.ReadLine());
                                    break;
                                case 3:
                                    Console.WriteLine("请输入修改后的明细商品数目。");
                                    y.goodnum = int.Parse(Console.ReadLine());
                                    break;
                                default:
                                    Console.WriteLine("请输入正确的数字。");
                                    break;
                            }
                            flag5 = 1;
                            Console.WriteLine("成功修改该订单。");
                        }
                    }
                    if (flag5 == 0)
                    {
                        Console.WriteLine("未找到该订单明细，修改失败。");
                    }
                }
            }
            if (flag4 == 0)
            {
                Console.WriteLine("未找到该订单，修改失败。");
            }
        }
        public static void Find()
        {
            Console.WriteLine("请输入要查询的订单号。");
            Order order = new Order();
            order.id = int.Parse(Console.ReadLine());
            int flag6 = 0;
            foreach (Order x in orders)
            {
                if (x.Equals(order))
                {
                    flag6 = 1;
                    Console.WriteLine("成功找到该订单，详情如下：");
                    x.ToString();
                }
            }
            if (flag6 == 0)
            {
                Console.WriteLine("未找到该订单。");
            }

        }
        public static void Display()
        {
            orders.Sort((o1, o2) => o1.id - o2.id);
            orders.ForEach(o => o.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("请输入操作对应的数字：1、添加订单。2、删除订单。3、修改订单。4、查询订单。5、展示订单。");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        OrderService.Add();
                        break;
                    case 2:
                        OrderService.Delete();
                        break;
                    case 3:
                        OrderService.Change();
                        break;
                    case 4:
                        OrderService.Find();
                        break;
                    case 5:
                        OrderService.Display();
                        break;
                    default:
                        Console.WriteLine("请输入正确的的数字。");
                        break;
                }
            }
        }
    }
}
