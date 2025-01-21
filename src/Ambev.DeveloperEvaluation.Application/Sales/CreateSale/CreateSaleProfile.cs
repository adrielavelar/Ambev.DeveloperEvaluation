using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>();
            CreateMap<Sale, CreateSaleResult>();

            CreateMap<ExternalProductCommand, ExternalProduct>();
            CreateMap<SaleItemCommand, SaleItem>();
            CreateMap<ExternalBranchCommand, ExternalBranch>();
            CreateMap<ExternalCustomerCommand, ExternalCustomer>();
        }
    }
}
