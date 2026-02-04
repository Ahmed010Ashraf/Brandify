using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationException:Exception
    {
        public List<string> errors;
        public ValidationException(List<string> Errors):base("validation errors")
        {
            errors = Errors;
        }
    }
}
