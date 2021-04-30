using FluentValidation;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.ValidationRules.FluentValidation
{
    public class ContactFormValidator:AbstractValidator<ContactForm>
    {
        public ContactFormValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınızı giriniz.");

            RuleFor(x => x.EMail).NotEmpty().WithMessage("Email adresi giriniz.");
            RuleFor(x => x.EMail).Must(Inside).WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesajınızı giriniz.");
            RuleFor(x => x.Message).MaximumLength(300).WithMessage("Mesaj max. 300 karakter içermeli.");

        }

        private bool Inside(string arg)
        {
            return arg.Contains('@');
        }
    }
}
