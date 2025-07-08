namespace Domain.MailService;

public interface IMailService
{ 
    public  void SendEmail(MailSendable sendableItem);
}