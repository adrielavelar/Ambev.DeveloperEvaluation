namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleItemRepository
    {
        Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
        Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, SaleItem saleItem, CancellationToken cancellationToken = default);
    }
}
