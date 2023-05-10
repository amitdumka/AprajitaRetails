using Microsoft.AspNetCore.Identity;

namespace AprajitaRetails.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? StoreId { get; set; }
        public string? EmployeeId { get; set; }
        //public string? StoreGroupId { get; set; }
        //public Guid? AppClinetId { get; set; }
       // public RolePremission Premission { get; set; }

    }

    
}
public enum RolePremission { Owner, Accountant, CA, StoreManager, Salesmen, Guest, Other }