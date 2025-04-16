using Domine;
using Infra.Detos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interface
{

    public interface IPurchaseOrder
    {
        Task CreatePurchaseOrder(PurchaseOrderDto rec);

       
        Task<PurchaseOrderDto> GetPurchaseOrderById(long id);
        Task UpdatePurchaseOrder(PurchaseOrderDto rec);
        Task DeletePurchaseOrder(long id);
      



    }
}

        
 


