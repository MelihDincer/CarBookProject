namespace CarBookProject.Application.Features.Mediator.Results.CarPricingResults;

public class GetCarPricingWithCarQueryResult
{
	public int CarPricingID { get; set; }
	public string BrandName { get; set; }
	public string Model { get; set; }
	public string CoverImageUrl { get; set; }
	public string PricingName { get; set; }
	public decimal Amount { get; set; }
}
