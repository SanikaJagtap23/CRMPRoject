using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    
    
        [Area("HomeArea")]
        [Clompanyuserauth]
        public class UnitController : Controller
        {
            IbillingCompanyRepo BRepo;
            IUniteRepo URepo;
            public UnitController(IbillingCompanyRepo BRepo, IUniteRepo URepo)
            {
                this.URepo = URepo;
                this.BRepo = BRepo;
            }
        public async Task<IActionResult> Index()
        {
            return View(await this.URepo.GetAllUnits());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var res = await this.URepo.GetAll();
            ViewBag.MasterUnits = res.Where(p => p.IsMasterUnitID).ToList();

            return View(new Unit());
        }


        [HttpPost]
        public async Task<IActionResult> Create(Unit rec)
        {
            if (ModelState.IsValid)
            {
                if (rec.IsMasterUnitID)
                {
                    rec.MasterUnitID = 0;
                }

                await this.URepo.Add(rec);
                return RedirectToAction("Index");
            }

            var res = await this.URepo.GetAll();
            ViewBag.MasterUnits = res.Where(u => u.IsMasterUnitID).ToList();

            return View(rec);
        }
        [HttpGet]
            public async Task<ActionResult> Edit(Int64 id)
            {
                var rec = await this.URepo.Get(id);
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                return View(rec);
            }

            [HttpPost]

            public async Task<ActionResult> Edit(Unit rec)
            {
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                if (ModelState.IsValid)
                {

                    await this.URepo.Update(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Delete(Int64 id)
            {
                await this.URepo.Delete(id);
                return RedirectToAction("Index");
            }


        }
}









