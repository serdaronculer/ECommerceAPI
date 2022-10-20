using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Ürün adı boş geçilemez.").
                NotNull().WithMessage("Ürün adı boş geçilemez.").
                MaximumLength(50).WithMessage("Ürün adı 50 karakterden fazla olamaz");

            RuleFor(p => p.Stock)
                .Must(stock => stock >= 0).WithMessage("Stok adedi 0 dan küçük olamaz.");

            RuleFor(p => p.Price)
                .Must(price => price >= 0).WithMessage("Ürün fiyatı 0 dan küçük olamaz.");


        }

    }
}
