using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using AutoMapper.Configuration.Conventions;
using Syncfusion.Blazor.Schedule.Internal;
using System.Linq;

namespace AprajitaRetails.Server.BL.Reports.Inventory
{
    public class SaleReports
    {
        public static MemoryStream GenerateSaleReportForGST(ARDBContext db, int Month, int Year)
        {

            var saleData = db.SaleItems.Include(c => c.ProductSale).Include(c => c.ProductSale.Store).Where(c => c.ProductSale.OnDate.Year == Year && c.ProductSale.OnDate.Month == Month)
                .Select(c => new { c.ProductSale.StoreId, c.ProductSale.Store.StoreName, c.ProductSale.Store.GSTIN, c.Barcode, c.BilledQty, c.FreeQty, c.BasicAmount, c.DiscountAmount, c.TaxAmount, c.Value })
                .OrderBy(x => x.GSTIN).ThenBy(x => x.StoreId)
                .ToList();

            var stores = saleData.Select(c => new { c.StoreId, c.StoreName, c.GSTIN }).Distinct().ToList();

            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;
                //Add page to the PDF document.
                PdfPage page = pdfDocument.Pages.Add();
                //Create a new font.
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
                //Create a text element to draw a text in PDF page.
                PdfTextElement title = new PdfTextElement($"Sale Report For Month: {Month}/{Year}", font, PdfBrushes.DarkRed);

                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Sale Report Generated based on Sale.\n\t Report is generated for Each Store", contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;
                //Draw a text to the PDF document.
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                foreach (var st in stores)
                {
                    PdfTextElement stitle = new PdfTextElement($"Store: {st.StoreId}, {st.StoreName}, {st.GSTIN}", font, PdfBrushes.DarkRed);
                    result = stitle.Draw(page, new PointF(0, 0));

                    PdfGrid pdfGrid = new PdfGrid();
                    pdfGrid.Style.CellPadding.Left = cellMargin;
                    pdfGrid.Style.CellPadding.Right = cellMargin;

                    //Assign data source.
                     pdfGrid.DataSource = saleData.Where(c=>c.StoreId== st.StoreId).ToList();

                    //Applying built-in style to the PDF grid.
                    pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);
                    pdfGrid.Style.Font = contentFont;
                    //Draw PDF grid into the PDF page.
                    pdfGrid.Draw(page, new  PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                    PdfTextElement s2title = new PdfTextElement($"End of Store: {st.StoreName}/ Date: {DateTime.Now}", font, PdfBrushes.DarkRed);
                    result = s2title.Draw(page, new PointF(0, 0));

                }

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
}

