using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //模拟，假设时间范围：1/10到1/15号，缺少13号和14号

            string StartDate = "2022/10/10";
            string EndDate = "2022/10/15";

            List<Node> list = new List<Node> {
                 new Node{ NodeId = 1, NodeValue = 5, NodeDate = "2022/10/10" },
                 new Node{ NodeId = 1, NodeValue = 5, NodeDate = "2022/10/12" },
                 new Node{ NodeId = 1, NodeValue = 5, NodeDate = "2022/10/15" },
            };

            List<Node> newlist = new List<Node>();

            for (DateTime i = Convert.ToDateTime(StartDate); i <= Convert.ToDateTime(EndDate); i = i.AddDays(1))
            {
                Console.WriteLine(i.ToString("yyyy/M/dd"));

                var obj = list.FirstOrDefault(m => m.NodeDate == i.ToString("yyyy/M/dd"));

                if (obj == null)
                    newlist.Add(new Node { NodeDate = i.ToString("yyyy/M/dd"), NodeId = list.First().NodeId, NodeValue = 0 });
                else
                    newlist.Add(obj);
            }

            foreach (var item in newlist)
            {
                Console.WriteLine($"nodeid:{item.NodeId} nodevalue:{item.NodeValue} nodedate:{item.NodeDate}");
            }

            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }

    public class Node
    {
        public int NodeId { get; set; }
        public decimal NodeValue { get; set; }
        public string NodeDate { get; set; }
    }
}
