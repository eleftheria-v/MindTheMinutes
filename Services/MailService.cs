using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;

using MimeKit.Text;
using Meeting_Minutes.Services.IServices;

namespace Meeting_Minutes.Services
{
    public class MailService : IMailService
    {

        private string smtpServer = "smtp.gmail.com";
        private int smtpPort = 587;
        private string smtpUsername = "mindtheminutescode@gmail.com";
        private string smtpPass= "1234!@#$Qq";
        private string SenderName = "mindtheminutescode";
        static string SenderEmail = "mindtheminutescode@gmail.com";
        string msg ="test";
        //message.Body = ("")

        public void sendMail(MimeMessage message)
        {
            var mail = new MimeMessage();
            mail.Sender = new MailboxAddress(SenderName, SenderEmail);
            
            mail.Subject = "test Subject";
            mail.Body = new TextPart(TextFormat.Html) { Text = msg.ToString()};
            mail.To.Add(new MailboxAddress("test", SenderEmail));

            using (var smtp = new SmtpClient()) 
            {
                smtp.Connect(smtpServer, smtpPort, false);
                smtp.Authenticate(smtpUsername, smtpPass);
                smtp.Send(mail);
                smtp.Disconnect(true);

            }


        }


















    }
}
