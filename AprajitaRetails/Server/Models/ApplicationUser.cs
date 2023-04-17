using Microsoft.AspNetCore.Identity;

namespace AprajitaRetails.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? StoreId { get; set; }
        public string? EmployeeId { get; set; }
    }
}