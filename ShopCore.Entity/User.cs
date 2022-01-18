using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 集合导航属性
        /// </summary>
        public List<ShipAddress> shipAddresses { get; set; }
    }

    //    User.XXX = 999;
}
