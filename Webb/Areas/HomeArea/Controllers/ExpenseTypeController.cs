using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    
   
        [Area("HomeArea")]
        [Clompanyuserauth]
        public class ExpenseTypeController : Controller
        {
            IbillingCompanyRepo BRepo;
            IExpenseTypeRepo ERepo;
            public ExpenseTypeController(IbillingCompanyRepo BRepo, IExpenseTypeRepo ERepo)
            {
                this.ERepo = ERepo;
                this.BRepo = BRepo;
            }
            public async Task<IActionResult> Index()
            {
                return View(await this.ERepo.GetAll());
            }
            [HttpGet]
            public async Task<ActionResult> Create()
            {
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
                return View();
            }
            [HttpPost]
            public async Task<ActionResult> Create(ExpenseType rec)
            {
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
                if (ModelState.IsValid)
                {
                    await this.ERepo.Create(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Edit(Int64 id)
            {
                var rec = await this.ERepo.Get(id);
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                return View(rec);
            }

            [HttpPost]

            public async Task<ActionResult> Edit(ExpenseType rec)
            {
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                if (ModelState.IsValid)
                {

                    await this.ERepo.Update(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Delete(Int64 id)
            {
                await this.ERepo.Delete(id);
                return RedirectToAction("Index");
            }


        }
    }







