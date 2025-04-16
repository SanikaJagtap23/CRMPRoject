using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{ 
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class CityController : Controller
    {

        IStateRepo ISRepo;
        ICityRepo ICRepo;
        public CityController(IStateRepo ISRepo, ICityRepo ICRepo)
        {
            this.ICRepo = ICRepo;
            this.ISRepo = ISRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.ICRepo.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.States = new SelectList(await this.ISRepo.GetAll(), "StateID", "StateName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(City rec)
        {
            ViewBag.States = new SelectList(await this.ISRepo.GetAll(), "StateID", "StateName");
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
            ViewBag.States = new SelectList(await this.ISRepo.GetAll(), "StateID", "StateName", rec.StateID);
            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(City rec)
        {
            ViewBag.States = new SelectList(await this.ISRepo.GetAll(), "StateID", "StateName", rec.StateID);
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




