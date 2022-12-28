using AprajitaRetails.Shared.Models.Models.Vouchers;
using Microsoft.EntityFrameworkCore;

namespace AKS.Databases
{
    public class AccountsDBContext:DbContext
    {
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<CashVoucher> CashVouchers { get;set; }
        public AccountsDBContext(DbContextOptions<AccountsDBContext> options)
           : base(options)
        {
        }

    }

    public class PayrollDbContext : DbContext { }
    public class InventoryDbContext : DbContext { }
}