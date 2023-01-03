﻿public enum Gender { Male, Female, TransGender }
public enum Unit { Meters, Nos, Pcs, Packets, NoUnit }
public enum AttUnit { Present, Absent, HalfDay, Sunday, Holiday, StoreClosed, SundayHoliday, SickLeave, PaidLeave, CasualLeave, OnLeave };
public enum SalaryComponet { NetSalary, LastPcs, WOWBill, SundaySalary, Incentive, Others, Advance, PaidLeave, SickLeave, SalaryAdvance }
public enum EmpType { Salesman, StoreManager, HouseKeeping, Owner, Accounts, TailorMaster, Tailors, TailoringAssistance, Others }
public enum TaxType { GST, SGST, CGST, IGST, VAT, CST }
public enum NotesType { DebitNote, CreditNote }
public enum InvoiceType { Sales, SalesReturn, ManualSale, ManualSaleReturn }
public enum PurchaseInvoiceType { Purchase, PurchaseReturn }
public enum EntryStatus { Added, Approved, Rejected, Updated, Deleted, DeleteApproved }
public enum LedgerEntryType { Expenses, Payment, Reciept, Salary, AdvacePayment, AdvaceReciept, ArvindLimited, Others }
public enum VoucherType { Payment, Receipt, Contra, DebitNote, CreditNote, JV, Expense, CashReceipt, CashPayment }
public enum PayMode { Cash, Card, RTGS, NEFT, IMPS, Wallets, Cheques, DemandDraft, Points, Others, Coupons, MixPayments, UPI, SaleReturn };

public enum PaymentMode { Cash, Card, RTGS, NEFT, IMPS, Wallets, Cheques, DemandDraft, Others, UPI };
public enum Size { S, M, L, XL, XXL, XXXL, T28, T30, T32, T34, T36, T38, T40, T41, T42, T44, T46, T48, FreeSize, NS, NOTVALID, B36, B38, B40, B42, B44, B46, B96, B100, B104, B108 }
public enum ProductCategory { Fabric, Apparel, Accessiories, Tailoring, Trims, PromoItems, Coupons, GiftVouchers, Others, SuitCovers }
public enum Card { DebitCard, CreditCard, AmexCard }
public enum CardType { Visa, MasterCard, Mastro, Amex, Dinners, Rupay, }

public enum LedgerCategory { Credit, Debit, Income, Expenses, Assests, Bank, Loan, Purchase, Sale, Vendor, Customer }
public enum AccountType { Saving, Current, CashCredit, OverDraft, Others, Loan, CF }

