using ShopCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private ShopCoreContext db;
        public UserRepository(ShopCoreContext _db)
        {
            this.db = _db;
        }

        /// <summary>
        /// 根据用户名查实体
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public User GetEntity(string UserName)
        {
            return db.Users.FirstOrDefault(m => m.UserName == UserName);
        }
    }
}
