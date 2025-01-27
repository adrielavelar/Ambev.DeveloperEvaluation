using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return sale;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);

            if (sale is null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<Sale>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Sale>> GetByBranchAsync(Guid branchId, CancellationToken cancellationToken = default)
        {
            return await _context
                .Sales
                .Where(s => s.Branch.Id == branchId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Sale>> GetByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await _context
                .Sales
                .Where(s => s.Customer.Id == customerId)
                .ToListAsync(cancellationToken);
        }

        public async Task<Sale?> GetWithItemsAsync(Guid saleId, CancellationToken cancellationToken = default)
        {
            return await _context
                .Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == saleId, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, Sale sale, CancellationToken cancellationToken = default)
        {
            var existingSale = await GetByIdAsync(id);

            if (existingSale is not null)
            {
                _context
                .Entry(existingSale)
                .CurrentValues
                .SetValues(sale);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
