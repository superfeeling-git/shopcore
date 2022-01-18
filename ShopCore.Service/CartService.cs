using ShopCore.Dto;
using ShopCore.Entity;
using ShopCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Service
{
    public class CartService : ICartService
    {
        private ICartRepository CartRepository;
        private IUserService UserService;


        public CartService(ICartRepository _CartRepository, IUserService _UserService)
        {
            this.CartRepository = _CartRepository;
            this.UserService = _UserService;
        }

        public int AddCart(CartDto dto)
        {
            var userid = UserService.LoginInfo().UserId;

            //第一步：先获取当前用户购物车的所有商品数据
            var currCart = CartRepository.GetAll(userid);

            var existsGoods = currCart.FirstOrDefault(m => m.SKUID == dto.SKUID);

            if(existsGoods == null)
            {
                //添加
                return CartRepository.AddCart(new Cart { BuyCount = dto.BuyCount, SKUID = dto.SKUID, UserId = UserService.LoginInfo().UserId });
            }
            else
            {
                //更新
                existsGoods.BuyCount += dto.BuyCount;
                return CartRepository.UpdateCart(new Cart { BuyCount = existsGoods.BuyCount, SKUID = dto.SKUID, UserId = userid });
            }
        }

        /// <summary>
        /// 获取购物车商品
        /// </summary>
        /// <returns></returns>
        public List<CartDto> GetAll()
        {
            var userid = UserService.LoginInfo().UserId;
            var list = CartRepository.GetAll(userid);

            list.ForEach(m => {
                 m.GoodsImg = m.GoodsImg.Split(';')[0];
             });

            return list;
        }

        public int UpdateCart(CartDto dto)
        {
            var userid = UserService.LoginInfo().UserId;
            return CartRepository.UpdateCart(new Cart { BuyCount = dto.BuyCount, SKUID = dto.SKUID, UserId = userid });
        }
    }
}
