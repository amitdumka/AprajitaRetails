using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class OracleARDBLedgers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Customers",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "CashDetails",
                columns: table => new
                {
                    CashDetailId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Count = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalAmount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N2000 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N1000 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N500 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N200 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N100 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N50 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N20 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    N10 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    C10 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    C5 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    C2 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    C1 = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashDetails", x => x.CashDetailId);
                    table.ForeignKey(
                        name: "FK_CashDetails_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LedgerGroups",
                columns: table => new
                {
                    LedgerGroupId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    GroupName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Category = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Remark = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerGroups", x => x.LedgerGroupId);
                });

            migrationBuilder.CreateTable(
                name: "LedgerMasters",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    PartyName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerMasters", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "PettyCashSheets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BankDeposit = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BankWithdrawal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DailySale = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TailoringSale = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TailoringPayment = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ManualSale = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CardSale = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NonCashSale = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CustomerDue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DueList = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CustomerRecovery = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    RecoveryList = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ReceiptsNarration = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ReceiptsTotal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PaymentNarration = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PaymentTotal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PettyCashSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PettyCashSheets_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    PartyName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Category = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GSTIN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PANNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Remarks = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LedgerGroupId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Parties_LedgerGroups_LedgerGroupId",
                        column: x => x.LedgerGroupId,
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parties_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashDetails_StoreId",
                table: "CashDetails",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_LedgerGroupId",
                table: "Parties",
                column: "LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_StoreId",
                table: "Parties",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PettyCashSheets_StoreId",
                table: "PettyCashSheets",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashDetails");

            migrationBuilder.DropTable(
                name: "LedgerMasters");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "PettyCashSheets");

            migrationBuilder.DropTable(
                name: "LedgerGroups");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Customers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
