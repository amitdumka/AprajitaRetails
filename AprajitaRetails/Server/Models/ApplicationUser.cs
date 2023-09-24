using Microsoft.AspNetCore.Identity;

namespace AprajitaRetails.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? StoreId { get; set; }
        public string? EmployeeId { get; set; }

        public string? StoreGroupId { get; set; }
        public Guid? AppClinetId { get; set; }
        public UserType? UserType { get; set; } = global::UserType.Guest;
        public RolePermission? Permission { get; set; } = RolePermission.Guest;
        public bool Approved { get; set; } = false;
    }
}