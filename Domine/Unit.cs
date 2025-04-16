using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("UnitTbl")]
    public class Unit
    {
        [Key]
        public Int64 UnitID {  get; set; }
        public string UnitName { get; set; }
        public bool IsMasterUnitID {  get; set; }
        public bool ActiveFlag {  get; set; }
        public decimal QtyPerUnit {  get; set; }

        public Int64? MasterUnitID {  get; set; }

        public Int64 BillingCompanyID { get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<SalesInvoiceDet> SalesInvoiceDets { get; set; } 
        public virtual List<PurchaseOrderDet> PurchaseOrderDets { get; set; }

    }
}
