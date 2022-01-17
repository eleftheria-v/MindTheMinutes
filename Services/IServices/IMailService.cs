using MimeKit;

namespace Meeting_Minutes.Services.IServices
{
    public interface IMailService
    {
        public void sendMail(MimeMessage message);
    }
}
