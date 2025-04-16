using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
public class POTermandConditionController : Controller
{
    IbillingCompanyRepo BRepo;
    IPOTemsAndConditionRepo IPRepo;
    public POTermandConditionController(IbillingCompanyRepo BRepo, IPOTemsAndConditionRepo IPRepo)
    {
        this.BRepo = BRepo;
       this.IPRepo = IPRepo;
    }
    public async Task<IActionResult> Index()
    {
        return View(await this.IPRepo.GetAll());
    }

    [HttpGet]
    public async Task<ActionResult> Create()
    {
        ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(POTermsAndConditions rec)
    {
        ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
        if (ModelState.IsValid)
        {
            await this.IPRepo.Create(rec);
            return RedirectToAction("Index");
        }
        return View(rec);
    }
    [HttpGet]
    public async Task<ActionResult> Edit(Int64 id)
    {
        var rec = await this.IPRepo.Get(id);
        ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
        return View(rec);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(POTermsAndConditions rec)
    {
        ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
        if (ModelState.IsValid)
        {

            await this.IPRepo.Update(rec);
            return RedirectToAction("Index");
        }
        return View(rec);
    }

    [HttpGet]
    public async Task<ActionResult> Delete(Int64 id)
    {
        await this.IPRepo.Delete(id);
        return RedirectToAction("Index");
    }


}
}



