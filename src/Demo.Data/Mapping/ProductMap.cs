using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.Property(p => p.Id)
                   .UseSqlServerIdentityColumn();

            builder.Property(p => p.Name)
                   .HasColumnType("nvarchar(50)")
                   .HasColumnName("Nome");
            
            builder.HasOne(p => p.Category)
                   .WithMany(p => p.Products)
                   .HasForeignKey(p => p.CategoryId);
        }
    }
}