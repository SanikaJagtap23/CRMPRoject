using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domine
{
    [Table("BillingCompanyTbl")]
    public class BillingCompany
    {
        [Key]
        public Int64 BillingCompanyID {  get; set; }
        public string CompanyName {  get; set; }
        public string CompanyAddress {  get; set; }
        public string EmailID {  get; set; }
        public string MobileNumber {  get; set; }
        public string WebSiteUrl {  get; set; }
        public string PinCode {  get; set; }
        public Int64 CityID {  get; set; }
        public virtual City City { get; set; }
        public virtual List<CompanyUser> CompanyUsers { get; set; }
        public virtual List<ItemCategory> ItemCategories { get; set; }
        public virtual List<InVoiceTermAndConditions>InVoiceTermAndConditions { get; set; }
        public virtual List<POTermsAndConditions> POTermsAndConditions { get; set; }  
        public virtual List<Discount> Discounts { get; set; }
        public virtual List<CustomerCategory>CustomerCategories { get; set; }
        public virtual List<Accounting> Accountings { get; set; }
        public virtual List<PaymentMode> GetPaymentModes { get; set; }
        public virtual List<Brand> Brands { get; set; }
        public virtual List<ExpenseType> ExpenseTypes { get; set; }
        public virtual List<Unit>Units { get; set; }
        public virtual List<SalesInvoice> SalesInvoices { get; set;}
        public virtual List<PurchaseOrder> PurchaseOrders { get; set; } 
        public virtual List<SalesInvoiceTermsAndCondition> GetSalesInvoiceTermsAndConditions { get; set; }
      


    }
}
