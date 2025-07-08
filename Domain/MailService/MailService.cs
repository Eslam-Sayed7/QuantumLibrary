namespace Domain.MailService;

public class MailService : IMailService
{
    public MailService()
    {
    }
    public void SendEmail( MailSendable sendableItem)
    {
        sendableItem.Send();
    }
}