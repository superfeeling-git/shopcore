using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public class OrderGoods
    {
        public string OrderGoodsId { get; set; }
        public int OrderID { get; set; }
        public string GoodsName { get; set; }
        public int Price  { get; set; }
        public string TasteName { get; set; }
        public int SKUID { get; set; }
        public int BuyCount { get; set; }
        public Order Order { get; set; }
    }
}
