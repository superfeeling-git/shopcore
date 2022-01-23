using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCore.Entity;
using ShopCore.Repository;
using ShopCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private IGoodsService GoodsService;
        private IGoodsRepository GoodsRepository;
        private IOrderRepository OrderRepository;

        public GoodsController(IGoodsService _GoodsService, IGoodsRepository GoodsRepository, IOrderRepository OrderRepository)
        {
            this.GoodsService = _GoodsService;
            this.GoodsRepository = GoodsRepository;
            this.OrderRepository = OrderRepository;
        }

        [HttpGet]
        public IActionResult GetEntity(int id)
        {
            return Ok(GoodsService.GetEntity(id));
        }

        [HttpGet]
        public IActionResult GetTasteByGoods(int id)
        {
            return new JsonResult(GoodsService.GetTasteByGoods(id));
        }

        [HttpPost]
        public IActionResult Create(Taste taste)
        {
            return Ok(GoodsRepository.CreateTastes(taste));
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            return Ok(OrderRepository.Create(order));
        }
    }
}
