using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AprajitaRetails.Server.BL.Inventory
{
    public class InventroyManager
    {
        //TODO: Need to Handle Purhchase , Sale and Stock , and InterStore transfer.

        public static bool UpdateStock(ARDBContext db, string storecode, List<SaleItem> items)
        {
            foreach (var tm in items)
            {
                var stk = db.Stocks.Where(c => c.StoreId == storecode && c.Barcode == tm.Barcode).FirstOrDefault();
                if (stk != null)
                {
                    if (tm.InvoiceType == InvoiceType.ManualSale || tm.InvoiceType == InvoiceType.ManualSaleReturn)
                    {
                        stk.HoldQty = tm.BilledQty + tm.FreeQty;
                    }
                    else
                    {
                        stk.SoldQty = tm.BilledQty + tm.FreeQty;
                    }
                    db.Stocks.Update(stk);
                }
                else
                {
                    Stock mStk = new Stock
                    {
                        MultiPrice = false,
                        StoreId = storecode,
                        Barcode = tm.Barcode,
                        EntryStatus = EntryStatus.Rejected,
                        CostPrice = 0,
                        MRP = (tm.Value + tm.DiscountAmount) / tm.BilledQty,
                        HoldQty = 0,
                        IsReadOnly = false,
                        MarkedDeleted = false,
                        PurchaseQty = 0,
                        SoldQty = 0,
                        Unit = tm.Unit,
                        UserId = "AUTOERRORADMIN"
                    };

                    if (tm.InvoiceType == InvoiceType.ManualSale || tm.InvoiceType == InvoiceType.ManualSaleReturn)
                    {
                        mStk.HoldQty = tm.BilledQty + tm.FreeQty;
                    }
                    else
                    {
                        mStk.SoldQty = tm.BilledQty + tm.FreeQty;
                    }
                    if (db.ProductItems.Find(tm.Barcode) != null)
                    {
                        ProductItem pi = new ProductItem
                        {
                            Barcode = tm.Barcode,
                            Description = "#missing",
                            MRP = mStk.MRP,
                            Name = "MISS",
                            Unit = mStk.Unit,
                            TaxType = TaxType.GST,
                            ProductCategory = ProductCategory.Others,
                            StyleCode = "",
                            Size = Size.NOTVALID,
                            HSNCode = "",
                            SubCategory = "Promo",
                            ProductTypeId = "PT00013",
                            BrandCode = "NOB"
                        };
                        db.ProductItems.Add(pi);
                    }
                    db.Stocks.Add(mStk);
                }
            }
            return db.SaveChanges() > 0;
        }

        public static void CleanUpStock(ARDBContext db, string storeid)
        {
            var stockList = db.Stocks.Where(c => c.StoreId == storeid).ToList();

            foreach (var item in stockList)
            {
                item.HoldQty = item.PurchaseQty = item.SoldQty = 0;
            }

            var purchase = db.PurchaseItems.Include(c => c.ProductItem).Include(c => c.PurchaseProduct).Where(c => c.PurchaseProduct.StoreId == storeid)
                .Select(c => new { c.Unit, c.ProductItem.MRP, Qty = c.Qty + c.FreeQty, CostPrice = c.CostPrice, c.Barcode }).ToList();

            var sale = db.SaleItems.Include(c => c.ProductSale).Where(c => c.ProductSale.StoreId == storeid)
                .Select(c => new { c.Barcode, c.BilledQty, c.FreeQty, c.InvoiceType })
                .ToList();
        }

        public static async Task<bool> StockCorrectionAsync(ARDBContext db, string storecode)
        {
            try
            {
                var purchases = await db.PurchaseItems.Include(c => c.PurchaseProduct)
                    .Where(c => c.PurchaseProduct.StoreId == storecode)
                    .GroupBy(c => c.Barcode)
                    .Select(c => new { Barcode = c.Key, Qty = c.Sum(x => x.Qty + x.FreeQty) })
                    .ToListAsync();
                var sales = await db.SaleItems.Include(c => c.ProductSale)
                    .Where(c => c.ProductSale.StoreId == storecode)
                    .GroupBy(c => c.Barcode)
                    .Select(c => new { Barcode = c.Key, Qty = c.Sum(x => x.BilledQty + x.FreeQty) })
                    .ToListAsync();
                var stocks = await db.Stocks.Where(c => c.StoreId == storecode).ToListAsync();
                // List<Stock> updateList = new List<Stock>();
                int x = 0;
                foreach (var stk in stocks)
                {
                    var ss = sales.Where(c => c.Barcode == stk.Barcode).FirstOrDefault();
                    if (ss != null)
                        stk.SoldQty = ss.Qty;
                    var pp = purchases.Where(c => c.Barcode == stk.Barcode).FirstOrDefault();
                    if (pp != null)
                        stk.PurchaseQty = pp.Qty;
                    db.Stocks.Update(stk);
                    ++x;
                }
                if (stocks.Count != x)
                {
                    Console.WriteLine("X doesnt match with stock");
                }
                Console.WriteLine($"X={x}/ Stock={stocks.Count}/ pur={purchases.Count}/ sales={sales.Count}");

                // db.Stocks.UpdateRange(stocks);
                return (await db.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<SortedDictionary<string, List<Stock>>> ReOraganiseStockAsync(ARDBContext db)
        {
            //Delete All Stock from List.
            var status = await db.Stocks.ExecuteDeleteAsync();
            //Create Stock Item List.
            var storescode = db.Stores.Select(c => c.StoreId).ToList();

            SortedDictionary<string, List<Stock>> stocks = new SortedDictionary<string, List<Stock>>();
            foreach (var sc in storescode)
            {
                var pStock = db.PurchaseItems.Include(c => c.ProductItem).Include(c => c.PurchaseProduct).Where(c => c.PurchaseProduct.StoreId == sc)
                .Select(c => new { c.Unit, c.ProductItem.MRP, Qty = c.Qty + c.FreeQty, CostPrice = c.CostPrice, c.Barcode }).ToList();

                var stock = pStock.GroupBy(c => c.Barcode)
                    .Select(c => new Stock
                    {
                        Id = Guid.NewGuid(),
                        Barcode = c.Select(x => x.Barcode).First(),
                        EntryStatus = EntryStatus.Added,
                        HoldQty = 0,
                        IsReadOnly = true,
                        MarkedDeleted = false,
                        SoldQty = 0,
                        UserId = "AutoAdmin",
                        Unit = c.Select(x => x.Unit).First(),
                        StoreId = sc,
                        PurchaseQty = c.Sum(x => x.Qty),
                        MRP = c.Select(x => x.MRP).Max(),
                        CostPrice = (c.Sum(x => (x.Qty * x.CostPrice)) / (c.Sum(x => x.Qty))),
                        MultiPrice = c.Count() > 1 ? true : false
                    }).OrderBy(c => c.MultiPrice).OrderBy(c => c.Barcode).ToList();
                stocks.Add(sc, stock);

                string JSONFILE = JsonSerializer.Serialize<List<Stock>>(stock);
                using StreamWriter writer = new StreamWriter(Path.Combine("", $"Data/{sc}_PurchaseStock.json"));
                await writer.WriteAsync(JSONFILE);
                writer.Close();

                var sStock = db.SaleItems.Include(c => c.ProductSale).Where(c => c.ProductSale.StoreId == sc)
                    .GroupBy(c => c.Barcode)
                    .Select(c => new { Barcode = c.Key, Qty = c.Sum(x => x.FreeQty + x.BilledQty) })
                    .ToList();
                foreach (var item in sStock)
                {
                    var stk = stock.Where(c => c.Barcode == item.Barcode).FirstOrDefault();
                    if (stk != null)
                    {
                        stk.SoldQty = item.Qty;
                    }
                }
                JSONFILE = JsonSerializer.Serialize<List<Stock>>(stock);
                using StreamWriter writer2 = new StreamWriter(Path.Combine("", $"Data/{sc}_WithSaleStock.json"));
                await writer2.WriteAsync(JSONFILE);
                writer.Close();
                //await  db.Stocks.AddRangeAsync(stock);
                //  int x = await db.SaveChangesAsync();
                // System.Console.WriteLine("x:" + x);
            }
            return stocks;
        }
    }
}