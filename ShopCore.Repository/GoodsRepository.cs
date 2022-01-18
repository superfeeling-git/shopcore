using ShopCore.Dto;
using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Repository
{
    public class GoodsRepository : IGoodsRepository
    {
        private ShopCoreContext db;
        public GoodsRepository(ShopCoreContext _db)
        {
            this.db = _db;
        }

        public Goods GetEntity(int id)
        {
            return db.Goods.Find(id);
        }


        public IQueryable<SKU> SKUQuery()
        {
            return db.SKU.AsQueryable();
        }

        public IQueryable<Taste> TastesQuery()
        {
            return db.Tastes.AsQueryable();
        }
    }
}
