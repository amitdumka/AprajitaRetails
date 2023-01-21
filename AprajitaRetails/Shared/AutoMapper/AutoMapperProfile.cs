using System;
using AprajitaRetails.Shared.Models.Banking;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Auth;
using AprajitaRetails.Shared.AutoMapper.DTO;

using AutoMapper;

namespace AprajitaRetails.Shared.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Attendance, AttendanceDTO>();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<Store, StoreDTO>();
            CreateMap<StoreDTO, Store>();

            CreateMap<PaySlip, PaySlipDTO>();
            CreateMap<StaffAdvanceReceipt, StaffAdvanceReceiptDTO>();
            CreateMap<SalaryPayment, SalaryPaymentDTO>();

            CreateMap<EmployeeDTO, Employee>();
            CreateMap<AttendanceDTO, Attendance>();

            CreateMap<PaySlipDTO, PaySlip>();

            CreateMap<StaffAdvanceReceiptDTO, StaffAdvanceReceipt>();
            CreateMap<SalaryPaymentDTO, SalaryPayment>();

            CreateMap<Employee, EmployeeDTO>();

            CreateMap<Party, PartyDTO>();
            CreateMap<PartyDTO, Party>();

            //CreateMap<Voucher, VoucherDTO>().ForMember(d => d.LedgerName, opt => opt.MapFrom(s => s.Party.PartyName));
            CreateMap<CashVoucher, CashVoucherDTO>();//.ForMember(dest => dest.LedgerName, opt => opt.MapFrom(src => src.Partys.PartyName));

            CreateMap<VoucherDTO, Voucher>();
            // CreateMap<CashVoucherDTO, CashVoucher>();

            //    CreateMap<User, UserViewModel>()
            //.ForMember(dest =>
            //    dest.FName,
            //    opt => opt.MapFrom(src => src.FirstName))
            //.ForMember(dest =>
            //    dest.LName,
            //    opt => opt.MapFrom(src => src.LastName))
        }
    }
}