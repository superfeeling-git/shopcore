using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ShopCoreContext db;
        public OrderRepository(ShopCoreContext _db)
        {
            this.db = _db;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int Create(Order order)
        {
            db.Orders.Add(order);
            return db.SaveChanges();
        }
    }
}
