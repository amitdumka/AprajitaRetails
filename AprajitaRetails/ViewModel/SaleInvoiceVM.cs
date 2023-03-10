using AprajitaRetails.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace AprajitaRetails.ViewModel
{
    public enum TaxType { Vat = 0, Gst = 1, SGST = 2, CGST = 3, IGST = 4 }

    public enum SalePayMode { Cash = 1, Card = 2, Mix = 3 }

    public class UtilOps
    {
        public static string PrinterName = new PrintDocument().PrinterSettings.PrinterName;

        public static int TaxMode( TaxType taxType )
        {
            switch (taxType)
            {
                case TaxType.IGST:
                    return 4;

                case TaxType.Gst:
                    return 1;

                case TaxType.CGST:
                    return 3;

                case TaxType.SGST:
                    return 2;

                case TaxType.Vat:
                    return 0;

                default:
                    return -999;
            }
        }

        public static TaxType TaxMode( int taxType )
        {
            switch (taxType)
            {
                case 4:
                    return TaxType.IGST;

                case 1:
                    return TaxType.Gst;

                case 3:
                    return TaxType.CGST;

                case 2:
                    return TaxType.SGST;

                case 0:
                    return TaxType.Vat;

                default:
                    return TaxType.Gst;
            }
        }

        /// <summary>
        /// Get Sale Payment Mode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns>return Mode in interger , on error returns 1(Cash)</returns>
        public static int GetSalePayMode( SalePayMode mode )
        {
            if (mode == SalePayMode.Card)
                return 2;
            if (mode == SalePayMode.Cash)
                return 1;
            if (mode == SalePayMode.Mix)
                return 3;
            return 1;
        }

        /// <summary>
        /// SalePayMode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns> Return Sale Payment mode, default or on error return cash</returns>
        public static SalePayMode GetSalePayMode( int mode )
        {
            if (mode == 1)
                return SalePayMode.Cash;
            if (mode == 2)
                return SalePayMode.Card;
            if (mode == 3)
                return SalePayMode.Mix;
            return SalePayMode.Cash;
        }
    }

    internal abstract class Taxes
    {
        public int ID { set; get; }
        public TaxType TaxType { set; get; }
        public double TotalTaxAmount { set; get; }

        public abstract Taxes TaxAmount( TaxType type, double BillAmount, double rate );
    }

    internal class VAT : Taxes
    {
        //public int ID { set; get; }
        public double VatRate { set; get; }

        public double VatAmount { set; get; }

        public override Taxes TaxAmount( TaxType type, double BillAmount, double rate )
        {
            if (type == TaxType.Vat)
            {
                VatRate = rate;
                VatAmount = BillAmount - ((BillAmount * rate) / 100);
                TotalTaxAmount = VatAmount;
                return this;
            }
            else
            { return null; }
        }
    }

    internal class GST : Taxes
    {
        // public int ID { set; get; }
        public double CGSTRate { set; get; }

        public double SGSTRate { set; get; }
        public double IGSTRate { set; get; }

        public double IGSTAmount { set; get; }
        public double CGSTAmount { set; get; }
        public double SGSTAmount { set; get; }

        public override Taxes TaxAmount( TaxType type, double BillAmount, double rate )
        {   //TODO: Check and verify for GST Tax Calculation.
            if (type == TaxType.Gst)
            {
                CGSTRate = rate / 2;
                SGSTRate = rate / 2;
                TotalTaxAmount = BillAmount - ((BillAmount * rate) / 100);
                CGSTAmount = TotalTaxAmount / 2;
                SGSTAmount = CGSTAmount;
                return this;
            }
            else if (type == TaxType.SGST || type == TaxType.CGST)
            {
                CGSTRate = rate / 2;
                SGSTRate = rate / 2;
                TotalTaxAmount = BillAmount - ((BillAmount * rate) / 100);
                CGSTAmount = TotalTaxAmount / 2;
                SGSTAmount = CGSTAmount;
                return this;
            }
            else if (type == TaxType.IGST)
            {
                TotalTaxAmount = BillAmount - ((BillAmount * rate) / 100);
                return this;
            }
            else
            {
                return null;
            }
        }
    }

    internal class ProductCategory
    {
        public static readonly int Fabric = 1;
        public static readonly int RMZ = 2;
        public static readonly int Accessiories = 3;
        public static readonly int Tailoring = 4;
    }

    internal class StockItem
    {
        public int ID { set; get; }
        public int ProductId { set; get; }
        public double QTY { set; get; }
    }

    internal class ProductItems
    {
        public int ID { set; get; }
        public string StyleCode { get; set; }
        public string Barcode { get; set; }

        public string SupplierId { get; set; }

        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ItemDesc { get; set; }

        public double MRP { get; set; }
        public double Tax { get; set; }    // TODO:Need to Review in final Edition
        public double Cost { get; set; }

        public string Size { get; set; }
        public double Qty { get; set; }
        //GST Implementation    Version 1.0
        //TODO: GST implementation should use Taxes Class
        //public double HSNCode { get; set; }
        //public int PreGST { get; set; }
        //public double SGST { get; set; }
        //public double CGST { get; set; }
        //public double IGST { get; set; }
    }

    internal class Salesman
    {
        public int ID
        {
            set; get;
        }

        public string SMCode { get; set; }
        public string SalesmanName { get; set; }
    }

    internal class Supplier
    {
        public int ID { get; set; }
        public string SuppilerName { get; set; }
        public string Warehouse { get; set; }
    }

    internal class SaleReturnInvoice
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string SaleInvoiceNo { get; set; }
        public string ReturnInvoiceNo { get; set; }
        public double TotalQty { get; set; }
        public int TotalReturnItem { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime OnDate { get; set; }
        public string NewSaleInvoiceNo { get; set; }
        public string Debit_CreditNotesNo { get; set; }
        public int SalesmanId { get; set; }
    }

    internal class SaleInvoice
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public DateTime OnDate { get; set; }
        public string InvoiceNo { get; set; }
        public int TotalItems { get; set; }
        public double TotalQty { get; set; }
        public double TotalBillAmount { get; set; }
        public double TotalDiscountAmount { get; set; }
        public double RoundOffAmount { get; set; }
        public double TotalTaxAmount { get; set; }
    }

    internal class PaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int PayMode { get; set; }
        public double CashAmount { get; set; }
        public double CardAmount { get; set; }
        public int CardDetailsID { get; set; }
    }

    internal class SalePaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int PayMode { get; set; }
        public double CashAmount { get; set; }
        public double CardAmount { get; set; }
        public CardPaymentDetails CardDetails { get; set; }
    }

    internal class CardMode
    {
        public static readonly int DebitCard = 1;
        public static readonly int CreditCard = 2;
        public static readonly int AmexCard = 3;
    }

    internal class CardType
    {
        public static readonly int Visa = 1;
        public static readonly int MasterCard = 2;
        public static readonly int Mastro = 3;
        public static readonly int Amex = 4;
        public static readonly int Dinners = 5;
        public static readonly int Rupay = 6;
    }

    internal class CardPaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int CardType { get; set; }
        public double Amount { get; set; }
        public int AuthCode { get; set; }
        public int LastDigit { get; set; }
    }

    internal class SaleItem
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public string BarCode { get; set; }
        public double Qty { get; set; }
        public double MRP { get; set; }
        public double BasicAmount { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double BillAmount { get; set; }
        public int SalesmanID { get; set; }
    }

    //-----------------------------------------------------------------------

    internal class SaleInvoiceVM
    {
        //Fields
        private SalesmanDB smDB;

        private SaleInvoiceDB sDB;
        private ProductItemsDB pDB;
        private SaleItemsDB siDB;
        private CardPaymentDB cpDB;
        private PaymentDetailDB payDB;
        private const string ManualSeries = "MI";
        private const long SeriesStart = 10000000;

        //Constructor
        public SaleInvoiceVM( )
        {
            smDB = new SalesmanDB();
            sDB = new SaleInvoiceDB();
            pDB = new ProductItemsDB();
            siDB = new SaleItemsDB();
            payDB = new PaymentDetailDB();
            cpDB = new CardPaymentDB();
        }

        public void SampleSalesman( )
        {
            smDB.SampleData();
        }

        public List<Salesman> GetSalesmanList( )
        {
            return smDB.GetAllRecord();
        }

        public List<string> GetSalesmanNameList( )
        {
            List<string> list = new List<string>();
            List<Salesman> salesman = smDB.GetAllRecord();
            foreach (Salesman data in salesman)
            {
                list.Add(data.SalesmanName);
            }
            return list;
        }

        public string GetSalesmanName( int id )
        {
            if (id > 0)
                return smDB.GetByID(id).SalesmanName;
            else
                return "NotFound";
        }

        public string GetSalesmanName( string smcode )
        {
            if (smcode != null && smcode != "")
                return smDB.GetByColName("SMCode", smcode).SalesmanName;
            return "NotFound";
        }

        public int GetSalesmanID( string salesmanname, string smcode )
        {
            if (salesmanname != null && salesmanname != "")
                return smDB.GetID("SalesmanName", salesmanname);

            if (smcode != null && smcode != "")
                return smDB.GetID("SMCode", smcode);
            return -1;
        }

        public string GetSalesmanCode( int id )
        {
            if (id > 0)
                return smDB.GetByID(id).SMCode;
            else
                return "NotFound";
        }

        public string GetSalesmanCode( string salesman )
        {
            if (salesman != null && salesman != "")
                return smDB.GetByColName("SalesmanName", salesman).SMCode;
            return "NotFound";
        }

        public List<string> GetBarCodesList( int x )
        {
            return pDB.GetBarCodeList(x);
        }

        //Functions/Methods
        public void AddData( ) { }

        public int SaveInvoiceData( SaleInvoice saleInv, DataTable itemTable, SalePaymentDetails payDetails )
        {    //TODO: Urgent SaveInoviceData.
            int status = SaveData(saleInv);
            if (status > 0)
            {
                string invNo = sDB.GetLastInvoiceNo();
                status = SaveItemsDetails(itemTable);
                if (status > 0)
                {
                    payDetails.InvoiceNo = invNo;
                    int status2 = -1;
                    bool modef = false;
                    if (payDetails.PayMode == UtilOps.GetSalePayMode(SalePayMode.Card) || payDetails.PayMode == UtilOps.GetSalePayMode(SalePayMode.Mix))
                    {
                        modef = true;
                        payDetails.CardDetails.InvoiceNo = invNo;
                        status2 = SaveCardDetails(payDetails.CardDetails);
                        int cardDetailsId = 0;
                        status = SavePaymentDetails(payDetails, cardDetailsId);
                    }
                    else
                    {
                        //For CashPayment
                        status = SavePaymentDetails(payDetails, -1);
                    }

                    if (modef && status > 0 && status2 > 0)
                    {
                        return 1;
                    }
                    else if (modef == false && status > 0)
                        return 1;
                    else if (modef && status <= 0 || status2 <= 0)
                        return -3;
                    else
                        return -4;
                    //TODO: Make Error Code so easy to debug and handle
                }
                else
                    return -2;
            }
            else
            {
                return -1;
            }
        }

        public int SaveData( SaleInvoice obj )
        {
            return sDB.InsertData(obj);
        }

        public int SaveItemsDetails( DataTable itemTable )
        {
            return siDB.InsertData(itemTable);
        }

        public int SavePaymentDetails( SalePaymentDetails pd, int cardDetailsID )
        {
            PaymentDetails payDetails = new PaymentDetails()
            {
                CardAmount = pd.CardAmount,
                CashAmount = pd.CashAmount,
                InvoiceNo = pd.InvoiceNo,
                PayMode = pd.PayMode,
                CardDetailsID = cardDetailsID,
                ID = pd.ID
            };
            return payDB.InsertData(payDetails);
        }

        public int SaveCardDetails( CardPaymentDetails cardDetails )
        {
            return cpDB.InsertData(cardDetails);
        }

        public List<string> GetInvoiceNoList( )
        {
            return sDB.GetInvoiceList();
        }

        public SortedDictionary<string, string> GetCustomerInfo( string mobileNo )
        {
            if (mobileNo.Trim().Length <= 0)
                return null;
            return sDB.GetCustomerInfo(0, mobileNo, 2);
        }

        public SortedDictionary<string, string> GetCustomerInfo( int custId )
        {
            return sDB.GetCustomerInfo(custId, "", 1);
        }

        public List<string> GetCustomerMobileNoList( )
        {
            return sDB.GetCustomerMobileList();
        }

        public List<SortedDictionary<string, string>> GetItemDetails( string barcode )
        {
            return sDB.GetItemDetails(barcode);
        }

        public ProductItems GetProductItemDetais( string barcode )
        {
            return pDB.GetProductItemDetais(barcode);
        }

        //Calucation Section
        public void CalculateTotalSaleAmount( ) { }

        public void CalculateTotalTaxAmount( )
        {
        }

        public void CalculateTotalDiscountAmount( )
        {
        }

        internal SortedDictionary<string, string> GetInvoiceDetails( string invoiceNo )
        {
            throw new NotImplementedException();
        }

        public int GetInvoiceNoList( ComboBox cBInvoiceNo )
        {
            List<string> itemList = GetInvoiceNoList();
            foreach (string item in itemList)
            {
                cBInvoiceNo.Items.Add(item);
            }
            return itemList.Count;
        }

        public int GetCustomerMobileNoList( ComboBox cBMobileNo )
        {
            List<string> itemList = GetCustomerMobileNoList();
            foreach (string item in itemList)
            {
                cBMobileNo.Items.Add(item);
            }
            return itemList.Count;
        }

        public InvoiceNo GenerateInvoiceNo( )
        {
            InvoiceNo inv = new InvoiceNo(ManualSeries);
            //TODO: series Start should be changed every Finnical Year;
            //TODO: Should have option to check data and based on that generate it
            string iNo = sDB.GetLastInvoiceNo();
            if (iNo.Length > 0)
            {
                if (iNo != "0")
                {
                    Logs.LogMe("Inv=" + iNo);
                    iNo = iNo.Substring(5);
                    Logs.LogMe("Inv=" + iNo);
                    long i = long.Parse(iNo);
                    Logs.LogMe("Inv=" + i);
                    inv.TP = i + 1;
                }
                else
                { inv.TP = SeriesStart + 1; }
            }
            else
            {
                //TODO: check future what happens and what condtion  come here
                inv.TP = SeriesStart + 1;
                Logs.LogMe("Future check :Inv=" + inv.TP);
            }
            return inv;
        }
    }

    //-------------------------------------------------------------------------
    internal class SalesmanDB : DataOps<Salesman>
    {
        public void SampleData( )
        {
            InsertData(new Salesman { ID = -1, SalesmanName = "Sanjeev", SMCode = "SM001" });
            InsertData(new Salesman { ID = -1, SalesmanName = "Mukesh", SMCode = "SM002" });
            InsertData(new Salesman { ID = -1, SalesmanName = "Santosh", SMCode = "SM003" });
        }

        public override int InsertData( Salesman obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@SalesmanName", obj.SalesmanName);
            cmd.Parameters.AddWithValue("@SMCode", obj.SMCode);
            return Db.Insert(cmd);
        }

        public override Salesman ResultToObject( List<Salesman> data, int index )
        {
            return data[index];
        }

        public override Salesman ResultToObject( SortedDictionary<string, string> data )
        {
            Salesman salesman = new Salesman
            {
                ID = int.Parse(data["ID"]),
                SalesmanName = data["SalesmanName"],
                SMCode = data["SMCode"]
            };
            return salesman;
        }

        public override List<Salesman> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<Salesman> list = new List<Salesman>();
            foreach (var data in dataList)
            {
                Salesman salesman = new Salesman
                {
                    ID = int.Parse(data["ID"]),
                    SalesmanName = data["SalesmanName"],
                    SMCode = data["SMCode"]
                };
                list.Add(salesman);
            }
            return list;
        }
    }

    internal class PaymentDetailDB : DataOps<PaymentDetails>
    {
        public override int InsertData( PaymentDetails obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue("@CardAmount", obj.CardAmount);
            cmd.Parameters.AddWithValue("@CardDetailsID", obj.CardDetailsID);
            cmd.Parameters.AddWithValue("@CashAmount", obj.CashAmount);
            cmd.Parameters.AddWithValue("@PayMode", obj.PayMode);
            return Db.Insert(cmd);
        }

        public override PaymentDetails ResultToObject( List<PaymentDetails> data, int index )
        {
            throw new NotImplementedException();
        }

        public override PaymentDetails ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<PaymentDetails> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }

    internal class CardPaymentDB : DataOps<CardPaymentDetails>
    {
        public override int InsertData( CardPaymentDetails obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@AuthCode", obj.AuthCode);
            cmd.Parameters.AddWithValue("@CardType", obj.CardType);
            cmd.Parameters.AddWithValue("@LastDigit", obj.LastDigit);
            return Db.Insert(cmd);

            //throw new NotImplementedException ();
        }

        public override CardPaymentDetails ResultToObject( List<CardPaymentDetails> data, int index )
        {
            throw new NotImplementedException();
        }

        public override CardPaymentDetails ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<CardPaymentDetails> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }

    internal class SaleInvoiceDB : DataOps<SaleInvoice>
    {
        /// <summary>
        /// Get Item Details Based on BarCode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public List<SortedDictionary<string, string>> GetItemDetails( string barcode )
        { //TODO: VerifY Uses.
            string sql = "select * from ProductItem where BarCode=@barcode ";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            return DataBase.GetSqlStoreProcedureString(cmd);
        }

        /// <summary>
        /// Get Last Invoice No
        /// </summary>
        /// <returns></returns>
        public string GetLastInvoiceNo( )
        {
            string sql = "select ISNULL( Max(ID),0) from  " + Tablename;
            string inv = "";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            int ids = (int)cmd.ExecuteScalar();

            if (ids > 0)
            {
                sql = "select InvoiceNo from " + Tablename + " where ID=" + ids;
                cmd.CommandText = sql;
                inv = (string)cmd.ExecuteScalar();
            }
            else
            {
                inv = "0";
            }
            return inv;
        }

        /// <summary>
        /// Get Customer Mobile List
        /// </summary>
        /// <returns>Its return list of Mobile no of Customer</returns>
        public List<string> GetCustomerMobileList( )
        {
            string sql = "select MobileNo from Customer";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "MobileNo");
        }

        /// <summary>
        /// Get Customer Infomarion based on MobileNo or ID  Based on search mode
        /// </summary>
        /// <param name="id">CustomerID</param>
        /// <param name="mobileno">MobileNo</param>
        /// <param name="searchMode">Search Mode ID/Mobile</param>
        /// <returns></returns>
        public SortedDictionary<string, string> GetCustomerInfo( int id, string mobileno, int searchMode )
        {
            string sql = "select ID, FirstName, LastName, MobileNo from Customer where ";
            if (searchMode == 1)
            {
                sql = sql + " ID=" + id;
            }
            else if (searchMode == 2)
            {
                sql = sql + "MobileNo='" + mobileno + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            SortedDictionary<string, string> result = DataBase.GetSqlStoreProcedureString(cmd)[0];
            return result;
        }

        /// <summary>
        /// Get Invoice List
        /// </summary>
        /// <returns>returns List of Invoice</returns>
        public List<string> GetInvoiceList( )
        {
            string sql = "select InvoiceNo from SaleInvoice";
            //TODO: Urgent where OnDate=Year(2017)
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "InvoiceNo");
        }

        public override int InsertData( SaleInvoice obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@CustomerId", obj.CustomerId);
            cmd.Parameters.AddWithValue("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue("@OnDate", obj.OnDate);
            cmd.Parameters.AddWithValue("@RoundOffAmount", obj.RoundOffAmount);
            cmd.Parameters.AddWithValue("@TotalBillAmount", obj.TotalBillAmount);
            cmd.Parameters.AddWithValue("@TotalDiscountAmount", obj.TotalDiscountAmount);
            cmd.Parameters.AddWithValue("@TotalItems", obj.TotalItems);
            cmd.Parameters.AddWithValue("@TotalQty", obj.TotalQty);
            cmd.Parameters.AddWithValue("@TotalTaxAmount", obj.TotalTaxAmount);
            return Db.Insert(cmd);
            // throw new NotImplementedException ();
        }

        public override SaleInvoice ResultToObject( List<SaleInvoice> data, int index )
        {
            throw new NotImplementedException();
        }

        public override SaleInvoice ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<SaleInvoice> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }

    internal class ProductItemsDB : DataOps<ProductItems>
    {
        public List<string> GetBarCodeList( int x )
        {
            string sql = "select BarCode from " + this.Tablename + " where  Size = '44'";
            //select* from ProductItems where Size = '44'
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "BarCode");
        }

        public List<string> GetItemsList( )
        {
            string sql = "select StyleCode from " + this.Tablename;
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "StyleCode");
        }

        public List<string> GetItemsList( string condition, string value )
        {
            string sql = "select StyleCode from " + this.Tablename +
                " where " + condition + "=@value";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@value", value);
            return DataBase.GetQueryString(cmd, "StyleCode");
        }

        public ProductItems GetProductItemDetais( string barcode )
        {
            return this.GetByColName("Barcode", barcode);
        }

        public ProductItems GetProductItemByStyle( string styleCode )
        {
            return this.GetByColName("StyleCode", styleCode);
        }

        public bool IsStyleCodeExist( string styleCode )
        {
            string sql = "select Count(StyleCode) from " + Tablename + " where StyleCode=@code";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@code", styleCode);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
                return true;
            else
                return false;
        }

        public double GetQty( string styleCode )
        {
            string sql = "select Qty from " + Tablename + " where StyleCode=@code";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@code", styleCode);

            object count = cmd.ExecuteScalar();
            Console.WriteLine("Qty={0}", count);
            double c = double.Parse("" + count);
            return c;
        }

        public int UpdateQty( string styleCode, double qty, int mode )
        {
            double fQty = 0;
            double pQty = GetQty(styleCode);
            if (mode == 0)
                fQty = pQty + qty;
            else if (mode == 1)
                fQty = pQty - qty;
            string sql = "Update " + Tablename + " set Qty=" + fQty + "where StyleCode='" + styleCode + "'";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return cmd.ExecuteNonQuery();
        }

        public int InsertDataWithVerify( ProductItems obj )
        {
            if (IsStyleCodeExist(obj.StyleCode))
            {
                //Add Qty
                return UpdateQty(obj.StyleCode, obj.Qty, 0);
            }
            else
            {
                return InsertData(obj);
            }
        }

        public override int InsertData( ProductItems obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@Barcode", obj.Barcode);
            cmd.Parameters.AddWithValue("@BrandName", obj.BrandName);
            cmd.Parameters.AddWithValue("@Cost", obj.Cost);
            cmd.Parameters.AddWithValue("@ItemDesc", obj.ItemDesc);
            cmd.Parameters.AddWithValue("@MRP", obj.MRP);
            cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue("@Size", obj.Size);
            cmd.Parameters.AddWithValue("@StyleCode", obj.StyleCode);
            cmd.Parameters.AddWithValue("@SupplierId", obj.SupplierId);
            cmd.Parameters.AddWithValue("@Tax", obj.Tax);

            //GST Implementation
            /* cmd.Parameters.AddWithValue ("@CGST", obj.CGST);
             cmd.Parameters.AddWithValue ("@SGST", obj.SGST);
             cmd.Parameters.AddWithValue ("@IGST", obj.IGST);
             cmd.Parameters.AddWithValue ("@PreGST", obj.PreGST);
             cmd.Parameters.AddWithValue ("@HSNCode", obj.HSNCode);
              */
            return cmd.ExecuteNonQuery();
        }

        public override ProductItems ResultToObject( List<ProductItems> data, int index )
        {
            return data[index];
        }

        public override ProductItems ResultToObject( SortedDictionary<string, string> data )
        {
            if (data == null)
                return null;
            ProductItems pItem = new ProductItems()
            {
                ID = Basic.ToInt(data["ID"]),
                Tax = double.Parse(data["Tax"]),
                SupplierId = data["SupplierId"],
                StyleCode = data["StyleCode"],
                Size = data["Size"],
                Qty = double.Parse(data["Qty"]),
                Barcode = data["Barcode"],
                BrandName = data["BrandName"],
                Cost = double.Parse(data["Cost"]),
                ItemDesc = data["ItemDesc"],
                MRP = double.Parse(data["MRP"]),
                ProductName = data["ProductName"]
                /* CGST = double.Parse (data ["CGST"]),
                 HSNCode = double.Parse (data ["HSNCode"]),
                 IGST = double.Parse (data ["IGST"]),
                 SGST = double.Parse (data ["SGST"]),
                 PreGST = Int32.Parse (data ["PreGST"])*/
            };
            return pItem;
        }

        public override List<ProductItems> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<ProductItems> listItem = new List<ProductItems>();
            foreach (var data in dataList)
            {
                ProductItems pItem = new ProductItems()
                {
                    ID = Basic.ToInt(data["ID"]),
                    Tax = double.Parse(data["Tax"]),
                    SupplierId = data["SupploerId"],
                    StyleCode = data["StyleCode"],
                    Size = data["Size"],
                    Qty = double.Parse(data["Qty"]),
                    Barcode = data["Barcode"],
                    BrandName = data["BrandName"],
                    Cost = double.Parse(data["Cost"]),
                    ItemDesc = data["ItemDesc"],
                    MRP = double.Parse(data["MRP"]),
                    ProductName = data["ProductName"]/*,
                    CGST = double.Parse (data ["CGST"]),
                    HSNCode = double.Parse (data ["HSNCode"]),
                    IGST = double.Parse (data ["IGST"]),
                    SGST = double.Parse (data ["SGST"]),
                    PreGST = Int32.Parse (data ["PreGST"])*/
                };
                listItem.Add(pItem);
            }
            return listItem;
        }
    }

    internal class SaleItemsDB : DataOps<SaleItem>
    {
        public int InsertData( DataTable dt )
        {
            int ctr = 0;
            foreach (DataRow dr in dt.Rows)
            {
                SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
                cmd.Parameters.AddWithValue("@InvoiceNo", dr["InvoiceNo"]);
                cmd.Parameters.AddWithValue("@BarCode", dr["BarCode"]);
                cmd.Parameters.AddWithValue("@Qty", dr["Qty"]);
                cmd.Parameters.AddWithValue("@MRP", dr["MRP"]);
                cmd.Parameters.AddWithValue("@BasicAmount", dr["MRP"]);
                //TODO:urgent basic amount cal
                cmd.Parameters.AddWithValue("@Discount", dr["Discount"]);
                cmd.Parameters.AddWithValue("@Tax", dr["Tax"]);
                cmd.Parameters.AddWithValue("@BillAmount", dr["Amount"]);
                cmd.Parameters.AddWithValue("@SalesmanID", "001");
                //TODO: saleman need to add up

                if (cmd.ExecuteNonQuery() > 0)
                    ctr++;
            }
            return ctr;
        }

        public override int InsertData( SaleItem dr )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);

            cmd.Parameters.AddWithValue("@InvoiceNo", dr.InvoiceNo);
            cmd.Parameters.AddWithValue("@BarCode", dr.BarCode);
            cmd.Parameters.AddWithValue("@Qty", dr.Qty);
            cmd.Parameters.AddWithValue("@MRP", dr.MRP);
            cmd.Parameters.AddWithValue("@BasicAmount", dr.BasicAmount);
            cmd.Parameters.AddWithValue("@Discount", dr.Discount);
            cmd.Parameters.AddWithValue("@Tax", dr.Tax);
            cmd.Parameters.AddWithValue("@BillAmount", dr.BillAmount);
            cmd.Parameters.AddWithValue("@SalesmanID", dr.SalesmanID);
            return cmd.ExecuteNonQuery();
        }

        public override SaleItem ResultToObject( List<SaleItem> data, int index )
        {
            throw new NotImplementedException();
        }

        public override SaleItem ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<SaleItem> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }
}