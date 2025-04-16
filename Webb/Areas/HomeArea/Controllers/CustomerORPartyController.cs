using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class CustomerORPartyController : Controller
    {
        ICityRepo ICRepo;
        ICustomerORPartyRepo ICPRepo;
        ICustomerCategoryRepo ICCRepo;

        public CustomerORPartyController(ICityRepo ICRepo, ICustomerORPartyRepo ICPRepo, ICustomerCategoryRepo ICCRepo)
        {
            this.ICRepo = ICRepo;
            this.ICCRepo = ICCRepo;
            this.ICPRepo = ICPRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.ICPRepo.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.Cities = new SelectList(await this.ICRepo.GetAll(), "CityID", "CityName");
            ViewBag.CustomerCategory = new SelectList(await this.ICCRepo.GetAll(), "CustomerCategoryID", "CustomerCategoryName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CustomerORParty rec)
        {
            ViewBag.Cities = new SelectList(await this.ICRepo.GetAll(), "CityID", "CityName");
            ViewBag.CustomerCategory = new SelectList(await this.ICCRepo.GetAll(), "CustomerCategoryID", "CustomerCategoryName");
            if (ModelState.IsValid)
            {
                await this.ICPRepo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.ICPRepo.Get(id);
            ViewBag.Cities = new SelectList(await this.ICRepo.GetAll(), "CityID", "CityName");
            ViewBag.CustomerCategory = new SelectList(await this.ICCRepo.GetAll(), "CustomerCategoryID", "CustomerCategoryName");
            return View(rec);
        }

        [HttpPost]

        public async Task<ActionResult> Edit(CustomerORParty rec)
        {
            
            if (ModelState.IsValid)
            {
                ViewBag.Cities = new SelectList(await this.ICRepo.GetAll(), "CityID", "CityName");
                ViewBag.CustomerCategory = new SelectList(await this.ICCRepo.GetAll(), "CustomerCategoryID", "CustomerCategoryName");
                await this.ICPRepo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.ICPRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}



