using System;
using System.Drawing;
using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.PdfExport;

namespace AprajitaRetails.Server.BL.Reports.Inventory
{
    public class StockHistoryReport
    {
        private const string DMK = "AprajitaRetails, Dumka";
        private const string JSD = "AprajitaRetauls,Jamshedpur";
        private readonly ARDBContext ardb;
        public List<PurchaseData> PurchaseList;
        public List<SaleData> SaleList;
        public List<StockHistory> StockHistories;
        public List<HistoryPath> HistoryPaths;

        public StockHistoryReport(ARDBContext db)
        {
            ardb = db;
        }
        public void ProcessStockHistory()
        {
            FetchPurchaseData();
            FetchSaleData();
            FetchSaleHistory();
            UpdateInterStockTransfer();
            GenerateStockSummary();
        }
        private void FetchPurchaseData()
        {
            PurchaseList = ardb.PurchaseItems.Include(c => c.PurchaseProduct).
                OrderBy(c => c.PurchaseProduct.OnDate).OrderBy(c => c.PurchaseProduct.StoreId)
                .Select(c => new PurchaseData { Barcode = c.Barcode, OnDate = c.PurchaseProduct.OnDate, Qty = c.Qty, CostPrice = c.CostPrice, StoreId = c.PurchaseProduct.StoreId, CostValue = c.CostValue, TaxValue = c.TaxAmount }).ToList();
        }
        private void FetchSaleData()
        {
            var SaleList = ardb.SaleItems.Include(c => c.ProductSale)
                .OrderBy(c => c.ProductSale.OnDate).OrderBy(c => c.ProductSale.StoreId)
                .Select(c => new { c.Barcode, c.ProductSale.OnDate, Qty = c.BilledQty + c.FreeQty, c.Value, c.TaxAmount }).ToList();
        }
        private void FetchSaleHistory()
        {
            StockHistories = ardb.PurchaseItems.Include(c => c.PurchaseProduct).
                  OrderBy(c => c.PurchaseProduct.OnDate).OrderBy(c => c.PurchaseProduct.StoreId)
                  .Select(c => new StockHistory { Barcode = c.Barcode, OnDate = c.PurchaseProduct.OnDate, PurchaseQty = c.Qty, CostPrice = c.CostPrice, StoreId = c.PurchaseProduct.StoreId, CostValue = c.CostValue, PurchaseTaxValue = c.TaxAmount }).ToList();
            StockHistories.AddRange(ardb.SaleItems.Include(c => c.ProductSale)
                .OrderBy(c => c.ProductSale.OnDate).OrderBy(c => c.ProductSale.StoreId)
                .Select(c => new StockHistory { Barcode = c.Barcode, OnDate = c.ProductSale.OnDate, SaleQty = c.BilledQty + c.FreeQty, SaleValue = c.Value, SaleTaxValue = c.TaxAmount, StoreId = c.ProductSale.StoreId, SalePrice = c.Value / c.BilledQty }).ToList());

            StockHistories = StockHistories.OrderBy(c => c.Barcode).OrderBy(c => c.OnDate).ToList();

        }
        //Exclusive for Apraijita Retails TAS
        private void UpdateInterStockTransfer()
        {
            var jamshedpur = ardb.PurchaseItems.Include(c => c.PurchaseProduct).
                Where(c => c.PurchaseProduct.Warehouse == JSD)
                 .OrderBy(c => c.PurchaseProduct.OnDate).OrderBy(c => c.PurchaseProduct.StoreId)
                  .Select(c => new StockHistory { Barcode = c.Barcode, OnDate = c.PurchaseProduct.OnDate, PurchaseQty = c.Qty, CostPrice = c.CostPrice, StoreId = c.PurchaseProduct.StoreId, CostValue = c.CostValue, PurchaseTaxValue = c.TaxAmount }).ToList();

            var dumka = ardb.PurchaseItems.Include(c => c.PurchaseProduct).
                 Where(c => c.PurchaseProduct.Warehouse == DMK)
                 .OrderBy(c => c.PurchaseProduct.OnDate).OrderBy(c => c.PurchaseProduct.StoreId)
                  .Select(c => new StockHistory { Barcode = c.Barcode, OnDate = c.PurchaseProduct.OnDate, PurchaseQty = c.Qty, CostPrice = c.CostPrice, StoreId = c.PurchaseProduct.StoreId, CostValue = c.CostValue, PurchaseTaxValue = c.TaxAmount }).ToList();

            //Adding Sale at Dumka
            foreach (var item in jamshedpur)
            {
                StockHistories.Add(new StockHistory
                {
                    Barcode = item.Barcode,
                    OnDate = item.OnDate,
                    SaleQty = item.PurchaseQty,
                    PurchaseQty = 0,
                    CostPrice = 0,
                    CostValue = 0,
                    PurchaseTaxValue = 0,
                    SalePrice = item.CostPrice,
                    SaleTaxValue = item.PurchaseTaxValue,
                    SaleValue = item.CostValue,
                    StoreId = "ARD"
                });
            }
            //Adding Sale at Jameshedur
            foreach (var item in dumka)
            {
                StockHistories.Add(new StockHistory
                {
                    Barcode = item.Barcode,
                    OnDate = item.OnDate,
                    SaleQty = item.PurchaseQty,
                    PurchaseQty = 0,
                    CostPrice = 0,
                    CostValue = 0,
                    PurchaseTaxValue = 0,
                    SalePrice = item.CostPrice,
                    SaleTaxValue = item.PurchaseTaxValue,
                    SaleValue = item.CostValue,
                    StoreId = "ARJ"
                });
            }
            StockHistories = StockHistories.OrderBy(c => c.Barcode).OrderBy(c => c.OnDate).OrderBy(c => c.StoreId).ToList();


        }
        private void GenerateStockSummary()
        {
            HistoryPaths = StockHistories.GroupBy(c => c.Barcode).
               Select(c => new HistoryPath
               {
                   Barcode = c.Key,
                   InQty = c.Sum(x => x.PurchaseQty),
                   OutQty = c.Sum(x => x.SaleQty),
                   CostValue = c.Sum(x => x.CostValue) + c.Sum(x => x.PurchaseTaxValue),
                   SaleValue = c.Sum(x => x.SaleValue),
                   TaxValue = c.Sum(x => x.SaleValue),
                   StockInHand = c.Sum(x => x.PurchaseQty) - c.Sum(x => x.SaleQty),
                   StockValue = (c.Sum(x => x.PurchaseQty) - c.Sum(x => x.SaleQty)) * c.Average(c => c.CostPrice)
               }).ToList();
        }
        //TODO: Use this function to create PDF Report
        //TODO: make function to generate Excel Report also 
        //public MemoryStream CreatePdf()
        //{
        //    //Create a new PDF document.
        //    using (PdfDocument pdfDocument = new PdfDocument())
        //    {
        //        int paragraphAfterSpacing = 8;
        //        int cellMargin = 8;
        //        //Add page to the PDF document.
        //        PdfPage page = pdfDocument.Pages.Add();
        //        //Create a new font.
        //        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

        //        //Create a text element to draw a text in PDF page.
        //        PdfTextElement title = new PdfTextElement("Weather Forecast", font, PdfBrushes.Black);
        //        PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
        //        PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
        //        PdfTextElement content = new PdfTextElement("This component demonstrates fetching data from a service and Exporting the data to PDF document using Syncfusion .NET PDF library.", contentFont, PdfBrushes.Black);
        //        PdfLayoutFormat format = new PdfLayoutFormat();
        //        format.Layout = PdfLayoutType.Paginate;
        //        //Draw a text to the PDF document.
        //        result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

        //        //Create a PdfGrid.
        //        PdfGrid pdfGrid = new PdfGrid();
        //        pdfGrid.Style.CellPadding.Left = cellMargin;
        //        pdfGrid.Style.CellPadding.Right = cellMargin;
        //        //Applying built-in style to the PDF grid.
        //        pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

        //        //Assign data source.
        //        pdfGrid.DataSource = forecasts
        //pdfGrid.Style.Font = contentFont;
        //        //Draw PDF grid into the PDF page.
        //        pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            //Saving the PDF document into the stream.
        //            pdfDocument.Save(stream);
        //            //Closing the PDF document.
        //            pdfDocument.Close(true);
        //            return stream;
        //        }
        //    }
        }
        public class PurchaseData
        {
            public string Barcode { get; set; }
            public DateTime OnDate { get; set; }
            public decimal Qty { get; set; }
            public decimal CostPrice { get; set; }
            public decimal CostValue { get; set; }
            public decimal TaxValue { get; set; }
            public string StoreId { get; set; }
        }
        public class SaleData
        {
            public string StoreId { get; set; }
            public string Barcode { get; set; }
            public DateTime OnDate { get; set; }
            public decimal Qty { get; set; }
            public decimal SaleValue { get; set; }
            public decimal TaxValue { get; set; }
        }
        public class StockHistory
        {
            public int Id { get; set; }
            public string Barcode { get; set; }
            public DateTime OnDate { get; set; }
            public decimal PurchaseQty { get; set; }
            public decimal SaleQty { get; set; }
            public decimal CostPrice { get; set; }
            public decimal CostValue { get; set; }
            public decimal PurchaseTaxValue { get; set; }
            public decimal SalePrice { get; set; }
            public decimal SaleValue { get; set; }
            public decimal SaleTaxValue { get; set; }
            public string StoreId { get; set; }

        }
        public class HistoryPath
        {
            public string Barcode { get; set; }
            //public DateTime OnDate { get; set; }

            public decimal InQty { get; set; }
            public decimal OutQty { get; set; }

            public decimal CostValue { get; set; }
            public decimal SaleValue { get; set; }
            public decimal TaxValue { get; set; }

            public decimal StockInHand { get; set; }
            public decimal StockValue { get; set; }

            public decimal ProfitLossValue { get { return SaleValue + StockValue - TaxValue - CostValue; } }

        }
    }

