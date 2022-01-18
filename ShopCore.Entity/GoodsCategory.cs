using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public class GoodsCategory:BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
        public string Remark { get; set; }
        public List<Goods> Goods { get; set; }
    }
}
