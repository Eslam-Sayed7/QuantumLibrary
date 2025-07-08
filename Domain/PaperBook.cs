using Domain.ShippingService;

namespace Domain;

public class PaperBook : Book
{
    private int Stock;

    public PaperBook(string isbn, string title, DateTime bookDate, int stock) : base(isbn, title, bookDate)
    {
        Stock = stock;
    }

    public void AddToStock(int added)
    {
        Stock += added;
    }

    public int getStock() => Stock;
}