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
    public class ConfirmOrderMap : IEntityTypeConfiguration<ConfirmOrder>
    {       

        public void Configure(EntityTypeBuilder<ConfirmOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(x => x.Quantity)
                    .HasMaxLength(5);
            builder.HasOne(x => x.CartDetail)
                    .WithMany()
                    .HasForeignKey(x=>x.CartDetailId)
                    .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.User)
                    .WithMany(x=>x.ConfirmOrder)
                    .HasForeignKey(x=>x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
