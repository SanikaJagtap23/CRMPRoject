using Infra.Detos;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Webb.ViewComponents
{
    public class SalesTermsVC: ViewComponent
    {
        CRMContext cntx;
        public SalesTermsVC(CRMContext cntx)
        {
            this.cntx = cntx;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new SalesInvoiceDto();

            var terms = this.cntx.SalesInvoiceTermsAndConditions.ToList();
            viewModel.SalesInvoiceTermsAndCondition = terms.Select(item => new SelectListItem
            {
                Value = item.SalesInvoiceTermsAndConditionID.ToString(),
                Text = item.SalesInvoiceTermsAndConditionName
            }).ToList();

            return View(viewModel);
        }
    }
}
    

