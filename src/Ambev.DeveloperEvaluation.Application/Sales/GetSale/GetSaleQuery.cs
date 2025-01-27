﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleQuery : IRequest<GetSaleResult>
    {
        public Guid Id { get; }

        public GetSaleQuery(Guid id)
        {
            Id = id;
        }
    }
}
