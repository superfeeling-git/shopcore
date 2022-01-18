using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCore.Service;
using ShopCore.Entity;
using Microsoft.AspNetCore.Authorization;

namespace ShopCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GoodsCategoryController : ControllerBase
    {
        private IGoodsCategoryService GoodsCategoryService;

        public GoodsCategoryController(IGoodsCategoryService GoodsCategoryService)
        {
            this.GoodsCategoryService = GoodsCategoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            return new JsonResult(GoodsCategoryService.GetList());
        }
    }
}
