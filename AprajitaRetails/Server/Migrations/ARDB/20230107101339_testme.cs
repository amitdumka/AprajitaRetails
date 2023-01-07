using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class testme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

             

            //migrationBuilder.CreateTable(
            //    name: "AccountLists",
            //    columns: table => new
            //    {
            //        AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        SharedAccount = table.Column<bool>(type: "INTEGER", nullable: false),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        AccountHolderName = table.Column<string>(type: "TEXT", nullable: false),
            //        BankId = table.Column<string>(type: "TEXT", nullable: false),
            //        IFSCCode = table.Column<string>(type: "TEXT", nullable: false),
            //        BranchName = table.Column<string>(type: "TEXT", nullable: false),
            //        AccountType = table.Column<int>(type: "INTEGER", nullable: false),
            //        IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AccountLists", x => x.AccountNumber);
            //        table.ForeignKey(
            //            name: "FK_AccountLists_Banks_BankId",
            //            column: x => x.BankId,
            //            principalTable: "Banks",
            //            principalColumn: "BankId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BankAccounts",
            //    columns: table => new
            //    {
            //        AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        DefaultBank = table.Column<bool>(type: "INTEGER", nullable: false),
            //        SharedAccount = table.Column<bool>(type: "INTEGER", nullable: false),
            //        OpeningBalance = table.Column<decimal>(type: "TEXT", nullable: false),
            //        CurrentBalance = table.Column<decimal>(type: "TEXT", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        ClosingDate = table.Column<DateTime>(type: "TEXT", nullable: true),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        AccountHolderName = table.Column<string>(type: "TEXT", nullable: false),
            //        BankId = table.Column<string>(type: "TEXT", nullable: false),
            //        IFSCCode = table.Column<string>(type: "TEXT", nullable: false),
            //        BranchName = table.Column<string>(type: "TEXT", nullable: false),
            //        AccountType = table.Column<int>(type: "INTEGER", nullable: false),
            //        IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BankAccounts", x => x.AccountNumber);
            //        table.ForeignKey(
            //            name: "FK_BankAccounts_Banks_BankId",
            //            column: x => x.BankId,
            //            principalTable: "Banks",
            //            principalColumn: "BankId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VendorBankAccounts",
            //    columns: table => new
            //    {
            //        AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        VendorId = table.Column<string>(type: "TEXT", nullable: false),
            //        OpeningBalance = table.Column<decimal>(type: "TEXT", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        ClosingDate = table.Column<DateTime>(type: "TEXT", nullable: true),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        AccountHolderName = table.Column<string>(type: "TEXT", nullable: false),
            //        BankId = table.Column<string>(type: "TEXT", nullable: false),
            //        IFSCCode = table.Column<string>(type: "TEXT", nullable: false),
            //        BranchName = table.Column<string>(type: "TEXT", nullable: false),
            //        AccountType = table.Column<int>(type: "INTEGER", nullable: false),
            //        IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VendorBankAccounts", x => x.AccountNumber);
            //        table.ForeignKey(
            //            name: "FK_VendorBankAccounts_Banks_BankId",
            //            column: x => x.BankId,
            //            principalTable: "Banks",
            //            principalColumn: "BankId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

             


            //migrationBuilder.CreateIndex(
            //    name: "IX_AccountLists_BankId",
            //    table: "AccountLists",
            //    column: "BankId");



            //migrationBuilder.CreateIndex(
            //    name: "IX_BankAccounts_BankId",
            //    table: "BankAccounts",
            //    column: "BankId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
