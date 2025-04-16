using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
   

        [Area("HomeArea")]
        [Clompanyuserauth]
        public class BrandController : Controller
        {
            IbillingCompanyRepo IBRepo;
             IBrandRepo BRepo;
            
            public BrandController(IbillingCompanyRepo IBRepo, IBrandRepo BRepo)
            {
                this.IBRepo = IBRepo;
                this.BRepo = BRepo;
            }
            public async Task<IActionResult> Index()
            {
                return View(await this.BRepo.GetAll());
            }
            [HttpGet]
            public async Task<ActionResult> Create()
            {
                ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName");
                return View();
            }
            [HttpPost]
            public async Task<ActionResult> Create(Brand rec)
            {
                ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName");
                if (ModelState.IsValid)
                {
                    await this.BRepo.Create(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Edit(Int64 id)
            {
                var rec = await this.BRepo.Get(id);
                ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                return View(rec);
            }

            [HttpPost]

            public async Task<ActionResult> Edit(Brand rec)
            {
                ViewBag.BillingCompanies = new SelectList(await this.IBRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                if (ModelState.IsValid)
                {

                    await this.BRepo.Update(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Delete(Int64 id)
            {
                await this.BRepo.Delete(id);
                return RedirectToAction("Index");
            }


        }
    }







