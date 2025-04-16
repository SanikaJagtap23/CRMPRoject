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
    [Table("SalesInvoiceTbl")]
    public class SalesInvoice
    {
        [Key]
        public Int64 SalesInvoiceID {  get; set; }
        public DateTime SalesInVoiceDate { get; set; }
        public string InVoiceNo {  get; set; }
        public bool ActiveFlag {  get; set; }
        public DateTime SalesOrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Int64 BillingCompanyID { get; set; }      
        public virtual BillingCompany BillingCompany { get; set; }
        public Int64 CustomerOrPartyID {  get; set; }
        public virtual CustomerORParty CustomerORParty { get; set; }
        public string SalesOrderNo {  get; set; }
        public InVoicePaymentTypeEnum InVoicePaymentType { get; set; }

        public virtual List<SalesInvoiceDet> SalesInvoiceDets { get; set; } 
        public virtual List<PurchaseInvoiceTerms> PurchaseInvoiceTerms { get; set; } 
        public virtual List<SalesInvoiceDiscount> SalesInvoiceDiscounts { get; set; } 
        public virtual List<SalesInvoicePayment> SalesInvoicePayments { get; set; }
      
    }
}
