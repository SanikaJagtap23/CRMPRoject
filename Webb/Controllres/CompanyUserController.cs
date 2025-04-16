using Infra.Detos;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Webb.custauth;

namespace Webb.Controllres
{
    
    public class CompanyUserController : Controller
    {
        ICompanyRepo repo;
        public CompanyUserController(ICompanyRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this.repo.Login(rec);
                if (res.IsLoggedIn)
                {
                    HttpContext.Session.SetString("LoggedInName", res.LoggedInName);
                    HttpContext.Session.SetString("CompanyUserID", res.LoggedInID.ToString());
                    TempData["message"] = "You have successfully logged in!";
                    return RedirectToAction("Index", "AdminArea", new { area = "HomeArea" });
                }

                ModelState.AddModelError("", res.Message);
                return View(rec);
            }
            return View(rec);
        }


        [HttpGet]
        public new IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            TempData["message"] = "You have successfully logged out!";
            return View();
        }

       
    }
}

    

