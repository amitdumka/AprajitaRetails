using AprajitaRetails.BL.Vouchers;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;

namespace AprajitaRetails.Server.BL.Accounts
{

    public class LedgerHelper{

        public static List<LedgerDetail> GetLedgerDetails(ARDBContext db, string storeGroup, string storeid, string LedgerId){

            //TODO: Here we need to add banking transfer and cash vouchers, then it will be preferect 
            var ledgers=db.Voucher.Where(c=>c.StoreId==storeid && c.PartyId==LedgerId).OrderBy(c=>c.OnDate).ToList();
            var data= ledgers.Select(c=>new LedgerDetail{ OnDate=c.OnDate,VoucherType= c.VoucherType,VoucherNumber= c.VoucherNumber,
            Naration= c.Remarks,PaymentMode= c.PaymentMode, Amount=c.Amount PaymentDetails=c.PaymentDetails});
            return data;
        }

        public static void GeneratePdfLedgerReport(string PartyName, string StoreName, string StoreAddress, string filename){

        }
        public static void GenerateExcelLedgerReport(string PartyName, string StoreName, string StoreAddress, string filename){
            
        }
    }
    public class AccountHelper
    {
        /// <summary>
        /// Generate Voucher Number
        /// </summary>
        /// <param name="db"></param>
        /// <param name="type"></param>
        /// <param name="storeId"></param>
        /// <param name="onDate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add or Update Due Bill
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dailySale"></param>
        /// <param name="isNew"></param>
        public static void AddUpdateDueBill(ARDBContext db, DailySale dailySale, bool isNew)
        {
            CustomerDue due;
            if (isNew)
            {
                 due = new CustomerDue {
                EntryStatus=EntryStatus.Added, ClearingDate=null, IsReadOnly=false, OnDate=dailySale.OnDate, 
                Paid=false, InvoiceNumber=dailySale.InvoiceNumber, MarkedDeleted=false,
                StoreId=dailySale.StoreId,UserId=dailySale.UserId
                };

                if (dailySale.PayMode == PayMode.Cash)
                {
                    due.Amount = dailySale.Amount - dailySale.CashAmount; 
                }
                else
                {
                    due.Amount = dailySale.Amount -dailySale.NonCashAmount- dailySale.CashAmount;
                }
                db.CustomerDues.Add(due);
            }
            else {

                var old = db.CustomerDues.Where(c => c.InvoiceNumber == dailySale.InvoiceNumber).FirstOrDefault();
                if(old!=null && !dailySale.IsDue)
                {
                    db.CustomerDues.Remove(old);
                }
                else if (old == null)
                {
                    due = new CustomerDue
                    {
                        EntryStatus = EntryStatus.Added,
                        ClearingDate = null,
                        IsReadOnly = false,
                        OnDate = dailySale.OnDate,
                        Paid = false,
                        InvoiceNumber = dailySale.InvoiceNumber,
                        MarkedDeleted = false,
                        StoreId = dailySale.StoreId,
                        UserId = dailySale.UserId
                    };

                    if (dailySale.PayMode == PayMode.Cash)
                    {
                        due.Amount = dailySale.Amount - dailySale.CashAmount;
                    }
                    else
                    {
                        due.Amount = dailySale.Amount - dailySale.NonCashAmount - dailySale.CashAmount;
                    }
                    db.CustomerDues.Add(due);
                }
                else
                {
                    old = new CustomerDue
                    {
                        EntryStatus = EntryStatus.Updated,
                        ClearingDate = null,
                        IsReadOnly = false,
                        OnDate = dailySale.OnDate,
                        Paid = false,
                        InvoiceNumber = dailySale.InvoiceNumber,
                        MarkedDeleted = false,
                        StoreId = dailySale.StoreId,
                        UserId = dailySale.UserId
                    };

                    if (dailySale.PayMode == PayMode.Cash)
                    {
                        old.Amount = dailySale.Amount - dailySale.CashAmount;
                    }
                    else
                    {
                        old.Amount = dailySale.Amount - dailySale.NonCashAmount - dailySale.CashAmount;
                    }
                    db.CustomerDues.Update(old);
                }
            }
        }
    }
}

