﻿using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.Models.Auth
{
    public class RegisterUserVM
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string StoreId { get; set; }
        public string EmployeeId { get; set; }
        public string StoreGroupId { get; set; }

        //public Guid AppClientId { get; set; }
        //public UserType UserType { get; set; }
        //public RolePermission Permission { get; set; }
    }

    public class LoginVM
    {
        public string StoreId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoggedUser
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string StoreId { get; set; }
        public string EmployeeId { get; set; }

        public string StoreGroupId { get; set; }
        public Guid AppClinetId { get; set; }
        public UserType UserType { get; set; }
        public RolePermission Permission { get; set; }
    }

    public class NewPassowrd
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
    public class AproveUserVM
    {
        public string UserName { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }

        public UserType UserType { get; set; }
        public RolePermission RolePermission { get; set; }
        public bool Aproved { get; set; }
    }

    [Obsolete]
    public class Role
    {
        [Key]
        public string Id { get; set; }

        public string RoleName { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsEnabled { get; set; } = true;
    }
}