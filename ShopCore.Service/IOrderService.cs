using ShopCore.Dto;

namespace ShopCore.Service
{
    public interface IOrderService
    {
        ResultDto Create(int AddressId, string Remark);
    }
}