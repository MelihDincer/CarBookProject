using CarBookProject.Domain.Entities;

namespace UdemyCarBook.Domain.Entities;

public class CarPricing
{
    //CarID-PricingID-Amount => 1-1-5200,25₺
    public int CarPricingID { get; set; }
    public int CarID { get; set; }
    public Car Car { get; set; }
    public int PricingID { get; set; }
    public Pricing Pricing { get; set; }
    public decimal Amount { get; set; }
}
