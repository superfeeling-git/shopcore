using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework;
using Z.EntityFramework.Extensions;
using Z.EntityFramework.Plus;

namespace ShopCore.Repository
{
    public class SKURepository : ISKURepository
    {
        private ShopCoreContext db;
        public SKURepository(ShopCoreContext db)
        {
            this.db = db;
        }

        public List<SKU> GetList(Expression<Func<SKU, bool>> predicate)
        {
            return db.SKU.Where(predicate).ToList();
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public int Update(SKU sku)
        {
            var entity = db.SKU.Find(sku.SKUID);
            entity.Stock -= sku.Stock;
            return db.SaveChanges();
        }
    }
}
