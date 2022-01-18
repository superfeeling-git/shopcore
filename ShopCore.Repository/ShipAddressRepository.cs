using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Repository
{
    public class ShipAddressRepository : IShipAddressRepository
    {
        private ShopCoreContext db;
        public ShipAddressRepository(ShopCoreContext _db)
        {
            this.db = _db;
        }

        /// <summary>
        /// 根据条件查询对应的收货地址
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<ShipAddress> GetAll(Expression<Func<ShipAddress, bool>> predicate)
        {
            return db.ShipAddresses.Where(predicate).ToList();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shipAddress"></param>
        /// <returns></returns>
        public int Create(ShipAddress shipAddress)
        {
            db.ShipAddresses.Add(shipAddress);
            return db.SaveChanges();
        }
    }
}
