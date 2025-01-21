using Ambev.DeveloperEvaluation.Domain.Common;

public class Sale : BaseEntity
{
    public string SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public ExternalCustomer Customer { get; set; }
    public ExternalBranch Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new();
    public decimal TotalAmount => Items.Sum(item => item.TotalAmount);
    public bool IsCancelled { get; set; }

    public Sale(string saleNumber, DateTime saleDate, ExternalCustomer customer, ExternalBranch branch)
    {
        Id = Guid.NewGuid();
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Branch = branch ?? throw new ArgumentNullException(nameof(branch));
        IsCancelled = false;
    }

    public Sale()
    {

    }

    public void AddItem(SaleItem item)
    {
        if (IsCancelled) throw new InvalidOperationException("Cannot add items to a cancelled sale.");
        Items.Add(item);
    }

    public void Cancel()
    {
        IsCancelled = true;
        LogEvent("SaleCancelled");
    }

    private void LogEvent(string eventName) => Console.WriteLine($"{eventName} - SaleId: {Id}");
}