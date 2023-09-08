using System.ComponentModel.DataAnnotations;

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
    }

    public class NewPassowrd
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }


    public class Role
    {
        [Key]
        public string Id { get; set; }
        public string RoleName { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsEnabled { get; set; } = true;

    }
}

