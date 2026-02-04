using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs.AuthDtos
{
    public class registrDto
    {
        [Required(ErrorMessage ="user name is required")]
        public string DiaplayName { get; set; }
        [Required(ErrorMessage ="user email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="user password is required")]
        public string Password { get; set; }    

        [Required(ErrorMessage ="phoneNumber is required")]
        public string PhoneNumber { get; set; }
    }
}
