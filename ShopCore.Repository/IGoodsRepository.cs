using ShopCore.Entity;
using System.Linq;

namespace ShopCore.Repository
{
    public interface IGoodsRepository
    {
        Goods GetEntity(int id);
        IQueryable<SKU> SKUQuery();
        IQueryable<Taste> TastesQuery();
    }
}