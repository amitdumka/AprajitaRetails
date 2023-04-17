using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Inventory;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Server.Helpers.Printer
{
    public class InvoicePrinter
    {
        [Required]
        public bool InvoiceSet { get; set; }

        private int PageWith = 150;
        private int PageHeight = 1500;// 1170;
        private int FontSize = 8;
        public bool Page2Inch { get; set; } = false;

        public bool ServiceBill { get; set; } = false;

        public const string DotedLine = "---------------------------------\n";
        public const string DotedLineLong = "--------------------------------------------------\n";

        public const string tab = "    ";

        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string TaxNo { get; set; }

        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }

        public ProductSaleDTO ProductSale { get; set; }
        public List<SaleItemDTO> SaleItems { get; set; }
        public List<SalePaymentDetail> PaymentDetails { get; set; }
        public CardPaymentDetailDTO CardDetails { get; set; }

        public int NoOfCopy { get; set; }
        public bool Reprint { get; set; }

        public string PathName { get; set; }
        public string FileName { get; set; }

        private const string InvoiceTitle = "                 RETAIL INVOICE";
        private const string ItemLineHeader1 = "SKU Code / Description / HSN";
        private const string ItemLineHeader2 = "MRP     Qty     Disc     Amount";
        private const string ItemLineHeader3 = "CGST%    AMT     SGST%   AMT";

        private const string FooterFirstMessage = "** Amount Inclusive GST **";
        private const string FooterThanksMessage = "Thank You";
        private const string FooterLastMessage = "Visit Again";
        private const int paragraphAfterSpacing = 8;
        private const string Employee = "Cashier: M0001      Name: Manager";

        public MemoryStream InvoiceThermalPdf()
        {
            if (!this.InvoiceSet) return null;
            if (!Page2Inch)
            {
                PageWith = 240;
                FontSize = 10;
            }
            using (PdfDocument pdfDoc = new PdfDocument())
            {
                try
                {
                    pdfDoc.PageSettings.Size = new SizeF(PageWith, PageHeight);

                    //Create a new font.
                    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, this.FontSize);
                    if (Page2Inch)
                        pdfDoc.PageSettings.SetMargins(90, 25, 90, 8);
                    else
                        pdfDoc.PageSettings.SetMargins(25, 25, 40, 25);

                    PdfPage page = pdfDoc.Pages.Add();

                    // pdfDoc.PageSettings.SetMargins(170, 25, 90, 35);
                    PdfLayoutFormat format = new PdfLayoutFormat();
                    //format.Layout = PdfLayoutType.Paginate;
                    format.Layout = PdfLayoutType.OnePage;

                    PdfTextElement title = new PdfTextElement($"{StoreName}\n{Address}\n{City}\nPhone No: {Phone}\n{TaxNo}", font, PdfBrushes.Black);
                    PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                    string line = "";
                    string sBill = "";

                    if (!Page2Inch) line = DotedLineLong;
                    else line = DotedLine;

                    if (ServiceBill)
                    {
                        sBill = $"Service Invoice\n{line}";
                    }
                    string detailString = $"{line}{InvoiceTitle}\n{line}{sBill}{Employee}\nBill No: {ProductSale.InvoiceNo}\nDate: {ProductSale.OnDate.ToShortDateString()}\n{line}";
                    string d2 = $"Name: {CustomerName}\nMobile : {MobileNumber}\n{line}{ItemLineHeader1}\n{ItemLineHeader2}\n{line}";

                    PdfTextElement details = new PdfTextElement($"{detailString}{d2}", font, PdfBrushes.Black);
                    result = details.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                    string invItemStr = "";
                    string f = "0.##";
                    foreach (var itm in SaleItems)
                    {
                        invItemStr += $"{itm.Barcode} / {itm.ProductName} /{itm.HSNCode} \n";
                        invItemStr += $"{itm.MRP.ToString(f)} / {itm.BilledQty.ToString(f)} / {itm.DiscountAmount.ToString(f)} / {itm.Value.ToString(f)}\n\n";
                    }
                    invItemStr += line;
                    invItemStr += $"Total: {ProductSale.BilledQty.ToString(f)}   \t                          {(ProductSale.TotalPrice - ProductSale.RoundOff).ToString(f)}\n";
                    invItemStr += $"Items(s): {ProductSale.TotalQty.ToString(f)} \t Net Amount: {(ProductSale.TotalPrice - ProductSale.RoundOff).ToString(f)}\n{line}";

                    invItemStr += $"Tender (s)\t\nPaid Amount:\t\t Rs. {(ProductSale.TotalPrice).ToString(f)}\n{line}";

                    invItemStr += $"Basic Price: \t{ProductSale.TotalBasicAmount.ToString("0.##")}";
                    invItemStr += $"\nCGST:   \t \t {(ProductSale.TotalTaxAmount / 2).ToString("0.##")}";
                    invItemStr += $"\nSGST:   \t \t {(ProductSale.TotalTaxAmount / 2).ToString("0.##")}\n{line}";

                    PdfTextElement invitm = new PdfTextElement(invItemStr, font, PdfBrushes.Black);
                    result = invitm.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                    if (PaymentDetails.Count > 0)
                    {
                        string payStr = line;

                        foreach (var pd in PaymentDetails)
                        {
                            payStr += $"Paid Rs. {pd.PaidAmount.ToString("0.##")} in {pd.PayMode}\n";

                            if (pd.PayMode == PayMode.Card)
                            {
                                if (CardDetails != null)
                                    payStr += $"{CardDetails.CardType}/{CardDetails.CardLastDigit}";
                            }
                            else if (pd.PayMode == PayMode.UPI || pd.PayMode == PayMode.Wallets)
                            {
                                payStr += $"Ref No:{pd.RefId}\n";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(pd.RefId) == false && pd.PayMode != PayMode.Cash)
                                    payStr += $"Ref No:{pd.RefId}\n";
                            }
                        }
                        payStr += line;
                        PdfTextElement pay = new PdfTextElement(payStr, font, PdfBrushes.Black);
                        result = pay.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);
                    }

                    //Footer
                    string footerstr = $"{FooterFirstMessage}\n";

                    if (ServiceBill) footerstr += "** Tailoring Service Invoice **";
                    footerstr += $"{DotedLineLong}{FooterThanksMessage}\n{FooterLastMessage}\n{DotedLineLong}\n";

                    if (Reprint)
                    {
                        footerstr += "(Reprinted Duplicate)\n";
                    }
                    else
                    {
                        footerstr += "(Customer Copy)\n";
                    }

                    footerstr += $"Printed on:  {DateTime.Now}  \n\n\n\n\n\n{DotedLine}\n\n\n";

                    PdfTextElement foot = new PdfTextElement(footerstr, font, PdfBrushes.Black);
                    result = foot.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                    PdfQRBarcode qrBarcode = new PdfQRBarcode();

                    qrBarcode.ErrorCorrectionLevel = PdfErrorCorrectionLevel.High;
                    //Set XDimension

                    qrBarcode.XDimension = 3;
                    qrBarcode.Text = ProductSale.InvoiceNo;

                    //Printing barcode on to the PDF
                    qrBarcode.Draw(page, new PointF(30, result.Bounds.Bottom + paragraphAfterSpacing));

                    pdfDoc.PageSettings.Height = result.Bounds.Bottom + paragraphAfterSpacing + 100;

                    //using (
                    MemoryStream stream = new MemoryStream();
                    //  )
                    //{
                    //Saving the PDF document into the stream.
                    pdfDoc.Save(stream);
                    //Closing the PDF document.
                    pdfDoc.Close(true);
                    return stream;
                    //}
                }
                catch (Exception ex)
                {
                    return null;
                    //throw;
                }
            }
        }
    }
}