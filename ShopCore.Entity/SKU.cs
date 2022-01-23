using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public class SKU
    {
        public int SKUID { get; set; }
        public int GoodsId { get; set; }
        public int TasteId { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Stock { get; set; }
    }
}
