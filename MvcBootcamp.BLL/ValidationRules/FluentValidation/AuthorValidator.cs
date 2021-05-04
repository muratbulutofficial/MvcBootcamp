using FluentValidation;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<Author>
    {

        public AuthorValidator()
        {
            RuleFor(x => x.Nickname).NotEmpty().WithMessage("Kullanıcı adı giriniz.");

            RuleFor(x => x.EMail).NotEmpty().WithMessage("Email adresi giriniz.");
            RuleFor(x => x.EMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.").When(x => !string.IsNullOrEmpty(x.EMail));

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre giriniz.")
           .Must(IsPasswordValid).WithMessage("Parolanız en az 8 en fazla 20 karakter, en az bir harf ve bir sayı içermelidir!"); ;


        }

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$");
            return regex.IsMatch(arg);
        }
    }
}
