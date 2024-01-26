using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Shared.Constants
{
    public static class AKSConstant
    {

        //Import File Constant 
        public const string ProductItems = "ProductItem.json";
        public const string ProductPurchase = "ProductPurchase.json";
        public const string Stocks = "Stocks.json";
        public const string PurchaseItems = "PurchaseItems.json";
        public const string PurchaseInvoice = "PurchaseInvoice.json";

        public const string ImportedObjects = "ImportedObjects";

        public static ExcelFile Dumka = new() { StoreCode = "ARD", SheetName = "MasterData", Range = "A1:AA7037" };
        public static ExcelFile Jamshedpur = new() { StoreCode = "ARJ", SheetName = "JamshedpurData", Range = "A1:AA4401" };
        public static ExcelFile InearWear = new() { StoreCode = "ARJ", SheetName = "InnearWear Sheet", Range = "A1:AA131" };

    }

    public class ExcelFile
    {
        public string StoreCode { get; set; }
        public string SheetName { get; set; }
        public string Range { get; set; }
    }
}
