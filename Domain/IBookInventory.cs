using Domain.ShippingService;

namespace Domain;

public interface IBookInventory
{
    IDictionary<string, DemoBook> LoadDemoBooks();
    IDictionary<string, PaperBook> LoadPaperBooks();
    IDictionary<string, EBook> LoadEBooks();
    void AddBook<T>(T book) where T : Book;
    void RemoveBook<T>(T book) where T : Book;
    IEnumerable<Book> ReturnOutdatedBooksBefore(DateTime time);
    IEnumerable<Book> getAllBooks();
    T getBookById<T>(string id) where T: Book;

}