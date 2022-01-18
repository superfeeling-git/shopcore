using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopCore.Entity
{
    public class ShopCoreContext:DbContext
    {
        public ShopCoreContext(DbContextOptions<ShopCoreContext> options)
            :base(options)
        {

        }

        public DbSet<GoodsCategory> GoodsCategories { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Taste> Tastes { get; set; }
        public DbSet<SKU> SKU { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ShipAddress> ShipAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipAddress>(config => {
                config.HasKey(m => m.AddressId);
                config.Property(m => m.FullName).HasMaxLength(20);
                //是必填，非空    char(20)
                config.Property(m => m.Province)
                .IsRequired(true)
                .HasColumnName("Provinces")
                .HasComment("省")
                .IsFixedLength(true)
                .HasMaxLength(20)
                .IsUnicode(false);

                config.HasOne(m => m.User).WithMany(m => m.shipAddresses).HasForeignKey(m => m.UserId).HasConstraintName("FK_Address_User");




                //nvarchar  nchar(20)  varchar  char
                //var 变长、定长的区别    nchar(20)   定长20个长度字符串，如果字符串长度为10，剩下的用空格填充
                //N,unicode/非unicode


                //默认值
                config.Property(m => m.CreateTime).HasDefaultValueSql("getdate()");

                //细粒度

            });


            //base.OnModelCreating(modelBuilder);
        }
    }
}
