namespace AprajitaRetails.Server.TallyBackend
{

    //TODO: Use TallyServer API for Adding to Tally Software
    //TODO: later on move new Lib for this for better modularity and usebility.
    //TODO: Basic Naration Conncept For Tally  i.e : #ID#Date#Name#Amount/Unit#LastEditDate#Naration#EntryType#SRP_Auto
    //TODO: Basic Naration or remarks in SRP  #Masterid#EntryTye#LastUpdate#EntrySoftware#LastUpdate#
    
    //TODO: adding field or Tally MasterId Field for crossed and closed linked so this helps to navigate data properly. 

    //TODO: need to look for solution for Making local tally to listen on remote id . and remote server. 


    public class TallySyncOperation
    {
        public void DailySyncOperation() { }

        public void MonthSyncOperation() { }
        public void YearSyncOperation() { }

    }
    public class TallyToSRP : ITallyOperation
    {
        public void UpdateAttendance()
        {
            throw new NotImplementedException();
        }

        public void UpdateCashExpenseReceipt()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployees()
        {
            throw new NotImplementedException();
        }

        public void UpdateExpense()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchase()
        {
            throw new NotImplementedException();
        }

        public void UpdateReciept()
        {
            throw new NotImplementedException();
        }

        public void UpdateSales()
        {
            throw new NotImplementedException();
        }

        public void UpdateStockItem()
        {
            throw new NotImplementedException();
        }
    }
    public class SRPToTally : ITallyOperation
    {
        public void UpdateAttendance() { }
        public void UpdateSales() { }
        public void UpdatePurchase() { }
        public void UpdateExpense() { }
        public void UpdateReciept() { }
        public void UpdateCashExpenseReceipt() { }
        public void UpdateEmployees() { }
        public void UpdateProduct() { }
        public void UpdateStockItem() { }

    }

    public class TallyServer
    {
        public static bool IsTallyWebServerLive { get; set; } = false;
        public static bool IsTallyServerLive { get; set; } = false;
        public static string TallyWebServerUrl {  get; set; }=string.Empty;
        public static string TallyServrUrl {  get; set; }=string.Empty;

        public static void CheckTallyServerStatus() { }
        public  static void UpdateTallyServerDetails()
        {

        }
        public static void InitTallyServerConnection() { }

    }
}
