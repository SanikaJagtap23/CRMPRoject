using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("BrandTbl")]
    public class Brand
    {
        [Key]
        public Int64 BrandID {  get; set; }
        public string BrandName { get; set; }
        public bool IsActiveFlag {  get; set; }

        public Int64 BillingCompanyID { get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
    }
}
