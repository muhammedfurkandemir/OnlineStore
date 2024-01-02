using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Concrete;

namespace OnlineStore.Utilities.EntityFreamwork
{
    public class OnlineStoreContext:IdentityDbContext
    {
        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
