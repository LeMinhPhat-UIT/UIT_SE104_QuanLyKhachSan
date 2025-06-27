using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.BLL;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private int _id;
        private string _name;
        private string _email;
        private string _role;
        private string _identity;
        private string _phone;
        private DateTime _date;

        public int ID { get; set; }
        public string UserName { get => _name; set { _name = value; OnPropertyChanged(nameof(UserName)); } }
        public string UserEmail { get => _email; set { _email = value; OnPropertyChanged(nameof(UserEmail)); } }
        public string UserRole { get => _role; set { _role = value; OnPropertyChanged(nameof(UserRole)); } }
        public string Identity { get => _identity; set { _identity = value; OnPropertyChanged(nameof(Identity)); } }
        public DateTime WorkingDate { get => _date; set { _date = value; OnPropertyChanged(nameof(WorkingDate)); } }
        public string PhoneNumber { get => _phone; set { _phone = value; OnPropertyChanged(nameof(PhoneNumber)); } }

        public UserViewModel() 
        {
            WorkingDate = DateTime.Now;
        }
        public UserViewModel(User user) 
        {
            ID = user.UserID;
            UserName = user.UserName;
            UserEmail = user.EmailAddress;
            UserRole = QuanLyKhachSan.Models.BLL.Service.UserService.GetRole(user.UserID).RoleName;
            Identity = user.IdentityNumber;
            WorkingDate = user.WorkingDate;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
