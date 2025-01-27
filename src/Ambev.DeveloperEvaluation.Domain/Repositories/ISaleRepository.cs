namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Sale>> GetAsync(CancellationToken cancellationToken = default);    
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Sale>> GetByBranchAsync(Guid branchId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Sale>> GetByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default);
        Task<Sale?> GetWithItemsAsync(Guid saleId, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, Sale sale, CancellationToken cancellationToken = default);
    }
}
