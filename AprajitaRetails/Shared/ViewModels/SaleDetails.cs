using System;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Inventory;

namespace AprajitaRetails.Shared.ViewModels
{
	public class SaleDetails
	{
		public ProductSale Invoice { get; set; }
		public List<SaleItem> Items { get; set; }
		public SalePaymentDetail? PaymentDetail { get; set; }
		public CardPaymentDetail? CardPayment { get; set; }
	}

	public class SaleDetailsDTO
	{
        public ProductSaleDTO Invoice { get; set; }
        public List<SaleItemDTO> Items { get; set; }
        public SalePaymentDetail? PaymentDetail { get; set; }
        public CardPaymentDetailDTO? CardPayment { get; set; }
    }
}

