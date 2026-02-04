using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserNofFoundException(string email):NotFoundExceptions($"user with this email is not found : {email}")
    {
    }
}
