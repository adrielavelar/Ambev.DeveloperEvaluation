namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public string SaleNumber { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public ExternalCustomerRequest Customer { get; set; } = null!;
        public ExternalBranchRequest Branch { get; set; } = null!;
        public List<SaleItemRequest> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(item => item.TotalAmount);
        public bool IsCancelled { get; set; }
    }

    public class ExternalCustomerRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ExternalBranchRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
    }

    public class SaleItemRequest
    {
        public ExternalProductRequest Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }

    public class ExternalProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
