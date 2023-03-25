using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class OracleARDBInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppClients",
                columns: table => new
                {
                    AppClientId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ClientName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClientAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MobileNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClients", x => x.AppClientId);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MobileNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    State = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StreetName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ZipCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AddressLine = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DOB = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    MobileNo = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NoOfBills = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.MobileNo);
                });

            migrationBuilder.CreateTable(
                name: "TransactionModes",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TransactionName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionModes", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "StoreGroups",
                columns: table => new
                {
                    StoreGroupId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    GroupName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AppClientId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Remarks = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    StoreCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StoreName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreManager = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StoreManagerContactNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StorePhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StoreEmailId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    State = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ZipCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PanNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GSTIN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VatNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreGroupId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    AppClientId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Stores_AppClients_AppClientId",
                        column: x => x.AppClientId,
                        principalTable: "AppClients",
                        principalColumn: "AppClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_StoreGroups_StoreGroupId",
                        column: x => x.StoreGroupId,
                        principalTable: "StoreGroups",
                        principalColumn: "StoreGroupId");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "TransactionModes");

            migrationBuilder.DropTable(
                name: "StoreGroups");

            migrationBuilder.DropTable(
                name: "AppClients");
        }
    }
}
