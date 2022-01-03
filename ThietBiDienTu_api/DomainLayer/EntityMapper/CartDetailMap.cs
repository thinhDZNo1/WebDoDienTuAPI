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
    public class CartDetailMap : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(x => x.Quantity)
                .HasMaxLength(5);
            builder.HasOne(x => x.Cart)
                .WithMany(x => x.CartDetail)
                .HasForeignKey(x => x.CartId);
            builder.HasOne(x => x.ProductDetail)
                .WithMany(x => x.CartDetail)
                .HasForeignKey(x => x.PDId);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.CartDetail)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
