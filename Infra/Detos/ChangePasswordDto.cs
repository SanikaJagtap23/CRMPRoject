using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Password Requried")]
        [DataType(DataType.Password)]
        public String OldPassword {  get; set; }
        [Required(ErrorMessage = "New Password Requried")]
        [DataType(DataType.Password)]
        public String NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password Requried")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Confirm Password and New Password are not Same!")]
        public String ConfirmPassword { get; set; }
    }
}
