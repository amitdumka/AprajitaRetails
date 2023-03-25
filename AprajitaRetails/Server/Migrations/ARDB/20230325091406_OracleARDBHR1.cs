using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    /// <inheritdoc />
    public partial class OracleARDBHR1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TotalAmount",
                table: "Customers",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EmpId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsWorking = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Category = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsTailors = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
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
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    SalesmanId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EntryTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Remarks = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    IsTailoring = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AdharNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PanNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OtherIdDetails = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FatherName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SpouseName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HighestQualification = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankNameWithBranch = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IFSCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "MonthlyAttendances",
                columns: table => new
                {
                    MonthlyAttendanceId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Present = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HalfDay = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Sunday = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PaidLeave = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Holidays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CasualLeave = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Absent = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    WeeklyLeave = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Remarks = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NoOfWorkingDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    OutTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Reason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MarkedDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    StoreId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EntryStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StoreId",
                table: "Attendances",
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
                name: "IX_Salesmen_StoreId",
                table: "Salesmen",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_EmployeeId",
                table: "TimeSheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_StoreId",
                table: "TimeSheets",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "MonthlyAttendances");

            migrationBuilder.DropTable(
                name: "Salesmen");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "Employees");

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
                name: "TotalAmount",
                table: "Customers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
