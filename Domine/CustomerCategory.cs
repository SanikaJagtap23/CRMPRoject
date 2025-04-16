using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("CustomerCategoryTbl")]
    public class CustomerCategory
    {
        [Key]
        public Int64 CustomerCategoryID {  get; set; }
        public string CustomerCategoryName { get; set; }
        public bool ActiveFlag {  get; set; }
        public Int64 BillingCompanyID {  get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
        public virtual List<CustomerORParty> CustomerORParties { get; set; }


    }
}
