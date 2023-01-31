namespace AprajitaRetails.Helpers
{
    public class ClientSetting
    {
        public string Name { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string Role { get; set; }
        public string EmployeeId { get; set; }

        //public event EventHandler UserChangedEvent;

        public void SetLogin(string code, string sName, string uName, string userid, string eid)
        {
            EmployeeId = eid; StoreCode = code; StoreName = sName; UserId = userid; UserName = uName;
        }

        public void Clear()
        {
            StoreName = EmployeeId = StoreCode = UserName = UserId = Role = "";
        }
    }
}