using Domine;
using Infra.Detos;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    public class AdminAreaController : Controller
    {
        ICompanyRepo repo;
        public AdminAreaController(ICompanyRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto rec)
        {
            if (ModelState.IsValid)
            {

                Int64 CompanyUserID = Convert.ToInt64(HttpContext.Session.GetString("CompanyUserID"));

                var res = await this.repo.ChangePassword(rec, CompanyUserID);

                ViewBag.Message = res.Message;
                return View(rec);
            }
            return View(rec);
        }


        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            Int64 CompanyUserID = Convert.ToInt64(HttpContext.Session.GetString("CompanyUserID"));
            var res = await this.repo.GetProfile(CompanyUserID);
            return View(res);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileDeto rec)
        {
            if (ModelState.IsValid)
            {
                Int64 CompanyUserID = Convert.ToInt64(HttpContext.Session.GetString("CompanyUserID"));
                var res = await this.repo.EditProfile(rec, CompanyUserID);
                ViewBag.Message = res.Message;
                return View(rec);
            }
            return View(rec);
        }


    }
}
    

