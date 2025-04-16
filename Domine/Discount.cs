using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("DiscountTbl")]
    public class Discount
    {
        [Key]
        public Int64 DiscountID {  get; set; }
        public string DiscountName {  get; set; }
        public bool ActiveFlag {  get; set; }
        public decimal DiscountAmount { get; set; }
        public bool IsPercentile {  get; set; }
        public Int64 BillingCompanyID {  get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
        public virtual List<SalesInvoiceDiscount>SalesInvoiceDiscounts { get; set; }    
    }
}
