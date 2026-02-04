using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Services.Abastraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class AttachmentService : IAttachmentService
    {
        
        private List<string> AllowedExtentions = [".jpg","png","jpeg"];

        private int MaxSize = 2 * 1024 * 1024;
        public string Upload(IFormFile file , string FolderName = "Images")
        {
            if(file == null)
            {
                return "";
            }

            if (file.Length > MaxSize) {
                throw new OverSizeImageException();
            }
            var extention = Path.GetExtension(file.FileName);
            if (!AllowedExtentions.Contains(extention)) {
                throw new NotAllowedExtention();
            }

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot" , "Files",FolderName);

            var FileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filepath = Path.Combine(folderPath,FileName);

            using var  FileStream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(FileStream);

            return $"Files/Images/{FileName}";

            
        }

        public bool Delete(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                return true;
            }
            return false;
        }
    }
}
