using Microsoft.AspNetCore.Identity.UI.Services;

namespace OnlineStore.Utilities.Helpers.EmailHelper
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Email kodları buraya yazılabilir.
            return Task.CompletedTask;
        }
    }
}
