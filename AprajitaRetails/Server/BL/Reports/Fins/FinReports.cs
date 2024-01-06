using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.PerformanceData;

namespace AprajitaRetails.Server.BL.Reports.Fins
{
    public class FinReports
    {
        public static DayBookReturn GetDayView(ARDBContext db, DateTime? ondate, string storecode, bool cashvouchers = false)
        {
            // if ondate is null
            ondate = ondate ?? DateTime.Today; //;!= null ?ondate: DateTime.Today;
            var st = db.Stores.Find(storecode);
            var storeLocation = $"{st.StoreName},{st.City}";
            var count = 0;
            DayBookReturn returndata = new DayBookReturn
            {
                OnDate = ondate,
                StoreCode = storecode,
                Location = storeLocation, DayBooks= new List<DayBook>()
            };
            // Sales
            var sales = db.ProductSales.Where(c => c.OnDate == ondate && c.StoreId == storecode)
                .Select(c => new DayBook
                {
                    Id = (count),
                    VoucherType = "Sales",
                    VoucherNumber = c.InvoiceNo,
                    InAmount = c.TotalPrice,
                    Location = storeLocation,
                    OutAmount = 0,
                    ParticularsName = $"Sale Inv:{c.InvoiceNo}",
                    Naration = $"Sale Inv{c.InvoiceNo}, Paid={c.Paid}, Qty={c.TotalQty}, Tax={c.TotalTaxAmount}, Discount={c.TotalDiscountAmount}"
                })
                .ToList();
            // purchases. 
            var purchases = db.ProductPurchases.Where(c => c.OnDate == ondate && c.StoreId == storecode)
                .Select(c => new DayBook
                {
                    Id = (count),
                    VoucherType = "Purchases",
                    VoucherNumber = c.InvoiceNo,
                    InAmount = 0,
                    Location = storeLocation,
                    OutAmount = c.TotalAmount,
                    ParticularsName = $"Purchase Inv:{c.InvoiceNo}",
                    Naration = $"Type={c.InvoiceType}, Warehouse={c.Warehouse}, Paid={c.Paid}, Qty={c.TotalQty}, Tax={c.TaxAmount}, Discount={c.DiscountAmount}, InwardDate={c.InwardDate}, Indward No={c.InwardNumber}"
                })
                .ToList();
            // vouchers
            var Expvoucherers = db.Vouchers.Where(c => c.OnDate == ondate && c.StoreId == storecode && (c.VoucherType == VoucherType.Payment || c.VoucherType == VoucherType.Expense))
                .Select(c => new DayBook
                {
                    Id = count,
                    Location = storeLocation,
                    VoucherNumber = c.VoucherNumber,
                    VoucherType = c.VoucherType.ToString(),
                    OutAmount = c.Amount,
                    InAmount = 0,
                    ParticularsName = $"{c.Particulars}",
                    Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Payment={c.PaymentMode.ToString()},{c.PaymentDetails}"
                })
                .ToList();
            var rcpvoucherers = db.Vouchers.Where(c => c.OnDate == ondate && c.StoreId == storecode && (c.VoucherType == VoucherType.Receipt))
               .Select(c => new DayBook
               {
                   Id = count,
                   Location = storeLocation,
                   VoucherNumber = c.VoucherNumber,
                   VoucherType = c.VoucherType.ToString(),
                   InAmount = c.Amount,
                   OutAmount = 0,

                   ParticularsName = $"{c.Particulars}",
                   Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Payment={c.PaymentMode.ToString()},{c.PaymentDetails}"
               })
               .ToList();
          
            var salarypayments = db.SalaryPayments.Where(c => c.OnDate == ondate && c.StoreId == storecode).Select(c => new DayBook
            {
                Id = count,
                Location = storeLocation,
                VoucherNumber = c.SalaryPaymentId,
                VoucherType = "Payment(Staff)",
                OutAmount = c.Amount,
                InAmount = 0,

                ParticularsName = $"{c.Employee.StaffName}",
                Naration = $"SlipNo:{c.Employee.StaffName}, Details= {c.Details}, PayMode= {c.PayMode.ToString()}, salary Month{c.SalaryMonth}, SalComp={c.SalaryComponet}"
            }).ToList();

            var advsalary = db.StaffAdvanceReceipts.Where(c => c.OnDate == ondate && c.StoreId == storecode).Select(c => new DayBook
            {
                Id = count,
                Location = storeLocation,
                VoucherNumber = c.StaffAdvanceReceiptId,
                VoucherType = "Receipt(Staff)",
                InAmount = c.Amount,
                OutAmount = 0,

                ParticularsName = $"{c.Employee.StaffName}",
                Naration = $"SlipNo:{c.Employee.StaffName}, Details= {c.Details}, PayMode= {c.PayMode.ToString()}"
            }).ToList();

            var dues = db.CustomerDues.Where(c => c.OnDate == ondate && c.StoreId == storecode).Select(c => new DayBook
            {
                Id = count,
                Location = storeLocation,
                VoucherNumber = c.InvoiceNumber,
                VoucherType = "Customer Dues",
                InAmount = 0,
                OutAmount = c.Amount,

                ParticularsName = $"{c.InvoiceNumber}",
                Naration = $"Inv No:{c.InvoiceNumber}, ClearingDate= {c.ClearingDate}, Paid= {c.Paid}"
            }).ToList();

            var recovery = db.DuesRecovery.Where(c => c.OnDate == ondate && c.StoreId == storecode).Select(c => new DayBook
            {
                Id = count,
                Location = storeLocation,
                VoucherNumber = c.InvoiceNumber,
                VoucherType = "Receipt(Dues)",
                InAmount = c.Amount,
                OutAmount = 0,

                ParticularsName = $"{c.InvoiceNumber}",
                Naration = $"Inv No:{c.InvoiceNumber}, PayMode= {c.PayMode.ToString()}, Due Amount= {c.Due}, Remarks{c.Remarks}"
            }).ToList();
            //TODO: Consider for Sale payment of different type in same and other invs  and sale return . 
            returndata.DayBooks.AddRange(sales);
            returndata.DayBooks.AddRange(purchases);
            returndata.DayBooks.AddRange(recovery);
            returndata.DayBooks.AddRange(dues);
            returndata.DayBooks.AddRange(advsalary);
            returndata.DayBooks.AddRange(salarypayments);
            returndata.DayBooks.AddRange(rcpvoucherers);
            returndata.DayBooks.AddRange(Expvoucherers);
           
            if (cashvouchers)
            {
                var cashExpvoucherers = db.CashVouchers.Include(c => c.TransactionMode).Where(c => c.OnDate == ondate && c.StoreId == storecode && (c.VoucherType == VoucherType.CashPayment))
                .Select(c => new DayBook
                {
                    Id = count,
                    Location = storeLocation,
                    VoucherNumber = c.VoucherNumber,
                    VoucherType = c.VoucherType.ToString(),
                    OutAmount = c.Amount,
                    InAmount = 0,
                    ParticularsName = $"{c.Particulars}",
                    Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Trnascation={c.TransactionMode.TransactionName}"
                })
                .ToList();
                var cashrcpvoucherers = db.CashVouchers.Include(c => c.TransactionMode).Where(c => c.OnDate == ondate && c.StoreId == storecode && (c.VoucherType == VoucherType.CashReceipt))
                   .Select(c => new DayBook
                   {
                       Id = count,
                       Location = storeLocation,
                       VoucherNumber = c.VoucherNumber,
                       VoucherType = c.VoucherType.ToString(),
                       InAmount = c.Amount,
                       OutAmount = 0,

                       ParticularsName = $"{c.Particulars}",
                       Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Trnascation= {c.TransactionMode.TransactionName}"
                   })
                   .ToList();
                returndata.DayBooks.AddRange(cashExpvoucherers);
                returndata.DayBooks.AddRange(cashrcpvoucherers);
            }
            
            return  returndata;
        }
    }


}
