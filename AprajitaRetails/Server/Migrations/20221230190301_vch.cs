﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations
{
    /// <inheritdoc />
    public partial class vch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LedgerGroups",
                columns: table => new
                {
                    LedgerGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerGroups", x => x.LedgerGroupId);
                });

            migrationBuilder.CreateTable(
                name: "LedgerMasters",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerMasters", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "PettyCashSheets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankWithdrawal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailySale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TailoringSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TailoringPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManualSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonCashSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerRecovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecoveryList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptsNaration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptsTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentNaration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PettyCashSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StoreManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreManagerContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VatNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionModes",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionModes", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsWorking = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    IsTailors = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    GSTIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PANNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LedgerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Parties_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashVouchers",
                columns: table => new
                {
                    VoucherNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashVouchers", x => x.VoucherNumber);
                    table.ForeignKey(
                        name: "FK_CashVouchers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CashVouchers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CashVouchers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashVouchers_TransactionModes_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TransactionModes",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotesType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithGST = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteNumber);
                    table.ForeignKey(
                        name: "FK_Notes_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Notes_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMode = table.Column<int>(type: "int", nullable: false),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherNumber);
                    table.ForeignKey(
                        name: "FK_Vouchers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vouchers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vouchers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashVouchers_EmployeeId",
                table: "CashVouchers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashVouchers_PartyId",
                table: "CashVouchers",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CashVouchers_StoreId",
                table: "CashVouchers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CashVouchers_TransactionId",
                table: "CashVouchers",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StoreId",
                table: "Employees",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PartyId",
                table: "Notes",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StoreId",
                table: "Notes",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_StoreId",
                table: "Parties",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_EmployeeId",
                table: "Vouchers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_PartyId",
                table: "Vouchers",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_StoreId",
                table: "Vouchers",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashVouchers");

            migrationBuilder.DropTable(
                name: "LedgerGroups");

            migrationBuilder.DropTable(
                name: "LedgerMasters");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "PettyCashSheets");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "TransactionModes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
