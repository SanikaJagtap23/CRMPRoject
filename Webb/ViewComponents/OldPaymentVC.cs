using Castle.Core.Resource;
using Domine;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Webb.ViewComponents
{
    public class OldPaymentVC:ViewComponent
    {
        CRMContext cntx;
        public OldPaymentVC(CRMContext cntx)
        {
            this.cntx = cntx;
        }

        public async Task<IViewComponentResult> InvokeAsync( Int64 customerId)
        {
            
            var salesInvoiceIds = await this.cntx.SalesInvoices
                .Where(si => si.CustomerOrPartyID == customerId)
                .Select(si => si.SalesInvoiceID)
                .ToListAsync();
            
            var payments = await this.cntx.SalesInvoicesPayment
                .Where(p => salesInvoiceIds.Contains(p.SalesInvoiceID))
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();

            return View(payments);
        }
    }
}
