﻿namespace AprajitaRetails.Client.Helpers
{
    public class ClientSetting
    {
        public string Name { get; set; }

        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreGroupId { get; set; }
        public Guid? AppClientId { get; set; }

        
        public string UserName { get; set; }
        public string UserId { get; set; }
        public UserType UserType { get; set; }
        public RolePermission Permission{get;set;}
        //TODO: Need to implemnet Role and User based operation
        //TODO: Multiple store access or default single role access.

        public string Role { get; set; }

        public string EmployeeId { get; set; }

        //public event EventHandler UserChangedEvent;

        public void SetLogin(string code, string sName, string uName, string userid, string eid)
        {
            EmployeeId = eid; StoreCode = code; StoreName = sName; UserId = userid; UserName = uName;
            Name= uName; UserType = "StoreManager"; Role = "User";
            
        }

        public void SetLogin(string clientid, string groupcode, string storeName, string code, string userName, UserType userType, RolePermission rolePermission, string userid, string eid)
        {
            EmployeeId = eid; StoreCode = code; StoreName = storeName; UserId = userid; UserName = userName;

            Name= userName; UserType = userType; Role = "User";
            Permission =rolePermission;
        }

        public void Clear()
        {
            StoreName = EmployeeId = StoreCode = UserName = UserId = Role = "";
        }
    }
}