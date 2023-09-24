using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class BankingToGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Stores_AppClients_AppClientId",
            //    table: "Stores");

            //migrationBuilder.AddColumn<byte[]>(
            //    name: "AppClientId",
            //    table: "VendorBankAccounts",
            //    type: "RAW(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "StoreGroupId",
            //    table: "VendorBankAccounts",
            //    type: "NVARCHAR2(450)",
            //    nullable: true);

            //migrationBuilder.AddColumn<byte[]>(
            //    name: "AppClinetId",
            //    table: "ChequeLogs",
            //    type: "RAW(2000)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreGroupId",
                table: "ChequeLogs",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AppClinetId",
                table: "ChequeIssued",
                type: "RAW(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreGroupId",
                table: "ChequeIssued",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AppClinetId",
                table: "ChequeBooks",
                type: "RAW(2000)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AppClinetId",
                table: "BankTransactions",
                type: "RAW(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreGroupId",
                table: "BankTransactions",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AppClientId",
                table: "BankAccounts",
                type: "RAW(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreGroupId",
                table: "BankAccounts",
                type: "NVARCHAR2(2000)",
                nullable: true);

            ;

            migrationBuilder.AddColumn<byte[]>(
                name: "AppClientId",
                table: "AccountLists",
                type: "RAW(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreGroupId",
                table: "AccountLists",
                type: "NVARCHAR2(2000)",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductItems_StoreGroupId",
            //    table: "ProductItems",
            //    column: "StoreGroupId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductItems_Brands_BrandCode",
            //    table: "ProductItems",
            //    column: "BrandCode",
            //    principalTable: "Brands",
            //    principalColumn: "BrandCode");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductItems_ProductTypes_ProductTypeId",
            //    table: "ProductItems",
            //    column: "ProductTypeId",
            //    principalTable: "ProductTypes",
            //    principalColumn: "ProductTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductItems_StoreGroups_StoreGroupId",
            //    table: "ProductItems",
            //    column: "StoreGroupId",
            //    principalTable: "StoreGroups",
            //    principalColumn: "StoreGroupId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductPurchases_Vendors_VendorId",
            //    table: "ProductPurchases",
            //    column: "VendorId",
            //    principalTable: "Vendors",
            //    principalColumn: "VendorId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Stores_AppClients_AppClientId",
            //    table: "Stores",
            //    column: "AppClientId",
            //    principalTable: "AppClients",
            //    principalColumn: "AppClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

//migrationBuilder.DropForeignKey(
//                name: "FK_ProductItems_Brands_BrandCode",
//                table: "ProductItems");

//            migrationBuilder.DropForeignKey(
//                name: "FK_ProductItems_ProductTypes_ProductTypeId",
//                table: "ProductItems");

//            migrationBuilder.DropForeignKey(
//                name: "FK_ProductItems_StoreGroups_StoreGroupId",
//                table: "ProductItems");

//            migrationBuilder.DropForeignKey(
//                name: "FK_ProductPurchases_Vendors_VendorId",
//                table: "ProductPurchases");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Stores_AppClients_AppClientId",
//                table: "Stores");

//            migrationBuilder.DropIndex(
//                name: "IX_ProductItems_StoreGroupId",
//                table: "ProductItems");

//            migrationBuilder.DropColumn(
//                name: "AppClientId",
//                table: "VendorBankAccounts");

//            migrationBuilder.DropColumn(
//                name: "StoreGroupId",
//                table: "VendorBankAccounts");

//            migrationBuilder.DropColumn(
//                name: "StoreGroupId",
//                table: "ProductItems");

//            migrationBuilder.DropColumn(
//                name: "AppClinetId",
//                table: "ChequeLogs");

//            migrationBuilder.DropColumn(
//                name: "StoreGroupId",
//                table: "ChequeLogs");

//            migrationBuilder.DropColumn(
//                name: "AppClinetId",
//                table: "ChequeIssued");

//            migrationBuilder.DropColumn(
//                name: "StoreGroupId",
//                table: "ChequeIssued");

//            migrationBuilder.DropColumn(
//                name: "AppClinetId",
//                table: "ChequeBooks");

//            migrationBuilder.DropColumn(
//                name: "AppClinetId",
//                table: "BankTransactions");

//            migrationBuilder.DropColumn(
//                name: "StoreGroupId",
//                table: "BankTransactions");

//            migrationBuilder.DropColumn(
//                name: "AppClientId",
//                table: "BankAccounts");

//            migrationBuilder.DropColumn(
//                name: "StoreGroupId",
//                table: "BankAccounts");

//            migrationBuilder.DropColumn(
//                name: "AppClientId",
//                table: "AccountLists");

//            migrationBuilder.DropColumn(
//                name: "StoreGroupId",
//                table: "AccountLists");

//           // migrationBuilder.AlterColumn<string>(
//                name: "Remarks",
//                table: "Vouchers",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "PaymentDetails",
//                table: "Vouchers",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "Vouchers",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "AccountId",
//                table: "Vouchers",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "OpeningBalance",
//                table: "VendorBankAccounts",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CompositeRate",
//                table: "Taxes",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<byte[]>(
//                name: "AppClientId",
//                table: "Stores",
//                type: "RAW(900)",
//                nullable: false,
//                defaultValue: new byte[0],
//                oldClrType: typeof(byte[]),
//                oldType: "RAW(900)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "SoldQty",
//                table: "Stocks",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "PurchaseQty",
//                table: "Stocks",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "MRP",
//                table: "Stocks",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "HoldQty",
//                table: "Stocks",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CostPrice",
//                table: "Stocks",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "EmployeeId",
//                table: "Salesmen",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "PaidAmount",
//                table: "SalePaymentDetails",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Value",
//                table: "SaleItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TaxAmount",
//                table: "SaleItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "FreeQty",
//                table: "SaleItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "DiscountAmount",
//                table: "SaleItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "BilledQty",
//                table: "SaleItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "BasicAmount",
//                table: "SaleItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "OutAmount",
//                table: "SalaryLedgers",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "InAmount",
//                table: "SalaryLedgers",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TaxAmount",
//                table: "PurchaseItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Qty",
//                table: "PurchaseItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "FreeQty",
//                table: "PurchaseItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "DiscountValue",
//                table: "PurchaseItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CostValue",
//                table: "PurchaseItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CostPrice",
//                table: "PurchaseItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalTaxAmount",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalPrice",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalMRP",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalDiscountAmount",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalBasicAmount",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "RoundOff",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "FreeQty",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "BilledQty",
//                table: "ProductSales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "Warehouse",
//                table: "ProductPurchases",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "VendorId",
//                table: "ProductPurchases",
//                type: "NVARCHAR2(450)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(450)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalQty",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalAmount",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TaxAmount",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "ShippingCost",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "FreeQty",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "DiscountAmount",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "BillQty",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "BasicAmount",
//                table: "ProductPurchases",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "StyleCode",
//                table: "ProductItems",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "ProductTypeId",
//                table: "ProductItems",
//                type: "NVARCHAR2(450)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(450)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "MRP",
//                table: "ProductItems",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "HSNCode",
//                table: "ProductItems",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "Description",
//                table: "ProductItems",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "BrandCode",
//                table: "ProductItems",
//                type: "NVARCHAR2(450)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(450)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TailoringSale",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TailoringPayment",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "ReceiptsTotal",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "PaymentTotal",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "OpeningBalance",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "NonCashSale",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "ManualSale",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "DailySale",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CustomerRecovery",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CustomerDue",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "ClosingBalance",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CardSale",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "BankWithdrawal",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "BankDeposit",
//                table: "PettyCashSheets",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "NoOfDaysPresent",
//                table: "PaySlips",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "Remarks",
//                table: "Parties",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "PANNo",
//                table: "Parties",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "OpeningBalance",
//                table: "Parties",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "GSTIN",
//                table: "Parties",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "ClosingBalance",
//                table: "Parties",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "Address",
//                table: "Parties",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TaxRate",
//                table: "Notes",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "Notes",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "Remark",
//                table: "LedgerGroups",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "ZipCode",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "Title",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "StreetName",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "State",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "LastName",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "Country",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "City",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "AddressLine",
//                table: "Employees",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "Remarks",
//                table: "DuesRecovery",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "DuesRecovery",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "Remarks",
//                table: "DailySales",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "NonCashAmount",
//                table: "DailySales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CashAmount",
//                table: "DailySales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "DailySales",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "TotalAmount",
//                table: "Customers",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "LastName",
//                table: "Customers",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "CustomerDues",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "ZipCode",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "Title",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "StreetName",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "State",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "LastName",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "Country",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "City",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "AddressLine",
//                table: "Contacts",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "ChequeLogs",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "ChequeIssued",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "SlipNumber",
//                table: "CashVouchers",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "Remarks",
//                table: "CashVouchers",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "CashVouchers",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "PaidAmount",
//                table: "CardPaymentDetails",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Balance",
//                table: "BankTransactions",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "Amount",
//                table: "BankTransactions",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "OpeningBalance",
//                table: "BankAccounts",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           //migrationBuilder.AlterColumn<decimal>(
//                name: "CurrentBalance",
//                table: "BankAccounts",
//                type: "DECIMAL(18,2)",
//                nullable: false,
//                oldClrType: typeof(decimal),
//                oldType: "DECIMAL(18, 2)");

//           // migrationBuilder.AlterColumn<string>(
//                name: "Remarks",
//                table: "Attendances",
//                type: "NVARCHAR2(50)",
//                maxLength: 50,
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//           // migrationBuilder.AlterColumn<string>(
//                name: "EntryTime",
//                table: "Attendances",
//                type: "NVARCHAR2(2000)",
//                nullable: false,
//                defaultValue: "",
//                oldClrType: typeof(string),
//                oldType: "NVARCHAR2(2000)",
//                oldNullable: true);

//            migrationBuilder.AddForeignKey(
//                name: "FK_ProductItems_Brands_BrandCode",
//                table: "ProductItems",
//                column: "BrandCode",
//                principalTable: "Brands",
//                principalColumn: "BrandCode",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_ProductItems_ProductTypes_ProductTypeId",
//                table: "ProductItems",
//                column: "ProductTypeId",
//                principalTable: "ProductTypes",
//                principalColumn: "ProductTypeId",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_ProductPurchases_Vendors_VendorId",
//                table: "ProductPurchases",
//                column: "VendorId",
//                principalTable: "Vendors",
//                principalColumn: "VendorId",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Stores_AppClients_AppClientId",
//                table: "Stores",
//                column: "AppClientId",
//                principalTable: "AppClients",
//                principalColumn: "AppClientId",
//                onDelete: ReferentialAction.Cascade);
//        }
//    }
//}