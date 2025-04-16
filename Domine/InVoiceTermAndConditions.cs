using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("InVoiceTermAndConditionsTbl")]
    public class InVoiceTermAndConditions
    {
        [Key]
       public Int64 InVoiceTermAndConditionsID {  get; set; }
        public string InVoiceTermAndConditionsName { get; set; }
        public bool ActiveFlag {  get; set; }
        public Int64 BillingCompanyID {  get; set; }
        public virtual BillingCompany BillingCompany { get; set; }
    }
}
