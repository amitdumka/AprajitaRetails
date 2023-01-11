namespace AprajitaRetails.BL.Vouchers;

public class VoucherManager
{
    public static string GenerateVoucherNumber(VoucherType type, string storeId, DateTime onDate, int count)
    {
        string typ = "PYM";

        switch (type)
        {
            case VoucherType.Payment:
                typ = "PYM";
                break;

            case VoucherType.Receipt:
                typ = "RCT";
                break;

            case VoucherType.Contra:
                break;

            case VoucherType.DebitNote:
                break;

            case VoucherType.CreditNote:
                break;

            case VoucherType.JV:
                break;

            case VoucherType.Expense:
                typ = "EXP";
                break;

            case VoucherType.CashReceipt:
                typ = "PCT";
                break;

            case VoucherType.CashPayment:
                typ = "CPT";
                break;

            default:
                typ = "PYM";
                break;
        }
        return $"{storeId}-${typ}-{onDate.Year}-{onDate.Month}-{onDate.Day}-{count}";
    }
}