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

        public void sendMail(MimeMessage message, List<String> participants)
        {
            var mail = new MimeMessage();
            mail.Sender = new MailboxAddress(SenderName, SenderEmail);
            
            mail.Subject = "New Meeting Created";
            mail.Body = new TextPart(TextFormat.Html) { Text = msg.ToString()};

            foreach (var address in participants)
            {
                mail.Bcc.Add(new MailboxAddress("", address));
                mail.To.Add(new MailboxAddress("",address));
            }
            

            using (var smtp = new SmtpClient()) 
            {
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect(smtpServer, smtpPort, SecureSocketOptions.Auto);
                smtp.Authenticate(smtpUsername, smtpPass);
                smtp.Send(mail);
                smtp.Disconnect(true);

            }


        }


















    }
}
