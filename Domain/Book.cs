namespace Domain;

public abstract class Book
{
    private string ISBN;
    private string Title;
    private DateTime BookDate;

    public Book(string isbn, string title, DateTime bookDate)
    {
        ISBN = isbn;
        Title = title;
        BookDate = bookDate;
    }
    public string getISBN() => ISBN ;
    public DateTime getBookDate() => BookDate;
    public string getBookTitle() => Title;
}