using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace AprajitaRetails.Server.BL.Reports.Fins
{

    public class FinReports
    {
        //TODO: make this filter of data in daily , monthly and yearly mode . 
        //it will reduces the code and make efficent and constitant 



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
                Location = storeLocation,
                DayBooks = new List<DayBook>()
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

            return returndata;
        }

        public static MonthViewReturn GetMonthView(ARDBContext db, DateTime? ondate, string storecode, ClientReportMode mode = ClientReportMode.Store, bool cashvoucher = false)
        {
            var applcientid = "";
            var storegroupid = "";
            ondate = ondate ?? DateTime.Today;
            var count = 0;
            string storeLocation = "";
            List<string> StoreList = new List<string>();

            // If Client wise report of an Client 
            if (mode == ClientReportMode.Client)
            {
                var client = db.AppClients.Find(storecode);
                storeLocation = $"{client.ClientName},{client.City}";
                applcientid = client.AppClientId.ToString();
                var sgs = db.StoreGroups.Where(c => c.AppClientId == client.AppClientId).Select(c => c.StoreGroupId).ToList();

                foreach (var item in sgs)
                {
                    var scs = db.Stores.Where(c => c.StoreGroupId == item).Select(c => c.StoreCode).ToList();
                    StoreList.AddRange(scs);
                }

            }
            // Store Group Wise Report, report of an group 
            if (mode == ClientReportMode.StoreGroup)
            {
                var sg = db.StoreGroups.Include(s => s.AppClient).Where(c => c.StoreGroupId == storecode).FirstOrDefault();
                storeLocation = $"{sg.AppClient.ClientName}, {sg.AppClient.City}, Group[{sg.GroupName}]";
                applcientid = sg.AppClientId.ToString();
                storegroupid = sg.StoreGroupId;

                var scs = db.Stores.Where(c => c.StoreGroupId == sg.StoreGroupId).Select(c => c.StoreCode).ToList();
                StoreList.AddRange(scs);

            }

            // Report of an Store 
            if (mode == ClientReportMode.Store)
            {
                var st = db.Stores.Find(storecode);
                storeLocation = $"{st.StoreName},{st.City}";
                StoreList.Add(storecode);
            }

            MonthViewReturn returnData = new MonthViewReturn
            {
                FilterMode = storecode,
                Location = storeLocation,
                Mode = mode,
                OnDate = ondate.Value,
                MonthViews = new List<MonthView>()

            };

            //TODO: need to implement to get paymode from Sale Invoice
            //and for purchase it will be bank transfer
            //TODO: need to do mapping between paymode and payment mode. 
            //TODO: need to convert into single payment mode in entire system 

            foreach (var scode in StoreList)
            {
                //Incomes.
                //Sales
                var sales = db.ProductSales.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == scode)
               .Select(c => new MonthView
               {
                   Id = (count),
                   OnDate = c.OnDate,
                   IsExpense = false,
                   PayMode = PayMode.Others,
                   IsIncome = true,
                   IsReceipt = true,
                   VoucherType = "Sales",
                   StoreCode = c.StoreId,
                   VoucherNumber = c.InvoiceNo,
                   InAmount = c.TotalPrice,
                   Location = storeLocation,
                   OutAmount = 0,
                   ParticularsName = $"Sale Inv:{c.InvoiceNo}",
                   Naration = $"Sale Inv{c.InvoiceNo}, Paid={c.Paid}, Qty={c.TotalQty}, Tax={c.TotalTaxAmount}, Discount={c.TotalDiscountAmount}"
               })
               .ToList();
                returnData.MonthViews.AddRange(sales);
                // purchases. 
                var purchases = db.ProductPurchases.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode)
                    .Select(c => new MonthView
                    {
                        Id = (count),
                        IsExpense = false,
                        IsIncome = false,
                        IsReceipt = false,
                        OnDate = c.OnDate,
                        VoucherType = "Purchases",
                        StoreCode = c.StoreId,
                        PayMode = PayMode.Cheque,
                        VoucherNumber = c.InvoiceNo,
                        InAmount = 0,
                        Location = storeLocation,
                        OutAmount = c.TotalAmount,
                        ParticularsName = $"Purchase Inv:{c.InvoiceNo}",
                        Naration = $"Type={c.InvoiceType}, Warehouse={c.Warehouse}, Paid={c.Paid}, Qty={c.TotalQty}, Tax={c.TaxAmount}, Discount={c.DiscountAmount}, InwardDate={c.InwardDate}, Indward No={c.InwardNumber}"
                    })
                    .ToList();
                returnData.MonthViews.AddRange(purchases);
                //Reciepts
                var rcpvoucherers = db.Vouchers.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode && (c.VoucherType == VoucherType.Receipt))
               .Select(c => new MonthView
               {
                   Id = count,
                   IsExpense = false,
                   IsIncome = false,
                   IsReceipt = true,
                   OnDate = c.OnDate,
                   StoreCode = c.StoreId,
                   Location = storeLocation,
                   PayMode = (PayMode)c.PaymentMode,
                   VoucherNumber = c.VoucherNumber,
                   VoucherType = c.VoucherType.ToString(),
                   InAmount = c.Amount,
                   OutAmount = 0,

                   ParticularsName = $"{c.Particulars}",
                   Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Payment={c.PaymentMode.ToString()},{c.PaymentDetails}"
               })
               .ToList();
                returnData.MonthViews.AddRange(rcpvoucherers);

                //StaffAdv Reciepts
                var advsalary = db.StaffAdvanceReceipts.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode).Select(c => new MonthView
                {
                    Id = count,
                    StoreCode = c.StoreId,
                    PayMode = c.PayMode,
                    IsExpense = false,
                    IsIncome = false,
                    IsReceipt = true,
                    OnDate = c.OnDate,
                    Location = storeLocation,
                    VoucherNumber = c.StaffAdvanceReceiptId,
                    VoucherType = "Receipt(Staff)",
                    InAmount = c.Amount,
                    OutAmount = 0,

                    ParticularsName = $"{c.Employee.StaffName}",
                    Naration = $"SlipNo:{c.Employee.StaffName}, Details= {c.Details}, PayMode= {c.PayMode.ToString()}"
                }).ToList();
                returnData.MonthViews.AddRange(advsalary);
                //Dues Recovery

                var recovery = db.DuesRecovery.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode).Select(c => new MonthView
                {
                    Id = count,
                    IsExpense = false,
                    OnDate = c.OnDate,
                    StoreCode = c.StoreId,
                    IsIncome = false,
                    IsReceipt = true,
                    Location = storeLocation,
                    PayMode = c.PayMode,
                    VoucherNumber = c.InvoiceNumber,
                    VoucherType = "Receipt(Dues)",
                    InAmount = c.Amount,
                    OutAmount = 0,
                    ParticularsName = $"{c.InvoiceNumber}",
                    Naration = $"Inv No:{c.InvoiceNumber}, PayMode= {c.PayMode.ToString()}, Due Amount= {c.Due}, Remarks{c.Remarks}"
                }).ToList();
                returnData.MonthViews.AddRange(recovery);
                //CashReceipts
                if (cashvoucher)
                {
                    var cashrcpvoucherers = db.CashVouchers.Include(c => c.TransactionMode).Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode && (c.VoucherType == VoucherType.CashReceipt))
                      .Select(c => new MonthView
                      {
                          Id = count,
                          IsIncome = false,
                          IsReceipt = true,
                          IsExpense = false,
                          OnDate = c.OnDate,
                          Location = storeLocation,
                          StoreCode = c.StoreId,
                          PayMode = PayMode.Cash,
                          VoucherNumber = c.VoucherNumber,
                          VoucherType = c.VoucherType.ToString(),
                          InAmount = c.Amount,
                          OutAmount = 0,

                          ParticularsName = $"{c.Particulars}",
                          Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Trnascation= {c.TransactionMode.TransactionName}"
                      })
                      .ToList();
                    returnData.MonthViews.AddRange(cashrcpvoucherers);
                }
                //Expenses
                //Expense Vouchers
                var Expvoucherers = db.Vouchers.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode && (c.VoucherType == VoucherType.Payment || c.VoucherType == VoucherType.Expense))
                .Select(c => new MonthView
                {
                    Id = count,
                    IsExpense = true,
                    OnDate = c.OnDate,
                    StoreCode = c.StoreId,
                    PayMode = (PayMode)c.PaymentMode, 
                    Location = storeLocation,
                    VoucherNumber = c.VoucherNumber,
                    VoucherType = c.VoucherType.ToString(),
                    OutAmount = c.Amount,
                    InAmount = 0,
                    ParticularsName = $"{c.Particulars}",
                    Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Payment={c.PaymentMode.ToString()},{c.PaymentDetails}"
                })
                .ToList();
                returnData.MonthViews.AddRange(Expvoucherers);

                //Salary Payments
                var salarypayments = db.SalaryPayments.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode).Select(c => new MonthView
                {
                    Id = count,
                    IsExpense = true,
                    IsIncome = false,
                    IsReceipt = false,
                    StoreCode = c.StoreId,
                    OnDate = c.OnDate,
                    PayMode = c.PayMode,
                    Location = storeLocation,
                    VoucherNumber = c.SalaryPaymentId,
                    VoucherType = "Payment(Staff)",
                    OutAmount = c.Amount,
                    InAmount = 0,

                    ParticularsName = $"{c.Employee.StaffName}",
                    Naration = $"SlipNo:{c.Employee.StaffName}, Details= {c.Details}, PayMode= {c.PayMode.ToString()}, salary Month{c.SalaryMonth}, SalComp={c.SalaryComponet}"
                }).ToList();

                returnData.MonthViews.AddRange(salarypayments);
                //Dues
                var dues = db.CustomerDues.Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode).Select(c => new MonthView
                {
                    Id = count,StoreCode=c.StoreId, PayMode=PayMode.Cash, OnDate = c.OnDate,
                    Location = storeLocation,
                    VoucherNumber = c.InvoiceNumber,
                    VoucherType = "Customer Dues",
                    InAmount = 0,
                    OutAmount = c.Amount,

                    ParticularsName = $"{c.InvoiceNumber}",
                    Naration = $"Inv No:{c.InvoiceNumber}, ClearingDate= {c.ClearingDate}, Paid= {c.Paid}"
                }).ToList();
                returnData.MonthViews.AddRange(dues);
                //CashExpenses
                if (cashvoucher)
                {
                    var cashExpvoucherers = db.CashVouchers.Include(c => c.TransactionMode).Where(c => c.OnDate.Year == ondate.Value.Year && c.OnDate.Month == ondate.Value.Month && c.StoreId == storecode && (c.VoucherType == VoucherType.CashPayment))
                    .Select(c => new MonthView
                    {
                        Id = count,
                        IsReceipt = false,
                        IsExpense = true,
                        IsIncome = false,
                        OnDate = c.OnDate,
                        StoreCode = c.StoreId,
                        PayMode = PayMode.Cash,
                        Location = storeLocation,
                        VoucherNumber = c.VoucherNumber,
                        VoucherType = c.VoucherType.ToString(),
                        OutAmount = c.Amount,
                        InAmount = 0,
                        ParticularsName = $"{c.Particulars}",
                        Naration = $"SlipNo:{c.SlipNumber}, PartyName= {c.PartyName}, Trnascation={c.TransactionMode.TransactionName}"
                    })
                    .ToList();
                    returnData.MonthViews.AddRange(cashExpvoucherers);
                }
            }

            return returnData;
        }
    }


}
