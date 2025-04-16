using Domine.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class SalesInvoiceDto
    {
        public Int64 SalesInvoiceID { get; set; }
        public DateTime SalesInVoiceDate { get; set; }
        public string InVoiceNo { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime SalesOrderDate { get; set; }
        public Int64 BillingCompanyID { get; set; }
        public Int64 CustomerOrPartyID { get; set; }
        public string SalesOrderNo { get; set; }
        public InVoicePaymentTypeEnum InVoicePaymentType { get; set; }
        public string TermAndCondition { get; set; }
        public Int64 DiscountID { get; set; }
        public decimal DiscountApplied { get; set; }
        public bool IsPercentile { get; set; }
        public decimal DisCountAmt { get; set; }
        public String SalesInvoiceTermsAndConditionName {  get; set; }
        public Int64 SalesInvoiceTermsAndConditionID { get; set; }
        public List<SalesInvoiceItemDto> Items { get; set; } = new List<SalesInvoiceItemDto>();


        public decimal TotalAmount => Items.Sum(i => i.Qty * i.Price);
        public List<SelectListItem> Discounts { get; set; }
        public List<SelectListItem> CustParties { get; set; }
        public List<SelectListItem> InvoiceItems { get; set; }
        public List<SelectListItem> SalesInvoiceTermsAndCondition { get; set; }
        public List<Int64> SelectedTerms { get; set; } = new List<Int64>();

    }
}
    


