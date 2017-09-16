using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categoria");

            builder.Property(p => p.Id)
                   .UseSqlServerIdentityColumn();

            builder.Property(p => p.Name)
                   .HasColumnType("nvarchar(50)")
                   .HasColumnName("Nome");
        }
    }
}