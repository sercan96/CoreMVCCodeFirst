﻿using CoreMVCCodeFirst_1.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMVCCodeFirst_1.Models.Configurations
{
    public class ProductConfiguration  :BaseConfigurations<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

        }
    }
}
