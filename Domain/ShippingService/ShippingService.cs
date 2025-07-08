namespace Domain.ShippingService;

public class ShippingService : IShippingService
{
    private double ShippingTax = 10;
    
    public ShippingService()
    {
    }
    public void shipItem<T>( T item ) where T : Shippable 
    {
        var taxes = item.Ship(ShippingTax);
        Console.WriteLine($"this {item} is shiped with cost {taxes}");
    }
    
}