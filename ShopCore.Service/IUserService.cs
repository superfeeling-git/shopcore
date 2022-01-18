using ShopCore.Dto;
using ShopCore.Entity;

namespace ShopCore.Service
{
    public interface IUserService
    {
        LoginDto Login(UserDto dto);
        bool IsLogin();
        User LoginInfo();
    }
}