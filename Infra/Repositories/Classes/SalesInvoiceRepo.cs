using Domine;
using Infra.Detos;
using Infra.Repositories.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infra.Repositories.Classes
{
    public class SalesInvoiceRepo : ISalesInvoiceRepo
    {
        CRMContext cntx;
    public SalesInvoiceRepo(CRMContext cntx)
    {
        this.cntx = cntx;
    }

    public async Task CreateSalesInvoice(SalesInvoiceDto rec)
    {
        var sal = new SalesInvoice()
        {
            SalesInVoiceDate = DateTime.Now,
            InVoiceNo = rec.InVoiceNo,
            ActiveFlag = true,
            SalesOrderDate = rec.SalesOrderDate,
            BillingCompanyID = 1,      
            CustomerOrPartyID = rec.CustomerOrPartyID,
            SalesOrderNo = rec.SalesOrderNo,
            InVoicePaymentType = rec.InVoicePaymentType,
            TotalAmount = rec.TotalAmount
        };


        await this.cntx.SalesInvoices.AddAsync(sal);
        await this.cntx.SaveChangesAsync();


        foreach (var item in rec.Items)
        {
                var res= await this.cntx.Items.FindAsync(item.ItemID);
            var saldet = new SalesInvoiceDet()
            {
                SalesInvoiceID = sal.SalesInvoiceID,
                Qty = item.Qty,
                Price = item.Price,
                IsFreeOrSample = item.IsFreeOrSample,
                ItemID = item.ItemID,
                UnitID= res.UnitID
            };

            await this.cntx.SalesInvoiceDets.AddAsync(saldet);
        }

            if (rec.DiscountID > 0)
            {
                var res = await this.cntx.Discounts.FindAsync(rec.DiscountID);
                var des = new SalesInvoiceDiscount()
                {

                    SalesInvoiceID = sal.SalesInvoiceID,
                    DiscountID = rec.DiscountID,
                    DiscountApplied = res.DiscountAmount,
                    DisCountAmt = rec.TotalAmount * res.DiscountAmount / 100,
                    IsPercentile = res.IsPercentile
                };

                await this.cntx.SalesInvoicesDiscount.AddAsync(des);
            }

            if (rec.SelectedTerms != null && rec.SelectedTerms.Any())
            {
                foreach (var termId in rec.SelectedTerms)
                {
                    var pt = new PurchaseInvoiceTerms
                    {
                        SalesInvoiceID = sal.SalesInvoiceID,
                        SalesInvoiceTermsAndConditionID = termId,
                    };
                    await this.cntx.PurchaseInvoiceTerms.AddAsync(pt);
                }
            }

        await this.cntx.SaveChangesAsync();
    }
        //public async Task EditSalesInvoice(SalesInvoiceDto rec)
        //{
        //    var invoice = await cntx.SalesInvoices
        //        .Include(s => s.SalesInvoiceDets)
        //        .Include(s => s.SalesInvoiceDiscounts)
        //        .Include(s => s.PurchaseInvoiceTerms)
        //        .FirstOrDefaultAsync(s => s.SalesInvoiceID == rec.SalesInvoiceID);

        //    if (invoice == null)
        //        throw new Exception("Sales invoice not found.");

        //    // Update invoice fields
        //    invoice.InVoiceNo = rec.InVoiceNo;
        //    invoice.SalesOrderDate = rec.SalesOrderDate;
        //    invoice.TotalAmount = rec.TotalAmount;
        //    invoice.SalesOrderNo = rec.SalesOrderNo;
        //    invoice.InVoicePaymentType = rec.InVoicePaymentType;
        //    invoice.CustomerOrPartyID = rec.CustomerOrPartyID;

        //    // Delete existing items
        //    cntx.SalesInvoiceDets.RemoveRange(invoice.SalesInvoiceDets);

        //    // Add new items
        //    foreach (var item in rec.Items)
        //    {
        //        var itemEntity = new SalesInvoiceDet
        //        {
        //            SalesInvoiceID = rec.SalesInvoiceID,
        //            ItemID = item.ItemID,
        //            Qty = item.Qty,
        //            Price = item.Price,
        //            IsFreeOrSample = item.IsFreeOrSample,
        //          //  UnitID = rec.UnitID
        //        };
        //        cntx.SalesInvoiceDets.Add(itemEntity);
        //    }

        //    // Handle discount and terms (existing logic)
        //    if (rec.DiscountID > 0)
        //    {
        //        var discount = await cntx.Discounts.FindAsync(rec.DiscountID);
        //        if (discount != null)
        //        {
        //            var salesInvoiceDiscount = new SalesInvoiceDiscount
        //            {
        //                SalesInvoiceID = rec.SalesInvoiceID,
        //                DiscountID = rec.DiscountID,
        //                DiscountApplied = discount.DiscountAmount,
        //                DisCountAmt = rec.TotalAmount * discount.DiscountAmount / 100,
        //                IsPercentile = discount.IsPercentile
        //            };
        //            cntx.SalesInvoicesDiscount.Add(salesInvoiceDiscount);
        //        }
        //    }

        //    var terms = new PurchaseInvoiceTerms
        //    {
        //        SalesInvoiceID = rec.SalesInvoiceID,
        //        TermAndCondition = rec.TermAndCondition
        //    };

        //    cntx.PurchaseInvoiceTerms.Add(terms);

        //    await cntx.SaveChangesAsync();
        //}

        public async Task DeleteSalesInvoice(long id)
        {
            var invoice = await cntx.SalesInvoices.FindAsync(id);
            if (invoice == null)
                throw new Exception("Sales invoice not found.");

            cntx.SalesInvoices.Remove(invoice);
            await cntx.SaveChangesAsync();
        }

        public Task EditSalesInvoice(SalesInvoiceDto rec)
        {
            throw new NotImplementedException();
        }

        public Task<SalesInvoiceDto> GetSalesInvoiceByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateSalesInvoicePayment(SalesInvoicePaymentDto rec)
        {
            var payment = new SalesInvoicePayment
            {
                SalesInvoiceID = rec.SalesInvoiceID,
                PaymentDate = DateTime.Now,
                PaymentAmt = rec.TotalInvoiceAmount,
                PaymentDesc = rec.PaymentDesc,
                PaymentModeID = rec.PaymentModeID
            };

            this.cntx.SalesInvoicesPayment.Add(payment);
            await this.cntx.SaveChangesAsync();

            if (rec.IsChequePayment)
            {
                var chequePayment = new SalesInvoicePaymentCheque
                {
                    SalesPaymentInVoiceID = payment.SalesInvoicePaymentID,
                    ChequeDate = rec.ChequeDate.Value,
                    BankName = rec.BankName,
                    ChequeNo = rec.ChequeNo
                };
                this.cntx.salesInvoicePaymentCheques.Add(chequePayment);
                await this.cntx.SaveChangesAsync();
            }
        }

        public async Task<decimal> GetCustomerBalance(long customerID)
        {
            var customer = await this.cntx.CustomerORParties
                .Where(c => c.CustomerORPartyID == customerID)
                .FirstOrDefaultAsync();

            if (customer == null)
                return 0;

            var totalPayments = await this.cntx.SalesInvoicesPayment
                .Where(p => p.SalesInvoice.CustomerOrPartyID == customerID)
                .SumAsync(p => (decimal?)p.PaymentAmt) ?? 0;

            return customer.OpeningBalance - totalPayments;
        }
    }

}
