using System;
using System.Collections.Generic;
using System.Linq;
using ShopCore.Entity;

namespace ShopCore.Repository
{
    public class GoodsCategoryRepository : IGoodsCategoryRepository
    {
        private ShopCoreContext db;
        public GoodsCategoryRepository(ShopCoreContext _db)
        {
            this.db = _db;
        }

        public List<GoodsCategory> GetList()
        {
            return db.GoodsCategories.ToList();
        }
    }
}
