using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;

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
    }
}
