using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Rebus.Bus;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public CreateSaleHandler
        (
            ISaleRepository saleRepository,
            IMapper mapper,
            IBus bus
        )
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            foreach (SaleItemCommand item in request.Items)
            {
                ValidateItemRules(item);
            }

            var entity = _mapper.Map<Sale>(request);

            var result = await _saleRepository.CreateAsync(entity, cancellationToken);

            await _bus.Publish(new SaleRegisteredEvent
            {
                SaleId = result.Id.ToString(),
                SaleNumber = request.SaleNumber,
                SaleDate = request.SaleDate,
                CustomerId = request.Customer.Id,
                BranchId = request.Branch.Id,
                TotalAmount = request.TotalAmount
            });

            return _mapper.Map<CreateSaleResult>(result);
        }

        private void ValidateItemRules(SaleItemCommand item)
        {
            if (item.Quantity < 4)
            {
                item.Discount = 0;
            }
            else if (item.Quantity >= 4 && item.Quantity < 10)
            {
                item.Discount = item.UnitPrice * item.Quantity * 0.10m;
            }
            else if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                item.Discount = item.UnitPrice * item.Quantity * 0.20m;
            }
            else
            {
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");
            }

            item.TotalAmount = (item.UnitPrice * item.Quantity) - item.Discount;
        }
    }
}
