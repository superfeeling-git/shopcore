using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopCore.Repository
{
    public interface IShipAddressRepository1
    {
        List<ShipAddress> GetAll(Expression<Func<ShipAddress, bool>> predicate);
    }
}