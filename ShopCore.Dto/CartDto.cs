using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Dto
{
    public class CartDto
    {
        public int SKUID { get; set; }
        public int BuyCount { get; set; }
        public string GoodsName { get; set; }
        public string GoodsImg { get; set; }
        public int Price { get; set; }
    }
}
