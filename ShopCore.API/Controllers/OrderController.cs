using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService OrderService;
        public OrderController(IOrderService OrderService)
        {
            this.OrderService = OrderService;
        }

        [HttpGet]
        public IActionResult Create(int AddressId, string Remark)
        {
            return Ok(OrderService.Create(AddressId, Remark));
        }
    }
}
