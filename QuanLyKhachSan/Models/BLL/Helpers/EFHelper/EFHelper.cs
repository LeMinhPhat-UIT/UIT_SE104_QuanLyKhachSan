using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuanLyKhachSan.Models.BLL.Helpers.EFHelper
{
    public static class EFHelper
    {
        public static T? DetachAndClone<T>(T entity)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(entity);
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }

        public static T AttachEntity<T>(DbContext context, T entity) where T : class
        {
            var keyNames = context.Model.FindEntityType(typeof(T))?
                .FindPrimaryKey()?
                .Properties
                .Select(p => p.Name)
                .ToList();

            if (keyNames == null || keyNames.Count == 0)
                throw new InvalidOperationException($"Cannot find primary key for type {typeof(T).Name}");

            // Giả sử chỉ có 1 khóa chính (có thể mở rộng cho composite key nếu cần)
            var keyName = keyNames.First();
            var keyValue = typeof(T).GetProperty(keyName)?.GetValue(entity);

            var local = context.Set<T>().Local
                .FirstOrDefault(e =>
                {
                    var localKeyValue = typeof(T).GetProperty(keyName)?.GetValue(e);
                    return Equals(localKeyValue, keyValue);
                });

            if (local == null)
            {
                context.Attach(entity);
                return entity;
            }
            else
            {
                context.Entry(local).CurrentValues.SetValues(entity);
                return local;
            }
        }
    }
}
