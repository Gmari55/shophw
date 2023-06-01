using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data
{
    public class shopdbcontext : IdentityDbContext
    {
       

       
         
        
        public shopdbcontext(DbContextOptions options): base (options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new[]
              {
                new Category() { Id = 1, Name = "Electronics" },
                new Category() { Id = 2, Name = "Sport" },
                new Category() { Id = 3, Name = "Fashion" },
                new Category() { Id = 4, Name = "Home & Garden" },
                new Category() { Id = 5, Name = "Transport" },
                new Category() { Id = 6, Name = "Toys & Hobbies" },
                new Category() { Id = 7, Name = "Musical Instruments" },
                new Category() { Id = 8, Name = "Art" }
            });

              
           
            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product() { Id = 1, Name = "iPhone X", CategoryId = 1, Price = 650, description="There is no bottom bezel, no Home button, and no Touch ID fingerprint sensor."},
                new Product() { Id = 3, Name = "Nike T-Shirt", CategoryId = 3, Price = 189, description="A T-shirt (also spelled tee-shirt or tee shirt), or tee for short, is a style of fabric shirt named after the T shape of its body and sleeves" },
                new Product() { Id = 4, Name = "Samsung S23", CategoryId = 1, Price = 1200, description="The Samsung Galaxy S23 specs are top-notch including a Snapdragon 8 Gen 2 chipset, 8GB RAM coupled with 128/256GB storage, and a 3900mAh battery"},
                new Product() { Id = 6, Name = "MacBook Pro 2019", CategoryId = 1, Price = 1200, description="The 2019 MacBook Pro delivers runs on the super-fast performance with the configuration of the latest 8-core processor with up to 5.0GHz " }
            }); ;
         
        }
  
        public DbSet<Product> products { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}
