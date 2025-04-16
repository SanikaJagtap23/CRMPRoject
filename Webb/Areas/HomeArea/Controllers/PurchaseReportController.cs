using Infra;
using Microsoft.AspNetCore.Mvc;
using Webb.custauth;

namespace Webb.Areas.HomeArea.Controllers
{
    [Area("HomeArea")]
    [Clompanyuserauth]
    public class PurchaseReportController : Controller
    {
        CRMContext cntx;
        public PurchaseReportController(CRMContext cntx)
        {
            this.cntx = cntx;
        }

        public IActionResult Index()
        {
            var res = this.cntx.PurchaseOrders.ToList();
            return View(res);
        }

        [HttpPost]
        public IActionResult SearchByDate(DateTime? fromDate, DateTime? toDate)
        {
            var orders = cntx.PurchaseOrders.AsQueryable();

            if (fromDate.HasValue && toDate.HasValue)
            {
                orders = orders.Where(x => x.OrderDate >= fromDate && x.OrderDate <= toDate);
            }

            var res = orders.ToList();
            return View("Index", res);
        }


    }
}
