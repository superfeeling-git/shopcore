using ShopCore.Entity;
using ShopCore.Repository;
using System;
using System.Collections.Generic;

namespace ShopCore.Service
{
    public class GoodsCategoryService : IGoodsCategoryService
    {
        private IGoodsCategoryRepository GoodsCategory;

        public GoodsCategoryService(IGoodsCategoryRepository GoodsCategory)
        {
            this.GoodsCategory = GoodsCategory;
        }

        public List<GoodsCategory> GetList()
        {
            return GoodsCategory.GetList();
        }
    }
}
