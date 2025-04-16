using Domine;
using Infra.Repositories.Classes;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class ItemController : Controller
    {
        IitemCategoryRepo IRepo;
        IUniteRepo URepo;
        IitemRepo IiRepo;
        public ItemController(IitemCategoryRepo IRepo, IUniteRepo URepo, IitemRepo IiRepo)
        {
            this.IRepo = IRepo;
            this.URepo = URepo;
            this.IiRepo = IiRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.IiRepo.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.ItemCategories = new SelectList(await this.IRepo.GetAll(), "ItemcategoryID", "ItemcategoryName");
            ViewBag.Unities = new SelectList(await this.URepo.GetAll(), "UnitID", "UnitName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Item rec)
        {
            ViewBag.ItemCategories = new SelectList(await this.IRepo.GetAll(), "ItemcategoryID", "ItemcategoryName");
            ViewBag.Unities = new SelectList(await this.URepo.GetAll(), "UnitID", "UnitName");
            if (ModelState.IsValid)
            {
                await this.IiRepo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.IiRepo.Get(id);
            ViewBag.ItemCategories = new SelectList(await this.IRepo.GetAll(), "ItemcategoryID", "ItemcategoryName",rec.ItemCategoryID);
            ViewBag.Unities = new SelectList(await this.URepo.GetAll(), "UnitID", "UnitName",rec.UnitID); 
            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Item rec)
        {
            ViewBag.ItemCategories = new SelectList(await this.IRepo.GetAll(), "ItemcategoryID", "ItemcategoryName");
            ViewBag.Unities = new SelectList(await this.URepo.GetAll(), "UnitID", "UnitName");
            if (ModelState.IsValid)
            {

                await this.IiRepo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.IiRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}

    
