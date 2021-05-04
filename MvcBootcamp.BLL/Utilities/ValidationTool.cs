using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Utilities
{
    public class ValidationTool
    {
        public static void FluentValidate(IValidator validatior, object entity)
        {
            var result = validatior.Validate(entity);
            if (result.Errors.Count > 0)
                throw new ValidationException(result.Errors);
        }

    }
}
