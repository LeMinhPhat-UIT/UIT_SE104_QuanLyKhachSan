using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class RoleViewModel : BaseViewModel
    {
        public int ID { get; set; }
        public string RoleName { get; set; }

        public RoleViewModel(Role role)
        {
            RoleName = role.RoleName;
            ID = role.RoleID;
        }
    }
}
