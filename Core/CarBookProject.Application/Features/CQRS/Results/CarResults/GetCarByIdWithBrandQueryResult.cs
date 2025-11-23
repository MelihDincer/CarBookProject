using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdWithBrandQueryResult
    {
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; } //Koltuk
        public byte Luggage { get; set; } //Bagaj
        public string Fuel { get; set; } //Yakıt
        public string BigImageUrl { get; set; }
    }
}
