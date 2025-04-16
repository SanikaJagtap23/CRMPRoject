using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("CustomerORPartyTbl")]
    public class CustomerORParty
    {
        [Key]
        public  Int64 CustomerORPartyID {  get; set; }
        public string CustomerName { get; set; }
        public string Address {  get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string WebsiteUrl {  get; set; }
        public string PinCode {  get; set; }
        public string ContactPersonName { get; set; }
        public decimal OpeningBalance {  get; set; }
        public bool IsActive {  get; set; }
        public Int64 CityID {  get; set; }
        public virtual City City { get; set; }
        public Int64 CustomerCategoryID {  get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual List<SalesInvoice> SalesInvoices { get; set; }


    }
}
