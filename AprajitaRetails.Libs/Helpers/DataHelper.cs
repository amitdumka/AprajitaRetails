
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Radzen;
using Syncfusion.Blazor.Popups;
using System.Net.Http.Json;

namespace AprajitaRetails.Helpers
{
    public class DataHelper : IAsyncDisposable
    {
        private HttpClient Http;
        private SfDialogService DialogService;
        private NotificationService NotificationService;

        public void ErrorMsg()
        { Msg("Error", "Enter data is not valid or missing mandatory data, Kindly check all fields and try again!", true); }

        //public void Goto(string url) => NavigationManager.NavigateTo(url);
        public DataHelper(HttpClient client, SfDialogService sf, NotificationService not)
        {
            Http = client; DialogService = sf; NotificationService = not;
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
                    Msg("Cancled", "User cancled delete operation!");
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
                    Msg("Error", $"An error occured while saving {className} and error is {result.StatusCode.ToString()}", true);
                    return false;
                }
            }
            catch (Exception e)
            {
                Msg("Error", $"An error occured while saving {className} and error is \n {e.Message}", true);
                return false;
            }
        }
    }
}