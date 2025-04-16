using Domine.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("PurchaseOrderTbl")]
    public class PurchaseOrder
    {
        [Key]
        public Int64 PurchaseOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public String PONumber { get; set; }
        public bool ActiveFlage { get; set; }
        public InVoicePaymentTypeEnum PaymentType { get; set; }
        public Int64 SupplierORVenderID { get; set; }
        public virtual SupplierORVender SupplierORVenders { get; set; }
        public Int64 BillingCompanyID {  get; set; }
        public virtual BillingCompany BillingCompany { get; set; }   
        public virtual List<PurchaseOrderTerms> PurchaseOrderTerms { get; set; }
        public virtual List<PurchaseOrderDet> PurchaseOrderDets { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
