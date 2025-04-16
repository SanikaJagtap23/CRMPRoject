using Domine;
using Infra.Detos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interface
{
    public interface ISalesInvoiceRepo
    {
        Task CreateSalesInvoice(SalesInvoiceDto rec);
        Task<SalesInvoiceDto> GetSalesInvoiceByIdAsync(long id);
        Task EditSalesInvoice(SalesInvoiceDto rec);
        Task DeleteSalesInvoice(long id);

        Task CreateSalesInvoicePayment(SalesInvoicePaymentDto rec);
        Task<decimal> GetCustomerBalance(long customerID);
    }
    
}
