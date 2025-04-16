using Infra;
using Infra.Detos;
using Microsoft.AspNetCore.Mvc;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class SalesReportController : Controller
    {
        CRMContext cntx;
        public SalesReportController(CRMContext cntx)
        {
            this.cntx = cntx;
        }

        public IActionResult Index()
        {
            var res= this.cntx.SalesInvoices.ToList();
            return View(res);
        }

        [HttpPost]
        public IActionResult SearchByDate(DateTime? fromDate, DateTime? toDate)
        {
            var salesInvoices = cntx.SalesInvoices.AsQueryable();

            if (fromDate.HasValue && toDate.HasValue)
            {
                salesInvoices = salesInvoices.Where(x => x.SalesInVoiceDate >= fromDate && x.SalesInVoiceDate <= toDate);
            }

            var res = salesInvoices.ToList();
            return View("Index", res); 
        }


        public IActionResult SalesPaymentRep()
        {
            var salesPayments = cntx.CustomerORParties.Select(cust => new SalesPaymentReportDto
            {
                CustomerName = cust.CustomerName,
                TotalAmount = cntx.SalesInvoices
            .Where(si => si.CustomerOrPartyID == cust.CustomerORPartyID)
            .Sum(si => si.TotalAmount),

                PaidAmount = cntx.SalesInvoicesPayment
            .Where(p => p.SalesInvoice.CustomerOrPartyID == cust.CustomerORPartyID)
            .Sum(p => p.PaymentAmt),

                BalanceAmount = cust.OpeningBalance - cntx.SalesInvoicesPayment
            .Where(p => p.SalesInvoice.CustomerOrPartyID == cust.CustomerORPartyID)
            .Sum(p => p.PaymentAmt)

            }).ToList();

            return View(salesPayments);
        }


        [HttpPost]
        public IActionResult SearchPaymentDate(DateTime? fromDate, DateTime? toDate)
        {
            var salesPayments = cntx.SalesInvoicesPayment
                .Where(p => (!fromDate.HasValue || p.PaymentDate >= fromDate) &&
                            (!toDate.HasValue || p.PaymentDate <= toDate))
                .GroupBy(p => p.SalesInvoice.CustomerOrPartyID)
                .Select(group => new SalesPaymentReportDto
                {
                    CustomerName = group.First().SalesInvoice.CustomerORParty.CustomerName,

                    TotalAmount = cntx.SalesInvoices
                        .Where(si => si.CustomerOrPartyID == group.Key)
                        .Sum(si => si.TotalAmount),

                    PaidAmount = group.Sum(p => p.PaymentAmt),

                    BalanceAmount = group.First().SalesInvoice.CustomerORParty.OpeningBalance - group.Sum(p => p.PaymentAmt)
                })
                .ToList();

            return View("SalesPaymentRep", salesPayments);
        }



    }
}
