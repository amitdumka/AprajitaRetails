using System;
using System.Globalization;
using System.Reflection;
using AprajitaRetails.Shared.AutoMapper.DTO;
using Syncfusion.Blazor.Grids;

namespace AprajitaRetails.Client.Shared.Test
{
    public partial class IndexView
    {
        protected List<GridColumn> GridCols;
        protected string[] GroupedColumn;

        protected void InitView()
        {
            CultureInfo.CurrentCulture = new CultureInfo("hi-IN", false);
            CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";
            if (string.IsNullOrEmpty(Setting.StoreCode))
            {
                Helper.Msg("Error", "Select store!, Kindly re-login", true);
                return;
            }
           

        }

        protected void GenerateColums(PropertyInfo[] infos, string idName)
        {
            GridCols = new List<GridColumn>();
            foreach (var prop in infos)
            {

                var x = prop.CustomAttributes;
                foreach (var item in x)
                {
                    Console.WriteLine(item.ToString());
                }

                if (prop.Name != "EmployeeId" && prop.Name != "TransactionId" && prop.Name != "TransactionMode" &&    prop.Name != "PartyId" &&    prop.Name != "StoreId" )
                {
                   
                    var v = new GridColumn()
                    {
                        AutoFit = true,
                       
                        Field = prop.Name,
                        AllowSorting = true,
                        IsPrimaryKey = prop.Name == idName ? true : false,
                        AllowEditing = prop.CanWrite,
                        HeaderText = prop.Name,
                        HeaderTextAlign = Syncfusion.Blazor.Grids.TextAlign.Center
                    };
                    if (prop.GetType() == typeof(decimal))
                    {
                        if (prop.Name.Contains("Amount") )
                           v.Format = "C2";
                    }

                    GridCols.Add(v);
                }
            }
        }


    }
}