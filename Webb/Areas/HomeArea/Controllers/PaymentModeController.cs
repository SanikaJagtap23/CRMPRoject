﻿using Domine;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
   
        [Area("HomeArea")]
        [Clompanyuserauth]
        public class PaymentModeController : Controller
        {
            IbillingCompanyRepo BRepo;
            IPaymentModeRepo PRepo;
            public PaymentModeController(IbillingCompanyRepo BRepo,IPaymentModeRepo PRepo)
            {
                this.PRepo = PRepo;
                this.BRepo = BRepo;
            }
            public async Task<IActionResult> Index()
            {
                return View(await this.PRepo.GetAll());
            }
            [HttpGet]
            public async Task<ActionResult> Create()
            {
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
                return View();
            }
            [HttpPost]
            public async Task<ActionResult> Create(PaymentMode rec)
            {
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName");
                if (ModelState.IsValid)
                {
                    await this.PRepo.Create(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Edit(Int64 id)
            {
                var rec = await this.PRepo.Get(id);
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                return View(rec);
            }

            [HttpPost]

            public async Task<ActionResult> Edit(PaymentMode rec)
            {
                ViewBag.BillingCompanies = new SelectList(await this.BRepo.GetAll(), "BillingCompanyID", "CompanyName", rec.BillingCompanyID);
                if (ModelState.IsValid)
                {

                    await this.PRepo.Update(rec);
                    return RedirectToAction("Index");
                }
                return View(rec);
            }
            [HttpGet]
            public async Task<ActionResult> Delete(Int64 id)
            {
                await this.PRepo.Delete(id);
                return RedirectToAction("Index");
            }


        }
    }





