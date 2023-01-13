using Radzen;
using Syncfusion.Blazor.Charts.Internal;

namespace AprajitaRetails.Client.Helpers
{
    public class Notify
    {
        public static void Msg(NotificationService NotificationService, string title, string text, bool isError)
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
    }
}