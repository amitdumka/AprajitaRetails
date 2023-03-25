using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class OracleARDBabnk : Migration
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
                name: "TotalAmount",
                table: "Customers",
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

            migrationBuilder.CreateTable(
                name: "AccountLists",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SharedAccount = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccountHolderName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    IFSCCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BranchName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AccountType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLists", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_AccountLists_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    DefaultBank = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SharedAccount = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    StoreId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccountHolderName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    IFSCCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BranchName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AccountType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChequeLogs",
                columns: table => new
                {
                    ChequeLogId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InFavorOf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    AccountNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChequeIssuer = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChequeNumber = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeLogs", x => x.ChequeLogId);
                    table.ForeignKey(
                        name: "FK_ChequeLogs_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorBankAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    VendorId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    StoreId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccountHolderName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    IFSCCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BranchName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AccountType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorBankAccounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_VendorBankAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    BankTransactionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AccountNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Narration = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RefNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Balance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DebitCredit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BankDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Verified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.BankTransactionId);
                    table.ForeignKey(
                        name: "FK_BankTransactions_BankAccounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "BankAccounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransactions_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChequeBooks",
                columns: table => new
                {
                    ChequeBookId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    AccountId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankAccountAccountNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    StartingNumber = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EndingNumber = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Count = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NoOfChequeIssued = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NoOfPDC = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NoOfClearedCheques = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeBooks", x => x.ChequeBookId);
                    table.ForeignKey(
                        name: "FK_ChequeBooks_BankAccounts_BankAccountAccountNumber",
                        column: x => x.BankAccountAccountNumber,
                        principalTable: "BankAccounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_ChequeBooks_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChequeIssued",
                columns: table => new
                {
                    ChequeIssuedId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InFavorOf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    AccountId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankAccountAccountNumber = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    ChequeBookId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ChequeNumber = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeIssued", x => x.ChequeIssuedId);
                    table.ForeignKey(
                        name: "FK_ChequeIssued_BankAccounts_BankAccountAccountNumber",
                        column: x => x.BankAccountAccountNumber,
                        principalTable: "BankAccounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_ChequeIssued_ChequeBooks_ChequeBookId",
                        column: x => x.ChequeBookId,
                        principalTable: "ChequeBooks",
                        principalColumn: "ChequeBookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChequeIssued_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountLists_BankId",
                table: "AccountLists",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId",
                table: "BankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_AccountNumber",
                table: "BankTransactions",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_StoreId",
                table: "BankTransactions",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ChequeBooks_BankAccountAccountNumber",
                table: "ChequeBooks",
                column: "BankAccountAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ChequeBooks_StoreId",
                table: "ChequeBooks",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ChequeIssued_BankAccountAccountNumber",
                table: "ChequeIssued",
                column: "BankAccountAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ChequeIssued_ChequeBookId",
                table: "ChequeIssued",
                column: "ChequeBookId");

            migrationBuilder.CreateIndex(
                name: "IX_ChequeIssued_StoreId",
                table: "ChequeIssued",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ChequeLogs_StoreId",
                table: "ChequeLogs",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBankAccounts_BankId",
                table: "VendorBankAccounts",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLists");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "ChequeIssued");

            migrationBuilder.DropTable(
                name: "ChequeLogs");

            migrationBuilder.DropTable(
                name: "VendorBankAccounts");

            migrationBuilder.DropTable(
                name: "ChequeBooks");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Vouchers",
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
                name: "TotalAmount",
                table: "Customers",
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
        }
    }
}
