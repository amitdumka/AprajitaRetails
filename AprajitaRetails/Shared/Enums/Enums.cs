public enum Gender
{ Male, Female, TransGender }

public enum Unit
{ Meters, Nos, Pcs, Packets, NoUnit }

public enum AttUnit
{ Present, Absent, HalfDay, Sunday, Holiday, StoreClosed, SundayHoliday, SickLeave, PaidLeave, CasualLeave, OnLeave };

public enum SalaryComponent
{ NetSalary, LastPcs, WOWBill, SundaySalary, Incentive, Others, Advance, PaidLeave, SickLeave, SalaryAdvance }

public enum EmpType
{ Salesman, StoreManager, HouseKeeping, Owner, Accounts, TailorMaster, Tailors, TailoringAssistance, Others }

public enum TaxType
{ GST, SGST, CGST, IGST, VAT, CST }

public enum NotesType
{ DebitNote, CreditNote }

public enum InvoiceType
{ Sales, SalesReturn, ManualSale, ManualSaleReturn }

public enum PurchaseInvoiceType
{ Purchase, PurchaseReturn }

public enum EntryStatus
{ Added, Approved, Rejected, Updated, Deleted, DeleteApproved }

public enum LedgerEntryType
{ Expenses, Payment, Receipt, Salary, AdvancePayment, AdvanceReceipt, ArvindLimited, Others }

public enum VoucherType
{ Payment, Receipt, Contra, DebitNote, CreditNote, JV, Expense, CashReceipt, CashPayment }

public enum PayMode
{ Cash, Card, RTGS, NEFT, IMPS, Wallets, Cheque, DemandDraft, Points, Others, Coupons, MixPayments, UPI, SaleReturn };

public enum PaymentMode
{ Cash, Card, RTGS, NEFT, IMPS, Wallets, Cheque, DemandDraft, Others, UPI };

public enum Size2
{ S, M, L, XL, XXL, XXXL, T28, T30, T32, T34, T36, T38, T40, T41, T42, T44, T46, T48, FreeSize, NS, NOTVALID, B36, B38, B40, B42, B44, B46, B96, B100, B104, B108 }
public enum Size
{ S, M, L, XL, XXL, XXXL, C28, C30, C32, C34, C36, C38, C40, C41, C42, C44, C46, C48, C96, C100, C104, C108, FreeSize, NS, NOTVALID ,C39,C92 }

public enum ProductCategory
{ Fabric, Apparel, Accessories, Tailoring, Trims, PromoItems, Coupons, GiftVouchers, Others, SuitCovers, InnerWear }

public enum CARD
{ DebitCard, CreditCard, AmexCard }

public enum CARDType
{ Visa, MasterCard, Maestro, Amex, Dinners, Rupay, }

public enum LedgerCategory
{ Credit, Debit, Income, Expenses, Assets, Bank, Loan, Purchase, Sale, Vendor, Customer }

public enum AccountType
{ Saving, Current, CashCredit, OverDraft, Others, Loan, CF }

public enum VendorType
{ EBO, MBO, Tailoring, NonSalable, OtherSaleable, Others, TempVendor, InHouse, Distributor, Brands, BrandAuth }

public enum DebitCredit
{ In, Out }

public enum UserType
{ Admin, SuperAdmin, SuperUser, PowerUser, User, Guest }

public enum RolePermission
{ Owner, GeneralManager, GroupManager, Accountant, CA, StoreManager, Salesmen, Guest, Other }


//For Mobile Client 
public enum ConType { Local, Remote, RemoteDb, HybridApi, HybridDB, Hybrid }
public enum DBType { Local, Azure, API, Remote, Mango, Others }
