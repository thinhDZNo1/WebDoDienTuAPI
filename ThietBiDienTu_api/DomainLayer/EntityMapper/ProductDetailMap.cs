using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMapper
{
    public class ProductDetailMap : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
            builder.HasOne(x => x.Product)
                .WithMany(x=>x.ProductDetails)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Color)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x=>x.ColorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product_Type)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x=>x.Product_TypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
