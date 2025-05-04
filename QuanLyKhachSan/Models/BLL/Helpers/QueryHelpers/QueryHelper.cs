using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.Models.BLL.Helpers.QueryHelpers
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }
    public class QueryHelper
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
    }
}
