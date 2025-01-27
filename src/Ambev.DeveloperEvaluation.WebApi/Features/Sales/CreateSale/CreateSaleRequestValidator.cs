using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.SaleNumber)
                .NotEmpty()
                .WithMessage("Sale number is required.")
                .MaximumLength(50)
                .WithMessage("Sale number cannot exceed 50 characters.");

            RuleFor(x => x.SaleDate)
                .NotEmpty()
                .WithMessage("Sale date is required.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Sale date cannot be in the future.");

            RuleFor(x => x.Customer)
                .NotNull()
                .WithMessage("Customer information is required.")
                .SetValidator(new ExternalCustomerRequestValidator());

            RuleFor(x => x.Branch)
                .NotNull()
                .WithMessage("Branch information is required.")
                .SetValidator(new ExternalBranchRequestValidator());

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("At least one sale item is required.")
                .Must(items => items.All(item => item.Quantity > 0))
                .WithMessage("All items must have a quantity greater than zero.")
                .ForEach(item => item.SetValidator(new SaleItemRequestValidator()));
        }
    }

    public class ExternalCustomerRequestValidator : AbstractValidator<ExternalCustomerRequest>
    {
        public ExternalCustomerRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Customer ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");
        }
    }

    public class ExternalBranchRequestValidator : AbstractValidator<ExternalBranchRequest>
    {
        public ExternalBranchRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Branch ID is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Branch description is required.")
                .MaximumLength(100).WithMessage("Branch description cannot exceed 100 characters.");
        }
    }

    public class SaleItemRequestValidator : AbstractValidator<SaleItemRequest>
    {
        public SaleItemRequestValidator()
        {
            RuleFor(x => x.Product)
                .NotNull().WithMessage("Product information is required.")
                .SetValidator(new ExternalProductRequestValidator());

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Unit price must be zero or greater.");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount must be zero or greater.")
                .LessThanOrEqualTo(x => x.UnitPrice * x.Quantity)
                .WithMessage("Discount cannot exceed the total price of the item.");

            RuleFor(x => x.TotalAmount)
                .Equal(x => (x.UnitPrice * x.Quantity) - x.Discount)
                .WithMessage("Total amount must match the calculated value.");
        }
    }

    public class ExternalProductRequestValidator : AbstractValidator<ExternalProductRequest>
    {
        public ExternalProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");
        }
    }
}
