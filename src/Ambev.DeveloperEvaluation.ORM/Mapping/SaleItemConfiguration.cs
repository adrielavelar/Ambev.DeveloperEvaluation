using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder
            .ToTable("SaleItems");

        builder
            .HasKey(si => si.Id);

        builder
            .Property(si => si.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder
            .OwnsOne(si => si.Product, product =>
            {
                product.Property(p => p.Id).HasColumnName("ProductId").IsRequired();
                product.Property(p => p.Name).HasColumnName("ProductName").HasMaxLength(100).IsRequired();
            });

        builder
            .Property(si => si.Quantity)
            .IsRequired();

        builder
            .Property(si => si.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(si => si.Discount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(si => si.IsCancelled)
            .IsRequired();

        builder
            .Property(si => si.CreatedAt)
            .IsRequired();

        builder
            .Property(si => si.UpdatedAt);
    }
}
