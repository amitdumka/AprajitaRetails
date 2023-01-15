using AprajitaRetails.BL.Vouchers;
using AprajitaRetails.Server.Data;

namespace AprajitaRetails.Server.BL.Accounts
{
    public class AccountHelper
    {
        public static string VoucherNumberGenerator(ARDBContext db, VoucherType type, string storeId, DateTime onDate)
        {
            int count = 0;
            if (type == VoucherType.CashReceipt || type == VoucherType.CashPayment)
            {
                count = db.CashVouchers.Where(c => c.StoreId == storeId && c.OnDate.Year == onDate.Year && c.OnDate.Month == onDate.Month && c.VoucherType == type).Count() + 1;
            }
            else
            {
                count = db.Vouchers.Where(c => c.StoreId == storeId && c.OnDate.Year == onDate.Year && c.OnDate.Month == onDate.Month && c.VoucherType == type).Count() + 1;
            }
            return VoucherManager.GenerateVoucherNumber(type, storeId, onDate, count);

        }
    }
}

