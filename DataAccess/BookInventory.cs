using System.Data;
using Domain;
using Domain.ShippingService;

namespace DataAccess;

public class BookInventory : IBookInventory
{
    private IDictionary< string ,DemoBook> _demoBooks;
    private IDictionary< string ,EBook> _eBooks;
    private IDictionary<string, PaperBook> _paperBooks;
    
    public BookInventory()
    {
        _demoBooks = LoadDemoBooks();
        _eBooks = LoadEBooks();
        _paperBooks = LoadPaperBooks();
    }

    public T getBookById<T>(string id) where T : Book 
    {
        if (typeof(T) == typeof(PaperBook)) // used AI for this syntax 
        {
            _paperBooks.TryGetValue(id , out var result1);
            if (result1 is not null)
            {
                return (T)(object) result1; // used AI for this syntax of casting
            }
        }

        if (typeof(T) == typeof(EBook))
        {
            _eBooks.TryGetValue(id , out var result2);
            if (result2 is not null)
            {
                return (T)(object) result2;
            }
        }

        if (typeof(T) == typeof(DemoBook))
        {
            _eBooks.TryGetValue(id , out var result3);
            if (result3 is not null)
            {
                return (T)(object) result3;
            }
        }
        Console.WriteLine($"{id} is not a valid book id in the database");
        return null;
    }
    public IEnumerable<Book>  getAllBooks()
    {
        var result1 = _paperBooks
            .Select(bookPair => (Book) bookPair.Value); // asked Ai how to cast here 
            
        var result2 = _eBooks 
            .Select(bookPair => (Book) bookPair.Value);
             
        var result3 = _demoBooks 
            .Select(bookPair => (Book) bookPair.Value);
         
        IEnumerable<Book> result = result1.Concat(result2).Concat(result3);
        return result; 
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
            { "111-111-111" , new PaperBook("111-111-111" , "Head First Object Oriented Analysis and Design" , DateTime.Now, 10 , 30 , 600)},
        };
    }

    public IDictionary<string, EBook> LoadEBooks()
    {
        return new Dictionary<string, EBook>()
        {
            { "333-333-333", new EBook("333-333-333", "Demo Angular in Depth" , DateTime.Now, "PDF" , 10) }
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