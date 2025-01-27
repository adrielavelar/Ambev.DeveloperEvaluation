using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    public class ListSaleHandler : IRequestHandler<ListSaleQuery, IEnumerable<ListSaleResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public ListSaleHandler
        (
            ISaleRepository saleRepository,
            IMapper mapper
        )
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListSaleResult>> Handle(ListSaleQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ListSaleResult>>(sales);
        }
    }
}
