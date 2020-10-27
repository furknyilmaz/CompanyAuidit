using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.EntityConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(item => item.SerialNumber).HasMaxLength(50).IsRequired();
            builder.Property(item => item.Cost).IsRequired();
            builder.Property(item => item.Description).HasMaxLength(100).IsRequired(false);
        }
    }
}
