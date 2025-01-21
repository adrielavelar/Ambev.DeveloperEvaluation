using Ambev.DeveloperEvaluation.Domain.Common;

public class SaleItem : BaseEntity
{
    public ExternalProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount => (UnitPrice * Quantity) - Discount;
    public bool IsCancelled { get; set; }

    public SaleItem(ExternalProduct product, int quantity, decimal unitPrice, decimal discount = 0)
    {
        Id = Guid.NewGuid();
        Product = product ?? throw new ArgumentNullException(nameof(product));
        Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be greater than zero.");
        UnitPrice = unitPrice >= 0 ? unitPrice : throw new ArgumentException("Unit price must be non-negative.");
        Discount = discount >= 0 ? discount : throw new ArgumentException("Discount must be non-negative.");
        IsCancelled = false;
    }

    public SaleItem()
    {

    }

    public void Cancel()
    {
        IsCancelled = true;
        LogEvent("ItemCancelled");
    }

    private void LogEvent(string eventName) => Console.WriteLine($"{eventName} - ItemId: {Id}");

    public void SetDiscount(decimal value)
    {
        Discount = value;
    }
}
