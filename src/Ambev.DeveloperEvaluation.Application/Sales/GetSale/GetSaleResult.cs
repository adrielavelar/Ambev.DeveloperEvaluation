namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResult
    {
        public string SaleNumber { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public ExternalCustomerResult Customer { get; set; } = null!;
        public ExternalBranchResult Branch { get; set; } = null!;
        public List<SaleItemResult> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(item => item.TotalAmount);
        public bool IsCancelled { get; set; }
    }

    public class ExternalCustomerResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ExternalBranchResult
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
    }

    public class SaleItemResult
    {
        public ExternalProductResult Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }

    public class ExternalProductResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
