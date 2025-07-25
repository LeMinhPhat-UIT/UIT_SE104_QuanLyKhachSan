﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuanLyKhachSan.Models.BLL.Helpers.Security
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserViewModel? User { get; set; }
    }

    public class LoginService
    {
        public static LoginResult Login(int id, string password)
        {
            if (id <= 0)
                return new LoginResult
                {
                    Success = false,
                    Message = "id invalid",
                    User = null
                };
            var user = RepositoryHub.UserRepo.GetById(id);
            if (user is null)
                return new LoginResult
                {
                    Success = false,
                    Message = "no account was found",
                    User = null
                };
            var verify = PasswordService.VerifyPassword(password, user.Password);
            return 
                verify == true ? new LoginResult
                {
                    Success = true,
                    Message = "",
                    User = new UserViewModel(user)
                }
                : new LoginResult 
                {
                    Success = false,
                    Message = "incorrect password",
                    User = null
                };
        }
    }
}
