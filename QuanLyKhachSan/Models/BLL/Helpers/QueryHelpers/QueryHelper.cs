using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        //public static List<T> Search<T>(T template) where T : class
        //{
        //    using var dbcontext = new HotelDbContext();
        //    IQueryable<T> query = dbcontext.Set<T>().AsQueryable();

        //    var parameter = Expression.Parameter(typeof(T), "x");
        //    Expression? combined = null;

        //    foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        //    {
        //        if (!prop.CanRead) continue;

        //        // Skip navigation/collection types (except string)
        //        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
        //            continue;

        //        if (!prop.PropertyType.IsValueType && prop.PropertyType != typeof(string))
        //            continue;

        //        var value = prop.GetValue(template);
        //        if (value == null) continue;

        //        var effectiveType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

        //        if (effectiveType == typeof(string))
        //        {
        //            if (string.IsNullOrWhiteSpace(value as string)) continue;
        //        }
        //        else
        //        {
        //            object? defaultValue = Activator.CreateInstance(effectiveType);
        //            if (value.Equals(defaultValue)) continue;
        //        }

        //        var propertyAccess = Expression.Property(parameter, prop.Name);
        //        var constant = Expression.Constant(value, prop.PropertyType);
        //        Expression? condition = null;

        //        if (effectiveType == typeof(string))
        //        {
        //            var likeMethod = typeof(DbFunctionsExtensions).GetMethod(
        //                nameof(DbFunctionsExtensions.Like),
        //                new[] { typeof(DbFunctions), typeof(string), typeof(string) }
        //            );

        //            if (likeMethod != null)
        //            {
        //                condition = Expression.Call(
        //                    null,
        //                    likeMethod,
        //                    Expression.Constant(EF.Functions),
        //                    propertyAccess,
        //                    Expression.Constant($"%{value}%", typeof(string))
        //                );
        //            }
        //        }
        //        else
        //        {
        //            condition = Expression.Equal(propertyAccess, constant);
        //        }

        //        if (condition != null)
        //        {
        //            combined = combined == null ? condition : Expression.AndAlso(combined, condition);
        //        }
        //    }

        //    if (combined != null)
        //    {
        //        var lambda = Expression.Lambda<Func<T, bool>>(combined, parameter);
        //        query = query.Where(lambda);
        //    }

        //    return query.ToList();
        //}

        public static List<T> Search<T>(List<T> list, T template) where T : class
        {
            var query = list.AsQueryable();

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? combined = null;

            foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanRead) continue;

                // Skip collections (except string)
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                    continue;

                if (!prop.PropertyType.IsValueType && prop.PropertyType != typeof(string))
                    continue;

                var value = prop.GetValue(template);
                if (value == null) continue;

                var effectiveType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                // Skip default values
                if (effectiveType == typeof(string))
                {
                    if (string.IsNullOrWhiteSpace(value as string)) continue;
                }
                else
                {
                    var defaultValue = Activator.CreateInstance(effectiveType);
                    if (value.Equals(defaultValue)) continue;
                }

                var propertyAccess = Expression.Property(parameter, prop.Name);
                var constant = Expression.Constant(value, prop.PropertyType);
                Expression? condition = null;

                if (effectiveType == typeof(string))
                {
                    var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
                    condition = Expression.Call(propertyAccess, containsMethod!, Expression.Constant((string)value));
                }
                else
                {
                    condition = Expression.Equal(propertyAccess, constant);
                }

                if (condition != null)
                {
                    combined = combined == null ? condition : Expression.AndAlso(combined, condition);
                }
            }

            if (combined != null)
            {
                var lambda = Expression.Lambda<Func<T, bool>>(combined, parameter);
                query = query.Where(lambda);
            }

            return query.ToList();
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
