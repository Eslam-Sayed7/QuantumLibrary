using Domain.MailService;
using Domain.ShippingService;
using Microsoft.VisualBasic;

namespace Domain.BuyService;

public class BookStore
{
    private readonly IBookInventory _bookInventory;
    private readonly IMailService _mailService;
    private readonly IShippingService _shippingService;

    public BookStore(IMailService mailService, IShippingService shippingService, IBookInventory bookInventory)
    {
        _mailService = mailService;
        _shippingService = shippingService;
        _bookInventory = bookInventory;
    }
    public void ListBooks()
    {
        var books  = _bookInventory.getAllBooks();
        foreach (var bk in books)
        {
            Console.WriteLine("book Id     Title  ");
            Console.WriteLine($"{bk.getISBN()}   {bk.getBookTitle()}  ");
        }
    }

    public void AddBook()
    {
        // test for simulation user input data
        // this should be replaced by entering data and validation but 
        // it is not needed for now as in the documentation

        var mockbooktobeadded = Testing.paperbooktobeAdded;
        _bookInventory.AddBook(mockbooktobeadded);
        Console.WriteLine($"book with title {mockbooktobeadded.getBookTitle()} is added list the books to view");
    }
    public bool Buybook(string bookId , int quantity , string email)
    {
        var paperbuy = _bookInventory.getBookById<PaperBook>(bookId);
        if (paperbuy is not null)
        {
            _bookInventory.RemoveBook(paperbuy);
            _shippingService.shipItem(paperbuy);
            return true;
        }
        var ebookbuy = _bookInventory.getBookById<EBook>(bookId);
        if (ebookbuy is not null)
        {
            _mailService.SendEmail(ebookbuy);
            return true;
        }
        var demobuy = _bookInventory.getBookById<DemoBook>(bookId);
        if (demobuy is not null)
        {
            _mailService.SendEmail(demobuy);
            return true;
        }
        Console.WriteLine("this book is not in the database");
        return false;
    }

    public IEnumerable<Book> ListOutDatedBooks()
    {
        return _bookInventory.ReturnOutdatedBooksBefore(DateTime.Now);
    }
    
}