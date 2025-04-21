using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.DAL;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class RentalFormService : IBusinessService<RentalForm>
    {
        public RentalForm GetById(int id)
            => DALs.RentalRepo.GetById(id);

        public List<RentalForm> GetAllData()
            => DALs.RentalRepo.GetAllData();

        public void Add(RentalForm rental)
            => DALs.RentalRepo.Add(rental);

        public void Delete(int Id)
            => DALs.RentalRepo.Delete(Id);

        public void Update(RentalForm rental)
            => DALs.RentalRepo.Update(rental);

        public List<RentalForm> Filter(RentalForm template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.RentalForm.AsQueryable();
            var props = typeof(RentalForm).GetProperties();
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
    }
}
