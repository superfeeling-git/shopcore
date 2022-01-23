using ShopCore.Dto;
using ShopCore.Entity;
using System.Collections.Generic;

namespace ShopCore.Repository
{
    public interface ICartRepository
    {
        int AddCart(Cart cart);
        List<CartDto> GetAll(int UserId);
        int UpdateCart(Cart cart);
        int Delete(int CartId);
        int Clear(int UserId);
    }
}