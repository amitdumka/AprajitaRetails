using AprajitaRetails.Shared.Models.Inventory;
using Syncfusion.Blazor.Kanban.Internal;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Server.Helpers.Printer
{
    public class InvoicePrinter1
    {
        [Required]
        public bool InvoiceSet { get; set; }

        private int PageWith = 150;
        private int PageHeight = 1170;
        private int FontSize = 8;
        public bool Page2Inch { get; set; } = false;

        public bool ServiceBill { get; set; } = false;

        public const string DotedLine = "---------------------------------\n";
        public const string DotedLineLong = "--------------------------------------------------\n";

        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string TaxNo { get; set; }

        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }

        public ProductSale ProductSale { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public List<SalePaymentDetail> PaymentDetails { get; set; }
        public CardPaymentDetail CardDetails { get; set; }

        public int NoOfCopy { get; set; }
        public bool Reprint { get; set; }

        public string PathName { get; set; }
        public string FileName { get; set; }

        private const string InvoiceTitle = "                 RETAIL INVOICE";
        private const string ItemLineHeader1 = "SKU Code/Description/ HSN";
        private const string ItemLineHeader2 = "MRP     Qty     Disc     Amount";
        private const string ItemLineHeader3 = "CGST%    AMT     SGST%   AMT";

        private const string FooterFirstMessage = "** Amount Inclusive GST **";
        private const string FooterThanksMessage = "Thank You";
        private const string FooterLastMessage = "Visit Again";
        private const int paragraphAfterSpacing = 8;
        private const string Employee = "Cashier: M0001      Name: Manager";

        public void InvoiceThermalPdf()
        {
            if (!this.InvoiceSet) return;
            if (!Page2Inch)
            {
                PageWith = 240;
                FontSize = 10;
            }
            using (PdfDocument pdfDoc = new PdfDocument())
            {
                try
                {
                    PdfPage page = pdfDoc.Pages.Add();
                    pdfDoc.PageSettings.Size =new SizeF(PageWith,PageHeight);
                    

                    //Create a new font.
                    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, this.FontSize);

                    if (Page2Inch)
                        pdfDoc.PageSettings.SetMargins(90, 25, 90, 8);
                    else
                        pdfDoc.PageSettings.SetMargins(170, 25, 90, 35);
                    PdfLayoutFormat format = new PdfLayoutFormat();
                    //format.Layout = PdfLayoutType.Paginate;
                    format.Layout = PdfLayoutType.OnePage;

                    PdfTextElement title = new PdfTextElement($"{StoreName}\n{Address}\n{City}\n Phone No: {Phone}\n {TaxNo}", font, PdfBrushes.Black);
                    PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                    string detailString = $@"";
                    PdfTextElement details= new PdfTextElement(detailString, font,PdfBrushes.Black);

                    Paragraph ip = new Paragraph().SetFontSize(FontSize);
                    ip.AddStyle(code);
                    ip.SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED_ALL);
                    if (!Page2Inch) ip.Add(DotedLineLong);
                    else ip.Add(DotedLine);
                    ip.AddTabStops(new TabStop(50));
                    ip.Add("  " + InvoiceTitle + "\n");
                    if (!Page2Inch) ip.Add(DotedLineLong); else ip.Add(DotedLine);
                    if (ServiceBill)
                    {
                        ip.Add("  Service Invoice\n");
                        if (!Page2Inch) ip.Add(DotedLineLong);
                        else ip.Add(DotedLine);
                    }

                    ip.Add(Employee + "\n");
                    ip.Add("Bill No: " + ProductSale.InvoiceNo + "\n");
                    ip.AddTabStops(new TabStop(30));
                    ip.Add("  " + "                  Date: " + ProductSale.OnDate.ToString() + "\n");
                    ip.AddTabStops(new TabStop(30));
                    //ip.Add("  " + "                  Time: " + ProductSale.OnDate.ToShortTimeString() + "\n");

                    if (!Page2Inch) ip.Add(DotedLineLong); else ip.Add(DotedLine);
                    ip.Add("Customer Name: " + CustomerName + "\n");
                    ip.Add("Customer Mobile: " + MobileNumber + "\n");
                    if (!Page2Inch) ip.Add(DotedLineLong); else ip.Add(DotedLine);

                    ip.Add(ItemLineHeader1 + "\n");
                    ip.Add(ItemLineHeader2 + "\n");

                    if (!Page2Inch) ip.Add(DotedLineLong); else ip.Add(DotedLine);

                    result = details.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}