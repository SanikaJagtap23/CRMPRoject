using Infra;
using Infra.Repositories.Classes;
using Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(
     opt =>
     {
         opt.IOTimeout = TimeSpan.FromMinutes(10);
         opt.Cookie.IsEssential = true;
         opt.Cookie.HttpOnly = true;
     }
    );
builder.Services.AddControllersWithViews();
var scon = builder.Configuration.GetConnectionString("scon");
builder.Services.AddDbContext<CRMContext>(
     op => op.UseLazyLoadingProxies().UseSqlServer(scon)
    );
builder.Services.AddScoped<ICompanyRepo, CompanyUserRepo>(); 
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<IStateRepo, StateRepo>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<IbillingCompanyRepo,BillingCompanyRepo>();
builder.Services.AddScoped<IitemCategoryRepo, ItemCategoryRepo>();
builder.Services.AddScoped<IinvoiceTermsAndConditionRepo, InvoiceTermsandConditionsRepo>();
builder.Services.AddScoped<IPOTemsAndConditionRepo, POTemsandConditionsRepo>();
builder.Services.AddScoped<IDiscountRepo, DiscountRepo>();
builder.Services.AddScoped<ICustomerCategoryRepo, CustomerCategoryRepo>();  
builder.Services.AddScoped<IAccountingRepo, AccountingRepo>();  
builder.Services.AddScoped<IPaymentModeRepo, PaymentModeRepo>();    
builder.Services.AddScoped<IBrandRepo, BrandRepo>();    
builder.Services.AddScoped<IExpenseTypeRepo,ExpenseTypeRepocs>();
builder.Services.AddScoped<IUniteRepo, UnitRepo>();
builder.Services.AddScoped<ISalesInvoiceRepo, SalesInvoiceRepo>();
builder.Services.AddScoped<IitemRepo, ItemRepo>();
builder.Services.AddScoped<ISupplierORVendorRepo, SupplierORVendorRepo>();
builder.Services.AddScoped<ICustomerORPartyRepo, CustomerORPartyRepo>();
builder.Services.AddScoped<IPurchaseOrder, PurchaseOrderRepo>();


var app = builder.Build();
app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
     name: "area",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}" );
app.MapDefaultControllerRoute();
app.Run();

