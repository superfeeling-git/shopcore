using System;

namespace ShopCore.Entity
{
    public class BaseEntity
    {
        public int CreateId { get; set; }
        public DateTime CreateTime { get; set; }
        public int? LastModityId { get; set; }
        public DateTime? LastModityTime { get; set; }
    }
}
