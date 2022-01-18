using ShopCore.Entity;
using ShopCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Service
{
    public class ShipAddressService : IShipAddressService
    {
        private IShipAddressRepository ShipAddressRepository;
        private IUserService UserService;

        public ShipAddressService(IShipAddressRepository _ShipAddressRepository, IUserService UserService)
        {
            this.ShipAddressRepository = _ShipAddressRepository;
            this.UserService = UserService;
        }


        /// <summary>
        /// BLL
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<ShipAddress> GetAll()
        {
            return ShipAddressRepository.GetAll(m => m.UserId == UserService.LoginInfo().UserId);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shipAddress"></param>
        /// <returns></returns>
        public int Create(ShipAddress shipAddress)
        {
            shipAddress.UserId = UserService.LoginInfo().UserId;
            return ShipAddressRepository.Create(shipAddress);
        }
    }
}
