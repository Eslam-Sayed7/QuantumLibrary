using System.Net.Mail;
using Domain;
using Domain.BuyService;
using UI;

public class Program
{
    public static void Main(string[] args)
    {
        bool RUNNING = true;

        var services = new DIContainer();
        var BookStoreServices = new BookStore(services._MailService,services._ShippingService, services._BookInventory);
        
        
        Console.WriteLine("Welcome to the Quantum Book Library!");
        while (RUNNING)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. Make Add Book");
            Console.WriteLine("3. Buybook");
            Console.WriteLine("4. List Outdated Books");
            Console.WriteLine("0. Exit");
            
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    BookStoreServices.ListBooks();
                    break;
                case "2":
                    BookStoreServices.AddBook();
                    break;
                case "3":
                    var testbook = Testing.EBooktobuy;
                    var res  = BookStoreServices.Buybook(testbook.getISBN() , 1 , "eslam@gmail.com");
                    if( res)
                    {
                        Console.WriteLine($"book with title {testbook.getBookTitle()} is bought");
                    }
                    else
                    {
                        Console.WriteLine("this book is not in the database");
                    }
                    break;
                case "4":
                    BookStoreServices.ListOutDatedBooks();
                    break;
                case "0":
                    RUNNING = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}