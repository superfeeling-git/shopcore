using ShopCore.Entity;
using System.Collections.Generic;

namespace ShopCore.Service
{
    public interface IShipAddressService
    {
        List<ShipAddress> GetAll();
        /// <summary>
        /// 添加当前用户的收货地址
        /// </summary>
        /// <param name="shipAddress"></param>
        /// <returns></returns>
        int Create(ShipAddress shipAddress);
    }
}