using ShopCore.Entity;
using System.Collections.Generic;

namespace ShopCore.Service
{
    public interface IGoodsCategoryService
    {
        List<GoodsCategory> GetList();
    }
}