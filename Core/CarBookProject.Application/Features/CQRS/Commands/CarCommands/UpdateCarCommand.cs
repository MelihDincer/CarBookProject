namespace CarBookProject.Application.Features.CQRS.Commands.CarCommands;

public class UpdateCarCommand
{
    public int CarID { get; set; }
    public int BrandID { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public int Km { get; set; }
    public string Transmission { get; set; }
    public byte Seat { get; set; } //Koltuk
    public byte Luggage { get; set; } //Bagaj
    public string Fuel { get; set; } //Yakıt
    public string BigImageUrl { get; set; } //Yakıt
}
