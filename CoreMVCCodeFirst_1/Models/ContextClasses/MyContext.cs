using CoreMVCCodeFirst_1.Models.Configurations;
using CoreMVCCodeFirst_1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCCodeFirst_1.Models.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // OnModelCreating içerisindeki ek kodlarınızı bu satırdan sonra yazmak çok önenmlidir... Çünkü asıl inşa görevi bu satırda olur ve altpağı bu şekilde kurulur... Yazmazsanız işlemlerin çift yapıldığını görürsünüz...

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
