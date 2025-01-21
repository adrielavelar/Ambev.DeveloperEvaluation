using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder
            .ToTable("Sales");

        builder
            .HasKey(s => s.Id);

        builder
            .Property(s => s.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder
            .Property(s => s.SaleNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(s => s.SaleDate)
            .IsRequired();

        builder
            .Property(s => s.IsCancelled)
            .IsRequired();

        builder
            .OwnsOne(s => s.Customer, customer =>
            {
                customer.Property(c => c.Id).HasColumnName("CustomerId").IsRequired();
                customer.Property(c => c.Name).HasColumnName("CustomerName").HasMaxLength(100).IsRequired();
            });

        builder
            .OwnsOne(s => s.Branch, branch =>
            {
                branch.Property(b => b.Id).HasColumnName("BranchId").IsRequired();
                branch.Property(b => b.Description).HasColumnName("BranchDescription").HasMaxLength(100).IsRequired();
            });

        builder
            .HasMany(s => s.Items)
            .WithOne()
            .HasForeignKey("SaleId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(s => s.CreatedAt)
            .IsRequired();

        builder
            .Property(s => s.UpdatedAt);
    }
}
