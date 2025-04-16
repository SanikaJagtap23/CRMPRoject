using Domine.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class PurchaseOrderDto
    {
        public Int64 PurchaseOrderID { get; set; }
        public String PONumber { get; set; }
        public InVoicePaymentTypeEnum PaymentType { get; set; }
        public Int64 SupplierORVenderID { get; set; }
        public Decimal Qty { get; set; }
        public Decimal Price { get; set; }
        public String PurchaseOrderTermsName { get; set; }
        public Int64 POTermsAndConditionID { get; set; }

        public List<SalesInvoiceItemDto> Items { get; set; } = new List<SalesInvoiceItemDto>();
        public decimal TotalAmount => Items.Sum(i => i.Qty * i.Price);

        public List<SelectListItem> InvoiceItems { get; set; }
        public List<SelectListItem> SupplierORVendors { get; set; }
        public List<SelectListItem> POTermsAndConditions { get; set; }
        public List<Int64> SelectedTerms { get; set; } = new List<Int64>();
    }
}
    


