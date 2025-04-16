using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("SupplierORVenderTbl")]
    public class SupplierORVender
    {
        [Key]
        public Int64 SupplierORVenderID {  get; set; }
        public string SupplierORVenderName {  get; set; }
        public string Address {  get; set; }
        public string MobileNo { get; set; }
        public string EmailID {  get; set; }
        public string WebSiteUrl { get; set; }
        public string PinCode {  get; set; }
        public string ContactPersonName { get; set; }
        public bool IsActive { get; set; }
        public DateTime OpeningBalanceDate {  get; set; }
        public Int64 CityID {  get; set; }
        public virtual City City { get; set; }
        public virtual List<PurchaseOrder> PurchaseOrders { get; set; }
      

    }
}
