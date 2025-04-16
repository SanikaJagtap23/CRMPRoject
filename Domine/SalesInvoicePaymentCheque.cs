using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("SalesInvoicePaymentChequeTbl")]
    public class SalesInvoicePaymentCheque
    {
        [Key]
        public Int64 SalesInvoicePaymentChequeID {  get; set; }
        public DateTime ChequeDate { get; set; }
        public string BankName {  get; set; }
        public string ChequeNo { get; set; }
        public Int64 SalesPaymentInVoiceID {  get; set; }
        public virtual SalesInvoicePayment GetSalesInvoicePayment {  get; set; }        

    }
}
