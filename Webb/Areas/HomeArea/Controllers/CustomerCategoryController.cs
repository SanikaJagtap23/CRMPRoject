using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{

    [Area("HomeArea")]
    [Clompanyuserauth]
    public class CustomerCategoryController : Controller
    {
        ICustomerCategoryRepo ICRepo;
        IbillingCompanyRepo BRepo;

        public CustomerCategoryController(ICustomerCategoryRepo ICRepo, IbillingCompanyRepo IBRepo)
        {
            this.ICRepo = ICRepo;
            this.BRepo = IBRepo;

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
        public async Task<ActionResult> Create(CustomerCategory rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
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
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
            return View(rec);
        }

        [HttpPost]

        public async Task<ActionResult> Edit(CustomerCategory rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
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




