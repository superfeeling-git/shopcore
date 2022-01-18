using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public class Goods : BaseEntity
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int Price { get; set; }
        public string GoodsImg { get; set; }
        public string Details { get; set; }
        //public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
