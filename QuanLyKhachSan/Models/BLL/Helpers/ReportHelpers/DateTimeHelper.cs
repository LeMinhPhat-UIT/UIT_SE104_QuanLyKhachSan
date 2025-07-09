using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.BLL.Helpers.ReportHelpers
{
    public class DateTimeHelper
    {
        public static List<DateTime> GetFullWeekFromDate(DateTime inputDate)
        {
            List<DateTime> result = new List<DateTime>();
            int isoDayOfWeek = ((int)inputDate.DayOfWeek + 6) % 7;
            DateTime monday = inputDate.Date.AddDays(-isoDayOfWeek);
            for (int i = 0; i < 7; i++)
                result.Add(monday.AddDays(i));

            return result;
        }
    }
}
