using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Bases;

namespace AprajitaRetails.Server.Data
{
    public class ARDBContext: DbContext
    {
        public ARDBContext(DbContextOptions<ARDBContext> options)
        : base(options)
        {
        }
        //public DbSet<AprajitaRetails.Shared.Models.Vouchers.Voucher> Voucher { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<CashVoucher> CashVouchers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<TransactionMode> TransactionModes { get; set; }
        public DbSet<LedgerGroup> LedgerGroups { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<LedgerMaster> LedgerMasters { get; set; }
        public DbSet<PettyCashSheet> PettyCashSheets { get; set; }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<AprajitaRetails.Shared.Models.Payroll.Attendance> Attendance { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.SalaryPayment> SalaryPayment { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Stores.Salesman> Salesman { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.MonthlyAttendance> MonthlyAttendance { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Bases.Contact> Contact { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Stores.Customer> Customer { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Stores.CashDetail> CashDetail { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.EmployeeDetails> EmployeeDetails { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.Salary> Salary { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.StaffAdvanceReceipt> StaffAdvanceReceipt { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.PaySlip> PaySlip { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.TimeSheet> TimeSheet { get; set; } = default!;
        public DbSet<AprajitaRetails.Shared.Models.Payroll.SalaryLedger> SalaryLedger { get; set; } = default!;
    }
}
