using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCore.Repository;
using ShopCore.Entity;
using ShopCore.Dto;
using Microsoft.AspNetCore.Http;
using IdentityModel;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace ShopCore.Service
{
    public class UserService : IUserService
    {
        private IUserRepository repository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private IConfiguration configuration;

        public UserService(IUserRepository _repository, IHttpContextAccessor _httpContextAccessor, IConfiguration _configuration)
        {
            this.repository = _repository;
            this.httpContextAccessor = _httpContextAccessor;
            this.configuration = _configuration;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public LoginDto Login(UserDto dto)
        {
            //获取用户
            var user = repository.GetEntity(dto.UserName);

            if (user == null)
            {
                return new LoginDto { Code = 1, Msg = "无此用户" };
            }
            else
            {
                if (dto.Password.ToLower() == user.Password.ToLower())
                {
                    //写入cookies
                    httpContextAccessor.HttpContext.Response.Cookies.Append("username", dto.UserName);

                    return new LoginDto { Code = 0 };

                    //改用JWT
                    /*IList<Claim> claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Name,dto.UserName)

                    };

                    //JWT密钥
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Bearer:SecurityKey"]));

                    //算法
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //过期时间
                    DateTime expires = DateTime.UtcNow.AddHours(10);


                    //Payload负载
                    var token = new JwtSecurityToken(
                        issuer: configuration["JwtConfig:Bearer:Issuer"],
                        audience: configuration["JwtConfig:Bearer:Audience"],
                        claims: claims,
                        notBefore: DateTime.UtcNow,
                        expires: expires,
                        signingCredentials: cred
                        );

                    var handler = new JwtSecurityTokenHandler();

                    //生成令牌
                    string jwt = handler.WriteToken(token);

                    return new LoginDto { Code = 0, token = jwt, expires = expires };*/
                }
                else
                {
                    return new LoginDto { Code = 2, Msg = "密码不对" };
                }
            }
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            var username = httpContextAccessor.HttpContext.Request.Cookies["username"];
            return string.IsNullOrWhiteSpace(username) ? false : true;
        }

        /// <summary>
        /// 获取当前登录信息
        /// </summary>
        /// <returns></returns>
        public User LoginInfo()
        {
            var username = httpContextAccessor.HttpContext.Request.Cookies["username"];
            return repository.GetEntity(username);
        }

        //注册

        //更新密码

        //更改用户信息
    }
}
