using FluentValidation;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı giriniz.");
            RuleFor(x => x.Name).Length(3,30).WithMessage("Kategori adı 3 - 30 karakter arası olmalıdır.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Açıklama en fazla 100 karakter olmalıdır.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Kategori durumu seçiniz.");
        }
    }
}
