using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Account? Account { get; set; }
    }

    public class AccountService
    {
        public static void Add(Account account)
        {
            account.Password = PasswordService.HashPassword(account.Password);
            DALs.AccountRepo.Add(account);
        }

        public static void Delete(int Id)
            =>DALs.AccountRepo.Delete(Id);

        public static void Update(Account account)
            =>DALs.AccountRepo.Update(account);

        public static LoginResult Login(int id, string password)
        {
            if (id <= 0)
                return new LoginResult
                {
                    Success = false,
                    Message = "id invalid",
                    Account = null
                };
            var account = DALs.AccountRepo.GetById(id);
            if (account == null)
                return new LoginResult
                {
                    Success = false,
                    Message = "no account",
                    Account = null
                };
            var verify = PasswordService.VerifyPassword(password, account.Password);
            return 
                verify == true ? new LoginResult
                {
                    Success = true,
                    Message = "",
                    Account = account
                }
                : new LoginResult 
                {
                    Success = false,
                    Message = "incorrect password",
                    Account = null
                };
        }
    }
}
