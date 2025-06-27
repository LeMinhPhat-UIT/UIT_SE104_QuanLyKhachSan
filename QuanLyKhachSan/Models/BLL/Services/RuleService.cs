using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class RuleService : IBusinessService<Rule>
    {
        public void Add(Rule entity)
            => RepositoryHub.RuleRepo.Add(entity);

        public void Delete(int id)
            => RepositoryHub.RuleRepo.Delete(id);

        public List<Rule> GetAllData()
            => RepositoryHub.RuleRepo.GetAllData();

        public Rule? GetById(int id)
            => RepositoryHub.RuleRepo.GetById(id);

        public void Update(Rule entity)
            => RepositoryHub.RuleRepo.Update(entity);
    }
}
