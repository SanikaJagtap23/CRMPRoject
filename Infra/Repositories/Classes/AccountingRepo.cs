using Domine;
using Infra.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class AccountingRepo: GenRepo<Accounting>, IAccountingRepo
    {

        CRMContext cntx;
        public AccountingRepo(CRMContext cntx) : base(cntx)
        {
            this.cntx = cntx;
        }
    }
    
    
}
