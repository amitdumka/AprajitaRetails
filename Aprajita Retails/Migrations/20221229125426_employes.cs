using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aprajita_Retails.Migrations
{
    public partial class employes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "TEXT", nullable: false),
            //        Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "TEXT", nullable: false),
            //        UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
            //        PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LedgerGroups",
            //    columns: table => new
            //    {
            //        LedgerGroupId = table.Column<string>(type: "TEXT", nullable: false),
            //        GroupName = table.Column<string>(type: "TEXT", nullable: false),
            //        Category = table.Column<int>(type: "INTEGER", nullable: false),
            //        Remark = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LedgerGroups", x => x.LedgerGroupId);
            //    });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<string>(type: "TEXT", nullable: false),
                    StoreCode = table.Column<string>(type: "TEXT", nullable: false),
                    StoreName = table.Column<string>(type: "TEXT", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreManager = table.Column<string>(type: "TEXT", nullable: false),
                    StoreManagerContactNo = table.Column<string>(type: "TEXT", nullable: false),
                    StorePhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    StoreEmailId = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    PanNo = table.Column<string>(type: "TEXT", nullable: false),
                    GSTIN = table.Column<string>(type: "TEXT", nullable: false),
                    VatNo = table.Column<string>(type: "TEXT", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            //migrationBuilder.CreateTable(
            //    name: "V1_LedgerMasters",
            //    columns: table => new
            //    {
            //        PartyId = table.Column<string>(type: "TEXT", nullable: false),
            //        PartyName = table.Column<string>(type: "TEXT", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_V1_LedgerMasters", x => x.PartyId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "V1_PettyCashSheets",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "TEXT", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        OpeningBalance = table.Column<decimal>(type: "TEXT", nullable: false),
            //        ClosingBalance = table.Column<decimal>(type: "TEXT", nullable: false),
            //        BankDeposit = table.Column<decimal>(type: "TEXT", nullable: false),
            //        BankWithdrawal = table.Column<decimal>(type: "TEXT", nullable: false),
            //        DailySale = table.Column<decimal>(type: "TEXT", nullable: false),
            //        TailoringSale = table.Column<decimal>(type: "TEXT", nullable: false),
            //        TailoringPayment = table.Column<decimal>(type: "TEXT", nullable: false),
            //        ManualSale = table.Column<decimal>(type: "TEXT", nullable: false),
            //        CardSale = table.Column<decimal>(type: "TEXT", nullable: false),
            //        NonCashSale = table.Column<decimal>(type: "TEXT", nullable: false),
            //        CustomerDue = table.Column<decimal>(type: "TEXT", nullable: false),
            //        DueList = table.Column<string>(type: "TEXT", nullable: false),
            //        CustomerRecovery = table.Column<decimal>(type: "TEXT", nullable: false),
            //        RecoveryList = table.Column<string>(type: "TEXT", nullable: false),
            //        ReceiptsNaration = table.Column<string>(type: "TEXT", nullable: false),
            //        ReceiptsTotal = table.Column<decimal>(type: "TEXT", nullable: false),
            //        PaymentNaration = table.Column<string>(type: "TEXT", nullable: false),
            //        PaymentTotal = table.Column<decimal>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_V1_PettyCashSheets", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "V1_TranscationModes",
            //    columns: table => new
            //    {
            //        TranscationId = table.Column<string>(type: "TEXT", nullable: false),
            //        TranscationName = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_V1_TranscationModes", x => x.TranscationId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        RoleId = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimType = table.Column<string>(type: "TEXT", nullable: true),
            //        ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimType = table.Column<string>(type: "TEXT", nullable: true),
            //        ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
            //        ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        RoleId = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
            //        Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
            //        Value = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "V1_Employees",
            //    columns: table => new
            //    {
            //        EmployeeId = table.Column<string>(type: "TEXT", nullable: false),
            //        EmpId = table.Column<int>(type: "INTEGER", nullable: false),
            //        JoiningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        LeavingDate = table.Column<DateTime>(type: "TEXT", nullable: true),
            //        IsWorking = table.Column<bool>(type: "INTEGER", nullable: false),
            //        Category = table.Column<int>(type: "INTEGER", nullable: false),
            //        IsTailors = table.Column<bool>(type: "INTEGER", nullable: false),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        City = table.Column<string>(type: "TEXT", nullable: false),
            //        State = table.Column<string>(type: "TEXT", nullable: false),
            //        Country = table.Column<string>(type: "TEXT", nullable: false),
            //        StreetName = table.Column<string>(type: "TEXT", nullable: false),
            //        ZipCode = table.Column<string>(type: "TEXT", nullable: false),
            //        AddressLine = table.Column<string>(type: "TEXT", nullable: false),
            //        FirstName = table.Column<string>(type: "TEXT", nullable: false),
            //        LastName = table.Column<string>(type: "TEXT", nullable: false),
            //        Title = table.Column<string>(type: "TEXT", nullable: false),
            //        Gender = table.Column<int>(type: "INTEGER", nullable: false),
            //        DOB = table.Column<DateTime>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_V1_Employees", x => x.EmployeeId);
            //        table.ForeignKey(
            //            name: "FK_V1_Employees_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "V1_Parties",
            //    columns: table => new
            //    {
            //        PartyId = table.Column<string>(type: "TEXT", nullable: false),
            //        PartyName = table.Column<string>(type: "TEXT", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        ClosingDate = table.Column<DateTime>(type: "TEXT", nullable: true),
            //        OpeningBalance = table.Column<decimal>(type: "TEXT", nullable: false),
            //        ClosingBalance = table.Column<decimal>(type: "TEXT", nullable: false),
            //        Category = table.Column<int>(type: "INTEGER", nullable: false),
            //        GSTIN = table.Column<string>(type: "TEXT", nullable: false),
            //        PANNo = table.Column<string>(type: "TEXT", nullable: false),
            //        Address = table.Column<string>(type: "TEXT", nullable: false),
            //        Remarks = table.Column<string>(type: "TEXT", nullable: false),
            //        LedgerGroupId = table.Column<string>(type: "TEXT", nullable: false),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        EntryStatus = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_V1_Parties", x => x.PartyId);
            //        table.ForeignKey(
            //            name: "FK_V1_Parties_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CashVouchers",
            //    columns: table => new
            //    {
            //        VoucherNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        VoucherType = table.Column<int>(type: "INTEGER", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        TranscationId = table.Column<string>(type: "TEXT", nullable: false),
            //        SlipNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        PartyName = table.Column<string>(type: "TEXT", nullable: false),
            //        Particulars = table.Column<string>(type: "TEXT", nullable: false),
            //        Amount = table.Column<decimal>(type: "TEXT", nullable: false),
            //        Remarks = table.Column<string>(type: "TEXT", nullable: false),
            //        EmployeeId = table.Column<string>(type: "TEXT", nullable: false),
            //        PartyId = table.Column<string>(type: "TEXT", nullable: false),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        EntryStatus = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CashVouchers", x => x.VoucherNumber);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_V1_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "V1_Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_V1_Parties_PartyId",
            //            column: x => x.PartyId,
            //            principalTable: "V1_Parties",
            //            principalColumn: "PartyId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_V1_TranscationModes_TranscationId",
            //            column: x => x.TranscationId,
            //            principalTable: "V1_TranscationModes",
            //            principalColumn: "TranscationId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "V1_Notes",
            //    columns: table => new
            //    {
            //        NoteNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        NotesType = table.Column<int>(type: "INTEGER", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        PartyName = table.Column<string>(type: "TEXT", nullable: false),
            //        WithGST = table.Column<bool>(type: "INTEGER", nullable: false),
            //        Amount = table.Column<decimal>(type: "TEXT", nullable: false),
            //        TaxRate = table.Column<decimal>(type: "TEXT", nullable: false),
            //        Reason = table.Column<string>(type: "TEXT", nullable: false),
            //        Remarks = table.Column<string>(type: "TEXT", nullable: false),
            //        PartyId = table.Column<string>(type: "TEXT", nullable: false),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        EntryStatus = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_V1_Notes", x => x.NoteNumber);
            //        table.ForeignKey(
            //            name: "FK_V1_Notes_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_V1_Notes_V1_Parties_PartyId",
            //            column: x => x.PartyId,
            //            principalTable: "V1_Parties",
            //            principalColumn: "PartyId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vouchers",
            //    columns: table => new
            //    {
            //        VoucherNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        VoucherType = table.Column<int>(type: "INTEGER", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        SlipNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        PartyName = table.Column<string>(type: "TEXT", nullable: false),
            //        Particulars = table.Column<string>(type: "TEXT", nullable: false),
            //        Amount = table.Column<decimal>(type: "TEXT", nullable: false),
            //        PaymentMode = table.Column<int>(type: "INTEGER", nullable: false),
            //        PaymentDetails = table.Column<string>(type: "TEXT", nullable: false),
            //        Remarks = table.Column<string>(type: "TEXT", nullable: false),
            //        AccountId = table.Column<string>(type: "TEXT", nullable: false),
            //        EmployeeId = table.Column<string>(type: "TEXT", nullable: false),
            //        PartyId = table.Column<string>(type: "TEXT", nullable: false),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
            //        StoreId = table.Column<string>(type: "TEXT", nullable: false),
            //        EntryStatus = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vouchers", x => x.VoucherNumber);
            //        table.ForeignKey(
            //            name: "FK_Vouchers_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Vouchers_V1_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "V1_Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Vouchers_V1_Parties_PartyId",
            //            column: x => x.PartyId,
            //            principalTable: "V1_Parties",
            //            principalColumn: "PartyId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_CashVouchers_EmployeeId",
            //    table: "CashVouchers",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CashVouchers_PartyId",
            //    table: "CashVouchers",
            //    column: "PartyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CashVouchers_StoreId",
            //    table: "CashVouchers",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CashVouchers_TranscationId",
            //    table: "CashVouchers",
            //    column: "TranscationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_V1_Employees_StoreId",
            //    table: "V1_Employees",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_V1_Notes_PartyId",
            //    table: "V1_Notes",
            //    column: "PartyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_V1_Notes_StoreId",
            //    table: "V1_Notes",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_V1_Parties_StoreId",
            //    table: "V1_Parties",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Vouchers_EmployeeId",
            //    table: "Vouchers",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Vouchers_PartyId",
            //    table: "Vouchers",
            //    column: "PartyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Vouchers_StoreId",
            //    table: "Vouchers",
            //    column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CashVouchers");

            migrationBuilder.DropTable(
                name: "LedgerGroups");

            migrationBuilder.DropTable(
                name: "V1_LedgerMasters");

            migrationBuilder.DropTable(
                name: "V1_Notes");

            migrationBuilder.DropTable(
                name: "V1_PettyCashSheets");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "V1_TranscationModes");

            migrationBuilder.DropTable(
                name: "V1_Employees");

            migrationBuilder.DropTable(
                name: "V1_Parties");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
