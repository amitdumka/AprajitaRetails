using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
//https://stackoverflow.com/questions/5596394/how-to-print-pdf-document-from-windows-service
//Below is good check first
//https://itecnote.com/tecnote/c-printing-in-windows-service-using-background-worker/
//Second
//https://blackice.com/Help/Tools/Auto-print%20SDK/webhelp/Auto-print_Service_C_Sample.htm
//Third
//https://whuysentruit.medium.com/printing-pdf-files-silently-from-a-windows-service-756a37450fc9
//First
//https://supportcenter.devexpress.com/ticket/details/t704993/printing-pdf-silently-from-windows-service
// First of First
//https://support.syncfusion.com/kb/article/11572/how-to-print-document-in-windows-service-using-winforms-pdf-viewer

namespace AprajitaRetails.Services.InfoManager.Helpers
{
    internal class Class1
    {
        try
 {
   var pdfPrinter = new PdfPrinter();
        logger.LogInformation("Created pdf printer");

   pdfPrinter.PrinterSettings.PrinterName = printerName;
   pdfPrinter.SerialNumber = "MY_LICENSE";
   pdfPrinter.SilentPrinting = true;
   pdfPrinter.PageSettings.Margins.Bottom = 0;
   pdfPrinter.PageSettings.Margins.Left = 0;
   pdfPrinter.PageSettings.Margins.Right = 0;
   pdfPrinter.PageSettings.Margins.Top = 0;
   pdfPrinter.PageSettings.Landscape = true;

   logger.LogInformation("About to print document");
   pdfPrinter.PrintPdf(fileBytes);
   logger.LogInformation("Document should be printed now");
 }
 catch (Exception e)
 {
   logger.LogError($"Error when printing.  Exception: {e}. Message: {e.Message}");
    throw;
 }
    }
    class ProcessSpawnMethod

{
    static void SetAsDefaultPrinter(string printerDevice)
    {
        foreach (var printer in PrinterSettings.InstalledPrinters)
        {
            //verify that the printer exists here
        }
        var path = "win32_printer.DeviceId='" + printerDevice + "'";
        using (var printer = new ManagementObject(path))
        {
            printer.InvokeMethod("SetDefaultPrinter",
                                 null, null);
        }

        return;
    }
    public void PrintHtml(string htmlPath, string printerDevice)
    {
        if (!string.IsNullOrEmpty(printerDevice))
            SetAsDefaultPrinter(printerDevice);


        Task.Factory.StartNew(() => PrintOnStaThread(htmlPath), CancellationToken.None, TaskCreationOptions.None, _sta).Wait();
    }
    public void printdoc(string document)
    {
        Process printjob = new Process();
        printjob.StartInfo.FileName = document;
        printjob.StartInfo.UseShellExecute = true;
        printjob.StartInfo.Verb = "print";
        printjob.StartInfo.CreateNoWindow = true;
        printjob.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        printjob.Start();
    }
    public void Print()

    {

        //PrintDialog printDialog1 = new PrintDialog();

        //printDialog1.PrinterSettings.PrinterName = "EasyCoder 91 DT (203 dpi)";

        System.Diagnostics.Process process = new System.Diagnostics.Process();

        process.Refresh();

        //process.StartInfo.Arguments = "EasyCoder 91 DT (203 dpi)";

        process.StartInfo.CreateNoWindow = true;

        process.StartInfo.Verb = "print";

        process.StartInfo.FileName = @"C:\\MyFile.txt";

        process.StartInfo.UseShellExecute = true;

        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.Start();
    }
}
    //    Windows Service
    //    And here is the code for Windows Service, to test the above methods.
    //protectedoverride void OnStart(string[] args)
    // {
    //        //PrintDocumentMethod way----
    //        WindowsFormsApplication1.PrintDocumentMethod printDoc = new WindowsFormsApplication1.PrintDocumentMethod();
    //        //printDoc.ChangeDefaultPrinter("SATO CG212");  // to change default printer.
    //        printDoc.Printing("SATO CG212");
    //        //ProcessSpawnMethod---
    //        //ProcessSpawnMethod pspawn = new ProcessSpawnMethod();
    //        //pspawn.Print();
    //    }


}

namespace WindowsFormsApplication1

{

    public static class myPrinters

    {

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern bool SetDefaultPrinter(string Name);

    }

    public class PrintDocumentMethod

    {

        // private Font printFont;

        private Stream IOStream;

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)

        {

            ev.Graphics.DrawImage(Image.FromStream(IOStream, true, false), ev.Graphics.VisibleClipBounds);

            ev.HasMorePages = false;

        }

        public void ChangeDefaultPrinter(string pname)

        {

            myPrinters.SetDefaultPrinter(pname);

        }

        public void Printing(string pname)

        {

            try

            {

                IOStream = new FileStream("C:\\scanned.jpeg", FileMode.Open, FileAccess.Read);

                //streamToPrint = new StreamReader(IOStream);

                try

                {

                    printFont = new Font("Arial", 10);

                    PrintDocument pd = new PrintDocument();

                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                    // Specify the printer to use.

                    pd.PrinterSettings.PrinterName = pname;

                    pd.Print();

                }

                finally

                {

                    IOStream.Close();

                }

            }

            catch (Exception ex)

            {

                EventLog e = new EventLog("Print Error");

                e.WriteEntry("Failed in Printing, Reason:" + ex.Message);

            }

        }

    }

}

//
TaskScheduler Sta = new StaTaskScheduler(1);
public void PrintHtml(string htmlPath)
{
    Task.Factory.StartNew(() => PrintOnStaThread(htmlPath), CancellationToken.None, TaskCreationOptions.None, Sta).Wait();
}

void PrintOnStaThread(string htmlPath)
{
    const short PRINT_WAITFORCOMPLETION = 2;
    const int OLECMDID_PRINT = 6;
    const int OLECMDEXECOPT_DONTPROMPTUSER = 2;
    using (var browser = new WebBrowser())
    {
        browser.Navigate(htmlPath);
        while (browser.ReadyState != WebBrowserReadyState.Complete)
            Application.DoEvents();

        dynamic ie = browser.ActiveXInstance;
        ie.ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_DONTPROMPTUSER, PRINT_WAITFORCOMPLETION);
    }
}

//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: StaTaskScheduler.cs
//
//--------------------------------------------------------------------------

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace System.Threading.Tasks.Schedulers
{
    /// <summary>Provides a scheduler that uses STA threads.</summary>
    public sealed class StaTaskScheduler : TaskScheduler, IDisposable
    {
        /// <summary>Stores the queued tasks to be executed by our pool of STA threads.</summary>
        private BlockingCollection<Task> _tasks;
        /// <summary>The STA threads used by the scheduler.</summary>
        private readonly List<Thread> _threads;

        /// <summary>Initializes a new instance of the StaTaskScheduler class with the specified concurrency level.</summary>
        /// <param name="numberOfThreads">The number of threads that should be created and used by this scheduler.</param>
        public StaTaskScheduler(int numberOfThreads)
        {
            // Validate arguments
            if (numberOfThreads < 1) throw new ArgumentOutOfRangeException("concurrencyLevel");

            // Initialize the tasks collection
            _tasks = new BlockingCollection<Task>();

            // Create the threads to be used by this scheduler
            _threads = Enumerable.Range(0, numberOfThreads).Select(i =>
            {
                var thread = new Thread(() =>
                {
                    // Continually get the next task and try to execute it.
                    // This will continue until the scheduler is disposed and no more tasks remain.
                    foreach (var t in _tasks.GetConsumingEnumerable())
                    {
                        TryExecuteTask(t);
                    }
                });
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                return thread;
            }).ToList();

            // Start all of the threads
            _threads.ForEach(t => t.Start());
        }

        /// <summary>Queues a Task to be executed by this scheduler.</summary>
        /// <param name="task">The task to be executed.</param>
        protected override void QueueTask(Task task)
        {
            // Push it into the blocking collection of tasks
            _tasks.Add(task);
        }

        /// <summary>Provides a list of the scheduled tasks for the debugger to consume.</summary>
        /// <returns>An enumerable of all tasks currently scheduled.</returns>
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            // Serialize the contents of the blocking collection of tasks for the debugger
            return _tasks.ToArray();
        }

        /// <summary>Determines whether a Task may be inlined.</summary>
        /// <param name="task">The task to be executed.</param>
        /// <param name="taskWasPreviouslyQueued">Whether the task was previously queued.</param>
        /// <returns>true if the task was successfully inlined; otherwise, false.</returns>
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // Try to inline if the current thread is STA
            return
                Thread.CurrentThread.GetApartmentState() == ApartmentState.STA &&
                TryExecuteTask(task);
        }

        /// <summary>Gets the maximum concurrency level supported by this scheduler.</summary>
        public override int MaximumConcurrencyLevel
        {
            get { return _threads.Count; }
        }

        /// <summary>
        /// Cleans up the scheduler by indicating that no more tasks will be queued.
        /// This method blocks until all threads successfully shutdown.
        /// </summary>
        public void Dispose()
        {
            if (_tasks != null)
            {
                // Indicate that no new tasks will be coming in
                _tasks.CompleteAdding();

                // Wait for all threads to finish processing tasks
                foreach (var thread in _threads) thread.Join();

                // Cleanup
                _tasks.Dispose();
                _tasks = null;
            }
        }
    }
}
//
//
#region SendPDFToPrinter
//Added on 17.06.2016  for printing PDF silently
public void SendPDFToPrinter(string pathPdf)
{
    try
    {
        ProcessStartInfo infoPrintPdf = new ProcessStartInfo();
        //pathPdf = @"D:\ITC.pdf";
        infoPrintPdf.FileName = pathPdf;
        // The printer name is hardcoded here, but normally I get this from a combobox with all printers
        string printerName = System.Configuration.ConfigurationManager.AppSettings["PrinterName"].ToString();
        //string printerName = "HP LaserJet Professional P1606dn";
        string driverName = System.Configuration.ConfigurationManager.AppSettings["DriverName"].ToString();
        string portName = System.Configuration.ConfigurationManager.AppSettings["portName"].ToString();
        infoPrintPdf.FileName = System.Configuration.ConfigurationManager.AppSettings["AcrobatExePath"].ToString();
        infoPrintPdf.Arguments = string.Format("/t {0} \"{1}\" \"{2}\" \"{3}\"",
            pathPdf, printerName, driverName, portName);
        infoPrintPdf.CreateNoWindow = true;
        infoPrintPdf.UseShellExecute = false;
        infoPrintPdf.WindowStyle = ProcessWindowStyle.Hidden;
        Process printPdf = new Process();
        printPdf.StartInfo = infoPrintPdf;
        printPdf.Start();

        // This time depends on the printer, but has to be long enough to
        // let the printer start printing
        System.Threading.Thread.Sleep(10000);

        if (!printPdf.CloseMainWindow())              // CloseMainWindow never seems to succeed
            printPdf.Kill();
        printPdf.WaitForExit();  // Kill AcroRd32.exe

        printPdf.Close();  // Close the process and release resources
    }
    catch (Exception ex)
    {

    }


}
//End
#endregion
//
