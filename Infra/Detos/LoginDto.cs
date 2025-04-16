using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "UserName Required")]
        public String UserName {  get; set; }
        [Required(ErrorMessage = "Password Requird")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
