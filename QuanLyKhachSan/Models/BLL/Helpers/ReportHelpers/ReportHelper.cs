using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.BLL.Helpers.QueryHelpers;

namespace QuanLyKhachSan.Models.BLL.Helpers.ReportHelpers
{
    public class MonthlyRevenueModel
    {
        public int? RoomTierID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class RoomTierPercentageModel
    {
        public int? RoomTierID { get; set; }
        public decimal Percentage { get; set; }
    }
    public class ReportHelper
    {
        public static void GenerateReport(int tierID, int userID, DateTime reportDate)
        {
            var list = QueryHelper.Filter(
                Service.InvoiceService.GetAllData(),
                x => x.InvoiceDate == reportDate
            );
            var total = list.Sum(x => x.TotalAmount);
            var report = new RevenueReport
            {
                UserID = userID,
                RoomTierID = tierID,
                RevenueDate = reportDate,
                TotalRevenue = total
            };
            Service.RevenueService.Add(report);
            list.ForEach(x => Service.RevenueService.AddInvoice(report.ReportID, x.InvoiceID));
        }

        public static List<MonthlyRevenueModel> GroupRevenueByMonth(List<RevenueReport> reports, bool groupByRoomTier)
        {
            var query = reports.AsQueryable();

            if (groupByRoomTier)
                return query
                    .GroupBy(x => new { x.RoomTierID, x.RevenueDate.Year, x.RevenueDate.Month })
                    .Select(group => new MonthlyRevenueModel
                    {
                        RoomTierID = group.Key.RoomTierID,
                        Year = group.Key.Year,
                        Month = group.Key.Month,
                        StartDate = new DateTime(group.Key.Year, group.Key.Month, 1),
                        EndDate = new DateTime(group.Key.Year, group.Key.Month, DateTime.DaysInMonth(group.Key.Year, group.Key.Month)),
                        TotalRevenue = group.Sum(x => x.TotalRevenue)
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToList();
            else
                return query
                    .GroupBy(x => new { x.RevenueDate.Year, x.RevenueDate.Month })
                    .Select(group => new MonthlyRevenueModel
                    {
                        RoomTierID = null,
                        Year = group.Key.Year,
                        Month = group.Key.Month,
                        StartDate = new DateTime(group.Key.Year, group.Key.Month, 1),
                        EndDate = new DateTime(group.Key.Year, group.Key.Month, DateTime.DaysInMonth(group.Key.Year, group.Key.Month)),
                        TotalRevenue = group.Sum(x => x.TotalRevenue)
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToList();
        }

        public static List<MonthlyRevenueModel> GetRTMonthlyRevenue(List<RevenueReport> dailyReports)
            => GroupRevenueByMonth(dailyReports, true);

        public static List<MonthlyRevenueModel> GetMonthlyRevenue(List<RevenueReport> dailyReports)
            => GroupRevenueByMonth(dailyReports, false);

        public static List<RoomTierPercentageModel> GetMonthlyStatistic(List<MonthlyRevenueModel> monthlyReports, int month, int year)
        {
            var list = QueryHelper.Filter(monthlyReports, x => x.Year == year && x.Month == month);
            decimal totalRevenue = list.Sum(x => x.TotalRevenue);
            if (totalRevenue == 0) 
                return list.Select
                (
                    x => new RoomTierPercentageModel
                    {
                        RoomTierID = x.RoomTierID,
                        Percentage = 0
                    }
                ).ToList();
            return 
                list
                    .GroupBy(x => x.RoomTierID)
                    .Select(group => new RoomTierPercentageModel
                    {
                        RoomTierID = group.Key,
                        Percentage = (group.Sum(x => x.TotalRevenue) / totalRevenue) * 100
                    })
                    .OrderByDescending(x => x.Percentage)
                    .ToList();
        }
    }
}
