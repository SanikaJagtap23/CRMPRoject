using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
   
        [Area("HomeArea")]
        [Clompanyuserauth]
        public class SupplierORVenderController : Controller
        {
            ISupplierORVendorRepo SRepo;
            ICityRepo CRepo;

            public SupplierORVenderController(ISupplierORVendorRepo SRepo, ICityRepo CRepo)
            {
                this.SRepo = SRepo;
                this.CRepo = CRepo;
            }
            public async Task<IActionResult> Index()
            {
                return View(await this.SRepo.GetAll());
            }
            [HttpGet]
            public async Task<ActionResult> Create()
            {
                ViewBag.Cities = new SelectList(await this.CRepo.GetAll(), "CityID", "CityName");
                return View();
            }
            [HttpPost]
            public async Task<ActionResult> Create(SupplierORVender rec)
            {
                ViewBag.Cities = new SelectList(await this.CRepo.GetAll(), "CityID", "CityName");
                if (ModelState.IsValid)
                {
                    await this.SRepo.Create(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Edit(Int64 id)
            {
                var rec = await this.SRepo.Get(id);
                ViewBag.Cities = new SelectList(await this.CRepo.GetAll(), "CityID", "CityName");
                return View(rec);
            }

            [HttpPost]

            public async Task<ActionResult> Edit(SupplierORVender rec)
            {
                ViewBag.Cities = new SelectList(await this.CRepo.GetAll(), "CityID", "CityName");
                if (ModelState.IsValid)
                {

                    await this.SRepo.Update(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Delete(Int64 id)
            {
                await this.SRepo.Delete(id);
                return RedirectToAction("Index");
            }


        }
    }




