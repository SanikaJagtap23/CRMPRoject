using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class ItemCategoryController : Controller
    {
        IbillingCompanyRepo BRepo;
        IitemCategoryRepo IRepo;
        public ItemCategoryController(IbillingCompanyRepo BRepo, IitemCategoryRepo IRepo)
        {
            this.BRepo = BRepo;
            this.IRepo = IRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.IRepo.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ItemCategory rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
            if (ModelState.IsValid)
            {
                await this.IRepo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.IRepo.Get(id);
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
            return View(rec);
        }

        [HttpPost]

        public async Task<ActionResult> Edit(ItemCategory rec)
        {
            ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
            if (ModelState.IsValid)
            {

                await this.IRepo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.IRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}


