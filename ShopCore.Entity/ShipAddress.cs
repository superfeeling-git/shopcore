using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Entity
{
    public class ShipAddress
    {
        //[Key]
        public int AddressId { get; set; }
        public string FullName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string TEL{ get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 引用导航属性
        /// </summary>
        public User User { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDefault { get; set; }
    }
}
