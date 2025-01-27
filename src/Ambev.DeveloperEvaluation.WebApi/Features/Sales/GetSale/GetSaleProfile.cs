using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<Guid, GetSaleQuery>()
                .ConstructUsing(id => new GetSaleQuery(id));

            CreateMap<GetSaleResult, GetSaleResponse>();

            CreateMap<ExternalProductResult, ExternalProductResponse>();
            CreateMap<SaleItemResult, SaleItemResponse>();
            CreateMap<ExternalBranchResult, ExternalBranchResponse>();
            CreateMap<ExternalCustomerResult, ExternalCustomerResponse>();
        }
    }
}
