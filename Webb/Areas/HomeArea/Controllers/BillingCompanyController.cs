using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{


    [Area("HomeArea")]
    [Clompanyuserauth]
    public class BillingCompanyController : Controller
    {
        IbillingCompanyRepo repo;
        public BillingCompanyController(IbillingCompanyRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetAll());
        }

    }

}

