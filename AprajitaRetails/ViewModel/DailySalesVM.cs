using AprajitaRetails.Data;
using AprajitaRetails.DataModel;
using System;
using System.Collections.Generic;

namespace AprajitaRetails.ViewModel
{   //TODO: Make static function to getID of tables so it will less memory uses and fast
    internal class DailySalesVM
    {
        private DailySaleDB DB;

        public DailySalesVM( )
        {
            Logs.LogMe("DailySaleVM: Creating DailySaleDB Object");
            DB = new DailySaleDB();
            Logs.LogMe("DailySaleVM: DailySaleDB object created");
        }

        public List<SortedDictionary<string, string>> GetSaleList( )
        {
            return DB.GetSaleList();
        }

        public List<string> GetMobileNoList( )
        {
            return DB.GetMobileNoList();
        }

        public string AddData( )
        {
            return "";
            //GenerateInvoiceNo ();
        }

        public string GenerateInvoiceNo( )
        {
            throw new NotImplementedException();
        }

        public int GetCustomerID( string mobile )
        {  //TODO: Make CustomerID function static
            CustomerDB cDM = new CustomerDB();
            return cDM.GetID("MobileNo", mobile);
        }

        public SaleInfo GetSaleInfo( )
        {
            return DB.GetSaleInfo();
        }

        public string GetCustomerName( int id )
        {
            return DB.GetCustomerName(id);
        }

        public string GetCustomerName( string mobileNo )
        {
            return DB.GetCustomerName(mobileNo);
        }

        public bool SaveData( DailySaleDM data )
        {
            bool status = false;
            DailySale dailySale = new DailySale()
            {
                ID = -1,
                Discount = data.Discount,
                Fabric = data.Fabric,
                Amount = data.Amount,
                InvoiceNo = data.InvoiceNo,
                RMZ = data.RMZ,
                SaleDate = data.SaleDate,
                Tailoring = data.Tailoring,
                PaymentMode = data.PaymentMode,
                CustomerID = GetCustomerID(data.CustomerMobileNo)
            };
            if (DB.InsertData(dailySale) > 0)
            {
                status = true;
                Logs.LogMe("DailySale is added!");
            }
            if (data.NewCustomer == 1)
            {
                NewCustomer newCust = new NewCustomer()
                {
                    CustomerID = dailySale.CustomerID,
                    ID = -1,
                    InvoiceNo = data.InvoiceNo,
                    OnDate = data.SaleDate,
                    CustomerFullName = data.CustomerFullName
                };
                NewCustomerDB nDB = new NewCustomerDB();
                if (nDB.Insert(newCust) > 0)
                {
                    status = true;
                }
                else
                {
                    if (status)
                    {
                        Logs.LogMe("New Customer Data not able to add!");
                    }
                }
            }
            return status;
        }

        public void InsertInvoiceDetails( DailySaleDM data )
        {
        }

        public DailySale GetInvoiceDetails( string invoiceno )
        {
            return DB.GetByColName("InvoiceNo", invoiceno);
        }

        public DailySale GetInvoiceDetails( int id )
        {
            return DB.GetByID(id);
        }

        public void UpdateInvoiceDetails( DailySaleDM data )
        {
        }

        public void DeleteInvoiceNo( string invoiceno )
        {
        }

        /// <summary>
        /// Get all Payment Modes
        /// </summary>
        /// <returns></returns>
        public List<PaymentMode> GetPaymentTypes( )
        {
            List<PaymentMode> listItem = new List<PaymentMode>();
            Logs.LogMe("GetPaymentTypes():Calling GetDataForm");
            List<SortedDictionary<string, string>> result = DB.GetDataFrom("PaymentMode");
            foreach (SortedDictionary<string, string> item in result)
            {
                PaymentMode mode = new PaymentMode()
                {
                    ID = Int32.Parse(item["ID"]),
                    PayMode = item["PayMode"]
                };
                listItem.Add(mode);
            }
            return listItem;
        }
    }
}