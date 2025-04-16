using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{

    [Area("HomeArea")]
    [Clompanyuserauth]
    public class CountryController : Controller
    {
        ICountryRepo repo;
        public CountryController(ICountryRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult>Index()
        {
            return View(await this.repo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public async Task<ActionResult> Create(Country rec)
        {
            if (ModelState.IsValid)
            {
                await this.repo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.repo.Get(id);
            return View(rec);
        }

        [HttpPost]

        public async Task<ActionResult> Edit(Country rec)
        {
            if (ModelState.IsValid)
            {

                await this.repo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.repo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
