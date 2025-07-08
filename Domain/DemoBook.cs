namespace Domain.ShippingService;

public class DemoBook : Book , MailSendable
{
    public DemoBook(string isbn, string title, DateTime bookDate) : base(isbn, title, bookDate)
    {
    }

    public void Send()
    {
        Console.WriteLine($"this is a demo {this.getBookTitle()}sendable mail");
    }
}