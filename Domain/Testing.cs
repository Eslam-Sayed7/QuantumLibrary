using Domain.ShippingService;

namespace Domain;

public static class Testing
{

    public static  PaperBook paperbooktobeAdded;
    public static  string paperbooktobuyId;
    public static  EBook EBooktobuy;
    public static  DemoBook Demobooktobesent;

    static Testing()
    {
        paperbooktobeAdded = new PaperBook("111-111-222", "addedPaperbook" , DateTime.Today - TimeSpan.FromDays(365),1, 20 , 200 );
        paperbooktobuyId = "111-111-111";
    }
    
}