using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("ExpenseTbl")]
    public class ExpenseType
    {
        [Key]
        public Int64 ExpenseTypeID {  get; set; }
        public string ExpenseTypeName { get; set; }
        public bool ActiveFlag {  get; set; }

        public Int64 BillingCompanyID { get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
    }
}
