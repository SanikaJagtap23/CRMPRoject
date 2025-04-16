using Domine;
using Infra.Detos;
using Microsoft.EntityFrameworkCore;
using Infra.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class UnitRepo : GenRepo<Unit>, IUniteRepo
    {

        CRMContext cntx;
    
    public UnitRepo(CRMContext cntx) : base(cntx)
    {
        this.cntx = cntx;
    }
        public async Task Add(Unit rec)
        {
            rec.ActiveFlag = true;

            rec.BillingCompanyID = 1;

            await this.cntx.Units.AddAsync(rec);
            await this.cntx.SaveChangesAsync();
        }

        public async Task<IEnumerable<UnitDto>> GetAllUnits()
        {
            var res = await (from u in this.cntx.Units
                             join mu in this.cntx.Units on u.MasterUnitID equals mu.UnitID into masterUnit
                             from muUnit in masterUnit.DefaultIfEmpty()
                             select new UnitDto
                             {
                                 UnitID = u.UnitID,
                                 UnitName = u.UnitName,
                                 IsMasterUnitID = u.IsMasterUnitID,
                                 ActiveFlag = u.ActiveFlag,
                                 QtyPerUnit = u.QtyPerUnit,
                                 MasterUnitID = u.MasterUnitID,
                                 MasterUnitName = muUnit == null ? null : muUnit.UnitName,
                                 BillingCompanyName = u.BillingCompany.CompanyName
                             })
                             .ToListAsync();

            return res;
        }


    }
}
