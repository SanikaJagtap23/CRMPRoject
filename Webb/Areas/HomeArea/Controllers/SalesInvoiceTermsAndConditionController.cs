using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class SalesInvoiceTermsAndConditionController : Controller
    {

        IbillingCompanyRepo BRepo;
        IinvoiceTermsAndConditionRepo ICRepo;
        public SalesInvoiceTermsAndConditionController(IbillingCompanyRepo BRepo, IinvoiceTermsAndConditionRepo ICRepo)
        {
            this.BRepo = BRepo;
            this.ICRepo = ICRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.ICRepo.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SalesInvoiceTermsAndCondition rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingID", "CompanyName");
            if (ModelState.IsValid)
            {
                await this.ICRepo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.ICRepo.Get(id);

            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SalesInvoiceTermsAndCondition rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);

            if (ModelState.IsValid)
            {

                await this.ICRepo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.ICRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
