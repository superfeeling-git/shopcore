using ShopCore.Dto;
using System.Collections.Generic;

namespace ShopCore.Service
{
    public interface IGoodsService
    {
        GoodsDto GetEntity(int id);
        List<GoodsTasteDto> GetTasteByGoods(int id);
    }
}