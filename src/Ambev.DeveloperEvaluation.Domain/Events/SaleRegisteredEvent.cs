namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleRegisteredEvent
    {
        public string SaleId { get; set; } = null!;
        public string SaleNumber { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
