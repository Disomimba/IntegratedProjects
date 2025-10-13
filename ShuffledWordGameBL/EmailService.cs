using MailKit.Net.Smtp;
using MimeKit;

namespace ShuffledWordGameBL;
class EmailService
{
    public void SendEmail(string user, int otp, string userEmail)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("Mekus-Mekus", "ShuffledWord@data.com"));
        message.To.Add(new MailboxAddress("Account Owner", userEmail));
        message.Subject = "Forget Password";

        // This is a simplified version of the body shown in the image
        string emailText = $"NEVER SHARE YOUR OTP especially on social media and SMS or email links.\n{user} You are trying to forgot your password here's your OTP " + otp ;
        
        message.Body = new TextPart("plain")
        {
            Text = emailText
        };

        using (var client = new SmtpClient())
        {
            var smtpHost = "sandbox.smtp.mailtrap.io";
            var smtpPort = 2525;
            var tsl = MailKit.Security.SecureSocketOptions.StartTls;

            client.Connect(smtpHost, smtpPort, tsl);

            var username = "4ed065b1e113cb";
            var password = "432d4af485c5d1";

            client.Authenticate(username, password);

            client.Send(message);
            client.Disconnect(true);
            
        }
    }
}
