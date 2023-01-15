using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class InventoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandCode);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubCategories",
                columns: table => new
                {
                    SubCategory = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubCategories", x => x.SubCategory);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierName);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StyleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HSNCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    BrandCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_ProductItems_Brands_BrandCode",
                        column: x => x.BrandCode,
                        principalTable: "Brands",
                        principalColumn: "BrandCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItems_ProductSubCategories_SubCategory",
                        column: x => x.SubCategory,
                        principalTable: "ProductSubCategories",
                        principalColumn: "SubCategory",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductItems_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_Vendors_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoldQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoldQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    MultiPrice = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_ProductItems_Barcode",
                        column: x => x.Barcode,
                        principalTable: "ProductItems",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CardPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    CardLastDigit = table.Column<int>(type: "int", nullable: false),
                    AuthCode = table.Column<int>(type: "int", nullable: false),
                    EDCTerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPaymentDetails_EDCTerminals_EDCTerminalId",
                        column: x => x.EDCTerminalId,
                        principalTable: "EDCTerminals",
                        principalColumn: "EDCTerminalId");
                });

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    BilledQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalMRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBasicAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoundOff = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxed = table.Column<bool>(type: "bit", nullable: false),
                    Adjusted = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    SalesmanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tailoring = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_ProductSales_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductSales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPurchases",
                columns: table => new
                {
                    InwardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InwardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    BillQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchases", x => x.InwardNumber);
                    table.ForeignKey(
                        name: "FK_ProductPurchases_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPurchases_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSales",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSales", x => x.InvoiceNumber);
                    table.ForeignKey(
                        name: "FK_CustomerSales_Customers_MobileNo",
                        column: x => x.MobileNo,
                        principalTable: "Customers",
                        principalColumn: "MobileNo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerSales_ProductSales_InvoiceNumber",
                        column: x => x.InvoiceNumber,
                        principalTable: "ProductSales",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BilledQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    Adjusted = table.Column<bool>(type: "bit", nullable: false),
                    LastPcs = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_ProductItems_Barcode",
                        column: x => x.Barcode,
                        principalTable: "ProductItems",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SaleItems_ProductSales_InvoiceNumber",
                        column: x => x.InvoiceNumber,
                        principalTable: "ProductSales",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalePaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    RefId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePaymentDetails_ProductSales_InvoiceNumber",
                        column: x => x.InvoiceNumber,
                        principalTable: "ProductSales",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InwardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_ProductItems_Barcode",
                        column: x => x.Barcode,
                        principalTable: "ProductItems",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_ProductPurchases_InwardNumber",
                        column: x => x.InwardNumber,
                        principalTable: "ProductPurchases",
                        principalColumn: "InwardNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardPaymentDetails_EDCTerminalId",
                table: "CardPaymentDetails",
                column: "EDCTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSales_MobileNo",
                table: "CustomerSales",
                column: "MobileNo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_BrandCode",
                table: "ProductItems",
                column: "BrandCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductTypeId",
                table: "ProductItems",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_SubCategory",
                table: "ProductItems",
                column: "SubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchases_StoreId",
                table: "ProductPurchases",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchases_VendorId",
                table: "ProductPurchases",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_SalesmanId",
                table: "ProductSales",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_StoreId",
                table: "ProductSales",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_Barcode",
                table: "PurchaseItems",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_InwardNumber",
                table: "PurchaseItems",
                column: "InwardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_Barcode",
                table: "SaleItems",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_InvoiceNumber",
                table: "SaleItems",
                column: "InvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SalePaymentDetails_InvoiceNumber",
                table: "SalePaymentDetails",
                column: "InvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Barcode",
                table: "Stocks",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StoreId",
                table: "Stocks",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_StoreId",
                table: "Vendors",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLists");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "CardPaymentDetails");

            migrationBuilder.DropTable(
                name: "CashDetails");

            migrationBuilder.DropTable(
                name: "CashVouchers");

            migrationBuilder.DropTable(
                name: "ChequeIssued");

            migrationBuilder.DropTable(
                name: "ChequeLogs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CustomerSales");

            migrationBuilder.DropTable(
                name: "DailySales");

            migrationBuilder.DropTable(
                name: "DuesRecovery");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "LedgerGroups");

            migrationBuilder.DropTable(
                name: "LedgerMasters");

            migrationBuilder.DropTable(
                name: "MonthlyAttendances");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "PaySlips");

            migrationBuilder.DropTable(
                name: "PettyCashSheets");

            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "SalaryLedgers");

            migrationBuilder.DropTable(
                name: "SalaryPayments");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "SalePaymentDetails");

            migrationBuilder.DropTable(
                name: "StaffAdvanceReceipts");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "VendorBankAccounts");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "TransactionModes");

            migrationBuilder.DropTable(
                name: "ChequeBooks");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EDCTerminals");

            migrationBuilder.DropTable(
                name: "CustomerDues");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "ProductPurchases");

            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Salesmen");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductSubCategories");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}