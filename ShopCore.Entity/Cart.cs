using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public class Cart
    {
        public int CartId { get; set; }
        public int SKUID { get; set; }
        public int UserId { get; set; }
        public int BuyCount { get; set; }
    }
}
