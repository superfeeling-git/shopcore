using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCore.Dto;
using ShopCore.Service;

namespace ShopCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService CartService;
        public CartController(ICartService CartService)
        {
            this.CartService = CartService;
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCart(CartDto dto)
        {
            return Ok(CartService.AddCart(dto));
        }

        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCart()
        {
            return new JsonResult(CartService.GetAll());
        }

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateCar(CartDto dto)
        {
            return Ok(CartService.UpdateCart(dto));
        }

        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="CartId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int CartId)
        {
            return Ok(CartService.Delete(CartId));
        }
    }
}
