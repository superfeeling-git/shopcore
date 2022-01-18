using ShopCore.Dto;
using System.Collections.Generic;

namespace ShopCore.Service
{
    public interface ICartService
    {
        int AddCart(CartDto dto);
        List<CartDto> GetAll();
        int UpdateCart(CartDto dto);
    }
}