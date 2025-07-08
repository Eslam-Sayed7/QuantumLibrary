namespace Domain.MailService;

public class MailService : IMailService
{
    public void SendEmail( MailSendable sendableItem)
    {
        sendableItem.Send();
    }
}