
namespace Domain;

public class PaperBook : Book , Shippable 
{
    private int Stock;
    private double price;
    private double weight;
    
    public PaperBook(string isbn, string title, DateTime bookDate, int stock, double price, double weight) : base(isbn, title, bookDate)
    {
        Stock = stock;
        this.price = price;
        this.weight = weight;
    }

    public void AddToStock(int added)
    {
        Stock += added;
    }

    public int getStock() => Stock;

    public double Ship(double costPergram)
    {
        return weight * costPergram;
    }
}