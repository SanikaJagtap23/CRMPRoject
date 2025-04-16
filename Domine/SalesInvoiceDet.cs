using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("SalesInvoiceDetTbl")]
    public class SalesInvoiceDet
    {
        [Key]
        public Int64 SalesInvoiceDetID {  get; set; }
        public decimal Qty {  get; set; }
        public decimal Price {  get; set; }
        public bool IsFreeOrSample {  get; set; }
        public Int64 ItemID {  get; set; }
        public virtual Item Item { get; set; }
        public Int64 UnitID {  get; set; }
        public virtual Unit Unit { get; set; }
        public Int64 SalesInvoiceID {  get; set; }
        public virtual SalesInvoice SalesInvoice { get; set; }
    }
}
