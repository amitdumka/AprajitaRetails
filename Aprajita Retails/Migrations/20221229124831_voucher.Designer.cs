﻿// <auto-generated />
using System;
using Aprajita_Retails.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aprajita_Retails.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221229124831_voucher")]
    partial class voucher
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.12");

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Payroll.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmpId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTailors")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("V1_Employees");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Stores.Store", b =>
                {
                    b.Property<string>("StoreId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("GSTIN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PanNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreEmailId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreManagerContactNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StorePhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VatNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Vouchers.CashVoucher", b =>
                {
                    b.Property<string>("VoucherNumber")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Particulars")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SlipNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TranscationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VoucherType")
                        .HasColumnType("INTEGER");

                    b.HasKey("VoucherNumber");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PartyId");

                    b.HasIndex("StoreId");

                    b.HasIndex("TranscationId");

                    b.ToTable("CashVouchers");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Vouchers.Party", b =>
                {
                    b.Property<string>("PartyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ClosingBalance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GSTIN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LedgerGroupId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("OpeningBalance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PANNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PartyId");

                    b.HasIndex("StoreId");

                    b.ToTable("V1_Parties");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Vouchers.TranscationMode", b =>
                {
                    b.Property<string>("TranscationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranscationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TranscationId");

                    b.ToTable("V1_TranscationModes");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Vouchers.Voucher", b =>
                {
                    b.Property<string>("VoucherNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MarkedDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Particulars")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentMode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SlipNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VoucherType")
                        .HasColumnType("INTEGER");

                    b.HasKey("VoucherNumber");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PartyId");

                    b.HasIndex("StoreId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Payroll.Employee", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Vouchers.CashVoucher", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Models.Payroll.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Models.Vouchers.Party", "Partys")
                        .WithMany()
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Models.Vouchers.TranscationMode", "TranscationMode")
                        .WithMany()
                        .HasForeignKey("TranscationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Partys");

                    b.Navigation("Store");

                    b.Navigation("TranscationMode");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Vouchers.Party", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AprajitaRetails.Shared.Models.Models.Vouchers.Voucher", b =>
                {
                    b.HasOne("AprajitaRetails.Shared.Models.Models.Payroll.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Models.Vouchers.Party", "Partys")
                        .WithMany()
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AprajitaRetails.Shared.Models.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Partys");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
