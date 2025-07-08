namespace Domain.MailService;

public class SendableItem : MailSendable
{
    public void Send()
    {
        Console.WriteLine($"This file is sendable ");
    }
}