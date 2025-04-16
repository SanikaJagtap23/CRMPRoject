using Infra.Detos;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Webb.ViewComponents
{
    public class PurchaseTermsVC:ViewComponent
    {
        CRMContext cntx;
        public PurchaseTermsVC(CRMContext cntx)
        {
            this.cntx = cntx;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new PurchaseOrderDto();

            var terms = this.cntx.POTermsAndConditions.ToList();
            viewModel.POTermsAndConditions = terms.Select(item => new SelectListItem
            {
                Value = item.POTermsAndConditionsID.ToString(),
                Text = item.POTermsAndConditionsName
            }).ToList();

            return View(viewModel);
        }
    }
}
