using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class SalesInvoicePaymentDto
    {
        public long SalesInvoicePaymentID { get; set; }
        public long SalesInvoiceID { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentDesc { get; set; }
        public long PaymentModeID { get; set; }
        public List<SelectListItem> PaymentModes { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal TotalInvoiceAmount { get; set; }
        public string CustomerOrPartyName { get; set; }
        public Int64 CustomerOrPartyID { get; set; }
        public bool IsChequePayment { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
    }
}
