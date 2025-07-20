using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingFrontendApp.Models;
using FluentValidation;
using FluentValidation.Results;
using ShoppingFrontendApp.Models.Validators;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;

namespace ShoppingFrontendApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public List<Product> Products { get; set; } = new();
        public List<string> ValidationErrors { get; set; } = new();
        public string PageTitle { get; set; } = "Default Title";

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void OnGet()
        {
            PageTitle = _configuration["PageTitle"] ?? "Shop";
            var productList = new List<Product>

        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, ImageUrl = "/images/laptop.jpg" },
             new Product { Id = 2, Name = "Headphones", Price = 199.99m, ImageUrl = "/images/headphones.jpg" },
            new Product { Id = 3, Name = "Phone", Price = 799.99m, ImageUrl = "/images/phone.jpg" }
        };

        ViewData["Title"] = PageTitle;
            var validator = new ProductValidator();

            foreach (var product in productList)
            {
                ValidationResult result = validator.Validate(product);
                if (result.IsValid)
                    Products.Add(product);
                else
                    ValidationErrors.AddRange(result.Errors.Select(e => e.ErrorMessage));
            }
        }

    }
}
