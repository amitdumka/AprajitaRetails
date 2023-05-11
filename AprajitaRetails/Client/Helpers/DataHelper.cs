using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using Radzen;
using Syncfusion.Blazor.PivotView;
using Syncfusion.Blazor.Popups;
using System;
using System.Net.Http.Json;

namespace AprajitaRetails.Client.Helpers
{
    public static class FileUtils
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));

    }

    public class DataHelper : IAsyncDisposable
    {
        private HttpClient Http;
        private SfDialogService DialogService;
        private NotificationService NotificationService;
        private static List<StockViewModel> CurrentStock = new List<StockViewModel>();
        public void ErrorMsg()
        { Msg("Error", "Enter data is not valid or missing mandatory data, Kindly check all fields and try again!", true); }

        //public void Goto(string url) => NavigationManager.NavigateTo(url);
        public DataHelper(HttpClient client, SfDialogService sf, NotificationService not)
        {
            Http = client; DialogService = sf; NotificationService = not;
        }

        public async Task<List<StockViewModel>?> FetchBarcodeAsync(string Barcode,string storeid)
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

        ValueTask IAsyncDisposable.DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> FetchFileAsync(string url, string condition)
        {
            try
            {

                var x= await Http.GetAsync($"{url}{condition}");
                x.EnsureSuccessStatusCode();
              return  await x.Content.ReadAsByteArrayAsync();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return null;
            }
        }
        // Condition ?id=adasd&storeid=ARD etc
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

        public async Task<T?> GetRecordAsync<T>(string url, string id)
        {
            try
            {
                return await Http.GetFromJsonAsync<T>($"{url}/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                Msg("Error", "Kindly login before use", true);
                return default(T);
            }
        }
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
        }
        public async Task<SortedDictionary<string,string>?> GetRecordAsSDAsync(string url)
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

        public async Task<SelectOption[]?> FetchOptionsAsync(string optionName, string? storeid)
        {
            SelectOption[]? option = null;
            switch (optionName)
            {
                case "Accounts":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/BankAccounts?storeid={storeid}");
                    break;

                case "Transactions":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/Transactions"); break;
                case "Parties":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/Parties?storeid={storeid}");
                    break;

                case "Stores":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/Stores");
                    break;

                case "Employees":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/Employees?storeid={storeid}");
                    break;
                case "MPOS":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/MPOS?storeid={storeid}");
                    break;
                case "Salesman":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/Salesman?storeid={storeid}");
                    break;
                case "LedgerGroups":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/LedgerGroups?storeid={storeid}");
                    break;
                case "StoreGroups":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/StoreGroups");
                    break;
                case "Clients":
                    option = await Http.GetFromJsonAsync<SelectOption[]>($"Helper/Clients");
                    break;
                default:
                    break;
            }
            return option;
        }

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


        public async Task<bool> PostOperationsAsync<T>(string url, T tentity, string className)
        {
            try
            {
                HttpResponseMessage? result;
                result= await Http.PostAsJsonAsync<T>($"{url}", tentity);
                if (result.IsSuccessStatusCode)
                {
                    Msg(className, $"{await result.Content.ReadAsStringAsync()} ");
                    return true;
                   
                }
                else
                {
                    Msg("Error", $"An error occurred  {className} and error is { await result.Content.ReadAsStringAsync()}", true);
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

    }
}