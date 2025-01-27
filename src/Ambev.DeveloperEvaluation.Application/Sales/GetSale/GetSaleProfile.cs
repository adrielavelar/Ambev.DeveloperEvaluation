using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<Sale, GetSaleResult>();

            CreateMap<ExternalProduct, ExternalProductResult>();
            CreateMap<SaleItem, SaleItemResult>();
            CreateMap<ExternalBranch, ExternalBranchResult>();
            CreateMap<ExternalCustomer, ExternalCustomerResult>();
        }
    }
}
