namespace Domain;

public class ShippableItem : Shippable
{
    private string Address;
    // public static int Stock;

    public ShippableItem()
    {
        // if (Stock <= 0)
        // {
            // Console.WriteLine("No more copies for this book");
        // }
        Address = "DemoAddress";
    }
    public void Ship()
    {
        Console.WriteLine($"this item is shipped to{Address}" );
    }
}