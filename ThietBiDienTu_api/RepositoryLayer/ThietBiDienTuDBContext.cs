using DomainLayer.EntityMapper;
using DomainLayer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace RepositoryLayer
{
    public class ThietBiDienTuDBContext: DbContext
    {
        public ThietBiDienTuDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Slide> Slide { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryDetail> CategoryDetail { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Product_Type> ProductType { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<ConfirmOrder> ConfirmOrder { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SlideMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CategoryDetailMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductImageMap());
            modelBuilder.ApplyConfiguration(new ProductDetailMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new MessageMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new ProductReviewMap());
            modelBuilder.ApplyConfiguration(new CartMap());
            modelBuilder.ApplyConfiguration(new CartDetailMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
