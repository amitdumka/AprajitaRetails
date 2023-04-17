﻿using System;
using System.Globalization;
using System.Reflection;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.ViewModels;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Grids.Internal;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.Navigations;
 
namespace AprajitaRetails.Client.Pages.Apps.Inventory.Sale
{
    public partial class SaleEntry
    {
        string Title = "Sale Invoice ";
        string backUrl = "/sales/false/Regular";

        ProductSale? entity = new ProductSale { OnDate = DateTime.Now };
        SalePaymentDetail payment = new SalePaymentDetail { PayMode = PayMode.Cash };
        CardPaymentDetail cardPayment= new CardPaymentDetail { PaidAmount= 0 };
        List<SaleItem>? saleItems = new List<SaleItem>();
        IList<string> payModes = Enum.GetNames(typeof(PayMode));
        IList<string> invTypes = Enum.GetNames(typeof(InvoiceType));
        IList<string> cards= Enum.GetNames(typeof(CARD));
        IList<string> cardTypes = Enum.GetNames(typeof(CARDType));
        IList<SelectOption>? Stores;
        IList<SelectOption>? Salesmen;
        IList<SelectOption>? EDCList;
        SItem Item = new SItem { Barcode = "", Amount = 0, Discount = 0, Qty = 0, Rate = 0, TaxAmount = 0, TaxRate = 0, Unit = Unit.Meters };


        List<object> toolbar = new List<object>() { new ItemModel() { Text = "Add", TooltipText = "Add", PrefixIcon = "e-icons e-collapse", Id = "New" }, new ItemModel() { Text = "Delete", TooltipText = "Delete", PrefixIcon = "e-icons e-collapse", Id = "Delete" } };
         List<GridColumn> Columns { get; set; }

        SfGrid<SItem>? Grid;
        List<SItem> SaleItemList = new List<SItem>();

        //Base Info
        string InvoiceNumber = "";
        InvoiceType invType = InvoiceType.Sales;
        TaxType taxType = TaxType.GST;

        void SetInvoiceMode()
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
        private async void OnItemValChange(ChangedEventArgs args)
        {
            //Item.Qty = stock[0].CurrentQty;
            //Item.Rate = stock[0].Rate;
            
            Item.Amount = Item.Qty * Item.Rate-Item.Discount;
            StateHasChanged();
        }
         
        private async void OnBarcodeChange(ChangedEventArgs args)
        {
             //CultureInfo.CurrentCulture = new CultureInfo("hi-IN", false);
            //CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";

            // Here you can customize your code
            if (args.Value.Length > 8)
            {
                Helper.Msg("Barcode", args.Value);

             var stock=  await Helper.FetchBarcodeAsync(args.Value, Setting.StoreCode);
                if(stock!=null && stock.Count > 0)
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
                Salesmen = await Helper.FetchOptionsAsync("Salesman", Setting.StoreCode);
                EDCList = await Helper.FetchOptionsAsync("MPOS", Setting.StoreCode);
                Stores = await Helper.FetchOptionsAsync("Stores", "");
            }
            catch (Exception e)
            {
                Helper.Msg("Error", e.Message, true);
            }
            return true;

        }

        void ReloadItem()
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
                    TaxRate = CalculateTaxRate(im.Value,im.TaxAmount),
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
            return (tax * 100) / amt;
        }
        private static decimal CalculateTaxAmount(decimal amt, decimal tax)
        {
            return (amt * (tax / 100));
        }

        private void UpdateSaleItemList()
        {
            foreach (var im in SaleItemList)
            {
                saleItems.Add(
                new SaleItem { Barcode=im.Barcode, Adjusted=false, BilledQty=im.Qty,
                 FreeQty=0, LastPcs=false, Unit=im.Unit, DiscountAmount=im.Discount,
                  Value=im.Amount, BasicAmount=(im.Qty*im.Rate)-im.Discount,
                  TaxAmount =im.TaxAmount,  InvoiceNumber=this.InvoiceNumber,
                   TaxType=this.taxType, InvoiceType=this.invType
                });

            }
        }
        public SaleEntry()
        {
            //CultureInfo.CurrentCulture = new CultureInfo("hi-IN", false);
            //CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";
        }
        private void AddItem()
        {
            if (Item.Qty != 0)
            {
                SaleItemList.Add(Item);
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
    class SItem
    {
        public string Barcode { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public Unit Unit { get; set; }
        public decimal TaxAmount { get; set; }


    }
}

