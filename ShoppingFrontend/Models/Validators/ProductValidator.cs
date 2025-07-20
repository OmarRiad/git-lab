using FluentValidation;

namespace ShoppingFrontendApp.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MinimumLength(3).WithMessage("Product name must be at least 3 characters long.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(p => p.ImageUrl)
                .Must(url => url.StartsWith("http") || url.StartsWith("/"))
                .WithMessage("Image URL must be valid.");
        }
    }
}
