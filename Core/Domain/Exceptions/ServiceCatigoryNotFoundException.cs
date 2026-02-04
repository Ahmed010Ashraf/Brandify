using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ServiceCatigoryNotFoundException(int id):NotFoundExceptions($"service category with this id :{id} is not found")
    {
    }
}
