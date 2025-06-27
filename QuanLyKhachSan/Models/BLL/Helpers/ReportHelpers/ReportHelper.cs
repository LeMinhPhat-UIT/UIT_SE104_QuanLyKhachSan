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

    public class WeeklyRevenueModel
    {
        public int? RoomTierID { get; set; }
        public int Year { get; set; }
        public int WeekNumber { get; set; }
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
                x =>
                {
                    var roomTierID = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetRoom(x.ReservationID).RoomTierID;
                    return x.InvoiceDate == reportDate && roomTierID == tierID;
                }
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
            list.ForEach(x =>
            {
                x.ReportID = report.ReportID;
                Service.InvoiceService.Update(x);
            });
        }

        private static List<MonthlyRevenueModel> GroupRevenueByMonth(List<RevenueReport> reports, bool groupByRoomTier)
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

        private static DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private static List<WeeklyRevenueModel> GetWeeklyRevenue(List<RevenueReport> reports, bool groupByRoomTier)
        {
            var preprocessed = reports
                .Select(x => new
                {
                    Report = x,
                    StartOfWeek = GetStartOfWeek(x.RevenueDate),
                })
                .ToList();

            if (groupByRoomTier)
                return preprocessed
                    .GroupBy(x => new { x.Report.RoomTierID, x.StartOfWeek })
                    .Select(group => new WeeklyRevenueModel
                    {
                        RoomTierID = group.Key.RoomTierID,
                        Year = group.Key.StartOfWeek.Year,
                        WeekNumber = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                            group.Key.StartOfWeek,
                            System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                            DayOfWeek.Monday
                        ),
                        StartDate = group.Key.StartOfWeek,
                        EndDate = group.Key.StartOfWeek.AddDays(6),
                        TotalRevenue = group.Sum(x => x.Report.TotalRevenue)
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.WeekNumber)
                    .ToList();
            else
                return preprocessed
                    .GroupBy(x => x.StartOfWeek)
                    .Select(group => new WeeklyRevenueModel
                    {
                        RoomTierID = null,
                        Year = group.Key.Year,
                        WeekNumber = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                            group.Key,
                            System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                            DayOfWeek.Monday
                        ),
                        StartDate = group.Key,
                        EndDate = group.Key.AddDays(6),
                        TotalRevenue = group.Sum(x => x.Report.TotalRevenue)
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.WeekNumber)
                    .ToList();
        }

        public static List<WeeklyRevenueModel> GetRTWeeklyRevenue(List<RevenueReport> dailyReports)
            => GetWeeklyRevenue(dailyReports, true);

        public static List<WeeklyRevenueModel> GetAllWeeklyRevenue(List<RevenueReport> dailyReports)
            => GetWeeklyRevenue(dailyReports, false);

        public static int GetWeekNumber(DateTime date)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return culture.Calendar.GetWeekOfYear(
                date,
                System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday
            );
        }
    }
}
