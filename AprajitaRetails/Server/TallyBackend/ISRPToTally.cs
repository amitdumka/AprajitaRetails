namespace AprajitaRetails.Server.TallyBackend
{
    public interface ITallyOperation
    {
        void UpdateAttendance();
        void UpdateCashExpenseReceipt();
        void UpdateEmployees();
        void UpdateExpense();
        void UpdateProduct();
        void UpdatePurchase();
        void UpdateReciept();
        void UpdateSales();
        void UpdateStockItem();
    }
}
