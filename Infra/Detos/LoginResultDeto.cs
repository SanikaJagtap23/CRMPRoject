using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class LoginResultDeto
    {
        public Int64 LoggedInID { get; set; }
        public string Message { get; set; }
        public bool IsLoggedIn { get; set; }
        public string LoggedInName { get; set; }
    }
}
