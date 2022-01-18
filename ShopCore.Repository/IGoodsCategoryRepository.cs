using ShopCore.Entity;
using System.Collections.Generic;

namespace ShopCore.Repository
{
    public interface IGoodsCategoryRepository
    {
        List<GoodsCategory> GetList();
    }
}