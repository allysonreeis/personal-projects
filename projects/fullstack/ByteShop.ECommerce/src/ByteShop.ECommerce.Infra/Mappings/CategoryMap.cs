﻿using ByteShop.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Infra.Mappings;
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .HasMaxLength(80)
            .IsRequired();

        builder.HasIndex(e => e.Name, "Idx_Category_Name")
            .IsUnique();
    }
}
