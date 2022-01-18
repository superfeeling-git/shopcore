using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopCore.Repository
{
    public interface IShipAddressRepository
    {
        List<ShipAddress> GetAll(Expression<Func<ShipAddress, bool>> predicate);
        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="shipAddress"></param>
        /// <returns></returns>
        int Create(ShipAddress shipAddress);
    }
}