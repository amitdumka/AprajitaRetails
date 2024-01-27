using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Radzen;
using Syncfusion.Blazor.Popups;
using System.Net.Http.Json;

namespace AprajitaRetails.Client.Helpers
{
    public class DataHelper : IAsyncDisposable
    {
        private static List<StockViewModel> CurrentStock = new List<StockViewModel>();
        private SfDialogService DialogService;
        private HttpClient Http;
        private NavigationManager NavigationManager;
        private NotificationService NotificationService;

        public DataHelper(HttpClient client, SfDialogService sf, NotificationService not, NavigationManager nav)
        {
            Http = client; DialogService = sf; NotificationService = not;
            NavigationManager = nav;
        }

        public async Task<bool> DeleteAsync(string apiUrl, string className, string id)
        {
            try
            {
                bool isConfirm = await DialogService.ConfirmAsync("Are you sure you want to permanently delete ?", "Delete ");
                if (isConfirm)
                {
                    var result = await Http.DeleteAsync($"{apiUrl}/{id}");
                    if (result.IsSuccessStatusCode)
                    {
                        Msg("Delete", $"{className} {id} is deleted");
                        return true;
                    }
                    else
                    {
                        Msg("Delete", $" Error : {className} {id} is not deleted", true);
                        return false;
                    }
                }
                else
                {
                    Msg("Canceled", "User canceled delete operation!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Msg("Error", ex.Message, true);
                return false;
            }
        }

         ValueTask IAsyncDisposable.DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public void ErrorMsg()
        { Msg("Error", "Enter data is not valid or missing mandatory data, Kindly check all fields and try again!", true); }

        // Condition ?id=adasd&storeid=ARD etc
        /// <summary>
        /// Fetch data from Get method and return in list of data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">api url</param>
        /// <param name="condition">condition if any </param>
        /// <returns></returns>
        public async Task<List<T>?> FetchAsync<T>(string url, string condition)
        {
            try
            {
                return await Http.GetFromJsonAsync<List<T>>($"{url}{condition}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return null;
            }
        }

        /// <summary>
        /// Get Stock View Model by barcode and storeid
        /// </summary>
        /// <param name="Barcode"></param>
        /// <param name="storeid"></param>
        /// <returns></returns>
        public async Task<List<StockViewModel>?> FetchBarcodeAsync(string Barcode, string storeid)
        {
            var stock = CurrentStock.Where(c => c.Barcode == Barcode).ToList();
            if (stock != null && stock.Count > 0)
            {
                return stock;
            }
            else
            {
                try
                {
                    return await Http.GetFromJsonAsync<List<StockViewModel>>($"api/Stocks/ByBarcode?barcode={Barcode}&storeid={storeid}");
                }
                catch (AccessTokenNotAvailableException exception)
                {
                    exception.Redirect();
                    Msg("Error", "Kindly login before use", true);
                    return null;
                }
            }
        }

        /// <summary>
        /// get data in Sorteddictory having string key and List of type data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<SortedDictionary<string, List<T>>?> FetchDictAsync<T>(string url, string condition)
        {
            try
            {
                return await Http.GetFromJsonAsync<SortedDictionary<string, List<T>>>($"{url}{condition}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return null;
            }
        }

        /// <summary>
        /// Get File from server
        /// </summary>
        /// <param name="url"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<byte[]> FetchFileAsync(string url, string condition)
        {
            try
            {
                var x = await Http.GetAsync($"{url}{condition}");
                x.EnsureSuccessStatusCode();
                return await x.Content.ReadAsByteArrayAsync();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return null;
            }
        }

        /// <summary>
        /// Fetch Option data for Combox box
        /// </summary>
        /// <param name="optionName"></param>
        /// <param name="storeid"></param>
        /// <returns></returns>
        public async Task<SelectOption[]?> FetchOptionsAsync(string optionName, string? storeid)
        {
            SelectOption[]? option = null;
            switch (optionName)
            {
                case "Accounts":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/BankAccounts?storeid={storeid}");
                    break;

                case "Transactions":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/Transactions"); break;
                case "Parties":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/Parties?storeid={storeid}");
                    break;

                case "Stores":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/Stores");
                    break;

                case "Employees":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/Employees?storeid={storeid}");
                    break;

                case "MPOS":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/MPOS?storeid={storeid}");
                    break;

                case "Salesman":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/Salesman?storeid={storeid}");
                    break;

                case "LedgerGroups":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/LedgerGroups?storeid={storeid}");
                    break;

                case "StoreGroups":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/StoreGroups");
                    break;

                case "Clients":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"api/Helper/Clients");
                    break;

                default:
                    break;
            }
            return option;
        }

        /// <summary>
        /// Fetch data in sorted dic have key and value list
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<SortedDictionary<string, string>?> GetRecordAsSDAsync(string url)
        {
            try
            {
                return await Http.GetFromJsonAsync<SortedDictionary<string, string>?>(url);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return default(SortedDictionary<string, string>?);
            }
        }

        /// <summary>
        /// Fetch record by id 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> GetRecordAsync<T>(string url, string id)
        {
            try
            {
                var x= await Http.GetFromJsonAsync<T>($"{url}/{id}");
                return x;
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return default(T);
            }
            catch(Exception e)
            {
                Msg("Error", e.ToString(), true); return default(T);
            }
        }

        /// <summary>
        /// Fetch Record by url using get Methord.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T?> GetRecordAsync<T>(string url)
        {
            try
            {
                return await Http.GetFromJsonAsync<T>(url);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return default(T);
            }
            catch (Exception e)
            {
                Msg("Error", e.ToString(), true); return default;
            }
        }

        public async Task<string?> GetRecordAsStringAsync(string url)
        {
            try
            {
                return await Http.GetStringAsync(url);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return default;
            }
            catch (Exception e)
            {
                Msg("Error", e.ToString(), true); return default;
            }
        }

        /// <summary>
        /// Navigate ti URl
        /// </summary>
        /// <param name="url"></param>
        public void Goto(string url) => NavigationManager.NavigateTo(url);
        /// <summary>
        /// Display Toast msg
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="isError"></param>
        public void Msg(string title, string text, bool isError = false)
        {
            var msg = new Radzen.NotificationMessage
            {
                Severity = isError ? NotificationSeverity.Error : NotificationSeverity.Info,
                Summary = title,
                Detail = text,
                Duration = 14000
            };
            NotificationService.Notify(msg);
        }

        /// <summary>
        /// Post data 
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <typeparam name="R">Request Type</typeparam>
        /// <param name="url"> post Url</param>
        /// <param name="tentity">Request Object</param>
        /// <param name="className">Data Request class Name</param>
        /// <returns></returns>
        public async Task<T?> PostDataFromAsync<T, R>(string url, R tentity, string className)
        {
            try
            {
                HttpResponseMessage? result;
                result = await Http.PostAsJsonAsync<R>($"{url}", tentity);

                if (result.IsSuccessStatusCode)
                {
                    Msg(className, "Success!");

                    return await result.Content.ReadFromJsonAsync<T>();
                }
                else
                {
                    Msg("Error", $"An error occurred  {className} and error is {await result.Content.ReadAsStringAsync()}", true);
                    return default;
                }
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return default;
            }
        }


        /// <summary>
        ///  Perfom post operation and return if it successful
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="tentity"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public async Task<bool> PostOperationsAsync<T>(string url, T tentity, string className)
        {
            try
            {
                HttpResponseMessage? result;
                result = await Http.PostAsJsonAsync<T>($"{url}", tentity);
                if (result.IsSuccessStatusCode)
                {
                    Msg(className, $"{await result.Content.ReadAsStringAsync()} ");
                    return true;
                }
                else
                {
                    Msg("Error", $"An error occurred  {className} and error is {await result.Content.ReadAsStringAsync()}", true);
                    return false;
                }
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return false;
            }
        }


        /// <summary>
        /// Save Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ApiUrl"></param>
        /// <param name="EntityModel"></param>
        /// <param name="className"></param>
        /// <param name="Id"></param>
        /// <param name="IsEdit"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync<T>(string ApiUrl, T EntityModel, string className, string? Id = null, bool IsEdit = false)
        {
            try
            {
                HttpResponseMessage? result;

                if (!IsEdit)
                    result = await Http.PostAsJsonAsync<T>(ApiUrl, EntityModel);
                else
                    result = await Http.PutAsJsonAsync<T>($"{ApiUrl}/{Id}", EntityModel);

                if (result.IsSuccessStatusCode)
                {
                    var ext = $"{className} is " + (IsEdit ? " edited!" : "added!");
                    Msg(IsEdit ? "Edited " : " Saved ", ext);
                    return true;
                    //EntityChanged = false;
                }
                else
                {
                    Msg("Error", $"An error occurred while saving {className} and error is {result.StatusCode.ToString()}", true);
                    return false;
                }
            }
            catch (Exception e)
            {
                Msg("Error", $"An error occurred while saving {className} and error is \n {e.Message}", true);
                return false;
            }
        }
    }
}