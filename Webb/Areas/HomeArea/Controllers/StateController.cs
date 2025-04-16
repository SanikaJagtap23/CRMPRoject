using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class StateController : Controller
    {
        ICountryRepo ICRepo;
        IStateRepo ISRepo;
       public StateController(ICountryRepo ICRepo,IStateRepo ISRepo)
        {
            this.ICRepo = ICRepo;
            this.ISRepo = ISRepo;   
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.ISRepo.GetAll());
        }
        [HttpGet]
        public async Task< ActionResult> Create()
        {
            ViewBag.Countries = new SelectList(await this.ICRepo.GetAll() ,"CountryID", "CountryName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(State rec)
        {
            ViewBag.Countries = new SelectList(await this.ICRepo.GetAll(), "CountryID", "CountryName");
            if (ModelState.IsValid)
            {
                await this.ISRepo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.ISRepo.Get(id);
            ViewBag.Countries = new SelectList(await this.ICRepo.GetAll(), "CountryID", "CountryName", rec.CountryID);
            return View(rec);
        }

        [HttpPost]

        public async Task<ActionResult> Edit(State rec)
        {
            ViewBag.Countries = new SelectList(await this.ICRepo.GetAll(), "CountryID", "CountryName",rec.CountryID);
            if (ModelState.IsValid)
            {

                await this.ISRepo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.ISRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}

