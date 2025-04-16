
using Domine;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class CRMContext:DbContext
    {
        public CRMContext(DbContextOptions<CRMContext>options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<BillingCompany> BillingCompanies{  get; set; }
        public DbSet<CompanyUser> CompanyUsers{ get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<InVoiceTermAndConditions> InVoiceTermAndConditions { get; set; }
        public DbSet<POTermsAndConditions> POTermsAndConditions { get; set; }
        public DbSet<Discount> Discounts {  get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Unit> Units {  get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CustomerORParty> CustomerORParties { get; set; }
        public DbSet<SupplierORVender> SupplierORVenders { get; set; }
        public DbSet<SalesInvoice> SalesInvoices {  get; set; }
        public DbSet<SalesInvoiceDet> SalesInvoiceDets { get; set; }
        public DbSet<PurchaseInvoiceTerms> PurchaseInvoiceTerms { get; set; }
        public DbSet<SalesInvoiceDiscount> SalesInvoicesDiscount { get; set; }  
        public DbSet<SalesInvoicePayment> SalesInvoicesPayment { get; set; }   
        public DbSet<SalesInvoicePaymentCheque> salesInvoicePaymentCheques {  get; set; } 
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet <PurchaseOrderDet> PurchaseOrdersDet { get; set; }  
        public DbSet<PurchaseOrderTerms> PurchaseOrderTerms { get; set; }
        public DbSet<SalesInvoiceTermsAndCondition> SalesInvoiceTermsAndConditions { get; set; }



    }
}
