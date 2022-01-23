using NLog;
using ShopCore.Dto;
using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Extensions;

namespace ShopCore.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private ShopCoreContext db;
        public CartRepository(ShopCoreContext _db)
        {
            this.db = _db;
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        public int AddCart(Cart cart)
        {
            db.Cart.Add(cart);
            return db.SaveChanges();
        }

        /// <summary>
        /// 获取购物车所有商品
        /// </summary>
        /// <returns></returns>
        public List<CartDto> GetAll(int UserId)
        {
            return db.Goods.Join(db.SKU, a => a.GoodsId, b => b.GoodsId, (a, b) => new { a, b })
                .Join(db.Cart.Where(m=>m.UserId == UserId), a => a.b.SKUID, b => b.SKUID, (a, b) => new { a, b })
                .Select(m => new CartDto {
                    BuyCount = m.b.BuyCount,
                    GoodsImg = m.a.a.GoodsImg,
                    GoodsName = m.a.a.GoodsName,
                    Price = m.a.a.Price,
                    SKUID = m.b.SKUID,
                    CartId = m.b.CartId
                }).ToList();
        }


        /// <summary>
        /// 更新购物车
        /// </summary>
        public int UpdateCart(Cart cart)
        {
            var currcart = db.Cart.First(m => m.SKUID == cart.SKUID && m.UserId == cart.UserId);
            currcart.BuyCount = cart.BuyCount;
            return db.SaveChanges();
        }

        /// <summary>
        /// 删除购物车商品
        /// </summary>
        public int Delete(int CartId)
        {
            try
            {
                var cart = db.Cart.Find(CartId);
                _logger.Info($"删除购物车商品:用户ID：{cart.UserId}，商品ID：{cart.SKUID}");

                db.Cart.Remove(cart);                
                return db.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw;
            }
        }

        /// <summary>
        /// 根据当前用户删除所有的商品
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int Clear(int UserId)
        {
            return db.Cart.Where(m => m.UserId == UserId).DeleteFromQuery();
        }
    }
}
