using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;

using MimeKit.Text;
using Meeting_Minutes.Services.IServices;
using Meeting_Minutes.Models;

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

        public void sendMail(MimeMessage message, List<String> participants, List<MeetingItem> meetingItems, Meeting meeting)
        {


            var mail = new MimeMessage();
            mail.Sender = new MailboxAddress(SenderName, SenderEmail);
            mail.Subject = $"A new meeting has been Created with title: {meeting.Title} .";

            var body = "The below Meeting Items where discussed: \n\n";

            foreach (var item in meetingItems)
            {
                
                body += $"Description : {item.Description} \n" +
                        $"Deadline : {item.Deadline} \n\n";
                
                //body += $"Risk level : {item.RiskLevel}";
            }

            foreach (var address in participants)
            {
                mail.Bcc.Add(new MailboxAddress("", address));
                mail.To.Add(new MailboxAddress("",address));
            }

            //string body = $"{body1}{body2}";
            mail.Body = new TextPart(TextFormat.Text) { Text = body};

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
