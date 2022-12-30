using System.IO;
using AprajitaRetails.Shared.Models.Models.Payroll;
using AprajitaRetails.Shared.Models.Models.Stores;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace AprajitaRetails.UI.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<CashVoucher> CashVouchers { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<TranscationMode> TranscationModes { get; set; }
    public DbSet<LedgerGroup> LedgerGroups { get; set; }
    public DbSet<Party> Parties { get; set; }
    public DbSet<LedgerMaster> LedgerMasters { get; set; }
    public DbSet<PettyCashSheet> PettyCashSheets { get; set; }


    public DbSet<Employee> Employees { get; set; }
    public DbSet<Store> Stores { get; set; }
}

