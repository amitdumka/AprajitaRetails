using AprajitaRetails.Shared.Models.Auth;

namespace AprajitaRetails.Client.Helpers
{
    public class ClientSetting
    {
        public string Name { get; set; }

        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreGroupId { get; set; }
        public Guid? AppClientId { get; set; } = Guid.Parse("a765c480-25c8-440b-9fc4-047e4a66834f");

        
        public string UserName { get; set; }
        public string UserId { get; set; }
        public UserType UserType { get; set; }
        public RolePermission Permission{get;set;}
        //TODO: Need to implemnet Role and User based operation
        //TODO: Multiple store access or default single role access.

        public string Role { get; set; }

        public string EmployeeId { get; set; }
      
        

        public void SetLogin( LoggedUser user)
        {
            this.StoreCode = user.StoreId;
            this.StoreGroupId = user.StoreGroupId; 
            this.EmployeeId = user.EmployeeId;
            this.AppClientId = user.AppClinetId;
            this.UserName = user.Id;
            this.UserId = user.Id;
            this.Permission = user.Permission;
            this.UserType = user.UserType;
            this.Role = user.Permission.ToString();
            this.Name = user.FullName;

        }


        //TODO: need to handle user settings on login
        [Obsolete]
        public void SetLogin(string code, string sName, string uName, string userid, string eid)
        {
            EmployeeId = eid; StoreCode = code; StoreName = sName; UserId = userid; UserName = uName;
            Name= uName; UserType = UserType.PowerUser; Role = "User";
            
        }

         

        public void Clear()
        {
           StoreGroupId= StoreName = EmployeeId = StoreCode = UserName = UserId = Role = "";
           AppClientId = Guid.Empty;
            Permission = RolePermission.Guest;
            UserType = UserType.Guest;


        }
    }
}