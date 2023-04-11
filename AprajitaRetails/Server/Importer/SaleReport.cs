﻿using System.Data;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Drawing;
using Syncfusion.XlsIO;

namespace AprajitaRetails.Server.Importer
{
    public class SaleReportVM
    {
        public InvoiceType InvoiceType { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public string Product { get; set; }
        public string Barcode { get; set; }
        public decimal BilledQty { get; set; }
        public Unit Unit { get; set; }
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public TaxType TaxType { get; set; }
        public decimal BasicAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
        public decimal BasicValue { get; set; }
        public decimal TaxValue { get; set; }
        public decimal RoundOff { get; set; }
        public decimal BillAmount { get; set; }
    }
    public class SaleReport
    {
        public static MemoryStream GenerateSaleReport(ARDBContext db, string storecode, int month, int year)//, string path)
        {
            var dataList = db.SaleItems.Include(c => c.ProductSale).Include(c => c.ProductItem).
                Where(c => c.ProductSale.OnDate.Year == year && c.ProductSale.OnDate.Month == month && c.ProductSale.StoreId == storecode)
                .OrderBy(c => c.ProductSale.OnDate).ThenBy(c => c.InvoiceType).ThenBy(c => c.InvoiceNumber)
                .Select(c => new SaleReportVM
                {
                    InvoiceType = c.InvoiceType,
                    Date = c.ProductSale.OnDate,
                    InvoiceNumber = c.InvoiceNumber,
                    Product = c.ProductItem.Name,
                    Barcode = c.Barcode,
                    BilledQty =
                    c.BilledQty,
                    Unit =
                    c.Unit,
                    MRP =
                    c.ProductItem.MRP,
                    Discount =
                    c.DiscountAmount,
                    TaxType =
                    c.TaxType,
                    BasicAmount =
                    c.BasicAmount,
                    Tax =
                    c.TaxAmount,
                    Amount =
                    c.Value,
                    RoundOff = c.ProductSale.RoundOff,
                    BasicValue = c.ProductSale.TotalBasicAmount,
                    TaxValue = c.ProductSale.TotalTaxAmount,
                  BillAmount =
                    c.ProductSale.TotalPrice
                })
                .ToList();
            var invList = dataList.GroupBy(c => c.InvoiceNumber).ToList();
            int i = 0;
            List<SaleReportVM> SaleList = new List<SaleReportVM>();
            foreach (var inv in invList)
            {
                var inSum = dataList.Where(c => c.InvoiceNumber == inv.Key).ToList();
                 i = 0;
                foreach(var itm in inSum)
                {
                    if (i > 0)
                    {
                        itm.BillAmount = itm.TaxValue = itm.RoundOff = 0;
                    }
                    i++;
                }
                SaleList.AddRange(inSum);
            }


            return CreateExcelFile(SaleList);
        }

        public static MemoryStream CreateExcelFile(List<SaleReportVM> dt)
        {
            string Period = "Jan-March/2023";
            DateTime SDate = DateTime.Today.Date;
            DateTime EDate = DateTime.Today.Date;

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Create a workbook
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Disable gridlines in the worksheet
                worksheet.IsGridLinesVisible = false;

                //Enter values to the cells from A3 to A5
                worksheet.Range["D2"].Text = "Aprajita Retails";
                worksheet.Range["D3"].Text = "Bhagalpur Road, Dumka";
                worksheet.Range["D5"].Text = "GSTIN: 20AJHPA7396P";

                worksheet.Range["B7"].Text = "Period";
                worksheet.Range["C7"].Text = Period;

                //Make the text bold
                worksheet.Range["D2:D5"].CellStyle.Font.Bold = true;

                //Merge cells
                worksheet.Range["D9:F9"].Merge();

                //Enter text to the cell D1 and apply formatting
                worksheet.Range["D9"].Text = "GST Sale Report";
                worksheet.Range["D9"].CellStyle.Font.Bold = true;
                worksheet.Range["D9"].CellStyle.Font.RGBColor = Color.FromArgb(42, 118, 189);
                worksheet.Range["D9"].CellStyle.Font.Size = 14;

                //Apply alignment in the cell D1
                worksheet.Range["D9"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                worksheet.Range["D9"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;
                //Enter values to the cells from D5 to E8

                worksheet.Range["D10:e10"].Merge();
                worksheet.Range["F10:G10"].Merge();
                worksheet.Range["I10:J10"].Merge();
                worksheet.Range["D10"].Text = "Sale Date From";
                worksheet.Range["F10"].DateTime = SDate.Date;
                worksheet.Range["H10"].Text = "To";
                worksheet.Range["I10"].DateTime = EDate.Date;

                DataTable table = DocIO.ToDataTable(dt);

                int rows = worksheet.ImportDataTable(table, true, 11, 1, true);

                worksheet.Range[$"A11:P{11 + rows}"].CellStyle.Font.Bold = true;
                worksheet.Range[$"A11:P{11 + rows}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range[$"A11:P{11 + rows}"].BorderAround();
                worksheet.Range[$"A11:P{11 + rows}"].BorderInside();
                worksheet.Range[$"A11:P{11 + rows}"].AutofitColumns();

                 int lr = 11 + 2 + rows;
               
                worksheet.Range[$"F{lr}"].Number=worksheet.Range[$"F11:F{12+rows}"].Sum();
                worksheet.Range[$"i{lr}"].Number = worksheet.Range[$"i11:i{12 + rows}"].Sum();
                worksheet.Range[$"k{lr}"].Number = worksheet.Range[$"k11:k{12 + rows}"].Sum();
                worksheet.Range[$"l{lr}"].Number = worksheet.Range[$"l11:l{12 + rows}"].Sum();

                worksheet.Range[$"m{lr}"].Number = worksheet.Range[$"m11:m{12 + rows}"].Sum();
                worksheet.Range[$"n{lr}"].Number = worksheet.Range[$"n11:l{12 + rows}"].Sum();
                worksheet.Range[$"o{lr}"].Number = worksheet.Range[$"o11:o{12 + rows}"].Sum();
                worksheet.Range[$"p{lr}"].Number = worksheet.Range[$"p11:p{12 + rows}"].Sum();
                worksheet.Range[$"q{lr}"].Number = worksheet.Range[$"q11:q{12 + rows}"].Sum();
                //Save the document as a stream and retrun the stream.
                MemoryStream stream = new MemoryStream();
                //Save the created Excel document to MemoryStream
                workbook.SaveAs(stream);
                return stream;


            }
        }

        public static MemoryStream CreateExcelFile(DataTable dt)
        {
            string Period = "Jan-March/2023";
            DateTime SDate = DateTime.Today.Date;
            DateTime EDate = DateTime.Today.Date;

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Create a workbook
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Disable gridlines in the worksheet
                worksheet.IsGridLinesVisible = false;

                //Enter values to the cells from A3 to A5
                worksheet.Range["D2"].Text = "Aprajita Retails";
                worksheet.Range["D3"].Text = "Bhagalpur Road, Dumka";
                worksheet.Range["D5"].Text = "GSTIN: 20AJHPA7396P";

                worksheet.Range["B7"].Text = "Period";
                worksheet.Range["C7"].Text = Period;

                //Make the text bold
                worksheet.Range["D2:D5"].CellStyle.Font.Bold = true;

                //Merge cells
                worksheet.Range["D9:F9"].Merge();

                //Enter text to the cell D1 and apply formatting
                worksheet.Range["D9"].Text = "GST Sale Report";
                worksheet.Range["D9"].CellStyle.Font.Bold = true;
                worksheet.Range["D9"].CellStyle.Font.RGBColor = Color.FromArgb(42, 118, 189);
                worksheet.Range["D9"].CellStyle.Font.Size = 14;

                //Apply alignment in the cell D1
                worksheet.Range["D9"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                worksheet.Range["D9"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;
                //Enter values to the cells from D5 to E8

                worksheet.Range["D10:e10"].Merge();
                worksheet.Range["F10:G10"].Merge();
                worksheet.Range["I10:J10"].Merge();
                worksheet.Range["D10"].Text = "Sale Date From";
                worksheet.Range["F10"].DateTime = SDate.Date;
                worksheet.Range["H10"].Text = "To";
                worksheet.Range["I10"].DateTime = EDate.Date;

                dt.Columns.Remove("Id");
                dt.Columns.Remove("Adjusted");
                dt.Columns.Remove("FreeQty");
                dt.Columns.Remove("LastPcs");
                dt.Columns.Remove("ProductSale");
                dt.Columns.Remove("ProductItem");

                int rows = worksheet.ImportDataTable(dt, true, 11, 1, true);
                worksheet.Range[$"A11:P{11 + rows}"].CellStyle.Font.Bold = true;
                worksheet.Range[$"A11:P{11 + rows}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range[$"A11:P{11 + rows}"].BorderAround();
                worksheet.Range[$"A11:P{11 + rows}"].BorderInside();
                worksheet.Range[$"A11:P{11 + rows}"].AutofitColumns();

                // int lr = 11 + 2 + rows;
                // worksheet.Range[$"D{lr}"].SubTotal(4,ConsolidationFunction.Sum,) ;

                //Save the document as a stream and retrun the stream.
                MemoryStream stream = new MemoryStream();
                //Save the created Excel document to MemoryStream
                workbook.SaveAs(stream);
                return stream;


            }
        }

        public static bool GenerateSaleInv(string json, ARDBContext db)
        {
            var sales = DocIO.JsonToObject<NewSale>(json);

            // List<ProductSale> pSale = new List<ProductSale>();
            List<SaleItem> saleItems = new List<SaleItem>();


            try
            {
                foreach (var im in sales)
                {
                    if (im.InvoiceNo != null)
                    {
                        if (im.InvoiceNo.Contains(@"/")) im.InvoiceNo = im.InvoiceNo.Replace(@"/", "-");

                        SaleItem si = new SaleItem
                        {
                            Adjusted = false,
                            Barcode = im.Barcode,
                            BilledQty = (decimal)im.QTY.Value,
                            DiscountAmount = (decimal)im.Discount.Value / 100,
                            FreeQty = 0,
                            InvoiceNumber = im.InvoiceNo,
                            LastPcs = false,
                            Value = (decimal)im.LineTotal.Value,
                            TaxType = TaxType.GST,
                            Unit = Unit.NoUnit,
                            InvoiceType = (decimal)im.QTY.Value > 0 ? InvoiceType.Sales : InvoiceType.SalesReturn,
                            BasicAmount = 0,
                            TaxAmount = 0,
                        };
                        si.Unit = (decimal)im.QTY % 1 == 0 ? Unit.Meters : Unit.NoUnit;
                        if (si.Unit == Unit.Meters)
                        {
                            si.BasicAmount = DocIO.GetBasicAmt(si.Value, Unit.Meters);
                            si.TaxAmount = si.Value - si.BasicAmount;
                        }
                        saleItems.Add(si);
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            // Adding Unit and tax details 

            var pis = db.ProductItems.Select(c => new { c.Barcode, c.Unit, c.MRP }).ToList();

            foreach (var im in saleItems)
            {
                var s = pis.Where(c => c.Barcode == im.Barcode).FirstOrDefault();
                if (s != null)
                {
                    im.Unit = s.Unit;
                    im.DiscountAmount = s.MRP * im.DiscountAmount;
                    if (im.Unit == Unit.Meters)
                    {
                        im.BasicAmount = DocIO.GetBasicAmt(im.Value, Unit.Meters);
                        im.TaxAmount = im.Value - im.BasicAmount;
                    }
                }
                else
                {
                    var x = sales.Where(c => c.Barcode == im.Barcode && c.InvoiceNo == im.InvoiceNumber).First();
                    ProductItem p = new ProductItem
                    {
                        HSNCode = "Missing#",
                        Description = "Missing#",
                        BrandCode = "NOB",
                        Barcode = im.Barcode,
                        MRP = x.MRP.Value,
                        Name = "#MISSINGINFO",
                        Unit = Unit.NoUnit,
                        TaxType = TaxType.GST,
                        SubCategory = "Promo",
                        StyleCode = "Missing#",
                        Size = Size.NOTVALID,
                        ProductTypeId = "PT00013",
                        ProductCategory = ProductCategory.Others
                    };
                    Stock stk = new Stock
                    {
                        Barcode = x.Barcode,
                        CostPrice = 0,
                        EntryStatus = EntryStatus.Rejected,
                        HoldQty = 0,
                        IsReadOnly = false,
                        MarkedDeleted = false,
                        MRP = x.MRP.Value,
                        MultiPrice = false,
                        PurchaseQty = 0,
                        SoldQty = 0,
                        StoreId = "ARD",
                        Unit = Unit.NoUnit,
                        UserId = "AIT",

                    };
                    // Productitem as Reject then confirm when item is added.
                    im.DiscountAmount = x.MRP.Value * im.DiscountAmount;
                    if (im.Unit == Unit.Meters)
                    {
                        im.BasicAmount = DocIO.GetBasicAmt(im.Value, Unit.Meters);
                        im.TaxAmount = im.Value - im.BasicAmount;
                    }
                    if (db.ProductItems.Local.Where(c => c.Barcode == p.Barcode).Count() == 0)
                    {
                        db.ProductItems.Add(p);
                        db.Stocks.Add(stk);
                    }

                }
            }

            var ins = saleItems.Where(c => !string.IsNullOrEmpty(c.InvoiceNumber)).GroupBy(c => c.InvoiceNumber).

                Select(c => new ProductSale
                {
                    Adjusted = false,
                    EntryStatus = EntryStatus.Added,
                    FreeQty = 0,
                    InvoiceNo = c.Key,
                    IsReadOnly = true,
                    MarkedDeleted = false,
                    Taxed = true,
                    StoreId = "ARD",
                    Paid = true,
                    Tailoring = false,
                    UserId = "AutoAdmin",
                    SalesmanId = "SMN-2016-001",
                    OnDate = sales.Where(x => x.InvoiceNo == c.Key).First().Date.Value,
                    BilledQty = c.Sum(x => x.BilledQty),
                    TotalBasicAmount = c.Sum(x => x.BasicAmount),
                    TotalDiscountAmount = c.Sum(x => x.DiscountAmount),
                    TotalTaxAmount = c.Sum(x => x.TaxAmount),
                    TotalMRP = c.Sum(x => x.DiscountAmount + x.Value),
                    InvoiceType = c.Select(x => x.InvoiceType).First(),
                    TotalPrice = sales.Where(x => x.InvoiceNo == c.Key).Sum(z => z.BillAmount).Value,
                    RoundOff = sales.Where(x => x.InvoiceNo == c.Key).Sum(z => z.BillAmount).Value - c.Sum(x => x.Value)
                }).ToList();

            var forP = sales.Where(c => string.IsNullOrEmpty(c.PayMode) == false)
                    .Select(c => new SalePaymentDetail
                    {
                        InvoiceNumber = c.InvoiceNo,
                        PaidAmount = c.BillAmount.Value,
                        RefId = "Missing",
                        PayMode = DocIO.PayModeType(c.PayMode)
                    }).ToList();
            db.SalePaymentDetails.AddRange(forP);
            foreach (var im in forP.Where(c => c.PayMode == PayMode.Card))
            {
                CardPaymentDetail cd = new CardPaymentDetail
                {
                    AuthCode = 0,
                    Card = Card.DebitCard,
                    CardLastDigit = -1,
                    CardType = CardType.Rupay,
                    InvoiceNumber = im.InvoiceNumber,
                    PaidAmount = im.PaidAmount,
                    EDCTerminalId = null,

                };
                db.CardPaymentDetails.Add(cd);
            }

            db.ProductSales.AddRange(ins);
            db.SaleItems.AddRange(saleItems);

            int ios = db.SaveChanges();
            return ios > 0;

        }


    }

}