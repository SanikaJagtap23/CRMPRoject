using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class UnitDto
    {
        public Int64 UnitID { get; set; }
        public string UnitName { get; set; }
        public bool IsMasterUnitID { get; set; }
        public bool ActiveFlag { get; set; }
        public decimal QtyPerUnit { get; set; }
        public Int64? MasterUnitID { get; set; }
        public string MasterUnitName { get; set; }
        public string BillingCompanyName { get; set; }
    }
}
