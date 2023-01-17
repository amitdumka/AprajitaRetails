using System;
using Radzen;
using Syncfusion.Blazor.Popups;
using static System.Net.WebRequestMethods;


namespace AprajitaRetails.Client.Helpers
{
	public class DataHelper:IAsyncDisposable
	{
        HttpClient Http;
        SfDialogService DialogService;
        NotificationService NotificationService;

        public DataHelper(HttpClient client, SfDialogService sf, NotificationService not)
        {
            Http = client; DialogService = sf; NotificationService =not;

        }
		public async Task<bool> DeleteAsync(string apiUrl,string className, string id)
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
    }
}

