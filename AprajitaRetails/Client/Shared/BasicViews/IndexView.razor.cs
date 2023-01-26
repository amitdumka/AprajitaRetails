using Syncfusion.Blazor.Grids;
using System.Globalization;
using System.Reflection;

namespace AprajitaRetails.BasicViews
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
                if (prop.Name.EndsWith("Id")==false && prop.Name.EndsWith("ID") == false )
                    //&& prop.Name != "EmployeeId" && prop.Name != "TransactionId" 
                    //&& prop.Name != "TransactionMode" && prop.Name != "PartyId" && prop.Name != "StoreId")
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
                        if (prop.Name.Contains("Amount"))
                            v.Format = "C2";
                    }

                    GridCols.Add(v);
                }
            }

            var CommandsList = new List<GridCommandColumn>();
            var edit = new GridCommandColumn()
            {
                ID = "edit",
                Title = "Edit",
                Type = CommandButtonType.None,
                ButtonOption = new CommandButtonOptions() { IconCss = "e-icons e-edit", CssClass = "e-flat" }
            };
            var delete = new GridCommandColumn()
            {
                ID = "delete",
                Title = "Delete",
                Type = CommandButtonType.None,
                ButtonOption = new CommandButtonOptions() { IconCss = "e-icons e-delete", CssClass = "e-flat" }
            };
            var info = new GridCommandColumn()
            {
                ID = "info",
                Title = "Detail",
                Type = CommandButtonType.None,
                ButtonOption = new CommandButtonOptions() { IconCss = "e-icons e-update", CssClass = "e-flat" }
            };
            CommandsList.Add(info);
            CommandsList.Add(edit);
            CommandsList.Add(delete);
            var cCol = new GridColumn()
            {
                HeaderText = "Actions",
                AutoFit = true,
                Commands = CommandsList

            };
            GridCols.Add(cCol);
        }


    }
}