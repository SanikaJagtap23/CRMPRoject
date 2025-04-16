using Domine;
using Infra.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class DiscountRepo: GenRepo<Discount>, IDiscountRepo
    {
        CRMContext cntx;
        public DiscountRepo(CRMContext cntx) : base(cntx)
        {
            this.cntx = cntx;
        }
    }
}
