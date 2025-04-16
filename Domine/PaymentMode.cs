
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("PaymentModeTbl")]
    public class PaymentMode
    {
        [Key]
        public Int64 PaymentModeID {  get; set; }
        public string PaymentModeName { get; set; }
        public bool IsActiveFlag {  get; set; }

        public Int64 BillingCompanyID { get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
        public virtual List<SalesInvoicePayment> SalesInvoicePayments { get; set; } 
    }
}
