using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace NoteService
{
    class EmailService
    {

        public void SendEmail(string userName, string noteContent)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("NoteTakingApp", "do-not-reply@noteapp.com"));
            message.To.Add(new MailboxAddress("Account Owner", "user@example.com"));
            message.Subject = "Note Created";
            message.Body = new TextPart("plain")
            {
                Text = $"Account: {userName}\n\n" +
                       $"A new note was added:\n\n{noteContent}"
            };
            using (var client = new SmtpClient())
            {
                var smtpHost = "sandbox.smtp.mailtrap.io";
                var smtpPort = 2525;
                var tsl = MailKit.Security.SecureSocketOptions.StartTls;
                client.Connect(smtpHost, smtpPort, tsl);

                var usernameSMTP = "90fadce705c53f";
                var passwordSMTP = "94d9d65e9e39a0";


                client.Authenticate(usernameSMTP, passwordSMTP);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
