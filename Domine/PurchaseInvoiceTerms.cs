using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("PurchaseInvoiceTermsTbl")]
    public class PurchaseInvoiceTerms
    {
        [Key]
        public Int64 PurchaseInvoiceTermsID {  get; set; }
        [ForeignKey("SalesInvoiceTermsAndCondition")]
        public Int64 SalesInvoiceTermsAndConditionID { get; set; }
        public Int64 SalesInvoiceID {  get; set; }
        public virtual SalesInvoice SalesInvoice { get; set; }
        public virtual SalesInvoiceTermsAndCondition SalesInvoiceTermsAndCondition { get; set; }

    }
}
