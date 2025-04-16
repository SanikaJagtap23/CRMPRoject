using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("POTermsAndConditionsTbl")]
    public class POTermsAndConditions
    {
        [Key]
        public Int64 POTermsAndConditionsID {  get; set; }
        public string POTermsAndConditionsName {  get; set; }
        public  bool ActiveFlag {  get; set; }
        public Int64 BillingCompanyID {  get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
        public virtual List<PurchaseOrderTerms> PurchaseOrderTerms { get; set; }
    }
}
