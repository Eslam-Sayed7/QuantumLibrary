using DataAccess;
using Domain;
using Domain.MailService;
using Domain.ShippingService;

namespace UI;

public class DIContainer
{
    public IMailService _MailService;
    public  IBookInventory _BookInventory;
    public  IShippingService _ShippingService;


    public DIContainer()
    {
        _MailService = new MailService();
        _BookInventory = new BookInventory();
        _ShippingService = new ShippingService();
    }
}