using CollegeMath.Application.Helpers;

namespace CollegeMath.Application.Interfaces
{
    public interface IEmailApplication
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
