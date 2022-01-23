using ShopCore.Entity;

namespace ShopCore.Repository
{
    public interface IOrderRepository
    {
        int Create(Order order);
    }
}