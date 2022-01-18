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
    public class GoodsController : ControllerBase
    {
        private IGoodsService GoodsService;
        public GoodsController(IGoodsService _GoodsService)
        {
            this.GoodsService = _GoodsService;
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
    }
}
