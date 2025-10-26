using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using ShuffledWordGameCommon;

namespace ShuffledWordGameBL;
public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void SendEmail(string user, int otp, string userEmail)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(
            _configuration["EmailSettings:FromName"],
            _configuration["EmailSettings:FromEmail"]));

        message.To.Add(new MailboxAddress(user, userEmail));
        message.Subject = _configuration["EmailSettings:Subject"];
        
        string emailText = $"NEVER SHARE YOUR OTP especially on social media and SMS or email links.\nYou are trying to forgot your password here's your OTP " + otp;

        message.Body = new TextPart("plain")
        {
            Text = emailText
        };

        using (var client = new SmtpClient())
        {
            client.Connect(
                    _configuration["EmailSettings:SmtpHost"],
                    Convert.ToInt16(_configuration["EmailSettings:SmtpPort"]),
                    SecureSocketOptions.StartTls
                );

            client.Authenticate(
                _configuration["EmailSettings:Username"],
                _configuration["EmailSettings:Password"]
                );

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
