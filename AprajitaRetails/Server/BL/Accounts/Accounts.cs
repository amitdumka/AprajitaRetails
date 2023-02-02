using AprajitaRetails.BL.Vouchers;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;

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

        public static void AddUpdateDueBill(ARDBContext db, DailySale dailySale, bool isNew)
        {
            if (isNew) {
                CustomerDue due = new CustomerDue {
                EntryStatus=EntryStatus.Added, ClearingDate=null, IsReadOnly=false, OnDate=dailySale.OnDate, 
                Paid=false, InvoiceNumber=dailySale.InvoiceNumber, MarkedDeleted=false,
                StoreId=dailySale.StoreId,UserId=dailySale.UserId
                };
                if (dailySale.PayMode == PayMode.Cash)
                {
                    due.Amount = dailySale.Amount - dailySale.CashAmount; 
                }
            }
            else { }
        }
    }
}

