using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace App.Services.Products
{
    public class CreateProductRequestValidator :AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ürün ismi gereklidir.")
                .NotEmpty().WithMessage("ürün ismi gereklidir.")
                .Length(3,10).WithMessage("ürün ismi 3 ile 10 karakter arasında olmalıdır");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("ürün fiyatı 0' dan büyük olmalıdır.");
            RuleFor(x => x.Stock).InclusiveBetween(1, 100).WithMessage("Stock miktarı 1 ila 100 arasında olmalıdır.");


        }


    }
}
