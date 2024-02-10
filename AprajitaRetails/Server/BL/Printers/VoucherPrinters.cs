using System;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Helpers.Printer;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.ViewModels;

namespace AprajitaRetails.Server.BL.Printers
{
    public class VoucherPrinters
    {
       public static MemoryStream VoucherPrinter(bool Page2Inch, StoreBasicDTO store, Voucher voucher, int copy=2, int isReprinted=false){
        
       }


        public static MemoryStream InvoicePrinter(bool Page2Inch, SaleDetailsDTO details, StoreBasicDTO store, string CustomerName, string MobileNo, int copy, bool isReprinted)
        {
            InvoicePrinter ip = new InvoicePrinter
            {
                Page2Inch = Page2Inch,
                Phone = store.StorePhoneNumber,
                Reprint = isReprinted,
                ServiceBill = details.Invoice.Tailoring,
                PaymentDetails = new List<Shared.Models.Inventory.SalePaymentDetail>(),
                Address = "Bhaglpur Raod",
                City = store.City,
                TaxNo = store.GSTIN,
                StoreName = store.StoreName,
                SaleItems = details.Items,
                CardDetails = details.CardPayment,
                ProductSale = details.Invoice,
                FileName = $"{details.Invoice.InvoiceNo}.pdf",
                PathName = @"/Data/Vouchers/SaleInvoice/",
                InvoiceSet = true,
                CustomerName = CustomerName,
                MobileNumber = MobileNo,
                NoOfCopy = copy
            };

            ip.PaymentDetails.Add(details.PaymentDetail);
            return ip.InvoiceThermalPdf();



        }
    }
}

