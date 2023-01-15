using AprajitaRetails.Shared.Models.Banking;
using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Data
{
    public class ARDBContext : DbContext
    {
        public ARDBContext(DbContextOptions<ARDBContext> options)
        : base(options)
        {
        }

        public DbSet<Voucher> Vouchers { get; set; }

        public DbSet<CashVoucher> CashVouchers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<TransactionMode> TransactionModes { get; set; }
        public DbSet<LedgerGroup> LedgerGroups { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<LedgerMaster> LedgerMasters { get; set; }
        public DbSet<PettyCashSheet> PettyCashSheets { get; set; }
        public DbSet<CashDetail> CashDetails { get; set; }

        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<SalaryPayment> SalaryPayments { get; set; }

        public DbSet<MonthlyAttendance> MonthlyAttendances { get; set; }

        public DbSet<Salary> Salaries { get; set; }
        public DbSet<StaffAdvanceReceipt> StaffAdvanceReceipts { get; set; }
        public DbSet<PaySlip> PaySlips { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<SalaryLedger> SalaryLedgers { get; set; }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<VendorBankAccount> VendorBankAccounts { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankAccountList> AccountLists { get; set; }

        public DbSet<BankTransaction> BankTransactions { get; set; }

        public DbSet<ChequeBook> ChequeBooks { get; set; }
        public DbSet<ChequeIssued> ChequeIssued { get; set; }
        public DbSet<ChequeLog> ChequeLogs { get; set; }
        //Daily Sale

        public DbSet<DailySale> DailySales { get; set; }
        public DbSet<CustomerDue> CustomerDues { get; set; }
        public DbSet<DueRecovery> DuesRecovery { get; set; }

        public DbSet<EDCTerminal> EDCTerminals { get; set; }

        //Inventory
        public DbSet<ProductItem> ProductItems { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        //Purchase
        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<ProductPurchase> ProductPurchases { get; set; }

        //Sale
        public DbSet<CustomerSale> CustomerSales { get; set; }

        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SalePaymentDetail> SalePaymentDetails { get; set; }
        public DbSet<CardPaymentDetail> CardPaymentDetails { get; set; }

        //Stock
        public DbSet<Stock> Stocks { get; set; }
    }
}