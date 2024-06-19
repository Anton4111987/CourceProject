using CourceProject.Components.Models;
namespace CourceProject.Components.Services
{
    public interface IEmailSender
    {
        public Task SendEmail(SendEmailDataModel model);
    }
}
