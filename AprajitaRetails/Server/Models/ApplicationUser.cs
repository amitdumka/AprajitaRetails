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
        //public UserType? UserType{get;set;}=UserType.Guest;
        //public RolePremission? Premission { get; set; }=Guest;
        //public bool Approved{get;set;}=false;

    }


}
public enum UserType { Admin, SuperUser, PwoerUser, User, Guest }

public enum RolePremission { Owner, GeneralManager, GroupManager, Accountant, CA, StoreManager, Salesmen, Guest, Other }