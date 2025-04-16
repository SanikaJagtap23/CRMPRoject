using Infra.Detos;
using Infra.Repositories.Interface;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domine;
using Webb.custauth;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json.Linq;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Threading.Channels;
using System;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class PurchaseOrderController : Controller
    {
        IPurchaseOrder PRepo;
        CRMContext cntx;

        public PurchaseOrderController(IPurchaseOrder PRepo, ISupplierORVendorRepo ISRepo, IbillingCompanyRepo IBRepo, CRMContext cntx)
        {
            this.PRepo = PRepo;
            this.cntx = cntx;

        }
        public IActionResult Index()
        {
            return View(this.cntx.PurchaseOrders.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new PurchaseOrderDto();

            var items = this.cntx.Items.ToList();
            viewModel.InvoiceItems = items.Select(item => new SelectListItem
            {
                Value = item.ItemID.ToString(),
                Text = item.ItemName
            }).ToList();

            var SupplierORVendors = this.cntx.SupplierORVenders.ToList();
            viewModel.SupplierORVendors = SupplierORVendors.Select(item => new SelectListItem
            {
                Value = item.SupplierORVenderID.ToString(),
                Text = item.SupplierORVenderName
            }).ToList();

            var terms = this.cntx.POTermsAndConditions.ToList();
            viewModel.POTermsAndConditions = terms.Select(item => new SelectListItem
            {
                Value = item.POTermsAndConditionsID.ToString(),
                Text = item.POTermsAndConditionsName
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderDto rec)
        {
            if (ModelState.IsValid)
            {
                var selectedTerms = Request.Form["SelectedTerms"].ToList();
                Console.WriteLine($"Selected Terms: {string.Join(", ", selectedTerms)}");

                if (selectedTerms.Any())
                {
                    rec.SelectedTerms = selectedTerms.Select(long.Parse).ToList();
                }
                else
                {
                    rec.SelectedTerms = new List<long>();
                }

                await this.PRepo.CreatePurchaseOrder(rec);
                return RedirectToAction("Index");
            }

            return View(rec);
        }

    

       [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var purchaseOrder = await this.PRepo.GetPurchaseOrderById(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            var items = this.cntx.Items.ToList();
            purchaseOrder.InvoiceItems = items.Select(item => new SelectListItem
            {
                Value = item.ItemID.ToString(),
                Text = item.ItemName
            }).ToList();

            var suppliers = this.cntx.SupplierORVenders.ToList();
            purchaseOrder.SupplierORVendors = suppliers.Select(s => new SelectListItem
            {
                Value = s.SupplierORVenderID.ToString(),
                Text = s.SupplierORVenderName
            }).ToList();

            var terms = this.cntx.POTermsAndConditions.ToList();
            purchaseOrder.POTermsAndConditions = terms.Select(t => new SelectListItem
            {
                Value = t.POTermsAndConditionsID.ToString(),
                Text = t.POTermsAndConditionsName
            }).ToList();

            return View(purchaseOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PurchaseOrderDto rec)
        {
            if (ModelState.IsValid)
            {
                await this.PRepo.UpdatePurchaseOrder(rec);
                return RedirectToAction("Index");
            }

       
            var items = this.cntx.Items.ToList();
            rec.InvoiceItems = items.Select(item => new SelectListItem
            {
                Value = item.ItemID.ToString(),
                Text = item.ItemName
            }).ToList();

            var suppliers = this.cntx.SupplierORVenders.ToList();
            rec.SupplierORVendors = suppliers.Select(s => new SelectListItem
            {
                Value = s.SupplierORVenderID.ToString(),
                Text = s.SupplierORVenderName
            }).ToList();

            var terms = this.cntx.POTermsAndConditions.ToList();
            rec.POTermsAndConditions = terms.Select(t => new SelectListItem
            {
                Value = t.POTermsAndConditionsID.ToString(),
                Text = t.POTermsAndConditionsName
            }).ToList();

            return View(rec);
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var purchaseOrder = await this.PRepo.GetPurchaseOrderById(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var purchaseOrder = await this.cntx.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            var relatedTerms = this.cntx.PurchaseOrderTerms.Where(t => t.PurchaseOrderID == id);
            this.cntx.PurchaseOrderTerms.RemoveRange(relatedTerms);

            var relatedDetails = this.cntx.PurchaseOrdersDet.Where(d => d.PurchaseOrderID == id);
            this.cntx.PurchaseOrdersDet.RemoveRange(relatedDetails);

            this.cntx.PurchaseOrders.Remove(purchaseOrder);

            await this.cntx.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
 }
    
  