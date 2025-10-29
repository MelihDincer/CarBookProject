using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.StatisticDtos
{
    public class ResultAllStatisticsDto
    {
        public int AuthorCount { get; set; }
        public decimal AvgDailyPrice { get; set; }
        public decimal AvgMonthlyPrice { get; set; }
        public decimal AvgWeeklyPrice { get; set; }
        public int BlogCount { get; set; }
        public string BlogTitleByMostComment { get; set; }
        public int BrandCount { get; set; }
        public string BrandNameByMostCars { get; set; }
        public int CarCountByAutoTransmission { get; set; }
        public int CarCount { get; set; }
        public int CarCountByLessThan1000Km { get; set; }
        public string BrandNameByCheapestCar { get; set; }
        public int ElectricCarCount { get; set; }
        public int GasolineOrDieselCarCount { get; set; }
        public int LocationCount { get; set; }
        public string BrandNameByMostExpensiveCar { get; set; }
    }
}
