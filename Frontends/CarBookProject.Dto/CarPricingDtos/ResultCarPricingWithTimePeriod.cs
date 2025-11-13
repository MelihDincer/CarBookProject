using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.CarPricingDtos
{
    public class ResultCarPricingWithTimePeriod
    {
        public string Model { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
