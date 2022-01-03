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
    public class CategoryDetailMap : IEntityTypeConfiguration<CategoryDetail>
    {

        public void Configure(EntityTypeBuilder<CategoryDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(x => x.Name)
                .HasMaxLength(150);
            builder.HasOne(x => x.Category)
                .WithMany(x=>x.CategoryDetails)
                .HasForeignKey(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
