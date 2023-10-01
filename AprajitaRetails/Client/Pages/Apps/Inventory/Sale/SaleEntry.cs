using AprajitaRetails.Client.Pages.Apps.Accounts.Vouchers;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.Navigations;
using System.Reflection;

namespace AprajitaRetails.Client.Pages.Apps.Inventory.Sale
{
    public partial class SaleEntry
    {
        private string Title = "Sale Invoice ";
        private string backUrl = "/sales/false/Regular";

        private ProductSale? entity = new ProductSale { OnDate = DateTime.Now };
        private SalePaymentDetail payment = new SalePaymentDetail { PayMode = PayMode.Cash };
        private CardPaymentDetail cardPayment = new CardPaymentDetail { PaidAmount = 0 };
        private List<SaleItem>? saleItems = new List<SaleItem>();
        private IList<string> payModes = Enum.GetNames(typeof(PayMode));
        private IList<string> invTypes = Enum.GetNames(typeof(InvoiceType));
        private IList<string> cards = Enum.GetNames(typeof(CARD));
        private IList<string> cardTypes = Enum.GetNames(typeof(CARDType));
        private IList<SelectOption>? Stores;
        private IList<SelectOption>? Salesmen;
        private IList<SelectOption>? EDCList;
        private SItem Item = new SItem { Barcode = "", Amount = 0, Discount = 0, Qty = 0, Rate = 0, TaxAmount = 0, TaxRate = 0, Unit = Unit.Meters };

        private List<object> toolbar = new List<object>() { new ItemModel() { Text = "Add", TooltipText = "Add", PrefixIcon = "e-icons e-collapse", Id = "New" }, new ItemModel() { Text = "Delete", TooltipText = "Delete", PrefixIcon = "e-icons e-collapse", Id = "Delete" } };
        private List<GridColumn> Columns { get; set; }

        private SfGrid<SItem>? Grid;
        private List<SItem> SaleItemList = new List<SItem>();

        //Base Info
        private string InvoiceNumber = "";

        private InvoiceType invType = InvoiceType.Sales;
        private TaxType taxType = TaxType.GST;

        private void SetInvoiceMode()
        {
            if (Returns)
            {
                Title = Params + "'s Return";
            }
            else Title = Params;

            switch (Params)
            {
                case "Regular":
                    invType = Returns ? InvoiceType.SalesReturn : InvoiceType.Sales;
                    break;

                case "Manual": invType = Returns ? InvoiceType.ManualSaleReturn : InvoiceType.ManualSale; break;
                //case "Service":
                default:
                    invType = InvoiceType.Sales; break;
                    break;
            }
        }
        void KeyPressed(KeyboardEventArgs args)
        {
        //    if (args.Key == "5")
        //    {
        //        Console.WriteLine("5 was pressed");
        //    }
        }
        //private async void OnItemValChange(ChangedEventArgs args)
        //{
        //    Item.Amount = Item.Qty * Item.Rate - Item.Discount;
        //    StateHasChanged();
        //}
        private async void OnChange()
        {
            //Helper.Msg("OnChange", $"{Item.Qty} {Item.Discount}",false);
            Item.Amount = Item.Qty * Item.Rate - Item.Discount;
            StateHasChanged();
        }
        private async void OnBarcodeChange(ChangedEventArgs args)
        {
            // Here you can customize your code
            if (args.Value.Length > 8)
            {
                Helper.Msg("Barcode", args.Value);

                var stock = await Helper.FetchBarcodeAsync(args.Value, Setting.StoreCode);
                if (stock != null && stock.Count > 0)
                {
                    Item.Qty = stock[0].CurrentQty;
                    Item.Rate = stock[0].Rate;
                    Item.Amount = Item.Qty * Item.Rate;
                    StateHasChanged();
                }
            }
        }

        public void ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "New")
            {
                // NavigationManager.NavigateTo($"{Baseurl}/edit/false");
                AddItem();
            }
            else
                if (args.Item.Id == "Delete")
            {
                // ExportPDF(Title);
            }
        }

        private async Task<bool> FetchSelectData()
        {
            try
            {
                Salesmen = await Helper.FetchOptionsAsync("api/Salesman", Setting.StoreCode);
                EDCList = await Helper.FetchOptionsAsync("api/MPOS", Setting.StoreCode);
                Stores = await Helper.FetchOptionsAsync("api/Stores", "");
            }
            catch (Exception e)
            {
                Helper.Msg("Error", e.Message, true);
            }
            return true;
        }

        private void ReloadItem()
        {
            foreach (var im in saleItems)
            {
                SaleItemList.Add(
                new SItem
                {
                    Amount = im.Value,
                    Barcode = im.Barcode,
                    Discount = im.DiscountAmount,
                    Qty = im.BilledQty,
                    Rate = im.ProductItem.MRP,
                    TaxRate = CalculateTaxRate(im.Value, im.TaxAmount),
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            backUrl = $"/sales/{Returns}/{Params}";
            SetInvoiceMode();
            await FetchSelectData();
            //CultureInfo.CurrentCulture = new CultureInfo("hi-IN", false);
            //CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";
            if (IsEdit)
            {
                Title = "Edit Daily Sales #" + ID;
                if (!string.IsNullOrEmpty(ID))
                {
                    Title = Title + " #Inv: " + ID;
                    entity = await Helper.GetRecordAsync<ProductSale>("api/ProductSales", ID);
                    saleItems = await Helper.FetchAsync<SaleItem>("api/SaleItems", $"?InvoiceNumber={ID}");
                    StateHasChanged();
                }
            }
            else
            {
                Title = "Add " + Title;
                entity = new ProductSale
                {
                    OnDate = DateTime.Now,
                    Adjusted = false,
                    BilledQty = 0,
                    TotalBasicAmount = 0,
                    FreeQty = 0,
                    InvoiceNo = "",
                    Paid = false,
                    InvoiceType = invType,//(InvoiceType)invTypes.IndexOf(Params),
                    Tailoring = false,
                    EntryStatus = EntryStatus.Added,
                    IsReadOnly = false,
                    TotalTaxAmount = 0,
                    TotalPrice = 0,
                    TotalMRP = 0,
                    TotalDiscountAmount = 0,
                    RoundOff = 0,
                    Taxed = true,
                    MarkedDeleted = false,
                    StoreId = Setting.StoreCode,
                    UserId = Setting.UserName,
                    SalesmanId = Salesmen[0].ID
                };
                SaleItemList = new List<SItem>();
                saleItems = new List<SaleItem>();
            }
            GenerateColums(typeof(SItem).GetProperties(), "Barcode");
            StateHasChanged();
            base.OnInitialized();
        }

        private static decimal CalculateTaxRate(decimal amt, decimal tax)
        {
            return Math.Round( (tax * 100) / amt);
        }

        private static decimal CalculateTaxAmount(decimal amt, decimal tax)
        {
            return Math.Round( (amt * (tax / 100)),2);
        }

        // Use this on basic Amount
        private static decimal CalculateTaxAmount(decimal amt, Unit unit)
        {
            return Math.Round( (decimal) ((unit != Unit.Meters && amt > 999) ? (decimal)0.12*amt : (decimal)0.5 *amt),2);
        }
        private static decimal CalculateTaxAmountOnMRP(decimal mrp, Unit unit)
        {
           var tr =(unit != Unit.Meters && mrp > 999) ? (decimal)1.12 : (decimal)1.05;
            return Math.Round( mrp-(mrp / tr),2);
        }

        public static decimal SetTaxRate(decimal amt, Unit unit)
        {
            //decimal r = 5;
            //if (unit != Unit.Meters && amt > 999) r = 12;
            //return r;
           return (unit != Unit.Meters && amt > 999) ? 12 : 5;
        }

        private void UpdateSaleItemList()
        {
            foreach (var im in SaleItemList)
            {
                saleItems.Add(
                new SaleItem
                {
                    Barcode = im.Barcode,
                    Adjusted = false,
                    BilledQty = im.Qty,
                    FreeQty = 0,
                    LastPcs = false,
                    Unit = im.Unit,
                    DiscountAmount = im.Discount,
                    Value = im.Amount,
                    BasicAmount = (im.Qty * im.Rate) - im.Discount,
                    TaxAmount = im.TaxAmount,
                    InvoiceNumber = this.InvoiceNumber,
                    TaxType = this.taxType,
                    InvoiceType = this.invType
                });
            }
        }

        private void AddItem()
        {
            if (Item.Qty != 0)
            {
                //TODO:Calculate Item then add to list and update in maim
                //Calculating Tax and TaxRate.
                var v = Item.Rate * Item.Qty;
                Item.TaxAmount = CalculateTaxAmountOnMRP(Item.Amount, Item.Unit);
                Item.TaxRate = SetTaxRate(Item.Amount, Item.Unit);

                SaleItemList.Add(Item);

                if (Item.Amount == 0)
                    entity.FreeQty += Item.Qty;
                else
                entity.BilledQty += Item.Qty;


                entity.TotalTaxAmount += Item.TaxAmount;
                entity.TotalMRP += v;
                entity.TotalPrice += Item.Amount;
                entity.TotalBasicAmount += (Item.Amount - Item.TaxAmount);
                entity.TotalDiscountAmount += Item.Discount;
                entity.RoundOff = entity.TotalPrice - Math.Round(entity.TotalPrice, 0);
                entity.TotalPrice = Math.Round(entity.TotalPrice, 0); ;
                Grid.Refresh();
                Item = new SItem { Barcode = "", Amount = 0, Discount = 0, Qty = 0, Rate = 0, TaxAmount = 0, TaxRate = 0, Unit = Unit.Meters };

                StateHasChanged();
            }
        }

        private void AddDiscount()
        {
            //Show pop window to ask amount in per/ or rs
            this.Visibility = true;
        }

        protected void GenerateColums(PropertyInfo[] infos, string idName)
        {
            this.Columns = new List<GridColumn>();
            foreach (var prop in infos)
            {
                if (prop.Name.StartsWith("Tax") == false && prop.Name.StartsWith("TAX") == false)
                {
                    var v = new GridColumn()
                    {
                        AutoFit = true,

                        Field = prop.Name,
                        AllowSorting = true,
                        //IsPrimaryKey = prop.Name == idName ? true : false,
                        AllowEditing = prop.CanWrite,
                        HeaderText = prop.Name,
                        HeaderTextAlign = Syncfusion.Blazor.Grids.TextAlign.Center
                    };
                    if (prop.GetType() == typeof(decimal))
                    {
                        if (prop.Name.Contains("Amount"))
                            v.Format = "C2";
                    }

                    this.Columns.Add(v);
                }
            }

            // var CommandsList = new List<GridCommandColumn>();
            //var edit = new GridCommandColumn()
            //{
            //    ID = "edit",
            //    Title = "Edit",
            //    Type = CommandButtonType.None,
            //    ButtonOption = new CommandButtonOptions() { IconCss = "e-icons e-edit", CssClass = "e-flat" }
            //};
            //var delete = new GridCommandColumn()
            //{
            //    ID = "delete",
            //    Title = "Delete",
            //    Type = CommandButtonType.None,
            //    ButtonOption = new CommandButtonOptions() { IconCss = "e-icons e-delete", CssClass = "e-flat" }
            //};
            //var info = new GridCommandColumn()
            //{
            //    ID = "info",
            //    Title = "Detail",
            //    Type = CommandButtonType.None,
            //    ButtonOption = new CommandButtonOptions() { IconCss = "e-icons e-update", CssClass = "e-flat" }
            //};
            //CommandsList.Add(info);
            //CommandsList.Add(edit);
            //CommandsList.Add(delete);
            //var cCol = new GridColumn()
            //{
            //    HeaderText = "Actions",
            //    AutoFit = true,
            //    Commands = CommandsList

            //};
            //Columns.Add(cCol);
        }
    }
}