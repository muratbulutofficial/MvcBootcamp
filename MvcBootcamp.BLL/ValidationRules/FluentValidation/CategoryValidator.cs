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
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Kategori adı en fazla 30 karakter olmalıdır.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Açıklama en fazla 100 karakter olmalıdır.");
        }
    }
}
