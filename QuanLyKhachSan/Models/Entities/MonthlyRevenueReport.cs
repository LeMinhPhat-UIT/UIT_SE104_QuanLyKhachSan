using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class MonthlyRevenueReport
    {
        [Key]
        public DateTime ReportMonth {  get; set; }
        public int TotalRevenue { get; set; }
        public List<MonthlyRevenueDetail> RevenueDetails { get; set; }
    }
}
