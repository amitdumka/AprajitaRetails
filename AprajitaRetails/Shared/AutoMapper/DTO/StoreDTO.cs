using System;
using AprajitaRetails.Shared.Models.Bases;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.AutoMapper.DTO
{
    public class StoreDTO
    {
        [Key]
        public string StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public DateTime BeginDate { get; set; }
        public bool IsActive { get; set; }
        public string StoreManager { get; set; }
        public string StorePhoneNumber { get; set; }
        public string StoreEmailId { get; set; }
        public string City { get; set; }
        public string PanNo { get; set; }
        public string GSTIN { get; set; }
        public string VatNo { get; set; }
         
    }


    public class SalesmanDTO
    {
        [Key]
        public string SalesmanId { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }


     

    public class CashDetailDTO
    {
        [Key]
        public string CashDetailId { get; set; }
        public DateTime OnDate { get; set; }
        public int Count { get; set; }
        public int TotalAmount { get; set; }

        public int N2000 { get; set; }
        public int N1000 { get; set; }
        public int N500 { get; set; }
        public int N200 { get; set; }
        public int N100 { get; set; }
        public int N50 { get; set; }
        public int N20 { get; set; }
        public int N10 { get; set; }

        public int C10 { get; set; }
        public int C5 { get; set; }
        public int C2 { get; set; }
        public int C1 { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }

    }
}

