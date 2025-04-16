using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("CompanyUserTbl")]
    public class CompanyUser
    {
        [Key]
        public Int64 CompanyUserID {  get; set; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string EmailID {  get; set; }
        public string MobileNumber {  get; set; }
        public bool IsActive {  get; set; }
        public Int64 BillingCompanyID {  get; set; }
        public virtual BillingCompany BillingCompany { get; set; }


    }
}
