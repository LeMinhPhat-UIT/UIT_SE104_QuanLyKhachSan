using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace QuanLyKhachSan.Models.BLL.Helper
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }
    public class HelperService
    {
        public static List<T> Search<T>(T template) where T : class
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.Set<T>().AsQueryable();
            var props = typeof(T).GetProperties();
            props.ToList().ForEach(
                prop =>
                {
                    var value = prop.GetValue(template);
                    if (value == null) return;
                    if (prop.PropertyType == typeof(string))
                    {
                        string strValue = value as string;
                        if (!string.IsNullOrWhiteSpace(strValue))
                        {
                            list = list.Where(a =>
                                EF.Functions.Like(EF.Property<string>(a, prop.Name), $"%{strValue}%"));
                        }
                    }
                    else if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                    {
                        // kiểu nullable như int?, DateTime?, bool?
                        list = list.Where(a =>
                            EF.Property<object>(a, prop.Name).Equals(value));
                    }
                }
            );
            return list.ToList();
        }

        public static List<T> Sort<T>(List<T> source, string property, SortOrder order=SortOrder.Ascending)
        {
            if (string.IsNullOrEmpty(property)) return source;
            var prop = typeof(T).GetProperty(property);
            if(prop == null) return source;
            if (order == SortOrder.Ascending)
                return source.OrderBy(x => prop.GetValue(x)).ToList();
            else
                return source.OrderByDescending(x => prop.GetValue(x)).ToList();
        }

        public static List<T> Filter<T>(List<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
                return source;
            return source.Where(predicate).ToList();
        }
        
        public static RevenueReport GenerateReport(int tierID, int userID, DateTime fromDate, DateTime toDate)
        {
            var report = new RevenueReport();
            var list = Filter<Invoice>(
                Service.InvoiceService.GetAllData(),
                x => x.InvoiceDate >= fromDate && x.InvoiceDate <= toDate
            )
            .Where(x =>
            {
                var y = Service.InvoiceService.GetRental(x.InvoiceID);
                var z = Service.RentalService.GetRoom(y.RoomID).RoomTierID;
                return tierID == z;
            }).ToList();
            var total = list.Sum(x => x.TotalAmount);
            report = new RevenueReport
            {
                UserID = userID,
                RoomTierID = tierID,
                FirstDate = fromDate,
                LastDate = toDate,
                TotalRevenue = total,
            };
            Service.RevenueService.Add(report);
            list.ForEach(x => 
                Service.RevenueDetailService.Add(new RevenueDetail { 
                    ReportID = report.ReportID, InvoiceID = x.InvoiceID 
                })
            );
            return report;
        }

        public static RevenueReport GenerateReport(int tierID, int userID, DateTime fromDate, int days)
        {
            var report = new RevenueReport();
            var list = Filter<Invoice>(
                Service.InvoiceService.GetAllData(),
                x => x.InvoiceDate >= fromDate && x.InvoiceDate <= fromDate.AddDays(days)
            )
            .Where(x =>
            {
                var y = Service.InvoiceService.GetRental(x.InvoiceID);
                var z = Service.RentalService.GetRoom(y.RoomID).RoomTierID;
                return tierID == z;
            }).ToList();
            var total = list.Sum(x => x.TotalAmount);
            report = new RevenueReport
            {
                UserID = userID,
                RoomTierID = tierID,
                FirstDate = fromDate,
                LastDate = fromDate.AddDays(days),
                TotalRevenue = total,
            };
            Service.RevenueService.Add(report);
            list.ForEach(x =>
                Service.RevenueDetailService.Add(new RevenueDetail
                {
                    ReportID = report.ReportID,
                    InvoiceID = x.InvoiceID
                })
            );
            return report;
        }
    }
}
