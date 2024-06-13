using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppClients",
                columns: table => new
                {
                    AppClientId = table.Column<byte[]>(type: "varbinary(3072)", nullable: false),
                    ClientName = table.Column<string>(type: "longtext", nullable: false),
                    ClientAddress = table.Column<string>(type: "longtext", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    MobileNumber = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClients", x => x.AppClientId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandCode = table.Column<string>(type: "varchar(255)", nullable: false),
                    BrandName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandCode);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    MobileNumber = table.Column<string>(type: "longtext", nullable: true),
                    EMail = table.Column<string>(type: "longtext", nullable: true),
                    City = table.Column<string>(type: "longtext", nullable: true),
                    State = table.Column<string>(type: "longtext", nullable: true),
                    Country = table.Column<string>(type: "longtext", nullable: true),
                    StreetName = table.Column<string>(type: "longtext", nullable: true),
                    ZipCode = table.Column<string>(type: "longtext", nullable: true),
                    AddressLine = table.Column<string>(type: "longtext", nullable: true),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    MobileNo = table.Column<string>(type: "varchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NoOfBills = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.MobileNo);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LedgerGroups",
                columns: table => new
                {
                    LedgerGroupId = table.Column<string>(type: "varchar(255)", nullable: false),
                    GroupName = table.Column<string>(type: "longtext", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerGroups", x => x.LedgerGroupId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LedgerMasters",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PartyName = table.Column<string>(type: "longtext", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerMasters", x => x.PartyId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductSubCategories",
                columns: table => new
                {
                    SubCategory = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProductCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubCategories", x => x.SubCategory);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProductTypeName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalaryLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<string>(type: "longtext", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Particulars = table.Column<string>(type: "longtext", nullable: false),
                    InAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryLedgers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Warehouse = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TallyServers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ServerUrl = table.Column<string>(type: "longtext", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true),
                    TallyPort = table.Column<string>(type: "longtext", nullable: true),
                    TallyUrlBase = table.Column<string>(type: "longtext", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Live = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallyServers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxNameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    CompositeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutPutTax = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxNameId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransactionModes",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "varchar(255)", nullable: false),
                    TransactionName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionModes", x => x.TransactionId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StoreGroups",
                columns: table => new
                {
                    StoreGroupId = table.Column<string>(type: "varchar(255)", nullable: false),
                    GroupName = table.Column<string>(type: "longtext", nullable: false),
                    AppClientId = table.Column<byte[]>(type: "varbinary(3072)", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGroups", x => x.StoreGroupId);
                    table.ForeignKey(
                        name: "FK_StoreGroups_AppClients_AppClientId",
                        column: x => x.AppClientId,
                        principalTable: "AppClients",
                        principalColumn: "AppClientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountLists",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    SharedAccount = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "longtext", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AppClientId = table.Column<byte[]>(type: "longblob", nullable: true),
                    StoreGroupId = table.Column<string>(type: "longtext", nullable: true),
                    AccountHolderName = table.Column<string>(type: "longtext", nullable: false),
                    BankId = table.Column<string>(type: "varchar(255)", nullable: false),
                    IFSCCode = table.Column<string>(type: "longtext", nullable: false),
                    BranchName = table.Column<string>(type: "longtext", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    DefaultBank = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SharedAccount = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StoreId = table.Column<string>(type: "longtext", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreGroupId = table.Column<string>(type: "longtext", nullable: true),
                    AppClientId = table.Column<byte[]>(type: "longblob", nullable: true),
                    AccountHolderName = table.Column<string>(type: "longtext", nullable: false),
                    BankId = table.Column<string>(type: "varchar(255)", nullable: false),
                    IFSCCode = table.Column<string>(type: "longtext", nullable: false),
                    BranchName = table.Column<string>(type: "longtext", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VendorBankAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    VendorId = table.Column<string>(type: "longtext", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StoreId = table.Column<string>(type: "longtext", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AppClientId = table.Column<byte[]>(type: "longblob", nullable: true),
                    StoreGroupId = table.Column<string>(type: "longtext", nullable: true),
                    AccountHolderName = table.Column<string>(type: "longtext", nullable: false),
                    BankId = table.Column<string>(type: "varchar(255)", nullable: false),
                    IFSCCode = table.Column<string>(type: "longtext", nullable: false),
                    BranchName = table.Column<string>(type: "longtext", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    StyleCode = table.Column<string>(type: "longtext", nullable: true),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
                    SubCategory = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProductTypeId = table.Column<string>(type: "varchar(255)", nullable: true),
                    HSNCode = table.Column<string>(type: "longtext", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    BrandCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    StoreGroupId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_ProductItems_Brands_BrandCode",
                        column: x => x.BrandCode,
                        principalTable: "Brands",
                        principalColumn: "BrandCode");
                    table.ForeignKey(
                        name: "FK_ProductItems_ProductSubCategories_SubCategory",
                        column: x => x.SubCategory,
                        principalTable: "ProductSubCategories",
                        principalColumn: "SubCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItems_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId");
                    table.ForeignKey(
                        name: "FK_ProductItems_StoreGroups_StoreGroupId",
                        column: x => x.StoreGroupId,
                        principalTable: "StoreGroups",
                        principalColumn: "StoreGroupId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    StoreCode = table.Column<string>(type: "longtext", nullable: false),
                    StoreName = table.Column<string>(type: "longtext", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreManager = table.Column<string>(type: "longtext", nullable: false),
                    StoreManagerContactNo = table.Column<string>(type: "longtext", nullable: false),
                    StorePhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    StoreEmailId = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false),
                    Country = table.Column<string>(type: "longtext", nullable: false),
                    ZipCode = table.Column<string>(type: "longtext", nullable: false),
                    PanNo = table.Column<string>(type: "longtext", nullable: false),
                    GSTIN = table.Column<string>(type: "longtext", nullable: false),
                    VatNo = table.Column<string>(type: "longtext", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreGroupId = table.Column<string>(type: "varchar(255)", nullable: true),
                    AppClientId = table.Column<byte[]>(type: "varbinary(3072)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Stores_AppClients_AppClientId",
                        column: x => x.AppClientId,
                        principalTable: "AppClients",
                        principalColumn: "AppClientId");
                    table.ForeignKey(
                        name: "FK_Stores_StoreGroups_StoreGroupId",
                        column: x => x.StoreGroupId,
                        principalTable: "StoreGroups",
                        principalColumn: "StoreGroupId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    BankTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Narration = table.Column<string>(type: "longtext", nullable: false),
                    RefNumber = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitCredit = table.Column<int>(type: "int", nullable: false),
                    BankDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Verified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AppClinetId = table.Column<byte[]>(type: "longblob", nullable: true),
                    StoreGroupId = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashDetails",
                columns: table => new
                {
                    CashDetailId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    N2000 = table.Column<int>(type: "int", nullable: false),
                    N1000 = table.Column<int>(type: "int", nullable: false),
                    N500 = table.Column<int>(type: "int", nullable: false),
                    N200 = table.Column<int>(type: "int", nullable: false),
                    N100 = table.Column<int>(type: "int", nullable: false),
                    N50 = table.Column<int>(type: "int", nullable: false),
                    N20 = table.Column<int>(type: "int", nullable: false),
                    N10 = table.Column<int>(type: "int", nullable: false),
                    C10 = table.Column<int>(type: "int", nullable: false),
                    C5 = table.Column<int>(type: "int", nullable: false),
                    C2 = table.Column<int>(type: "int", nullable: false),
                    C1 = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChequeBooks",
                columns: table => new
                {
                    ChequeBookId = table.Column<string>(type: "varchar(255)", nullable: false),
                    AccountId = table.Column<string>(type: "longtext", nullable: false),
                    BankAccountAccountNumber = table.Column<string>(type: "varchar(255)", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartingNumber = table.Column<long>(type: "bigint", nullable: false),
                    EndingNumber = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    NoOfChequeIssued = table.Column<int>(type: "int", nullable: false),
                    NoOfPDC = table.Column<int>(type: "int", nullable: false),
                    NoOfClearedCheques = table.Column<int>(type: "int", nullable: false),
                    AppClinetId = table.Column<byte[]>(type: "longblob", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChequeLogs",
                columns: table => new
                {
                    ChequeLogId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InFavorOf = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountNumber = table.Column<string>(type: "longtext", nullable: false),
                    ChequeIssuer = table.Column<string>(type: "longtext", nullable: false),
                    BankId = table.Column<string>(type: "longtext", nullable: false),
                    ChequeNumber = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    AppClinetId = table.Column<byte[]>(type: "longblob", nullable: true),
                    StoreGroupId = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerDues",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ClearingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EDCTerminals",
                columns: table => new
                {
                    EDCTerminalId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TID = table.Column<string>(type: "longtext", nullable: false),
                    MID = table.Column<string>(type: "longtext", nullable: false),
                    BankId = table.Column<string>(type: "longtext", nullable: false),
                    ProviderName = table.Column<string>(type: "longtext", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsWorking = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    IsTailors = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: true),
                    State = table.Column<string>(type: "longtext", nullable: true),
                    Country = table.Column<string>(type: "longtext", nullable: true),
                    StreetName = table.Column<string>(type: "longtext", nullable: true),
                    ZipCode = table.Column<string>(type: "longtext", nullable: true),
                    AddressLine = table.Column<string>(type: "longtext", nullable: true),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PartyName = table.Column<string>(type: "longtext", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    GSTIN = table.Column<string>(type: "longtext", nullable: true),
                    PANNo = table.Column<string>(type: "longtext", nullable: true),
                    Address = table.Column<string>(type: "longtext", nullable: true),
                    Remarks = table.Column<string>(type: "longtext", nullable: true),
                    LedgerGroupId = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PettyCashSheets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                    DueList = table.Column<string>(type: "longtext", nullable: false),
                    CustomerRecovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecoveryList = table.Column<string>(type: "longtext", nullable: false),
                    ReceiptsNarration = table.Column<string>(type: "longtext", nullable: false),
                    ReceiptsTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentNarration = table.Column<string>(type: "longtext", nullable: false),
                    PaymentTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    SalesmanId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    EmployeeId = table.Column<string>(type: "longtext", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.SalesmanId);
                    table.ForeignKey(
                        name: "FK_Salesmen_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(3072)", nullable: false),
                    Barcode = table.Column<string>(type: "varchar(255)", nullable: false),
                    PurchaseQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoldQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoldQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    MultiPrice = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<string>(type: "varchar(255)", nullable: false),
                    VendorName = table.Column<string>(type: "longtext", nullable: false),
                    VendorType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChequeIssued",
                columns: table => new
                {
                    ChequeIssuedId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InFavorOf = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<string>(type: "longtext", nullable: false),
                    BankAccountAccountNumber = table.Column<string>(type: "varchar(255)", nullable: true),
                    ChequeBookId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ChequeNumber = table.Column<long>(type: "bigint", nullable: false),
                    AppClinetId = table.Column<byte[]>(type: "longblob", nullable: true),
                    StoreGroupId = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DuesRecovery",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true),
                    PartialPayment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DueInvoiceNumber = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InvoiceNumber = table.Column<string>(type: "longtext", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    CardLastDigit = table.Column<int>(type: "int", nullable: false),
                    AuthCode = table.Column<int>(type: "int", nullable: false),
                    EDCTerminalId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPaymentDetails_EDCTerminals_EDCTerminalId",
                        column: x => x.EDCTerminalId,
                        principalTable: "EDCTerminals",
                        principalColumn: "EDCTerminalId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EntryTime = table.Column<string>(type: "longtext", nullable: true),
                    Remarks = table.Column<string>(type: "longtext", nullable: true),
                    IsTailoring = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AdharNumber = table.Column<string>(type: "longtext", nullable: false),
                    PanNo = table.Column<string>(type: "longtext", nullable: false),
                    OtherIdDetails = table.Column<string>(type: "longtext", nullable: false),
                    FatherName = table.Column<string>(type: "longtext", nullable: false),
                    MaritalStatus = table.Column<string>(type: "longtext", nullable: false),
                    SpouseName = table.Column<string>(type: "longtext", nullable: false),
                    HighestQualification = table.Column<string>(type: "longtext", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "longtext", nullable: false),
                    BankNameWithBranch = table.Column<string>(type: "longtext", nullable: false),
                    IFSCode = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MonthlyAttendances",
                columns: table => new
                {
                    MonthlyAttendanceId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Present = table.Column<int>(type: "int", nullable: false),
                    HalfDay = table.Column<int>(type: "int", nullable: false),
                    Sunday = table.Column<int>(type: "int", nullable: false),
                    PaidLeave = table.Column<int>(type: "int", nullable: false),
                    Holidays = table.Column<int>(type: "int", nullable: false),
                    CasualLeave = table.Column<int>(type: "int", nullable: false),
                    Absent = table.Column<int>(type: "int", nullable: false),
                    WeeklyLeave = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: false),
                    NoOfWorkingDays = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyAttendances", x => x.MonthlyAttendanceId);
                    table.ForeignKey(
                        name: "FK_MonthlyAttendances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlyAttendances_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsEffective = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WowBill = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Incentive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastPcs = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SundayBillable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FullMonth = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsTailoring = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salaries_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalaryPayments",
                columns: table => new
                {
                    SalaryPaymentId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    SalaryMonth = table.Column<int>(type: "int", nullable: false),
                    SalaryComponet = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryPayments", x => x.SalaryPaymentId);
                    table.ForeignKey(
                        name: "FK_SalaryPayments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryPayments_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffAdvanceReceipts",
                columns: table => new
                {
                    StaffAdvanceReceiptId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAdvanceReceipts", x => x.StaffAdvanceReceiptId);
                    table.ForeignKey(
                        name: "FK_StaffAdvanceReceipts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffAdvanceReceipts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Reason = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashVouchers",
                columns: table => new
                {
                    VoucherNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TransactionId = table.Column<string>(type: "varchar(255)", nullable: false),
                    SlipNumber = table.Column<string>(type: "longtext", nullable: true),
                    PartyName = table.Column<string>(type: "longtext", nullable: false),
                    Particulars = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PartyId = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashVouchers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    NotesType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PartyName = table.Column<string>(type: "longtext", nullable: false),
                    WithGST = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: false),
                    PartyId = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    VoucherType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SlipNumber = table.Column<string>(type: "longtext", nullable: false),
                    PartyName = table.Column<string>(type: "longtext", nullable: false),
                    Particulars = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMode = table.Column<int>(type: "int", nullable: false),
                    PaymentDetails = table.Column<string>(type: "longtext", nullable: true),
                    Remarks = table.Column<string>(type: "longtext", nullable: true),
                    AccountId = table.Column<string>(type: "longtext", nullable: true),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PartyId = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vouchers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vouchers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailySales",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonCashAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    SalesmanId = table.Column<string>(type: "varchar(255)", nullable: false),
                    IsDue = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ManualBill = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SalesReturn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TailoringBill = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true),
                    EDCTerminalId = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailySales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    BilledQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalMRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBasicAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoundOff = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Adjusted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SalesmanId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Tailoring = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductPurchases",
                columns: table => new
                {
                    InwardNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    InwardDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InvoiceNo = table.Column<string>(type: "longtext", nullable: false),
                    VendorId = table.Column<string>(type: "varchar(255)", nullable: true),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    BillQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Warehouse = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        principalColumn: "VendorId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaySlips",
                columns: table => new
                {
                    PaySlipId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    SalaryId = table.Column<string>(type: "varchar(255)", nullable: true),
                    BasicSalaryRate = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    TotalPayableSalary = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    NoOfDaysPresent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingDays = table.Column<int>(type: "int", nullable: false),
                    TotalSale = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    SaleIncentive = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    WOWBillAmount = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    WOWBillIncentive = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    LastPcsAmount = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    LastPCsIncentive = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    OthersIncentive = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    StandardDeductions = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    TDSDeductions = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    PFDeductions = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    AdvanceDeducations = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    OtherDeductions = table.Column<decimal>(type: "money(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: false),
                    IsTailoring = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EntryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySlips", x => x.PaySlipId);
                    table.ForeignKey(
                        name: "FK_PaySlips_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaySlips_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId");
                    table.ForeignKey(
                        name: "FK_PaySlips_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerSales",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    MobileNo = table.Column<string>(type: "varchar(255)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InvoiceNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    Barcode = table.Column<string>(type: "varchar(255)", nullable: false),
                    BilledQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    Adjusted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastPcs = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalePaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InvoiceNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    RefId = table.Column<string>(type: "longtext", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InwardNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    Barcode = table.Column<string>(type: "varchar(255)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_ProductPurchases_InwardNumber",
                        column: x => x.InwardNumber,
                        principalTable: "ProductPurchases",
                        principalColumn: "InwardNumber",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLists_BankId",
                table: "AccountLists",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StoreId",
                table: "Attendances",
                column: "StoreId");

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
                name: "IX_CardPaymentDetails_EDCTerminalId",
                table: "CardPaymentDetails",
                column: "EDCTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_CashDetails_StoreId",
                table: "CashDetails",
                column: "StoreId");

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
                name: "IX_CustomerDues_StoreId",
                table: "CustomerDues",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSales_MobileNo",
                table: "CustomerSales",
                column: "MobileNo");

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_StoreId",
                table: "EmployeeDetails",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StoreId",
                table: "Employees",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyAttendances_EmployeeId",
                table: "MonthlyAttendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyAttendances_StoreId",
                table: "MonthlyAttendances",
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
                name: "IX_Parties_LedgerGroupId",
                table: "Parties",
                column: "LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_StoreId",
                table: "Parties",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySlips_EmployeeId",
                table: "PaySlips",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySlips_SalaryId",
                table: "PaySlips",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySlips_StoreId",
                table: "PaySlips",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PettyCashSheets_StoreId",
                table: "PettyCashSheets",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_BrandCode",
                table: "ProductItems",
                column: "BrandCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductTypeId",
                table: "ProductItems",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_StoreGroupId",
                table: "ProductItems",
                column: "StoreGroupId");

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
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_StoreId",
                table: "Salaries",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPayments_EmployeeId",
                table: "SalaryPayments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPayments_StoreId",
                table: "SalaryPayments",
                column: "StoreId");

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
                name: "IX_Salesmen_StoreId",
                table: "Salesmen",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAdvanceReceipts_EmployeeId",
                table: "StaffAdvanceReceipts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAdvanceReceipts_StoreId",
                table: "StaffAdvanceReceipts",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Barcode",
                table: "Stocks",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StoreId",
                table: "Stocks",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGroups_AppClientId",
                table: "StoreGroups",
                column: "AppClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AppClientId",
                table: "Stores",
                column: "AppClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreGroupId",
                table: "Stores",
                column: "StoreGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_EmployeeId",
                table: "TimeSheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_StoreId",
                table: "TimeSheets",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBankAccounts_BankId",
                table: "VendorBankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_StoreId",
                table: "Vendors",
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
                name: "TallyServers");

            migrationBuilder.DropTable(
                name: "Taxes");

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
                name: "LedgerGroups");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "StoreGroups");

            migrationBuilder.DropTable(
                name: "AppClients");
        }
    }
}
