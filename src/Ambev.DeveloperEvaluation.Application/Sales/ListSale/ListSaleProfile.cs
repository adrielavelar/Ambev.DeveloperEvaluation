using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    public class ListSaleProfile : Profile
    {
        public ListSaleProfile()
        {
            CreateMap<Sale, ListSaleResult>();

            CreateMap<ExternalProduct, ExternalProductResult>();
            CreateMap<SaleItem, SaleItemResult>();
            CreateMap<ExternalBranch, ExternalBranchResult>();
            CreateMap<ExternalCustomer, ExternalCustomerResult>();
        }
    }
}
