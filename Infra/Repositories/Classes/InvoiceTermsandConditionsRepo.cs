using Domine;
using Infra.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class InvoiceTermsandConditionsRepo: GenRepo<SalesInvoiceTermsAndCondition>,IinvoiceTermsAndConditionRepo
    {

        CRMContext cntx;
        public InvoiceTermsandConditionsRepo(CRMContext cntx) : base(cntx)
        {
            this.cntx = cntx;
        }

       
    }
}
