using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotAllowedExtention(string msg = "the image extention is not allowed"):Exception(msg)
    {
    }
}
