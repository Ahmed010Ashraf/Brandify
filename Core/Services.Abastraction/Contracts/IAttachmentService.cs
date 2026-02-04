using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abastraction.Contracts
{
    public interface IAttachmentService
    {
        public string Upload(IFormFile file ,string FolderName = "Images");
        public bool Delete(string FilePath);
    }
}
