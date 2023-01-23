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
        protected string[] GroupedColumn;// = new string[] { "Store" };

        protected void InitView()
        {
            if (string.IsNullOrEmpty(Setting.StoreCode))
            {
                Helper.Msg("Error", "Select store!, Kindly re-login", true);
                return;
            }
            CultureInfo.CurrentCulture = new CultureInfo("hi-IN", false);
            CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₹";

        }

        protected void GenerateColums(PropertyInfo[] infos, string idName)
        {
            GridCols = new List<GridColumn>();
            foreach (var prop in infos)
            {
                if (prop.Name != "EmployeeId" && prop.Name != "TransactionId" && prop.Name != "TransactionMode" &&    prop.Name != "PartyId" &&    prop.Name != "StoreId" )
                {
                    var v = new GridColumn()
                    {
                        AutoFit = true,
                        Field = prop.Name,  
                        AllowSorting = true,
                        IsPrimaryKey = prop.Name == idName ? true : false,
                        AllowEditing = prop.CanWrite
                    };

                    GridCols.Add(v);
                }
            }
        }


    }
}