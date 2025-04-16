using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("SalesInvoiceDiscountTbl")]
    public class SalesInvoiceDiscount
    {
        [Key]
        public Int64 SalesInvoiceDiscountID {  get; set; }
        public decimal DiscountApplied {  get; set; }
        public  bool IsPercentile {  get; set; }
        public decimal DisCountAmt {  get; set; }
        public Int64 DiscountID {  get; set; }
        public virtual Discount Discount { get; set; }
        public Int64 SalesInvoiceID {  get; set; }
        public virtual SalesInvoice SalesInvoice { get; set; }
    }
}
