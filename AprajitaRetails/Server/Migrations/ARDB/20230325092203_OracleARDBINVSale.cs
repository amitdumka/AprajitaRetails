using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class OracleARDBINVSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Vouchers",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "VendorBankAccounts",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                table: "ProductItems",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TailoringSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TailoringPayment",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReceiptsTotal",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentTotal",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NonCashSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManualSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DailySale",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustomerRecovery",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustomerDue",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosingBalance",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CardSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BankWithdrawal",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BankDeposit",
                table: "PettyCashSheets",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "Parties",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosingBalance",
                table: "Parties",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate",
                table: "Notes",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Notes",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DuesRecovery",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NonCashAmount",
                table: "DailySales",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashAmount",
                table: "DailySales",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DailySales",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Customers",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CustomerDues",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ChequeLogs",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ChequeIssued",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CashVouchers",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "BankTransactions",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "BankTransactions",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "BankAccounts",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBalance",
                table: "BankAccounts",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "CardPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InvoiceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Card = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CardType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CardLastDigit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AuthCode = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EDCTerminalId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
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
                name: "ProductPurchases",
                columns: table => new
                {
                    InwardNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    InwardDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InvoiceNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VendorId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    InvoiceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TaxType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Count = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BillQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Paid = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Warehouse = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InvoiceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BilledQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalMRP = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalDiscountAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalBasicAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    RoundOff = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Taxed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Adjusted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Paid = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SalesmanId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Tailoring = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_ProductSales_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Barcode = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    PurchaseQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    SoldQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    HoldQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    MRP = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Unit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MultiPrice = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InwardNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Barcode = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Qty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Unit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CostValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_ProductItems_Barcode",
                        column: x => x.Barcode,
                        principalTable: "ProductItems",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_ProductPurchases_InwardNumber",
                        column: x => x.InwardNumber,
                        principalTable: "ProductPurchases",
                        principalColumn: "InwardNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSales",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    MobileNo = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSales", x => x.InvoiceNumber);
                    table.ForeignKey(
                        name: "FK_CustomerSales_Customers_MobileNo",
                        column: x => x.MobileNo,
                        principalTable: "Customers",
                        principalColumn: "MobileNo",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InvoiceNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Barcode = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    BilledQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Unit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TaxType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InvoiceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Adjusted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LastPcs = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_ProductItems_Barcode",
                        column: x => x.Barcode,
                        principalTable: "ProductItems",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InvoiceNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PayMode = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RefId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_CardPaymentDetails_EDCTerminalId",
                table: "CardPaymentDetails",
                column: "EDCTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSales_MobileNo",
                table: "CustomerSales",
                column: "MobileNo");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardPaymentDetails");

            migrationBuilder.DropTable(
                name: "CustomerSales");

            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "SalePaymentDetails");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "ProductPurchases");

            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Vouchers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "VendorBankAccounts",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                table: "ProductItems",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TailoringSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TailoringPayment",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReceiptsTotal",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentTotal",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NonCashSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManualSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DailySale",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustomerRecovery",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustomerDue",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosingBalance",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CardSale",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BankWithdrawal",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BankDeposit",
                table: "PettyCashSheets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "Parties",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosingBalance",
                table: "Parties",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate",
                table: "Notes",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Notes",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DuesRecovery",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NonCashAmount",
                table: "DailySales",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashAmount",
                table: "DailySales",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DailySales",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Customers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CustomerDues",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ChequeLogs",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ChequeIssued",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CashVouchers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "BankTransactions",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "BankTransactions",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "BankAccounts",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBalance",
                table: "BankAccounts",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
