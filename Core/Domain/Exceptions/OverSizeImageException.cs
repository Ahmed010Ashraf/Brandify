using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class OverSizeImageException(string msg = "the image size is over 2mb"):Exception(msg)
    {
    }
}
