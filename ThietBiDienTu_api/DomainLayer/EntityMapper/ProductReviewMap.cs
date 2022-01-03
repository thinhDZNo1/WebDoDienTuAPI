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
    public class ProductReviewMap : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
            builder.HasOne(x => x.User)
                .WithMany(x=>x.ProductReview)
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Product)
                .WithMany(x=>x.ProductReviews)
                .HasForeignKey(x=>x.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
