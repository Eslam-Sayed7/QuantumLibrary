namespace Domain.ShippingService;

public class ShippingService : IShippingService
{
    private double ShippingTax = 10;
    
    public ShippingService()
    {
    }
    public void shipItem( ShippableItem item )
    {
        item.Ship();
    }
    
}