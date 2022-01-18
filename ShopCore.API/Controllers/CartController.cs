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

        [HttpPost]
        public IActionResult AddCart(CartDto dto)
        {
            return Ok(CartService.AddCart(dto));
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            return new JsonResult(CartService.GetAll());
        }

        [HttpPost]
        public IActionResult UpdateCar(CartDto dto)
        {
            return Ok(CartService.UpdateCart(dto));
        }
    }
}
