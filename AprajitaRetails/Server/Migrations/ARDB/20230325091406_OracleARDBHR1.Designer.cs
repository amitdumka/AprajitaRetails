﻿// <auto-generated />
using System;
using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace AprajitaRetails.Server.Migrations.ARDB
{
    [DbContext(typeof(ARDBContext))]
    [Migration("20230325091406_OracleARDBHR1")]
    partial class OracleARDBHR1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Banking.Bank", b =>
                {
                    b.Property<string>("BankId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Bases.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Gender")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.Attendance", b =>
                {
                    b.Property<string>("AttendanceId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("EntryTime")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("IsTailoring")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("AttendanceId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Category")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("EmpId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Gender")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("IsTailors")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.EmployeeDetails", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("AdharNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("BankNameWithBranch")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("HighestQualification")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("IFSCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("OtherIdDetails")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PanNo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("SpouseName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("EmployeeDetails");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.MonthlyAttendance", b =>
                {
                    b.Property<string>("MonthlyAttendanceId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Absent")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("CasualLeave")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("HalfDay")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Holidays")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("NoOfWorkingDays")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("PaidLeave")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Present")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Sunday")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("WeeklyLeave")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("MonthlyAttendanceId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("MonthlyAttendances");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.TimeSheet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("InTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("OutTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.AppClient", b =>
                {
                    b.Property<Guid>("AppClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("AppClientId");

                    b.ToTable("AppClients");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.CashDetail", b =>
                {
                    b.Property<string>("CashDetailId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("C1")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("C10")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("C2")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("C5")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Count")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("N10")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("N100")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("N1000")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("N20")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("N200")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("N2000")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("N50")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("N500")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("CashDetailId");

                    b.HasIndex("StoreId");

                    b.ToTable("CashDetails");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.Customer", b =>
                {
                    b.Property<string>("MobileNo")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Age")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Gender")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("NoOfBills")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("MobileNo");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.Salesman", b =>
                {
                    b.Property<string>("SalesmanId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("SalesmanId");

                    b.HasIndex("StoreId");

                    b.ToTable("Salesmen");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.Store", b =>
                {
                    b.Property<string>("StoreId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<Guid?>("AppClientId")
                        .IsRequired()
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("GSTIN")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("PanNo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreEmailId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreGroupId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("StoreManager")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreManagerContactNo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StorePhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("VatNo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("StoreId");

                    b.HasIndex("AppClientId");

                    b.HasIndex("StoreGroupId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.StoreGroup", b =>
                {
                    b.Property<string>("StoreGroupId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<Guid>("AppClientId")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("StoreGroupId");

                    b.HasIndex("AppClientId");

                    b.ToTable("StoreGroups");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Vouchers.LedgerGroup", b =>
                {
                    b.Property<string>("LedgerGroupId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Category")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("LedgerGroupId");

                    b.ToTable("LedgerGroups");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Vouchers.LedgerMaster", b =>
                {
                    b.Property<string>("PartyId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PartyId");

                    b.ToTable("LedgerMasters");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Vouchers.Party", b =>
                {
                    b.Property<string>("PartyId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Category")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("ClosingBalance")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("GSTIN")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("LedgerGroupId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<decimal>("OpeningBalance")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("PANNo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PartyId");

                    b.HasIndex("LedgerGroupId");

                    b.HasIndex("StoreId");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Vouchers.PettyCashSheet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<decimal>("BankDeposit")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("BankWithdrawal")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("CardSale")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("ClosingBalance")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("CustomerDue")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("CustomerRecovery")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("DailySale")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("DueList")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("NUMBER(1)");

                    b.Property<decimal>("ManualSale")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("NUMBER(1)");

                    b.Property<decimal>("NonCashSale")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<decimal>("OpeningBalance")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("PaymentNarration")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("PaymentTotal")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("ReceiptsNarration")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("ReceiptsTotal")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("RecoveryList")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<decimal>("TailoringPayment")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("TailoringSale")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("PettyCashSheets");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Vouchers.TransactionMode", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("TransactionName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("TransactionId");

                    b.ToTable("TransactionModes");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.Attendance", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Payroll.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.Employee", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.EmployeeDetails", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Payroll.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.MonthlyAttendance", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Payroll.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Payroll.TimeSheet", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Payroll.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.CashDetail", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.Salesman", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.Store", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Stores.AppClient", "AppClient")
                        .WithMany()
                        .HasForeignKey("AppClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Stores.StoreGroup", "StoreGroup")
                        .WithMany()
                        .HasForeignKey("StoreGroupId");

                    b.Navigation("AppClient");

                    b.Navigation("StoreGroup");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Stores.StoreGroup", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Stores.AppClient", "AppClient")
                        .WithMany()
                        .HasForeignKey("AppClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppClient");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Vouchers.Party", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Vouchers.LedgerGroup", "LedgerGroup")
                        .WithMany()
                        .HasForeignKey("LedgerGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LedgerGroup");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Vouchers.PettyCashSheet", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });
#pragma warning restore 612, 618
        }
    }
}