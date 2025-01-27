namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale
{
    public class ListSaleResponse
    {
        public string SaleNumber { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public ExternalCustomerResponse Customer { get; set; } = null!;
        public ExternalBranchResponse Branch { get; set; } = null!;
        public List<SaleItemResponse> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(item => item.TotalAmount);
        public bool IsCancelled { get; set; }
    }

    public class ExternalCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ExternalBranchResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
    }

    public class SaleItemResponse
    {
        public ExternalProductResponse Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }

    public class ExternalProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
