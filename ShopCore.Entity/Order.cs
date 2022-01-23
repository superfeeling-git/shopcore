using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public enum OrderState
    {
        UnConfirm,
        Confirmed,
        UnPay,
        Pay,
        Success
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int UserId { get; set; }
        public string OrderNum { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string TEL { get; set; }
        public string Remark { get; set; }
        public OrderState OrderStatue { get; set; }
        public int PayType { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderGoods> OrderGoods { get; set; }
        public User User { get; set; }
    }
}
