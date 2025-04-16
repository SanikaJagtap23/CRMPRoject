using Infra.Detos;
using Infra.Repositories.Interface;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;
using Domine;
using Microsoft.EntityFrameworkCore;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class SalesInvoiceController : Controller
    {
        ISalesInvoiceRepo srepo;
        CRMContext cntx;
        public SalesInvoiceController(ISalesInvoiceRepo srepo, CRMContext cntx)
        {
            this.srepo = srepo;
            this.cntx = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cntx.SalesInvoices.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new SalesInvoiceDto();


            var customerParties = this.cntx.CustomerORParties.ToList();
            viewModel.CustParties = customerParties.Select(cp => new SelectListItem
            {
                Value = cp.CustomerORPartyID.ToString(),
                Text = cp.CustomerName
            }).ToList();
            var items = this.cntx.Items.ToList();
            viewModel.InvoiceItems = items.Select(item => new SelectListItem
            {
                Value = item.ItemID.ToString(),
                Text = item.ItemName
            }).ToList();

            var discounts = this.cntx.Discounts.ToList();
            viewModel.Discounts = discounts.Any()
                ? discounts.Select(d => new SelectListItem
                {
                    Value = d.DiscountID.ToString(),
                    Text = d.DiscountAmount.ToString()
                }).ToList()
                : new List<SelectListItem>();

            var terms = this.cntx.SalesInvoiceTermsAndConditions.ToList();
            viewModel.SalesInvoiceTermsAndCondition = terms.Select(item => new SelectListItem
            {
                Value = item.SalesInvoiceTermsAndConditionID.ToString(),
                Text = item.SalesInvoiceTermsAndConditionName
            }).ToList();

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SalesInvoiceDto rec)
        {
            if (ModelState.IsValid)
            {
                await srepo.CreateSalesInvoice(rec);
                return RedirectToAction("Index");

            }
            return View(rec);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var invoice = await srepo.GetSalesInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();

            var customerParties = this.cntx.CustomerORParties.ToList();
            invoice.CustParties = customerParties.Select(cp => new SelectListItem
            {
                Value = cp.CustomerORPartyID.ToString(),
                Text = cp.CustomerName
            }).ToList();

            var items = this.cntx.Items.ToList();
            invoice.InvoiceItems = items.Select(item => new SelectListItem
            {
                Value = item.ItemID.ToString(),
                Text = item.ItemName
            }).ToList();

            var discounts = this.cntx.Discounts.ToList();
            invoice.Discounts = discounts.Any()
                ? discounts.Select(d => new SelectListItem
                {
                    Value = d.DiscountID.ToString(),
                    Text = d.DiscountAmount.ToString()
                }).ToList()
                : new List<SelectListItem>();

            return View(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SalesInvoiceDto rec)
        {
            if (ModelState.IsValid)
            {
                await srepo.EditSalesInvoice(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        public async Task<IActionResult> Details(long id)
        {
            var invoice = await srepo.GetSalesInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var invoice = await cntx.SalesInvoices
                 .Include(s => s.SalesInvoiceDets)
                 .Include(s => s.SalesInvoiceDiscounts)
                 .Include(s => s.PurchaseInvoiceTerms)
                 .Include(s => s.SalesInvoicePayments)
                 .ThenInclude(p => p.SalesInvoicePaymentCheque)
                 .FirstOrDefaultAsync(s => s.SalesInvoiceID == id);

            if (invoice == null)
            {
                return NotFound();
            }

            foreach (var payment in invoice.SalesInvoicePayments)
            {
                cntx.salesInvoicePaymentCheques.RemoveRange(payment.SalesInvoicePaymentCheque);
            }


            cntx.SalesInvoiceDets.RemoveRange(invoice.SalesInvoiceDets);
            cntx.SalesInvoicesDiscount.RemoveRange(invoice.SalesInvoiceDiscounts);
            cntx.PurchaseInvoiceTerms.RemoveRange(invoice.PurchaseInvoiceTerms);
            cntx.SalesInvoicesPayment.RemoveRange(invoice.SalesInvoicePayments);

            cntx.SalesInvoices.Remove(invoice);

            await cntx.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> MakePayment(long id)
        {
            var invoice = await this.cntx.SalesInvoices
                .Include(s => s.CustomerORParty)
                .FirstOrDefaultAsync(s => s.SalesInvoiceID == id);

            if (invoice == null)
                return NotFound();

            var balanceAmount = await this.srepo.GetCustomerBalance(invoice.CustomerOrPartyID);

            var viewModel = new SalesInvoicePaymentDto
            {
                SalesInvoiceID = invoice.SalesInvoiceID,
                CustomerOrPartyID = invoice.CustomerOrPartyID,
                CustomerOrPartyName = invoice.CustomerORParty?.CustomerName ?? "N/A",
                TotalInvoiceAmount = invoice.TotalAmount,
                OpeningBalance = invoice.CustomerORParty?.OpeningBalance ?? 0,
                BalanceAmount = balanceAmount,
                PaymentModes = this.cntx.PaymentModes.Select(pm => new SelectListItem
                {
                    Value = pm.PaymentModeID.ToString(),
                    Text = pm.PaymentModeName
                }).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> MakePayment(SalesInvoicePaymentDto rec)
        {
            if (ModelState.IsValid)
            {
                await this.srepo.CreateSalesInvoicePayment(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
    }

}

