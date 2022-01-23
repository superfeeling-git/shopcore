using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCore.Dto;
using ShopCore.Repository;
using ShopCore.Entity;

namespace ShopCore.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository OrderRepository;
        private IUserService UserService;
        private ICartService CartService;
        private ISKURepository SKURepository;
        private IShipAddressRepository ShipAddressRepository;
        private IGoodsRepository GoodsRepository;


        public OrderService(IOrderRepository OrderRepository, IUserService UserService, ICartService CartService, ISKURepository SKURepository, IShipAddressRepository ShipAddressRepository, IGoodsRepository GoodsRepository)
        {
            this.OrderRepository = OrderRepository;
            this.UserService = UserService;
            this.CartService = CartService;
            this.SKURepository = SKURepository;
            this.ShipAddressRepository = ShipAddressRepository;
            this.GoodsRepository = GoodsRepository;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="AddressId">地址</param>
        /// <param name="msg">卖家留言</param>
        /// <returns></returns>
        public ResultDto Create(int AddressId, string Remark)
        {
            //工作单元//原子性，要么都成功，要么都失败
            //事务
            //ABP 

            //1、判断登录
            //2、调用仓储层，实现订单创建之前，判断库存是否满足
            //3、调用仓储层接口，实现订单创建
            //4、减库存
            //5、清空购物车
            if (!UserService.IsLogin())
            {
                return new ResultDto { Code = 1, Msg = "没有登录" };
            }

            //当前用户购物车的数据
            var cartList = CartService.GetAll();

            //判断库存
            foreach (var item in cartList)
            {
                if (item.BuyCount > SKURepository.GetList(m => m.SKUID == item.SKUID).First().Stock)
                {
                    return new ResultDto { Code = 2, Msg = "库存不足" };
                }
            }

            var address = ShipAddressRepository.GetAll(m => m.AddressId == AddressId).First();

            //订单生成
            List<OrderGoods> orderGoods = cartList.Select(m => new OrderGoods
            {
                BuyCount = m.BuyCount,
                GoodsName = m.GoodsName,
                Price = m.Price,
                OrderGoodsId = Guid.NewGuid().ToString(),
                SKUID = m.SKUID
            }).ToList();

            orderGoods.ForEach(a =>
            {
                a.TasteName =
                   GoodsRepository.QuerySKU()
                   .Join(GoodsRepository.QueryTaste()
                   , a => a.TasteId, b => b.TasteId, (a, b) => new { a, b }).Where
                   (sku => sku.a.SKUID == a.SKUID).First().b.TasteName;
            });

            Order order = new Order
            {
                Remark = Remark,
                PayType = 1,
                OrderStatue = OrderState.UnConfirm,
                UserId = UserService.LoginInfo().UserId,
                OrderNum = Guid.NewGuid().ToString(),
                OrderTime = DateTime.Now,
                Address = address.Address,
                Email = address.Email,
                FullName = address.FullName,
                TEL = address.TEL,
                OrderGoods = orderGoods
            };

            OrderRepository.Create(order);

            //减库存
            //判断库存
            //不可预估的异常
            foreach (var item in cartList)
            {
                SKURepository.Update(new SKU
                {
                    SKUID = item.SKUID,
                    Stock = item.BuyCount
                });
            }

            //清空购物车
            //异常
            CartService.Clear();

            return new ResultDto { Code = 0 };
        }
    }
}