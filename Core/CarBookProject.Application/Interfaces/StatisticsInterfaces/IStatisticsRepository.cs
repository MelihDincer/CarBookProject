namespace CarBookProject.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetCarCountAsync(); //Araba sayısı
        Task<int> GetLocationCountAsync(); //Lokasyon sayısı
        Task<int> GetAuthorCountAsync(); //Yazar sayısı
        Task<int> GetBlogCountAsync(); //Blog sayısı
        Task<int> GetBrandCountAsync(); //Marka sayısı
        Task<decimal> GetAvgRentPriceDailyAsync(); //Marka sayısı
        Task<decimal> GetAvgRentPriceWeeklyAsync(); //Günlük ortalama araç kiralama fiyatı
        Task<decimal> GetAvgRentPriceMonthlyAsync(); //Haftalık ortalama araç kiralama fiyatı
        Task<int> GetCarCountByTransmissionIsAutoAsync(); //Aylık ortalama araç kiralama fiyatı
        Task<string> GetBrandNameWithMostCarsAsync(); //en fazla aracı olan araba markası
        Task<string> GetBlogTitleWithMostCommentsAsync(); //en fazla yorum alan blog başlığı
        Task<int> GetCarsWithLessThan1000KmAsync(); //1000km den düşük araçlar
        Task<int> GetGasolineOrDieselCarsAsync(); //benzin veya dizel araçlar
        Task<int> GetElectricCarsAsync(); //elektrikli araçlar
        Task<string> GetMostExpensiveCarBrandAsync(); //en pahalı araç markası
        Task<string> GetCheapestCarBrandAsync(); //en ucuz araç markası
    }
}
