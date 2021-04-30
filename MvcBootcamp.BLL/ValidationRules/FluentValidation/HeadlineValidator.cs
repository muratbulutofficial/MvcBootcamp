using FluentValidation;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.ValidationRules.FluentValidation
{
    public class HeadlineValidator:AbstractValidator<Headline>
    {
        public HeadlineValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori seçiniz.");

            RuleFor(x => x.Text).NotEmpty().WithMessage("Başlık adı giriniz.");
            RuleFor(x => x.Text).MaximumLength(100).WithMessage("Başlık adı max. 100 karakter içermelidir.");
        }
    }
}
