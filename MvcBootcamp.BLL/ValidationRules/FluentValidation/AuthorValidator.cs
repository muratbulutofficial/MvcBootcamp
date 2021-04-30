using FluentValidation;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<Author>
    {

        public AuthorValidator()
        {
            RuleFor(x => x.Nickname).NotEmpty().WithMessage("Kullanıcı adı giriniz.");

            RuleFor(x => x.EMail).NotEmpty().WithMessage("Email adresi giriniz.");
            RuleFor(x => x.EMail).Must(Inside).WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre giriniz.");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifre min. 5 karakter içermeli.");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifre max. 20 karakter içermeli.");

        }

        private bool Inside(string arg)
        {
            return arg.Contains('@');
        }
    }
}
