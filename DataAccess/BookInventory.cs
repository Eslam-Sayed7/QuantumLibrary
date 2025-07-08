using System.Data;
using Domain;
using Domain.ShippingService;

namespace DataAccess;

public class BookInventory : IBookInventory
{
    private IDictionary< string ,DemoBook> _demoBooks;
    private IDictionary< string ,EBook> _eBooks;
    private IDictionary<string, PaperBook> _paperBooks;
    // private IDictionary<string, Book> _testBooks;
    
    public BookInventory()
    {
        _demoBooks = LoadDemoBooks();
        _eBooks = LoadEBooks();
        _paperBooks = LoadPaperBooks();
    }
    
    public IDictionary<string,DemoBook> LoadDemoBooks()
    {
        return new Dictionary<string, DemoBook>()
        {
            {"222-222-222", new DemoBook("222-222-222" , "Dependency Injectioin" , DateTime.Now - TimeSpan.FromDays(3))},
        };
    }

    public IDictionary<string, PaperBook> LoadPaperBooks()
    {
        return new Dictionary<string, PaperBook>()
        {
            { "111-111-111" , new PaperBook("111-111-111" , "Head First Object Oriented Analysis and Design" , DateTime.Now, 10)},
        };
    }

    public IDictionary<string, EBook> LoadEBooks()
    {
        return new Dictionary<string, EBook>()
        {
            { "333-333-333", new EBook("333-333-333", "Demo Angular in Depth" , DateTime.Now, "PDF") }
        };
    }

    public void AddBook<T>(T book) where T : Book 
    {
        if (book is PaperBook paperBook)
        {
            _paperBooks.TryGetValue(paperBook.getISBN() , out var result);
            if (result != null)
            {
                var UpadtedBook = result;
                UpadtedBook.AddToStock(1);
                var id = result.getISBN();
                _paperBooks[id] = UpadtedBook;
            }
            else
            {
                var id = paperBook.getISBN();
                _paperBooks[id] = paperBook;
            }
            
        } else if (book is EBook ebook)
        {
            _eBooks.TryGetValue(ebook.getISBN() , out var result);
            if (result != null)
            {
                Console.WriteLine($"{ebook.getBookTitle()} already exists");
            }
            else
            {
                var id = ebook.getISBN();
                _eBooks[id] = ebook;
            }
        } else if (book is DemoBook demoBook)
        {
            _eBooks.TryGetValue(demoBook.getISBN() , out var result);
            if (result != null)
            {
                Console.WriteLine($"{demoBook.getBookTitle()} already exists");
            }
            else
            {
                var id = demoBook.getISBN();
                _demoBooks[id] = demoBook;
            }
        }
    }
    
    public void RemoveBook<T>( T book) where T: Book
    {
        if (book is PaperBook paperBook)
        {
            var key = paperBook.getISBN();
            _paperBooks.TryGetValue(key , out var result);
            if (result != null)
            {
                _paperBooks.Remove(key);
            }
            else
            {
                Console.WriteLine($"{paperBook} is not in the database");
            }
            
        } else if (book is EBook ebook)
        {
            var key = ebook.getISBN();
            _eBooks.TryGetValue(key , out var result);
            if (result != null)
            {
                _eBooks.Remove(key);
            }
            else
            {
                Console.WriteLine($"{ebook} is not in the database");
            }
        } else if (book is DemoBook demoBook)
        {
            var key = demoBook.getISBN();
            _demoBooks.TryGetValue(key , out var result);
            if (result != null)
            {
                _demoBooks.Remove(key);
            }
            else
            {
                Console.WriteLine($"{demoBook} is not in the database");
            }
        }
    }

    public IEnumerable<Book> ReturnOutdatedBooksBefore(DateTime time)
    {

       var result1 = _paperBooks.Where(bookPair => bookPair.Value.getBookDate() <= time)
           .Select(bookPair => bookPair.Value);
            
         var result2 = _paperBooks.Where(bookPair => bookPair.Value.getBookDate() <= time)
             .Select(bookPair => bookPair.Value);
             
         var result3 = _paperBooks.Where(bookPair => bookPair.Value.getBookDate() <= time)
             .Select(bookPair => bookPair.Value);
         
       IEnumerable<Book> result = result1.Concat(result2).Concat(result3);
       return result;
    }
    
}