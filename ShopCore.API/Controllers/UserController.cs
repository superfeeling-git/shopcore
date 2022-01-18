using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCore.Dto;
using ShopCore.Entity;
using ShopCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService;
        private IShipAddressService ShipAddressService;

        public UserController(IUserService _UserService, IShipAddressService ShipAddressService)
        {
            this.UserService = _UserService;
            this.ShipAddressService = ShipAddressService;
        }


        [HttpPost]
        public IActionResult Login(UserDto dto)
        {
            return Ok(UserService.Login(dto));
        }

        [HttpGet]
        public IActionResult IsLogin()
        {
            return Ok(UserService.IsLogin());
        }

        [HttpGet]
        public IActionResult GetLoginInfo()
        {
            return Ok(UserService.LoginInfo());
        }

        /// <summary>
        /// 获取当前登录用户的收货地址
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAddress()
        {
            return new JsonResult(ShipAddressService.GetAll());
        }

        /// <summary>
        /// token是URL传参
        /// </summary>
        /// <param name="shipAddress"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(ShipAddress shipAddress,string token)
        {
            //这是url的token
            var urltoken = token;

            //这是请求头传的token
            var headertoken = HttpContext.Request.Headers["token"];


            return Ok(ShipAddressService.Create(shipAddress));
        }
    }
}
