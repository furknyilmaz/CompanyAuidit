using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(user => user.LastName).HasMaxLength(50).IsRequired();
            builder.Property(user => user.Department).HasMaxLength(50).IsRequired();
            builder.Property(user => user.Mission).HasMaxLength(100).IsRequired();
        }
    }
}
