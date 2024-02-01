//using Syncfusion.Drawing;
//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Graphics;

////https://www.c-sharpcorner.com/UploadFile/b1df45/web-api-self-hosting-using-windows-service/#:~:text=Go%20to%20the%20list%20of,ajax%20call%20to%20the%20API.
////https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-8.0&tabs=visual-studio
////https://www.google.com/search?q=calling+web+api+from+windows+server+background+service&sca_esv=be1f4daf33da1a0f&sxsrf=ACQVn08reQIq0V9au_CKAMvVDqlh8-oN4w%3A1706723033933&ei=2Ya6ZdzCONXkseMP9qe02Ag&oq=calling+web+api+from+windows+Server&gs_lp=Egxnd3Mtd2l6LXNlcnAiI2NhbGxpbmcgd2ViIGFwaSBmcm9tIHdpbmRvd3MgU2VydmVyKgIIADIFECEYoAEyBRAhGKABMgUQIRigATIFECEYoAEyBRAhGJ8FSLB2UIEJWNZScAF4AZABAJgBuAGgAYkoqgEEMC4zNbgBA8gBAPgBAagCEcICBxAjGOoCGCfCAhQQABiABBjjBBjpBBjqAhi0AtgBAcICChAjGIAEGIoFGCfCAgQQIxgnwgIOEAAYgAQYigUYkQIYsQPCAg4QLhiABBiKBRixAxiDAcICCxAAGIAEGLEDGIMBwgIIEAAYgAQYsQPCAgsQABiABBiKBRiRAsICFxAuGIAEGIoFGJECGLEDGIMBGMcBGNEDwgIWEC4YgAQYigUYQxixAxiDARjHARjRA8ICChAuGIAEGIoFGEPCAhEQLhiABBixAxiDARjHARjRA8ICEBAAGIAEGIoFGEMYsQMYgwHCAhAQLhiABBiKBRhDGLEDGIMBwgIfEC4YgAQYigUYQxixAxiDARiXBRjcBBjeBBjgBNgBAsICExAAGIAEGIoFGJECGLEDGEYY-QHCAgoQABiABBiKBRhDwgINEAAYgAQYigUYQxixA8ICCBAuGIAEGLEDwgIqEAAYgAQYigUYkQIYsQMYRhj5ARiXBRiMBRjdBBhGGPQDGPUDGPYD2AEDwgIFEAAYgATCAgoQABiABBgUGIcCwgINEC4YChiDARixAxiABMICBxAAGIAEGArCAgsQABiABBiKBRiGA8ICBhAAGBYYHsICCBAAGBYYHhgK4gMEGAAgQboGBggBEAEYAboGBggCEAEYFLoGBggDEAEYEw&sclient=gws-wiz-serp
////https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-8.0&tabs=visual-studio
////https://www.c-sharpcorner.com/article/hosting-asp-net-web-api-rest-service-on-iis-10/
////https://learn.microsoft.com/en-us/entra/identity-platform/scenario-desktop-call-api?tabs=dotnet
////https://www.c-sharpcorner.com/article/calling-web-api-using-httpclient/#:~:text=To%20call%20Web%20API%20methods,installed%20in%20the%20console%20Application.&text=Next%20step%20is%20to%20create%20HttpClient%20object.
////https://stackoverflow.com/questions/59636097/c-sharp-worker-service-vs-windows-service#:~:text=Both%20are%20real%20services.,and%20stops%20with%20the%20application.
////https://blog.hubspot.com/website/api-calls
////https://hevodata.com/learn/powershell-rest-api/#:~:text=To%20call%20a%20REST%20API,get%20data%20from%20API%20documentation.


//namespace AprajitaRetails.Services.InfoManager.Helpers
//{
//    public class Todo
//    {
//        public int Id { get; set; }
//        public string StoreId { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public DateTime OnDate { get; set; }
//        public DateTime? EOD { get; set; }
//        public string Status { get; set; }

//    }
//    public class FinInfo
//    {
//        public decimal Sale { get; set; }
//        public decimal CashSale { get; set; }
//        public decimal NonCashSale { get; set; }
//        public decimal Expenses { get; set; }
//        public decimal Receipts { get; set; }
//        public decimal Payments { get; set; }
//        public decimal CashInHand { get; set; }
//    }
//    public class CashDetailInfo
//    {
//        public int Id { get; set; }
//        public string StoreId { get; set; }

//        public DateTime OnDate { get; set; }
//        public int Count { get; set; }
//        public int TotalAmount { get; set; }

//        public int N2000 { get; set; }
//        public int N1000 { get; set; }
//        public int N500 { get; set; }
//        public int N200 { get; set; }
//        public int N100 { get; set; }
//        public int N50 { get; set; }
//        public int N20 { get; set; }
//        public int N10 { get; set; }

//        public int TotalCoins { get; set; }
//        public int CoainValue { get; set; }


//    }

//    public class MessagePrinter
//    {


//        public FinInfo Info { get; set; }
//        public CashDetailInfo CashInfo { get; set; }
//        public List<Todo> TodoList { get; set; }

//        private int PageWith = 150;
//        private int PageHeight = 1500;// 1170;
//        private int FontSize = 8;
//        public bool Page2Inch { get; set; } = false;
//        public const string DotedLine = "---------------------------------\n";
//        public const string DotedLineLong = "--------------------------------------------------\n";

//        public const string tab = "    ";
//        public string StoreName { get; set; }
//        public string Address { get; set; }
//        public string City { get; set; }
//        public string StoreCode { get; set; }

//        public string Location { get; set; }
//        public string EmployeeDept { get; set; }

//        public string PathName { get; set; }
//        public string FileName { get; set; }

//        public bool PrintHeader { get; set; }
//        private const int paragraphAfterSpacing = 8;

//        private const string JournalTitle = "                 Daily Journal";
//        private const string ItemLineHeader1 = "SN   Date     Journal RefNo";
//        private const string ItemLineHeader2 = "Message";

//        private const string TodaysTodoHeader1 = "Today's ToDo List";
//        private const string TodoLine1 = "SN   Work    ";
//        private const string TodoLine2 = "EOD       Work Status";



//        private const string Employee = "Location           Dept";


//        public MemoryStream JournalThermalPdf()
//        {
//            if (!Page2Inch)
//            {
//                PageWith = 240;
//                FontSize = 10;
//            }
//            using (PdfDocument pdfDoc = new PdfDocument())
//            {
//                try
//                {
//                    pdfDoc.PageSettings.Size = new SizeF(PageWith, PageHeight);
//                    //Create a new font.
//                    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, this.FontSize);
//                    //TODO: Page margin need to be check and adjusted for every option
//                    if (Page2Inch)
//                        pdfDoc.PageSettings.SetMargins(90, 25, 90, 8);
//                    else
//                        pdfDoc.PageSettings.SetMargins(25, 25, 40, 25);

//                    PdfPage page = pdfDoc.Pages.Add();
//                    PdfLayoutFormat format = new PdfLayoutFormat();
//                    format.Layout = PdfLayoutType.OnePage;

//                    PdfTextElement title = new PdfTextElement($"{StoreName}\n{Address}\n{City}\n Store Code: {StoreCode}\n", font, PdfBrushes.Black);
//                    PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

//                    string line = "";
//                    string todoline = "";
//                    string dash = "--";
//                    if (!Page2Inch) line = DotedLineLong;
//                    else line = DotedLine;

//                    if (TodoList == null || TodoList.Count == 0) { return null; }

//                    string detailString = $"{line}{TodaysTodoHeader1}\n{line}\nDate: {DateTime.Today.ToShortDateString()}\nTime: {DateTime.Now.ToShortTimeString()}\n{line}\n\n{TodoLine1}\n{TodoLine2}\n";
//                    foreach (var todo in TodoList)
//                    {
//                        todoline += $"{todo.Id}\t {todo.Title}:- {todo.Description}\n{(todo.EOD.HasValue ? todo.EOD.Value : dash)}\t\t{todo.Status}\n\n";

//                    }

//                    string sCash = $"{line} End of Today's ToDo List, Complete the work at earlist and report.\n{line}";


//                    PdfTextElement details = new PdfTextElement($"{detailString}{todoline}{sCash}", font, PdfBrushes.Black);
//                    result = details.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    string invItemStr = $"{Employee}\n{Location}\t\t {EmployeeDept}\n";



//                    PdfTextElement invitm = new PdfTextElement(invItemStr, font, PdfBrushes.Black);
//                    result = invitm.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    MemoryStream stream = new MemoryStream();
//                    //Saving the PDF document into the stream.
//                    pdfDoc.Save(stream);
//                    //Closing the PDF document.
//                    pdfDoc.Close(true);
//                    return stream;
//                    //TODO: do Logging Here

//                }
//                catch (Exception ex)
//                {
//                    //TODO: do Logging here
//                    return null;

//                }

//            }
//        }



//        public MemoryStream TodoThermalPdf()
//        {

//            if (!Page2Inch)
//            {
//                PageWith = 240;
//                FontSize = 10;
//            }
//            using (PdfDocument pdfDoc = new PdfDocument())
//            {
//                try
//                {
//                    pdfDoc.PageSettings.Size = new SizeF(PageWith, PageHeight);
//                    //Create a new font.
//                    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, this.FontSize);
//                    //TODO: Page margin need to be check and adjusted for every option
//                    if (Page2Inch)
//                        pdfDoc.PageSettings.SetMargins(90, 25, 90, 8);
//                    else
//                        pdfDoc.PageSettings.SetMargins(25, 25, 40, 25);

//                    PdfPage page = pdfDoc.Pages.Add();
//                    PdfLayoutFormat format = new PdfLayoutFormat();
//                    format.Layout = PdfLayoutType.OnePage;

//                    PdfTextElement title = new PdfTextElement($"{StoreName}\n{Address}\n{City}\n Store Code: {StoreCode}\n", font, PdfBrushes.Black);
//                    PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

//                    string line = "";
//                    string todoline = "";
//                    string dash = "--";
//                    if (!Page2Inch) line = DotedLineLong;
//                    else line = DotedLine;

//                    if (TodoList == null || TodoList.Count == 0) { return null; }

//                    string detailString = $"{line}{TodaysTodoHeader1}\n{line}\nDate: {DateTime.Today.ToShortDateString()}\nTime: {DateTime.Now.ToShortTimeString()}\n{line}\n\n{TodoLine1}\n{TodoLine2}\n";
//                    foreach (var todo in TodoList)
//                    {
//                        todoline += $"{todo.Id}\t {todo.Title}:- {todo.Description}\n{(todo.EOD.HasValue ? todo.EOD.Value : dash)}\t\t{todo.Status}\n\n";

//                    }

//                    string sCash = $"{line} End of Today's ToDo List, Complete the work at earlist and report.\n{line}";


//                    PdfTextElement details = new PdfTextElement($"{detailString}{todoline}{sCash}", font, PdfBrushes.Black);
//                    result = details.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    string invItemStr = $"{Employee}\n{Location}\t\t {EmployeeDept}\n";



//                    PdfTextElement invitm = new PdfTextElement(invItemStr, font, PdfBrushes.Black);
//                    result = invitm.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    MemoryStream stream = new MemoryStream();
//                    //Saving the PDF document into the stream.
//                    pdfDoc.Save(stream);
//                    //Closing the PDF document.
//                    pdfDoc.Close(true);
//                    return stream;
//                    //TODO: do Logging Here

//                }
//                catch (Exception ex)
//                {
//                    //TODO: do Logging here
//                    return null;

//                }

//            }
//        }

//        public MemoryStream DayStartThermalPdf()
//        {
//            if (!Page2Inch)
//            {
//                PageWith = 240;
//                FontSize = 10;
//            }
//            using (PdfDocument pdfDoc = new PdfDocument())
//            {
//                try
//                {
//                    pdfDoc.PageSettings.Size = new SizeF(PageWith, PageHeight);
//                    //Create a new font.
//                    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, this.FontSize);
//                    //TODO: Page margin need to be check and adjusted for every option
//                    if (Page2Inch)
//                        pdfDoc.PageSettings.SetMargins(90, 25, 90, 8);
//                    else
//                        pdfDoc.PageSettings.SetMargins(25, 25, 40, 25);

//                    PdfPage page = pdfDoc.Pages.Add();
//                    PdfLayoutFormat format = new PdfLayoutFormat();
//                    format.Layout = PdfLayoutType.OnePage;

//                    PdfTextElement title = new PdfTextElement($"{StoreName}\n{Address}\n{City}\n Store Code: {StoreCode}\n", font, PdfBrushes.Black);
//                    PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

//                    string line = "";
//                    string sFinInfo = "";

//                    if (!Page2Inch) line = DotedLineLong;
//                    else line = DotedLine;

//                    string detailString = $"{line}{JournalTitle}\n{line}\nDate: {DateTime.Today.ToShortDateString()}\nTime: {DateTime.Now.ToShortTimeString()}\n{line}\nDay Operation Starting\n{line}\n";

//                    if (Info != null)
//                    {
//                        sFinInfo = $"{line}Yesterday's Info\n Sale: {Info.Sale.ToString("0.##")}\nCash : {Info.CashInHand.ToString("0.##")}\tNon Cash:{Info.NonCashSale.ToString("0.##")}\n" +
//                            $"{line} Expenses:{Info.Expenses.ToString("0.##")}\nPayment:{Info.Payments.ToString("0.##")}\nReciepts:{Info.Receipts.ToString("0.##")}\n{line}Opening Cash:{Info.CashInHand.ToString("0.##")}\n{line}";
//                    }
//                    string sCash = "";
//                    if (CashInfo != null)
//                    {
//                        sCash = $"\tCash Details:\n\nTotal Cash: {CashInfo.TotalAmount}, Count: {CashInfo.Count}\n{line}Coins:{CashInfo.TotalCoins}\t Amt:{CashInfo.CoainValue}\n"
//                        + $"2000x{CashInfo.N2000}={(2000 * CashInfo.N2000).ToString("0.##")}\n"
//                        + $"500x{CashInfo.N500}={(500 * CashInfo.N500).ToString("0.##")}\n"
//                        + $"200x{CashInfo.N100}={(200 * CashInfo.N200).ToString("0.##")}\n"
//                        + $"100x{CashInfo.N200}={(100 * CashInfo.N100).ToString("0.##")}\n"
//                        + $"50x{CashInfo.N50}={(50 * CashInfo.N50).ToString("0.##")}\n"
//                        + $"20x{CashInfo.N20}={(20 * CashInfo.N20).ToString("0.##")}\n"
//                        + $"10x{CashInfo.N10}={(10 * CashInfo.N10).ToString("0.##")}\n{line}Verify Cash Details, Report any error!\n{line}";

//                    }

//                    PdfTextElement details = new PdfTextElement($"{detailString}{sFinInfo}{sCash}", font, PdfBrushes.Black);
//                    result = details.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    string invItemStr = $"{Employee}\n{Location}\t\t {EmployeeDept}\n{line} Store Operation Started!";
//                    //string f = "0.##";


//                    PdfTextElement invitm = new PdfTextElement(invItemStr, font, PdfBrushes.Black);
//                    result = invitm.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    MemoryStream stream = new MemoryStream();
//                    //Saving the PDF document into the stream.
//                    pdfDoc.Save(stream);
//                    //Closing the PDF document.
//                    pdfDoc.Close(true);
//                    return stream;
//                    //TODO: do Logging Here

//                }
//                catch (Exception ex)
//                {
//                    //TODO: do Logging here
//                    return null;

//                }
//            }
//        }

//        public MemoryStream DayEndThermalPdf()
//        {
//            if (!Page2Inch)
//            {
//                PageWith = 240;
//                FontSize = 10;
//            }
//            using (PdfDocument pdfDoc = new PdfDocument())
//            {
//                try
//                {
//                    pdfDoc.PageSettings.Size = new SizeF(PageWith, PageHeight);
//                    //Create a new font.
//                    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, this.FontSize);
//                    //TODO: Page margin need to be check and adjusted for every option
//                    if (Page2Inch)
//                        pdfDoc.PageSettings.SetMargins(90, 25, 90, 8);
//                    else
//                        pdfDoc.PageSettings.SetMargins(25, 25, 40, 25);

//                    PdfPage page = pdfDoc.Pages.Add();
//                    PdfLayoutFormat format = new PdfLayoutFormat();
//                    format.Layout = PdfLayoutType.OnePage;

//                    PdfTextElement title = new PdfTextElement($"{StoreName}\n{Address}\n{City}\n Store Code: {StoreCode}\n", font, PdfBrushes.Black);
//                    PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

//                    string line = "";
//                    string sFinInfo = "";

//                    if (!Page2Inch) line = DotedLineLong;
//                    else line = DotedLine;

//                    string detailString = $"{line}{JournalTitle}\n{line}\nDate: {DateTime.Today.ToShortDateString()}\nTime: {DateTime.Now.ToShortTimeString()}\n{line}Day Closing\n{line}\n";

//                    if (Info != null)
//                    {
//                        sFinInfo = $"{line}Today's Info\n Sale: {Info.Sale.ToString("0.##")}\nCash : {Info.CashInHand.ToString("0.##")}\tNon Cash:{Info.NonCashSale.ToString("0.##")}\n" +
//                            $"{line} Expenses:{Info.Expenses.ToString("0.##")}\nPayment:{Info.Payments.ToString("0.##")}\nReciepts:{Info.Receipts.ToString("0.##")}\n{line} Closing Bal:{Info.CashInHand.ToString("0.##")}\n{line}";
//                    }
//                    string sCash = "";
//                    if (CashInfo != null)
//                    {
//                        sCash = $"\tCash Details:\n\nTotal Cash: {CashInfo.TotalAmount}, Count: {CashInfo.Count}\n{line}Coins:{CashInfo.TotalCoins}\t Amt:{CashInfo.CoainValue}\n"
//                        + $"2000x{CashInfo.N2000}={(2000 * CashInfo.N2000).ToString("0.##")}\n"
//                        + $"500x{CashInfo.N500}={(500 * CashInfo.N500).ToString("0.##")}\n"
//                        + $"200x{CashInfo.N100}={(200 * CashInfo.N200).ToString("0.##")}\n"
//                        + $"100x{CashInfo.N200}={(100 * CashInfo.N100).ToString("0.##")}\n"
//                        + $"50x{CashInfo.N50}={(50 * CashInfo.N50).ToString("0.##")}\n"
//                        + $"20x{CashInfo.N20}={(20 * CashInfo.N20).ToString("0.##")}\n"
//                        + $"10x{CashInfo.N10}={(10 * CashInfo.N10).ToString("0.##")}\n{line}Verify Cash Details, Report any error!\n{line}";

//                    }

//                    PdfTextElement details = new PdfTextElement($"{detailString}{sFinInfo}{sCash}", font, PdfBrushes.Black);
//                    result = details.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    string invItemStr = $"{Employee}\n{Location}\t\t {EmployeeDept}\n{line} Store Operation Closed!";
//                    // string f = "0.##";


//                    PdfTextElement invitm = new PdfTextElement(invItemStr, font, PdfBrushes.Black);
//                    result = invitm.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

//                    MemoryStream stream = new MemoryStream();
//                    //Saving the PDF document into the stream.
//                    pdfDoc.Save(stream);
//                    //Closing the PDF document.
//                    pdfDoc.Close(true);
//                    return stream;
//                    //TODO: do Logging Here

//                }
//                catch (Exception ex)
//                {
//                    //TODO: do Logging here
//                    return null;

//                }
//            }
//        }



//    }
//}
