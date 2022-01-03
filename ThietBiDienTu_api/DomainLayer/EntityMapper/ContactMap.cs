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
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(x => x.Address)
                .HasMaxLength(150);
            builder.Property(x => x.Phone)
                .HasMaxLength(10)
                .HasColumnType("VARCHAR");
            builder.Property(x => x.Email)
                 .HasColumnType("VARCHAR");
            builder.Property(x => x.Fax)
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");
        }
    }
}
