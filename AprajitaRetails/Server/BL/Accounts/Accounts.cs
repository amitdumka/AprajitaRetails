using AprajitaRetails.BL.Vouchers;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.ViewModels;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using AutoMapper.Configuration.Conventions;
using Syncfusion.Blazor.Schedule.Internal;
using System.Linq;
namespace AprajitaRetails.Server.BL.Accounts
{

    public class LedgerHelper
    {

        public static IEnumerable<LedgerDetail>? GetLedgerDetails(ARDBContext db, string storeGroup, string storeid, string LedgerId)
        {

            //TODO: Here we need to add banking transfer and cash vouchers, then it will be preferect 
            var ledgers = db.Vouchers.Where(c => c.StoreId == storeid && c.PartyId == LedgerId).OrderBy(c => c.OnDate).ToList();
            var data = ledgers.Where(c=>c.VoucherType==VoucherType.Receipt).Select(c => new LedgerDetail
            {
                OnDate = c.OnDate,
                VoucherType = c.VoucherType.ToString(),
                VoucherNumber = c.VoucherNumber,
                Naration = c.Remarks+"#"+c.Particulars+"#"+c.PartyName+"#"+c.SlipNumber,
                PaymentMode = c.PaymentMode.ToString(),
                InAmount = c.Amount,OutAmount=0,
                PaymentDetails = c.PaymentDetails
            }).ToList();

             data.AddRange( ledgers.Where(c => c.VoucherType == VoucherType.Payment || c.VoucherType==VoucherType.Expense).Select(c => new LedgerDetail
            {
                OnDate = c.OnDate,
                VoucherType = c.VoucherType.ToString(),
                VoucherNumber = c.VoucherNumber,
                Naration = c.Remarks + "#" + c.Particulars + "#" + c.PartyName + "#" + c.SlipNumber,
                PaymentMode = c.PaymentMode.ToString(),
                OutAmount = c.Amount,
                InAmount = 0,
                PaymentDetails = c.PaymentDetails
            }).ToList());
            
            return  data;
        }

        
        public static void GenerateExcelLedgerReport(string PartyName, string StoreName, string StoreAddress, string filename)
        {

        }
        public static MemoryStream GeneratePdfLedgerReport(IEnumerable<LedgerDetail>?data , string PartyName, string StoreName, string StoreAddress, string filename)
        {

           

            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;
                //Add page to the PDF document.
                PdfPage page = pdfDocument.Pages.Add();
                //Create a new font.
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
                //Create a text element to draw a text in PDF page.
                PdfTextElement title = new PdfTextElement($"Ledger Book: {PartyName}", font, PdfBrushes.DarkRed);

                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Ledger Book  Report is generated for Each Store/Group", contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;
                //Draw a text to the PDF document.
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                
                    PdfTextElement stitle = new PdfTextElement($"Store: {StoreName}, \n{StoreAddress}", font, PdfBrushes.DarkRed);
                    result = stitle.Draw(page, new PointF(0, 0));

                    PdfGrid pdfGrid = new PdfGrid();
                    pdfGrid.Style.CellPadding.Left = cellMargin;
                    pdfGrid.Style.CellPadding.Right = cellMargin;

                    //Assign data source.
                    pdfGrid.DataSource = data;
                

                    //Applying built-in style to the PDF grid.
                    pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);
                    pdfGrid.Style.Font = contentFont;
                    //Draw PDF grid into the PDF page.
                    pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));
                    PdfTextElement footer = new PdfTextElement($"Ledger Summary  : Total In: {data.Sum(c=>c.InAmount)} \t Out:  {data.Sum(c => c.OutAmount)}\t Balance: {data.Sum(c => c.InAmount-c.OutAmount)}", font, PdfBrushes.DarkRed);
                    result = footer.Draw(page, new PointF(0, 0));

                    PdfTextElement s2title = new PdfTextElement($"Printer for  {StoreName}/ Date: {DateTime.Now}", font, PdfBrushes.DarkRed);
                    result = s2title.Draw(page, new PointF(0, 0));

                 

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream.
                    pdfDocument.Save(stream);
                    //Closing the PDF document.
                    pdfDocument.Close(true);
                    return stream;
                }

            }

        }
        private MemoryStream CreatePDF(int mon, int year)
        {
            //Create a new PDF document.
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;
                //Add page to the PDF document.
                PdfPage page = pdfDocument.Pages.Add();
                //Create a new font.
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
                //Create a text element to draw a text in PDF page.
                PdfTextElement title = new PdfTextElement($"Sale Report For Month: {mon}/{year}", font, PdfBrushes.DarkRed);

                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Sale Report Generated based on Sale.\n\t Report is generated for Each Store", contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;
                //Draw a text to the PDF document.
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Assign data source.
                // pdfGrid.DataSource = forecasts

                //Applying built-in style to the PDF grid.
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);
                pdfGrid.Style.Font = contentFont;
                //Draw PDF grid into the PDF page.
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream.
                    pdfDocument.Save(stream);
                    //Closing the PDF document.
                    pdfDocument.Close(true);
                    return stream;
                }

            }

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

                var old = db.CustomerDues.Where(c => c.InvoiceNumber == dailySale.InvoiceNumber).FirstOrDefault();
                if (old != null && !dailySale.IsDue)
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

