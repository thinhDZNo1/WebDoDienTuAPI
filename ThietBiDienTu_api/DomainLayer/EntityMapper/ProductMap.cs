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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(x => x.Name)
                .HasMaxLength(150);
            builder.Property(x => x.Discount)
                .HasMaxLength(3);
            builder.Property(x => x.Status)
                .HasMaxLength(50);
            builder.HasOne(x => x.Company)
                .WithMany(x=>x.Product)
                .HasForeignKey(x=>x.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.CategoryDetail)
                .WithMany(x=>x.Product)
                .HasForeignKey(x=>x.CategoryDetailId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
