using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AprajitaRetails.Shared.Models.Models.Bases;
using AprajitaRetails.Shared.Models.Models.Payroll;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Aprajita_Retails.Data;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Shared.Models.Models.Vouchers
{
    //public class Voucher
    //{
    //    [Key]
    //    public string VoucherNo { get; set; }
    //    public string VoucherType { get; set;}
    //    public DateTime OnDate { get; set; }
    //    public string PaidTo { get; set; }
    //    public decimal Amount { get; set; }
    //    public string PayMode { get; set; }
    //    public string PaymentDetails { get; set; }
    //    public string Remarks { get; set; }
    //    public string IssuedBy { get; set; }
    //    public string PartyId { get; set; }

    //}

    //public class CashVoucher
    //{
    //    [Key]
    //    public string CashVoucherNo { get; set; }
    //    public string CategoryId { get; set; }
    //    public string VoucherType { get; set; }
    //    public DateTime OnDate { get; set; }
    //    public string PaidTo { get; set; }
    //    public decimal Amount { get; set; }
    //    public string Remarks { get; set; }
    //    public string IssuedBy { get; set; }
    //}
    public class Voucher : BaseST
    {
        [Key]
        public string VoucherNumber { get; set; }
        public VoucherType VoucherType { get; set; }
        public DateTime OnDate { get; set; }
        public string SlipNumber { get; set; }

        public string PartyName { get; set; }

        public string Particulars { get; set; }

        public decimal Amount { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public string PaymentDetails { get; set; }
        public string Remarks { get; set; }
        public string AccountId { get; set; }
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public string PartyId { get; set; }
        public virtual Party Partys { get; set; }
    }

    [Table("V1_TranscationModes")]
    public class TranscationMode
    {
        [Key]
        public string TranscationId { get; set; }
        public string TranscationName { get; set; }
    }

    public class CashVoucher : BaseST
    {

        [Key]
        public string VoucherNumber { get; set; }
        public VoucherType VoucherType { get; set; }
        public DateTime OnDate { get; set; }


        public string TranscationId { get; set; }

        [ForeignKey("TranscationId")]
        public virtual TranscationMode TranscationMode { get; set; }

        public string SlipNumber { get; set; }
        public string PartyName { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public string PartyId { get; set; }
        public virtual Party Partys { get; set; }

    }
    [Table("V1_Notes")]
    public class Note : BaseST
    {
        [Key]
        public string NoteNumber { get; set; }
        public NotesType NotesType { get; set; }
        public DateTime OnDate { get; set; }

        public string PartyName { get; set; }
        public bool WithGST { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get { return (Amount * (TaxRate / 100)); } }
        public decimal NetAmount { get { return Amount + TaxAmount; } }
        public string Reason { get; set; }
        public string Remarks { get; set; }

        public string PartyId { get; set; }
        public virtual Party Party { get; set; }
    }

    public class LedgerGroup
    {
        [Key]
        public string LedgerGroupId { get; set; }
        public string GroupName { get; set; }
        public LedgerCategory Category { get; set; }
        public string Remark { get; set; }


    }
    [Table("V1_Parties")]
    public class Party : BaseST
    {
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public LedgerCategory Category { get; set; }
        public string GSTIN { get; set; }
        public string PANNo { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string LedgerGroupId { get; set; }
    }
    [Table("V1_LedgerMasters")]
    public class LedgerMaster
    {
        [Key]
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime OpeningDate { get; set; }
    }

    [Table("V1_PettyCashSheets")]
    public class PettyCashSheet
    {
        public string Id { get; set; }
        public DateTime OnDate { get; set; }
        //Balance
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }

        //Bank
        public decimal BankDeposit { get; set; }
        public decimal BankWithdrawal { get; set; }

        //Sale
        public decimal DailySale { get; set; }

        public decimal TailoringSale { get; set; }
        public decimal TailoringPayment { get; set; }

        //Different Sale
        public decimal ManualSale { get; set; }
        public decimal CardSale { get; set; }
        public decimal NonCashSale { get; set; }

        public decimal CustomerDue { get; set; }
        public string DueList { get; set; }
        public decimal CustomerRecovery { get; set; }
        public string RecoveryList { get; set; }

        public string ReceiptsNaration { get; set; }
        public decimal ReceiptsTotal { get; set; }

        public string PaymentNaration { get; set; }
        public decimal PaymentTotal { get; set; }

    }


public static class VoucherEndpoints
{
	public static void MapVoucherEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Voucher", async (ApplicationDbContext db) =>
        {
            return await db.Vouchers.ToListAsync();
        })
        .WithName("GetAllVouchers")
        .Produces<List<Voucher>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Voucher/{id}", async (string VoucherNumber, ApplicationDbContext db) =>
        {
            return await db.Vouchers.FindAsync(VoucherNumber)
                is Voucher model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetVoucherById")
        .Produces<Voucher>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Voucher/{id}", async (string VoucherNumber, Voucher voucher, ApplicationDbContext db) =>
        {
            var foundModel = await db.Vouchers.FindAsync(VoucherNumber);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(voucher);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateVoucher")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Voucher/", async (Voucher voucher, ApplicationDbContext db) =>
        {
            db.Vouchers.Add(voucher);
            await db.SaveChangesAsync();
            return Results.Created($"/Vouchers/{voucher.VoucherNumber}", voucher);
        })
        .WithName("CreateVoucher")
        .Produces<Voucher>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Voucher/{id}", async (string VoucherNumber, ApplicationDbContext db) =>
        {
            if (await db.Vouchers.FindAsync(VoucherNumber) is Voucher voucher)
            {
                db.Vouchers.Remove(voucher);
                await db.SaveChangesAsync();
                return Results.Ok(voucher);
            }

            return Results.NotFound();
        })
        .WithName("DeleteVoucher")
        .Produces<Voucher>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}

}
