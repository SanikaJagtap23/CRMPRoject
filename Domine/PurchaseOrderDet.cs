using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("PurchaseOrderDetTbl")]
    public class PurchaseOrderDet
    {
        [Key]
        public Int64 PurchaseOrderDetID {  get; set; }
        public Int64 PurchaseOrderID {  get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public Int64 ItemID {  get; set; }
        public virtual Item Item { get; set; }
        public Int64 UnitID {  get; set; }
        public virtual Unit Unit { get; set; }
        public Decimal Qty { get; set; }
        public Decimal Price {  get; set; }



    }
}
