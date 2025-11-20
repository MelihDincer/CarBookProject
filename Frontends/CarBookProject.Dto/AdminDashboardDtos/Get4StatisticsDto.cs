using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.AdminDashboardDtos
{
    public class Get4StatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int BrandCount { get; set; }
        public decimal AvgDailyPrice { get; set; }
    }
}
