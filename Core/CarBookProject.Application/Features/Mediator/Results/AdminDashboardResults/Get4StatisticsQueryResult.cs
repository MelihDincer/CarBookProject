using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.AdminDashboardResults
{
    public class Get4StatisticsQueryResult
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int BrandCount { get; set; }
        public decimal AvgDailyPrice { get; set; }
    }
}
