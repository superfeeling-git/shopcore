using ShopCore.Dto;
using ShopCore.Entity;
using System.Collections.Generic;

namespace ShopCore.Repository
{
    public interface ICartRepository
    {
        int AddCart(Cart cart);
        void Delete();
        List<CartDto> GetAll(int UserId);
        int UpdateCart(Cart cart);
    }
}