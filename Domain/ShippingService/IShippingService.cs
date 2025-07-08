namespace Domain.ShippingService;

public interface IShippingService
{
    public void shipItem<T>(T item) where T: Shippable;
}