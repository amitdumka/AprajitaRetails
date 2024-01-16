using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Importer
{
    public class ImportHelper
    {
        private ARDBContext aRDB;
        private IWebHostEnvironment hostingEnv;

        public ImportHelper(IWebHostEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env; aRDB = db;
        }

        public DbContext GetContact()
        { return aRDB; }

        public IWebHostEnvironment GetHostEnvironment()
        { return hostingEnv; }
    }

    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}