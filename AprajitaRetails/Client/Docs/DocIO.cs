using System.Data;
using System.Reflection;
using System.Data;
using System.Reflection;
using System.Text.Json;
using TypeSupport.Extensions;

namespace AprajitaRetails.Client.Docs
{
    public class DocIO
    {
        /// <summary>
        /// Convert List item to Datatable format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// Convert paymode string to paymode
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PayMode PayModeType(string p)
        {
            switch (p.ToLower())
            {
                case "cash": return PayMode.Cash;
                case "card": return PayMode.Card;
                case "upi": return PayMode.UPI;
                case "mix": return PayMode.MixPayments;
                case "icicipine": return PayMode.Card;
                case "icicipineupi": return PayMode.UPI;
                case "bomupi": return PayMode.UPI;

                default:
                    if (p.ToLower().Contains("mix")) return PayMode.MixPayments;
                    else if (p.ToLower().Contains("upi")) return PayMode.UPI;
                    else return PayMode.Others;
            }
        }

        /// <summary>
        /// Convert Datatable to List item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                try
                {
                    if (((string)dr[column.ColumnName]) != null || dr[column.ColumnName] != typeof(DBNull))
                    {
                        foreach (PropertyInfo pro in temp.GetProperties())
                        {
                            if (pro.Name == column.ColumnName)
                            {
                                switch (column.ColumnName)
                                {

                                    case "SGSTAmount":
                                    case "IGST_CGSTAmount":
                                    case "Amount":
                                    case "BillAmount":
                                    case "OldMRP":
                                    case "OpeningStock":
                                    case "Cost":
                                    case "Qty":
                                    case "Quantity":
                                    case "MRP":
                                    case "LineTotal":
                                    case "SaleAmount":
                                    case "CostPrice":
                                    case "CostValue":
                                    case "UnitMRP":
                                    case "UnitPrice":
                                    case "MRPValue":
                                    case "UnitCost": 
                                    case "CGST":
                                    case "SGST":
                                    case "CGSTAmount":
                                    case "TotalAmount":
                                    case "ExtraAmount":
                                    case "IGST_CGSTRate":
                                    case "SGSTRate":
                                    case "TaxAmount":
                                    case "BasicPrice":
                                    case "RoundOff":
                                    case "ProfitLoss":
                                    case "QTY":
                                    case "Per":
                                    case "Rate":
                                    case "Discount":
                                    case "DiscountP":
                                    case "DiscountAmount":
                                        pro.SetValue(obj, decimal.Parse((string)dr[column.ColumnName]), null);
                                        break;

                                    case "Date":
                                    case "InwardDate":
                                    case "InvoiceDate":
                                    case "OnDate":
                                        pro.SetValue(obj, DateTime.Parse((string)dr[column.ColumnName]), null);
                                        break;

                                    case "EntryStatus":
                                        //case "PayMode":
                                        pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
                                        break;

                                    case "IsDue":
                                    case "ManualBill":
                                    case "SalesReturn":
                                    case "TailoringBill":
                                    case "IsReadOnly":
                                    case "MarkedDeleted":

                                        pro.SetValue(obj, bool.Parse((string)dr[column.ColumnName]), null);
                                        break;

                                    case "EDCTerminalId":
                                        pro.SetValue(obj, null, null);
                                        break;


                                    case "Sn":
                                    case "SN":
                                        pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
                                        break;

                                    case "Customer":
                                    case "Mobile":
                                    case "PayMode":
                                    case "InvoiceNo":
                                    default:
                                        if (!string.IsNullOrEmpty((string)dr[column.ColumnName]))
                                            pro.SetValue(obj, (string)dr[column.ColumnName], null);
                                        break;
                                }
                            }
                            else
                                continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            return obj;
        }

        public decimal DisAmt(decimal mrp, decimal dis)
        {
            return Math.Round(mrp * (dis / 100), 2);
        }

        public static decimal GetBasicAmt(decimal amt, Unit unit)
        {
            decimal TaxRate = 5;
            if (unit != Unit.Meters && amt > 999) TaxRate = 12;
            //Need to implement for jacket and other then 12 % option
            TaxRate = TaxRate / 100;
            var Basic = amt / (1 + TaxRate);
            return Math.Round(Basic, 2);
        }

        public static List<T>? JsonToObject<T>(MemoryStream filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static List<T>? JsonToObject<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static string ObjectToJson<T>(List<T> lists)
        {
            return JsonSerializer.Serialize<List<T>>(lists);
        }

        public static async Task<string> ObjectToJsonFileAsync<T>(List<T> lists, string path)
        {
            var JSONFILE = JsonSerializer.Serialize<List<T>>(lists);
            using StreamWriter writer = new StreamWriter(path);
            await writer.WriteAsync(JSONFILE);
            writer.Close();
            return JSONFILE;
        }

        public static async Task<string> ObjectToJsonFileAsync<T>(T lists, string path)
        {
            var JSONFILE = JsonSerializer.Serialize<T>(lists);
            using StreamWriter writer = new StreamWriter(path);
            await writer.WriteAsync(JSONFILE);
            writer.Close();
            return JSONFILE;
        }
    }
}
