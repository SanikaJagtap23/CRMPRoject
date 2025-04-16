using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class DiscountController : Controller
    {
        IDiscountRepo IDRepo;
        IbillingCompanyRepo IBRepo;
       
        public DiscountController(IDiscountRepo IDRepo, IbillingCompanyRepo IBRepo)
        {
            this.IDRepo = IDRepo;
            this.IBRepo = IBRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.IDRepo.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Discount rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName");
            if (ModelState.IsValid)
            {
                await this.IDRepo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.IDRepo.Get(id);
            ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName");
            return View(rec);
        }

        [HttpPost]

        public async Task<ActionResult> Edit(Discount rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName");
            if (ModelState.IsValid)
            {

                await this.IDRepo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.IDRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}


