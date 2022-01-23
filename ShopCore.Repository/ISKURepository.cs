using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopCore.Repository
{
    public interface ISKURepository
    {
        List<SKU> GetList(Expression<Func<SKU, bool>> predicate);
        int Update(SKU sku);
    }
}