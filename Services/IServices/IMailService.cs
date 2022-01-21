using Meeting_Minutes.Models;
using MimeKit;

namespace Meeting_Minutes.Services.IServices
{
    public interface IMailService
    {
        public void sendMail(MimeMessage message, List<String> participants, List<MeetingItem> meetingItems, Meeting meeting);

    }
}
