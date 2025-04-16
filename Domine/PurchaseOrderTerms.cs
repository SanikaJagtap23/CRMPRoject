using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("PurchaseOrderTermsTbl")]
    public class PurchaseOrderTerms
    {
        [Key]
        public Int64 PurchaseOrderTermID {  get; set; }
        

        [ForeignKey("POTermsAndConditions")]
        public Int64 POTermsAndConditionID {  get; set; }   
        public virtual POTermsAndConditions POTermsAndConditions { get; set; }
        public Int64 PurchaseOrderID {  get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

    }
}
