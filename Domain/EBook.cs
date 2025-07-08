using Domain.MailService;
using Domain.ShippingService;

namespace Domain;

public class EBook : Book , MailSendable 
{
    private string Filetype;
    private double price;

    public EBook(string isbn, string title, DateTime bookDate , string filetype, double price) : base(isbn, title, bookDate)
    {
        Filetype = filetype;
        this.price = price;
    }

    // has its way of implementing send
    public void Send() 
    {
        Console.WriteLine("this is an Ebook sendable mail");
    }
}