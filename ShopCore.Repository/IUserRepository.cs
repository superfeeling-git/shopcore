using ShopCore.Entity;

namespace ShopCore.Repository
{
    public interface IUserRepository
    {
        User GetEntity(string UserName);
    }
}