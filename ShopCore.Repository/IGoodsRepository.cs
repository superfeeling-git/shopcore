using ShopCore.Entity;
using System.Linq;

namespace ShopCore.Repository
{
    public interface IGoodsRepository
    {
        Goods GetEntity(int id);
        IQueryable<SKU> SKUQuery();
        IQueryable<Taste> TastesQuery();
        int CreateTastes(Taste taste);
        IQueryable<Taste> QueryTaste();
        IQueryable<SKU> QuerySKU();
    }
}