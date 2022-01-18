using ShopCore.Dto;
using ShopCore.Entity;
using ShopCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Service
{
    public class GoodsService : IGoodsService
    {
        private IGoodsRepository GoodsRepository;
        public GoodsService(IGoodsRepository _GoodsRepository)
        {
            this.GoodsRepository = _GoodsRepository;
        }

        public GoodsDto GetEntity(int id)
        {
            var entity = GoodsRepository.GetEntity(id);
            GoodsDto dto = new GoodsDto
            {
                Details = entity.Details,
                GoodsId = entity.GoodsId,
                GoodsName = entity.GoodsName,
                Imgs = entity.GoodsImg.Split(';').Select(m => $"https://localhost:5001{m}").ToArray(),
                Price = entity.Price,
                GoodsImg = entity.GoodsImg
            };

            return dto;
        }

        public List<GoodsTasteDto> GetTasteByGoods(int id)
        {
            return GoodsRepository.SKUQuery().Where(m => m.GoodsId == id)
                .Join(GoodsRepository.TastesQuery(), a => a.TasteId, b => b.TasteId, (a, b) =>
                new GoodsTasteDto
                {
                    SKUID = a.SKUID,
                    TasteName = b.TasteName
                }).ToList();
        }
    }
}
