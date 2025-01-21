using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string SaleNumber { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public ExternalCustomerCommand Customer { get; set; } = null!;
        public ExternalBranchCommand Branch { get; set; } = null!;
        public List<SaleItemCommand> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(item => item.TotalAmount);
        public bool IsCancelled { get; set; }
    }

    public class ExternalCustomerCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ExternalBranchCommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
    }

    public class SaleItemCommand
    {
        public ExternalProductCommand Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }

    public class ExternalProductCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
