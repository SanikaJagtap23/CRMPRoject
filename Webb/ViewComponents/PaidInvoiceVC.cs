using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Webb.ViewComponents
{
    public class PaidInvoiceVC:ViewComponent
    {
        CRMContext cntx;
        public PaidInvoiceVC(CRMContext cntx)
        {
            this.cntx = cntx;
        }

        public IViewComponentResult Invoke()
        {
            var paidInvoices = cntx.SalesInvoices
                             .Include(si => si.CustomerORParty)
                             .Include(si => si.BillingCompany)
                             .Where(si => cntx.SalesInvoicesPayment.Any(p => p.SalesInvoiceID == si.SalesInvoiceID)) // Filter unpaid invoices
                             .ToList();

            return View(paidInvoices);
        }
    }
}
