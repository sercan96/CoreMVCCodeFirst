using CoreMVCCodeFirst_1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMVCCodeFirst_1.Models.Configurations
{
    public class CategoryConfiguration : BaseConfigurations<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder); // orjinal görevi

            builder.ToTable("Kategoriler");
            builder.Property(x => x.CategoryName).HasColumnName("KategoriIsmi");
            builder.Property(x => x.Description).HasColumnName("Aciklamasi");

        }
    }
}
