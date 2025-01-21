using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        public SaleItemRepository(DefaultContext defaultContext)
        {
            _context = defaultContext;
        }

        public async Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            await _context.SaleItems.AddAsync(saleItem);
            await _context.SaveChangesAsync(cancellationToken);

            return saleItem;
        }

        public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.SaleItems.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default)
        {
            return await _context
                .SaleItems
                .Where(si => EF.Property<Guid>(si, "SaleId") == saleId)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            var existingItem = await GetByIdAsync(id);

            if (existingItem is not null)
            {
                _context
                .Entry(existingItem)
                .CurrentValues
                .SetValues(saleItem);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
