using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Stores;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.Models.Bases
{
    public class Base
    {
        public string UserId { get; set; }
        public bool IsReadOnly { get; set; }
        public bool MarkedDeleted { get; set; }
    }

    public class BaseST : Base
    {
        [DefaultValue("ARD")]
        [Display(Name = "Store")]
        public string StoreId { get; set; }
        public virtual Store? Store { get; set; }
        public EntryStatus EntryStatus { get; set; }
    }



    public class Contact : Person
    {
        public int ContactId { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Phone]
        public string MobileNumber { get; set; }
        [EmailAddress]
        public string EMail { get; set; }
    }


    public class Person : Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Title { get; set; }
        public Gender Gender { get; set; } // Enum Gender
        public DateTime DOB { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public string AddressLine { get; set; }
    }

    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
    }

    public class State
    {
        [Key]
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
    public class Country
    {
        [Key]
        public string CountryName { get; set; }
    }
}
namespace AprajitaRetails.Shared.Models.Stores
{
    public class Store
    {
        [Key]
        public string StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public string StoreManager { get; set; }
        public string StoreManagerContactNo { get; set; }

        public string StorePhoneNumber { get; set; }
        public string StoreEmailId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public string PanNo { get; set; }
        public string GSTIN { get; set; }
        public string VatNo { get; set; }
        public bool MarkedDeleted { get; set; }
    }


    public class Salesman : BaseST
    {
        [Key]
        public string SalesmanId { get; set; }
        public string Name { get; set; }

        public string StoreId { get; set; }
        public string EmployeeId { get; set; }
        public bool IsActive { get; set; }
    }


    public class Customer
    {
        [Key]
        public string MobileNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get { return (FirstName + " " + LastName); } }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public int NoOfBills { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OnDate { get; set; }
    }

    public class CashDetail : BaseST
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

    }
}

