using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class DailySaleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Banks",
            //    columns: table => new
            //    {
            //        BankId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Banks", x => x.BankId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Contacts",
            //    columns: table => new
            //    {
            //        ContactId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        State = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Gender = table.Column<int>(type: "int", nullable: false),
            //        DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contacts", x => x.ContactId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        MobileNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Age = table.Column<int>(type: "int", nullable: false),
            //        DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Gender = table.Column<int>(type: "int", nullable: false),
            //        NoOfBills = table.Column<int>(type: "int", nullable: false),
            //        TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.MobileNo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LedgerGroups",
            //    columns: table => new
            //    {
            //        LedgerGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Category = table.Column<int>(type: "int", nullable: false),
            //        Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LedgerGroups", x => x.LedgerGroupId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LedgerMasters",
            //    columns: table => new
            //    {
            //        PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LedgerMasters", x => x.PartyId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SalaryLedgers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        InAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        OutAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SalaryLedgers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Stores",
            //    columns: table => new
            //    {
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        StoreCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        StoreManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StoreManagerContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StorePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StoreEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        State = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        GSTIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        VatNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Stores", x => x.StoreId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TransactionModes",
            //    columns: table => new
            //    {
            //        TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TransactionModes", x => x.TransactionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AccountLists",
            //    columns: table => new
            //    {
            //        AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        SharedAccount = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        AccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AccountType = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
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
            //        AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        DefaultBank = table.Column<bool>(type: "bit", nullable: false),
            //        SharedAccount = table.Column<bool>(type: "bit", nullable: false),
            //        OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        StoreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        AccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AccountType = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
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
            //        AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        VendorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        StoreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        AccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AccountType = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
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

            //migrationBuilder.CreateTable(
            //    name: "CashDetails",
            //    columns: table => new
            //    {
            //        CashDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Count = table.Column<int>(type: "int", nullable: false),
            //        TotalAmount = table.Column<int>(type: "int", nullable: false),
            //        N2000 = table.Column<int>(type: "int", nullable: false),
            //        N1000 = table.Column<int>(type: "int", nullable: false),
            //        N500 = table.Column<int>(type: "int", nullable: false),
            //        N200 = table.Column<int>(type: "int", nullable: false),
            //        N100 = table.Column<int>(type: "int", nullable: false),
            //        N50 = table.Column<int>(type: "int", nullable: false),
            //        N20 = table.Column<int>(type: "int", nullable: false),
            //        N10 = table.Column<int>(type: "int", nullable: false),
            //        C10 = table.Column<int>(type: "int", nullable: false),
            //        C5 = table.Column<int>(type: "int", nullable: false),
            //        C2 = table.Column<int>(type: "int", nullable: false),
            //        C1 = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CashDetails", x => x.CashDetailId);
            //        table.ForeignKey(
            //            name: "FK_CashDetails_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChequeLogs",
            //    columns: table => new
            //    {
            //        ChequeLogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        InFavorOf = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ChequeIssuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ChequeNumber = table.Column<long>(type: "bigint", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChequeLogs", x => x.ChequeLogId);
            //        table.ForeignKey(
            //            name: "FK_ChequeLogs_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "CustomerDues",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    ClearingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDues", x => x.InvoiceNumber);
                    table.ForeignKey(
                        name: "FK_CustomerDues_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EDCTerminals",
                columns: table => new
                {
                    EDCTerminalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDCTerminals", x => x.EDCTerminalId);
                    table.ForeignKey(
                        name: "FK_EDCTerminals_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Employees",
            //    columns: table => new
            //    {
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmpId = table.Column<int>(type: "int", nullable: false),
            //        JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsWorking = table.Column<bool>(type: "bit", nullable: false),
            //        Category = table.Column<int>(type: "int", nullable: false),
            //        IsTailors = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        State = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Gender = table.Column<int>(type: "int", nullable: false),
            //        DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employees", x => x.EmployeeId);
            //        table.ForeignKey(
            //            name: "FK_Employees_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Parties",
            //    columns: table => new
            //    {
            //        PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        ClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Category = table.Column<int>(type: "int", nullable: false),
            //        GSTIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PANNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LedgerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Parties", x => x.PartyId);
            //        table.ForeignKey(
            //            name: "FK_Parties_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PettyCashSheets",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        ClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        BankDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        BankWithdrawal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        DailySale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TailoringSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TailoringPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        ManualSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        CardSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        NonCashSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        CustomerDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        DueList = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CustomerRecovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        RecoveryList = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiptsNarration = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReceiptsTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        PaymentNarration = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PaymentTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PettyCashSheets", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PettyCashSheets_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Salesmen",
            //    columns: table => new
            //    {
            //        SalesmanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Salesmen", x => x.SalesmanId);
            //        table.ForeignKey(
            //            name: "FK_Salesmen_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    BankTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitCredit = table.Column<int>(type: "int", nullable: false),
                    BankDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                });

            //migrationBuilder.CreateTable(
            //    name: "ChequeBooks",
            //    columns: table => new
            //    {
            //        ChequeBookId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankAccountAccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StartingNumber = table.Column<long>(type: "bigint", nullable: false),
            //        EndingNumber = table.Column<long>(type: "bigint", nullable: false),
            //        Count = table.Column<int>(type: "int", nullable: false),
            //        NoOfChequeIssued = table.Column<int>(type: "int", nullable: false),
            //        NoOfPDC = table.Column<int>(type: "int", nullable: false),
            //        NoOfClearedCheques = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChequeBooks", x => x.ChequeBookId);
            //        table.ForeignKey(
            //            name: "FK_ChequeBooks_BankAccounts_BankAccountAccountNumber",
            //            column: x => x.BankAccountAccountNumber,
            //            principalTable: "BankAccounts",
            //            principalColumn: "AccountNumber");
            //        table.ForeignKey(
            //            name: "FK_ChequeBooks_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "DuesRecovery",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartialPayment = table.Column<bool>(type: "bit", nullable: false),
                    DueInvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuesRecovery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuesRecovery_CustomerDues_DueInvoiceNumber",
                        column: x => x.DueInvoiceNumber,
                        principalTable: "CustomerDues",
                        principalColumn: "InvoiceNumber");
                    table.ForeignKey(
                        name: "FK_DuesRecovery_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.NoAction);
                });

            //migrationBuilder.CreateTable(
            //    name: "Attendances",
            //    columns: table => new
            //    {
            //        AttendanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Status = table.Column<int>(type: "int", nullable: false),
            //        EntryTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsTailoring = table.Column<bool>(type: "bit", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
            //        table.ForeignKey(
            //            name: "FK_Attendances_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Attendances_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EmployeeDetails",
            //    columns: table => new
            //    {
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        AdharNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        OtherIdDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        HighestQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankNameWithBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IFSCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EmployeeDetails", x => x.EmployeeId);
            //        table.ForeignKey(
            //            name: "FK_EmployeeDetails_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_EmployeeDetails_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MonthlyAttendances",
            //    columns: table => new
            //    {
            //        MonthlyAttendanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Present = table.Column<int>(type: "int", nullable: false),
            //        HalfDay = table.Column<int>(type: "int", nullable: false),
            //        Sunday = table.Column<int>(type: "int", nullable: false),
            //        PaidLeave = table.Column<int>(type: "int", nullable: false),
            //        Holidays = table.Column<int>(type: "int", nullable: false),
            //        CasualLeave = table.Column<int>(type: "int", nullable: false),
            //        Absent = table.Column<int>(type: "int", nullable: false),
            //        WeeklyLeave = table.Column<int>(type: "int", nullable: false),
            //        Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NoOfWorkingDays = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MonthlyAttendances", x => x.MonthlyAttendanceId);
            //        table.ForeignKey(
            //            name: "FK_MonthlyAttendances_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_MonthlyAttendances_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Salaries",
            //    columns: table => new
            //    {
            //        SalaryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        BasicSalary = table.Column<decimal>(type: "money", nullable: false),
            //        EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsEffective = table.Column<bool>(type: "bit", nullable: false),
            //        WowBill = table.Column<bool>(type: "bit", nullable: false),
            //        Incentive = table.Column<bool>(type: "bit", nullable: false),
            //        LastPcs = table.Column<bool>(type: "bit", nullable: false),
            //        SundayBillable = table.Column<bool>(type: "bit", nullable: false),
            //        FullMonth = table.Column<bool>(type: "bit", nullable: false),
            //        IsTailoring = table.Column<bool>(type: "bit", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Salaries", x => x.SalaryId);
            //        table.ForeignKey(
            //            name: "FK_Salaries_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Salaries_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SalaryPayments",
            //    columns: table => new
            //    {
            //        SalaryPaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        SalaryMonth = table.Column<int>(type: "int", nullable: false),
            //        SalaryComponet = table.Column<int>(type: "int", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Amount = table.Column<decimal>(type: "money", nullable: false),
            //        PayMode = table.Column<int>(type: "int", nullable: false),
            //        Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SalaryPayments", x => x.SalaryPaymentId);
            //        table.ForeignKey(
            //            name: "FK_SalaryPayments_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_SalaryPayments_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StaffAdvanceReceipts",
            //    columns: table => new
            //    {
            //        StaffAdvanceReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Amount = table.Column<decimal>(type: "money", nullable: false),
            //        PayMode = table.Column<int>(type: "int", nullable: false),
            //        Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StaffAdvanceReceipts", x => x.StaffAdvanceReceiptId);
            //        table.ForeignKey(
            //            name: "FK_StaffAdvanceReceipts_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StaffAdvanceReceipts_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TimeSheets",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        InTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TimeSheets", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TimeSheets_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CashVouchers",
            //    columns: table => new
            //    {
            //        VoucherNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        VoucherType = table.Column<int>(type: "int", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        SlipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CashVouchers", x => x.VoucherNumber);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_Parties_PartyId",
            //            column: x => x.PartyId,
            //            principalTable: "Parties",
            //            principalColumn: "PartyId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CashVouchers_TransactionModes_TransactionId",
            //            column: x => x.TransactionId,
            //            principalTable: "TransactionModes",
            //            principalColumn: "TransactionId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Notes",
            //    columns: table => new
            //    {
            //        NoteNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        NotesType = table.Column<int>(type: "int", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WithGST = table.Column<bool>(type: "bit", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notes", x => x.NoteNumber);
            //        table.ForeignKey(
            //            name: "FK_Notes_Parties_PartyId",
            //            column: x => x.PartyId,
            //            principalTable: "Parties",
            //            principalColumn: "PartyId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Notes_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vouchers",
            //    columns: table => new
            //    {
            //        VoucherNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        VoucherType = table.Column<int>(type: "int", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SlipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        PaymentMode = table.Column<int>(type: "int", nullable: false),
            //        PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        PartyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vouchers", x => x.VoucherNumber);
            //        table.ForeignKey(
            //            name: "FK_Vouchers_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Vouchers_Parties_PartyId",
            //            column: x => x.PartyId,
            //            principalTable: "Parties",
            //            principalColumn: "PartyId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Vouchers_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "DailySales",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonCashAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    SalesmanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDue = table.Column<bool>(type: "bit", nullable: false),
                    ManualBill = table.Column<bool>(type: "bit", nullable: false),
                    SalesReturn = table.Column<bool>(type: "bit", nullable: false),
                    TailoringBill = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EDCTerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySales", x => x.InvoiceNumber);
                    table.ForeignKey(
                        name: "FK_DailySales_EDCTerminals_EDCTerminalId",
                        column: x => x.EDCTerminalId,
                        principalTable: "EDCTerminals",
                        principalColumn: "EDCTerminalId");
                    table.ForeignKey(
                        name: "FK_DailySales_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DailySales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "ChequeIssued",
            //    columns: table => new
            //    {
            //        ChequeIssuedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        InFavorOf = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankAccountAccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        ChequeBookId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ChequeNumber = table.Column<long>(type: "bigint", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChequeIssued", x => x.ChequeIssuedId);
            //        table.ForeignKey(
            //            name: "FK_ChequeIssued_BankAccounts_BankAccountAccountNumber",
            //            column: x => x.BankAccountAccountNumber,
            //            principalTable: "BankAccounts",
            //            principalColumn: "AccountNumber");
            //        table.ForeignKey(
            //            name: "FK_ChequeIssued_ChequeBooks_ChequeBookId",
            //            column: x => x.ChequeBookId,
            //            principalTable: "ChequeBooks",
            //            principalColumn: "ChequeBookId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ChequeIssued_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaySlips",
            //    columns: table => new
            //    {
            //        PaySlipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Month = table.Column<int>(type: "int", nullable: false),
            //        Year = table.Column<int>(type: "int", nullable: false),
            //        EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        SalaryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        BasicSalaryRate = table.Column<decimal>(type: "money", nullable: false),
            //        BasicSalary = table.Column<decimal>(type: "money", nullable: false),
            //        TotalPayableSalary = table.Column<decimal>(type: "money", nullable: false),
            //        NoOfDaysPresent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        WorkingDays = table.Column<int>(type: "int", nullable: false),
            //        TotalSale = table.Column<decimal>(type: "money", nullable: false),
            //        SaleIncentive = table.Column<decimal>(type: "money", nullable: false),
            //        WOWBillAmount = table.Column<decimal>(type: "money", nullable: false),
            //        WOWBillIncentive = table.Column<decimal>(type: "money", nullable: false),
            //        LastPcsAmount = table.Column<decimal>(type: "money", nullable: false),
            //        LastPCsIncentive = table.Column<decimal>(type: "money", nullable: false),
            //        OthersIncentive = table.Column<decimal>(type: "money", nullable: false),
            //        GrossSalary = table.Column<decimal>(type: "money", nullable: false),
            //        StandardDeductions = table.Column<decimal>(type: "money", nullable: false),
            //        TDSDeductions = table.Column<decimal>(type: "money", nullable: false),
            //        PFDeductions = table.Column<decimal>(type: "money", nullable: false),
            //        AdvanceDeducations = table.Column<decimal>(type: "money", nullable: false),
            //        OtherDeductions = table.Column<decimal>(type: "money", nullable: false),
            //        Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsTailoring = table.Column<bool>(type: "bit", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
            //        MarkedDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        EntryStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaySlips", x => x.PaySlipId);
            //        table.ForeignKey(
            //            name: "FK_PaySlips_Employees_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PaySlips_Salaries_SalaryId",
            //            column: x => x.SalaryId,
            //            principalTable: "Salaries",
            //            principalColumn: "SalaryId");
            //        table.ForeignKey(
            //            name: "FK_PaySlips_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "StoreId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AccountLists_BankId",
            //    table: "AccountLists",
            //    column: "BankId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Attendances_EmployeeId",
            //    table: "Attendances",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Attendances_StoreId",
            //    table: "Attendances",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BankAccounts_BankId",
            //    table: "BankAccounts",
            //    column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_AccountNumber",
                table: "BankTransactions",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_StoreId",
                table: "BankTransactions",
                column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CashDetails_StoreId",
            //    table: "CashDetails",
            //    column: "StoreId");

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
            //    name: "IX_CashVouchers_TransactionId",
            //    table: "CashVouchers",
            //    column: "TransactionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChequeBooks_BankAccountAccountNumber",
            //    table: "ChequeBooks",
            //    column: "BankAccountAccountNumber");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChequeBooks_StoreId",
            //    table: "ChequeBooks",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChequeIssued_BankAccountAccountNumber",
            //    table: "ChequeIssued",
            //    column: "BankAccountAccountNumber");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChequeIssued_ChequeBookId",
            //    table: "ChequeIssued",
            //    column: "ChequeBookId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChequeIssued_StoreId",
            //    table: "ChequeIssued",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChequeLogs_StoreId",
            //    table: "ChequeLogs",
            //    column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDues_StoreId",
                table: "CustomerDues",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_EDCTerminalId",
                table: "DailySales",
                column: "EDCTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_SalesmanId",
                table: "DailySales",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_StoreId",
                table: "DailySales",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DuesRecovery_DueInvoiceNumber",
                table: "DuesRecovery",
                column: "DueInvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DuesRecovery_StoreId",
                table: "DuesRecovery",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_EDCTerminals_StoreId",
                table: "EDCTerminals",
                column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_EmployeeDetails_StoreId",
            //    table: "EmployeeDetails",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employees_StoreId",
            //    table: "Employees",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MonthlyAttendances_EmployeeId",
            //    table: "MonthlyAttendances",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MonthlyAttendances_StoreId",
            //    table: "MonthlyAttendances",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Notes_PartyId",
            //    table: "Notes",
            //    column: "PartyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Notes_StoreId",
            //    table: "Notes",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Parties_StoreId",
            //    table: "Parties",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaySlips_EmployeeId",
            //    table: "PaySlips",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaySlips_SalaryId",
            //    table: "PaySlips",
            //    column: "SalaryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaySlips_StoreId",
            //    table: "PaySlips",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PettyCashSheets_StoreId",
            //    table: "PettyCashSheets",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Salaries_EmployeeId",
            //    table: "Salaries",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Salaries_StoreId",
            //    table: "Salaries",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SalaryPayments_EmployeeId",
            //    table: "SalaryPayments",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SalaryPayments_StoreId",
            //    table: "SalaryPayments",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Salesmen_StoreId",
            //    table: "Salesmen",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StaffAdvanceReceipts_EmployeeId",
            //    table: "StaffAdvanceReceipts",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StaffAdvanceReceipts_StoreId",
            //    table: "StaffAdvanceReceipts",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TimeSheets_EmployeeId",
            //    table: "TimeSheets",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_VendorBankAccounts_BankId",
            //    table: "VendorBankAccounts",
            //    column: "BankId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AccountLists");

            //migrationBuilder.DropTable(
            //    name: "Attendances");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            //migrationBuilder.DropTable(
            //    name: "CashDetails");

            //migrationBuilder.DropTable(
            //    name: "CashVouchers");

            //migrationBuilder.DropTable(
            //    name: "ChequeIssued");

            //migrationBuilder.DropTable(
            //    name: "ChequeLogs");

            //migrationBuilder.DropTable(
            //    name: "Contacts");

            //migrationBuilder.DropTable(
            //    name: "Customers");

            migrationBuilder.DropTable(
                name: "DailySales");

            migrationBuilder.DropTable(
                name: "DuesRecovery");

            //migrationBuilder.DropTable(
            //    name: "EmployeeDetails");

            //migrationBuilder.DropTable(
            //    name: "LedgerGroups");

            //migrationBuilder.DropTable(
            //    name: "LedgerMasters");

            //migrationBuilder.DropTable(
            //    name: "MonthlyAttendances");

            //migrationBuilder.DropTable(
            //    name: "Notes");

            //migrationBuilder.DropTable(
            //    name: "PaySlips");

            //migrationBuilder.DropTable(
            //    name: "PettyCashSheets");

            //migrationBuilder.DropTable(
            //    name: "SalaryLedgers");

            //migrationBuilder.DropTable(
            //    name: "SalaryPayments");

            //migrationBuilder.DropTable(
            //    name: "StaffAdvanceReceipts");

            //migrationBuilder.DropTable(
            //    name: "TimeSheets");

            //migrationBuilder.DropTable(
            //    name: "VendorBankAccounts");

            //migrationBuilder.DropTable(
            //    name: "Vouchers");

            //migrationBuilder.DropTable(
            //    name: "TransactionModes");

            //migrationBuilder.DropTable(
            //    name: "ChequeBooks");

            migrationBuilder.DropTable(
                name: "EDCTerminals");

            //migrationBuilder.DropTable(
            //    name: "Salesmen");

            migrationBuilder.DropTable(
                name: "CustomerDues");

            //migrationBuilder.DropTable(
            //    name: "Salaries");

            //migrationBuilder.DropTable(
            //    name: "Parties");

            //migrationBuilder.DropTable(
            //    name: "BankAccounts");

            //migrationBuilder.DropTable(
            //    name: "Employees");

            //migrationBuilder.DropTable(
            //    name: "Banks");

            //migrationBuilder.DropTable(
            //    name: "Stores");
        }
    }
}