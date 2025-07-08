using Domain.MailService;
using Domain.ShippingService;

namespace Domain;

public class EBook : Book , MailSendable 
{
    private string Filetype;

    public EBook(string isbn, string title, DateTime bookDate , string filetype) : base(isbn, title, bookDate)
    {
        Filetype = filetype;
    }

    // has its way of implementing send
    public void Send() 
    {
        Console.WriteLine("this is an Ebook sendable mail");
    }
}