using Domine;
using Infra.Detos;
using Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infra.Repositories.Classes
{

    public class PurchaseOrderRepo : GenRepo<PurchaseOrder>, IPurchaseOrder
    {

        CRMContext cntx;
        public PurchaseOrderRepo(CRMContext cntx) : base(cntx)
        {
            this.cntx = cntx;
        }

        public async Task CreatePurchaseOrder(PurchaseOrderDto rec)
        {
            var pur = new PurchaseOrder()
            {
                OrderDate = DateTime.Now,
                PONumber = rec.PONumber,
                ActiveFlage = true,
                TotalAmount = rec.TotalAmount,
                PaymentType = rec.PaymentType,
                SupplierORVenderID = rec.SupplierORVenderID,
                BillingCompanyID = 1,
            };

            await this.cntx.PurchaseOrders.AddAsync(pur);
            await this.cntx.SaveChangesAsync();

            foreach (var temp in rec.Items)
            {
                var res = await this.cntx.Items.FindAsync(temp.ItemID);

                if (res != null)
                {
                    var det = new PurchaseOrderDet()
                    {
                        PurchaseOrderID = pur.PurchaseOrderID,
                        ItemID = temp.ItemID,
                        Qty = temp.Qty,
                        Price = temp.Price,
                        UnitID = res.UnitID
                    };
                    await this.cntx.PurchaseOrdersDet.AddAsync(det);
                }
            }

            if (rec.SelectedTerms != null && rec.SelectedTerms.Any())
            {
                foreach (var termId in rec.SelectedTerms)
                {
                    var pt = new PurchaseOrderTerms()
                    {
                        PurchaseOrderID = pur.PurchaseOrderID,
                        POTermsAndConditionID = termId,
                    };
                    await this.cntx.PurchaseOrderTerms.AddAsync(pt);
                }
            }

            await this.cntx.SaveChangesAsync();
        }

        public Task DeletePurchaseOrder(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseOrderDto> GetPurchaseOrderById(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePurchaseOrder(PurchaseOrderDto rec)
        {
            throw new NotImplementedException();
        }
    }
}




        


    