using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Vouchers;
using AutoMapper;

namespace AprajitaRetails.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Attendance, AttendanceDTO>()
                 .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                 .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName)).ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                 .ReverseMap();

            CreateMap<MonthlyAttendance, MonthlyAttendanceDTO>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName)).ReverseMap();

            CreateMap<Store, StoreDTO>();

            CreateMap<PaySlip, PaySlipDTO>().ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                 .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName)).ReverseMap();
            CreateMap<StaffAdvanceReceipt, StaffAdvanceReceiptDTO>().ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                 .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName)).ReverseMap();
            CreateMap<SalaryPayment, SalaryPaymentDTO>().ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                 .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName)).ReverseMap();

            CreateMap<Party, PartyDTO>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                 .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.LedgerGroup.GroupName)).ReverseMap();

            CreateMap<Voucher, VoucherDTO>()
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.LedgerName, opt => opt.MapFrom(src => src.Party.PartyName)).ReverseMap();
            CreateMap<CashVoucher, CashVoucherDTO>()
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                .ForMember(dest => dest.TransactionName, opt => opt.MapFrom(src => src.TransactionMode.TransactionName))
                .ForMember(dest => dest.LedgerName, opt => opt.MapFrom(src => src.Partys.PartyName)).ReverseMap();

            CreateMap<TimeSheet, TimeSheetDTO>().ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName)).ReverseMap();
            CreateMap<Salary, SalaryDTO>().ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Employee.StaffName))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName)).ReverseMap();


            CreateMap<DailySale, DailySaleDTO>().ForMember(dest => dest.SalesmanName, opt => opt.MapFrom(src => src.Salesman.Name))
                 .ForMember(dest => dest.POSName, opt => opt.MapFrom(src => src.EDC.Name))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName)).ReverseMap();

            CreateMap<CashDetail, CashDetailDTO>()
               .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName)).ReverseMap();
            CreateMap<Stock, StockDTO>()
               .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName)).ReverseMap();
            CreateMap<ProductItem, ProductItemDTO>()
                 .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
             .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.ProductTypeName)).ReverseMap();
            CreateMap<ProductPurchase, ProductPurchaseDTO>()
                 .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor.VendorName))
              .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName)).ReverseMap();
        }
    }
}