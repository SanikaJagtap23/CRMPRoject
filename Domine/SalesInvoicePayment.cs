using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("SalesInvoicePaymentTbl")]
    public class SalesInvoicePayment
    {
        [Key]
        public Int64 SalesInvoicePaymentID {  get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmt {  get; set; }
        public string PaymentDesc {  get; set; }
        public Int64 PaymentModeID {  get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
        [ForeignKey("SalesInvoice")]
        public Int64 SalesInvoiceID {  get; set; }
        public virtual SalesInvoice SalesInvoice { get; set; }
        public  virtual List<SalesInvoicePaymentCheque> SalesInvoicePaymentCheque { get;set; }  
    }
}
