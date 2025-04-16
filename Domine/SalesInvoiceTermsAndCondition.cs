using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("SalesInvoiceTermsAndConditionTbl")]
    public class SalesInvoiceTermsAndCondition
    {
        [Key]
        public Int64 SalesInvoiceTermsAndConditionID {  get; set; }
        public String SalesInvoiceTermsAndConditionName {  get; set; }
        public bool ActiveFlag {  get; set; }
        public Int64 BillingCompanyID {  get; set; }    
        public virtual BillingCompany BillingCompany { get; set; }
        public virtual List<PurchaseInvoiceTerms> PurchaseInvoiceTerms { get; set; }
    }
}
