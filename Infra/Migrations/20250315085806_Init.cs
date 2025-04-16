using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTbl",
                columns: table => new
                {
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTbl", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "StateTbl",
                columns: table => new
                {
                    StateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTbl", x => x.StateID);
                    table.ForeignKey(
                        name: "FK_StateTbl_CountryTbl_CountryID",
                        column: x => x.CountryID,
                        principalTable: "CountryTbl",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTbl",
                columns: table => new
                {
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTbl", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_CityTbl_StateTbl_StateID",
                        column: x => x.StateID,
                        principalTable: "StateTbl",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillingCompanyTbl",
                columns: table => new
                {
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCompanyTbl", x => x.BillingCompanyID);
                    table.ForeignKey(
                        name: "FK_BillingCompanyTbl_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierORVenderTbl",
                columns: table => new
                {
                    SupplierORVenderID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierORVenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OpeningBalanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierORVenderTbl", x => x.SupplierORVenderID);
                    table.ForeignKey(
                        name: "FK_SupplierORVenderTbl_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountingTbl",
                columns: table => new
                {
                    AccountYearID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingTbl", x => x.AccountYearID);
                    table.ForeignKey(
                        name: "FK_AccountingTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrandTbl",
                columns: table => new
                {
                    BrandID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTbl", x => x.BrandID);
                    table.ForeignKey(
                        name: "FK_BrandTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUserTbl",
                columns: table => new
                {
                    CompanyUserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUserTbl", x => x.CompanyUserID);
                    table.ForeignKey(
                        name: "FK_CompanyUserTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCategoryTbl",
                columns: table => new
                {
                    CustomerCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategoryTbl", x => x.CustomerCategoryID);
                    table.ForeignKey(
                        name: "FK_CustomerCategoryTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountTbl",
                columns: table => new
                {
                    DiscountID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercentile = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTbl", x => x.DiscountID);
                    table.ForeignKey(
                        name: "FK_DiscountTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTbl",
                columns: table => new
                {
                    ExpenseTypeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTbl", x => x.ExpenseTypeID);
                    table.ForeignKey(
                        name: "FK_ExpenseTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InVoiceTermAndConditionsTbl",
                columns: table => new
                {
                    InVoiceTermAndConditionsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InVoiceTermAndConditionsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InVoiceTermAndConditionsTbl", x => x.InVoiceTermAndConditionsID);
                    table.ForeignKey(
                        name: "FK_InVoiceTermAndConditionsTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategoryTbl",
                columns: table => new
                {
                    ItemCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategoryTbl", x => x.ItemCategoryID);
                    table.ForeignKey(
                        name: "FK_ItemCategoryTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModeTbl",
                columns: table => new
                {
                    PaymentModeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentModeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModeTbl", x => x.PaymentModeID);
                    table.ForeignKey(
                        name: "FK_PaymentModeTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POTermsAndConditionsTbl",
                columns: table => new
                {
                    POTermsAndConditionsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POTermsAndConditionsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POTermsAndConditionsTbl", x => x.POTermsAndConditionsID);
                    table.ForeignKey(
                        name: "FK_POTermsAndConditionsTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceTermsAndConditionTbl",
                columns: table => new
                {
                    SalesInvoiceTermsAndConditionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceTermsAndConditionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceTermsAndConditionTbl", x => x.SalesInvoiceTermsAndConditionID);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceTermsAndConditionTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitTbl",
                columns: table => new
                {
                    UnitID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMasterUnitID = table.Column<bool>(type: "bit", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    QtyPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MasterUnitID = table.Column<long>(type: "bigint", nullable: true),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTbl", x => x.UnitID);
                    table.ForeignKey(
                        name: "FK_UnitTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderTbl",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlage = table.Column<bool>(type: "bit", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    SupplierORVenderID = table.Column<long>(type: "bigint", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderTbl", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTbl_SupplierORVenderTbl_SupplierORVenderID",
                        column: x => x.SupplierORVenderID,
                        principalTable: "SupplierORVenderTbl",
                        principalColumn: "SupplierORVenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerORPartyTbl",
                columns: table => new
                {
                    CustomerORPartyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CityID = table.Column<long>(type: "bigint", nullable: false),
                    CustomerCategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerORPartyTbl", x => x.CustomerORPartyID);
                    table.ForeignKey(
                        name: "FK_CustomerORPartyTbl_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerORPartyTbl_CustomerCategoryTbl_CustomerCategoryID",
                        column: x => x.CustomerCategoryID,
                        principalTable: "CustomerCategoryTbl",
                        principalColumn: "CustomerCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTbl",
                columns: table => new
                {
                    ItemID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitID = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsProductOrService = table.Column<int>(type: "int", nullable: false),
                    ItemCategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTbl", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_ItemTbl_ItemCategoryTbl_ItemCategoryID",
                        column: x => x.ItemCategoryID,
                        principalTable: "ItemCategoryTbl",
                        principalColumn: "ItemCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTbl_UnitTbl_UnitID",
                        column: x => x.UnitID,
                        principalTable: "UnitTbl",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderTermsTbl",
                columns: table => new
                {
                    PurchaseOrderTermID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POTermsAndConditionID = table.Column<long>(type: "bigint", nullable: false),
                    PurchaseOrderID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderTermsTbl", x => x.PurchaseOrderTermID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTermsTbl_POTermsAndConditionsTbl_POTermsAndConditionID",
                        column: x => x.POTermsAndConditionID,
                        principalTable: "POTermsAndConditionsTbl",
                        principalColumn: "POTermsAndConditionsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTermsTbl_PurchaseOrderTbl_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrderTbl",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceTbl",
                columns: table => new
                {
                    SalesInvoiceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInVoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InVoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    SalesOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillingCompanyID = table.Column<long>(type: "bigint", nullable: false),
                    CustomerOrPartyID = table.Column<long>(type: "bigint", nullable: false),
                    SalesOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InVoicePaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceTbl", x => x.SalesInvoiceID);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceTbl_BillingCompanyTbl_BillingCompanyID",
                        column: x => x.BillingCompanyID,
                        principalTable: "BillingCompanyTbl",
                        principalColumn: "BillingCompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceTbl_CustomerORPartyTbl_CustomerOrPartyID",
                        column: x => x.CustomerOrPartyID,
                        principalTable: "CustomerORPartyTbl",
                        principalColumn: "CustomerORPartyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetTbl",
                columns: table => new
                {
                    PurchaseOrderDetID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderID = table.Column<long>(type: "bigint", nullable: false),
                    ItemID = table.Column<long>(type: "bigint", nullable: false),
                    UnitID = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetTbl", x => x.PurchaseOrderDetID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetTbl_ItemTbl_ItemID",
                        column: x => x.ItemID,
                        principalTable: "ItemTbl",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetTbl_PurchaseOrderTbl_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrderTbl",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetTbl_UnitTbl_UnitID",
                        column: x => x.UnitID,
                        principalTable: "UnitTbl",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceTermsTbl",
                columns: table => new
                {
                    PurchaseInvoiceTermsID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermAndCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesInvoiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceTermsTbl", x => x.PurchaseInvoiceTermsID);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceTermsTbl_SalesInvoiceTbl_SalesInvoiceID",
                        column: x => x.SalesInvoiceID,
                        principalTable: "SalesInvoiceTbl",
                        principalColumn: "SalesInvoiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceDetTbl",
                columns: table => new
                {
                    SalesInvoiceDetID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFreeOrSample = table.Column<bool>(type: "bit", nullable: false),
                    ItemID = table.Column<long>(type: "bigint", nullable: false),
                    UnitID = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceDetTbl", x => x.SalesInvoiceDetID);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDetTbl_ItemTbl_ItemID",
                        column: x => x.ItemID,
                        principalTable: "ItemTbl",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDetTbl_SalesInvoiceTbl_SalesInvoiceID",
                        column: x => x.SalesInvoiceID,
                        principalTable: "SalesInvoiceTbl",
                        principalColumn: "SalesInvoiceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDetTbl_UnitTbl_UnitID",
                        column: x => x.UnitID,
                        principalTable: "UnitTbl",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceDiscountTbl",
                columns: table => new
                {
                    SalesInvoiceDiscountID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountApplied = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercentile = table.Column<bool>(type: "bit", nullable: false),
                    DisCountAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountID = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceDiscountTbl", x => x.SalesInvoiceDiscountID);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDiscountTbl_DiscountTbl_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "DiscountTbl",
                        principalColumn: "DiscountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDiscountTbl_SalesInvoiceTbl_SalesInvoiceID",
                        column: x => x.SalesInvoiceID,
                        principalTable: "SalesInvoiceTbl",
                        principalColumn: "SalesInvoiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicePaymentTbl",
                columns: table => new
                {
                    SalesInvoicePaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentModeID = table.Column<long>(type: "bigint", nullable: false),
                    SalesVoiceID = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicePaymentTbl", x => x.SalesInvoicePaymentID);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePaymentTbl_PaymentModeTbl_PaymentModeID",
                        column: x => x.PaymentModeID,
                        principalTable: "PaymentModeTbl",
                        principalColumn: "PaymentModeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePaymentTbl_SalesInvoiceTbl_SalesInvoiceID",
                        column: x => x.SalesInvoiceID,
                        principalTable: "SalesInvoiceTbl",
                        principalColumn: "SalesInvoiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicePaymentChequeTbl",
                columns: table => new
                {
                    SalesInvoicePaymentChequeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChequeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChequeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPaymentInVoiceID = table.Column<long>(type: "bigint", nullable: false),
                    GetSalesInvoicePaymentSalesInvoicePaymentID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicePaymentChequeTbl", x => x.SalesInvoicePaymentChequeID);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePaymentChequeTbl_SalesInvoicePaymentTbl_GetSalesInvoicePaymentSalesInvoicePaymentID",
                        column: x => x.GetSalesInvoicePaymentSalesInvoicePaymentID,
                        principalTable: "SalesInvoicePaymentTbl",
                        principalColumn: "SalesInvoicePaymentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingTbl_BillingCompanyID",
                table: "AccountingTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_BillingCompanyTbl_CityID",
                table: "BillingCompanyTbl",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTbl_BillingCompanyID",
                table: "BrandTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CityTbl_StateID",
                table: "CityTbl",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUserTbl_BillingCompanyID",
                table: "CompanyUserTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCategoryTbl_BillingCompanyID",
                table: "CustomerCategoryTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerORPartyTbl_CityID",
                table: "CustomerORPartyTbl",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerORPartyTbl_CustomerCategoryID",
                table: "CustomerORPartyTbl",
                column: "CustomerCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountTbl_BillingCompanyID",
                table: "DiscountTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTbl_BillingCompanyID",
                table: "ExpenseTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_InVoiceTermAndConditionsTbl_BillingCompanyID",
                table: "InVoiceTermAndConditionsTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryTbl_BillingCompanyID",
                table: "ItemCategoryTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTbl_ItemCategoryID",
                table: "ItemTbl",
                column: "ItemCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTbl_UnitID",
                table: "ItemTbl",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentModeTbl_BillingCompanyID",
                table: "PaymentModeTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_POTermsAndConditionsTbl_BillingCompanyID",
                table: "POTermsAndConditionsTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceTermsTbl_SalesInvoiceID",
                table: "PurchaseInvoiceTermsTbl",
                column: "SalesInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetTbl_ItemID",
                table: "PurchaseOrderDetTbl",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetTbl_PurchaseOrderID",
                table: "PurchaseOrderDetTbl",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetTbl_UnitID",
                table: "PurchaseOrderDetTbl",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTbl_BillingCompanyID",
                table: "PurchaseOrderTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTbl_SupplierORVenderID",
                table: "PurchaseOrderTbl",
                column: "SupplierORVenderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTermsTbl_POTermsAndConditionID",
                table: "PurchaseOrderTermsTbl",
                column: "POTermsAndConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTermsTbl_PurchaseOrderID",
                table: "PurchaseOrderTermsTbl",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDetTbl_ItemID",
                table: "SalesInvoiceDetTbl",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDetTbl_SalesInvoiceID",
                table: "SalesInvoiceDetTbl",
                column: "SalesInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDetTbl_UnitID",
                table: "SalesInvoiceDetTbl",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDiscountTbl_DiscountID",
                table: "SalesInvoiceDiscountTbl",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDiscountTbl_SalesInvoiceID",
                table: "SalesInvoiceDiscountTbl",
                column: "SalesInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePaymentChequeTbl_GetSalesInvoicePaymentSalesInvoicePaymentID",
                table: "SalesInvoicePaymentChequeTbl",
                column: "GetSalesInvoicePaymentSalesInvoicePaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePaymentTbl_PaymentModeID",
                table: "SalesInvoicePaymentTbl",
                column: "PaymentModeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePaymentTbl_SalesInvoiceID",
                table: "SalesInvoicePaymentTbl",
                column: "SalesInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceTbl_BillingCompanyID",
                table: "SalesInvoiceTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceTbl_CustomerOrPartyID",
                table: "SalesInvoiceTbl",
                column: "CustomerOrPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceTermsAndConditionTbl_BillingCompanyID",
                table: "SalesInvoiceTermsAndConditionTbl",
                column: "BillingCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_StateTbl_CountryID",
                table: "StateTbl",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierORVenderTbl_CityID",
                table: "SupplierORVenderTbl",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitTbl_BillingCompanyID",
                table: "UnitTbl",
                column: "BillingCompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingTbl");

            migrationBuilder.DropTable(
                name: "BrandTbl");

            migrationBuilder.DropTable(
                name: "CompanyUserTbl");

            migrationBuilder.DropTable(
                name: "ExpenseTbl");

            migrationBuilder.DropTable(
                name: "InVoiceTermAndConditionsTbl");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceTermsTbl");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetTbl");

            migrationBuilder.DropTable(
                name: "PurchaseOrderTermsTbl");

            migrationBuilder.DropTable(
                name: "SalesInvoiceDetTbl");

            migrationBuilder.DropTable(
                name: "SalesInvoiceDiscountTbl");

            migrationBuilder.DropTable(
                name: "SalesInvoicePaymentChequeTbl");

            migrationBuilder.DropTable(
                name: "SalesInvoiceTermsAndConditionTbl");

            migrationBuilder.DropTable(
                name: "POTermsAndConditionsTbl");

            migrationBuilder.DropTable(
                name: "PurchaseOrderTbl");

            migrationBuilder.DropTable(
                name: "ItemTbl");

            migrationBuilder.DropTable(
                name: "DiscountTbl");

            migrationBuilder.DropTable(
                name: "SalesInvoicePaymentTbl");

            migrationBuilder.DropTable(
                name: "SupplierORVenderTbl");

            migrationBuilder.DropTable(
                name: "ItemCategoryTbl");

            migrationBuilder.DropTable(
                name: "UnitTbl");

            migrationBuilder.DropTable(
                name: "PaymentModeTbl");

            migrationBuilder.DropTable(
                name: "SalesInvoiceTbl");

            migrationBuilder.DropTable(
                name: "CustomerORPartyTbl");

            migrationBuilder.DropTable(
                name: "CustomerCategoryTbl");

            migrationBuilder.DropTable(
                name: "BillingCompanyTbl");

            migrationBuilder.DropTable(
                name: "CityTbl");

            migrationBuilder.DropTable(
                name: "StateTbl");

            migrationBuilder.DropTable(
                name: "CountryTbl");
        }
    }
}
