using AprajitaRetails.Server.BL.Accounts;
using AprajitaRetails.Server.BL.Printers;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Vouchers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VouchersController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public VouchersController(ARDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("VoucherPrint")]
        public async Task<ActionResult> GetInvoice(string id, int copy = 1, bool pagesmall = false, bool reprint = false)
        {
            
            var vch= await _context.Vouchers.Include(c => c.Store).Include(c => c.Party).Include(c => c.Employee).Where(c => c.VoucherNumber == id)
               .ProjectTo<VoucherDTO>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            var inv = await _context.ProductSales.Include(c => c.Salesman).Include(c => c.Store)
                 .Where(c => c.InvoiceNo == id).ProjectTo<ProductSaleDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();


            if (vch == null) return NotFound();
            else
            {
                var storedto = await _context.Stores.Where(c => c.StoreId == inv.StoreId).
                 ProjectTo<StoreBasicDTO>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
                 
                var pdfile = VoucherPrinters.VoucherPrinter(pagesmall,  storedto, vch, copy, reprint);
                pdfile.Position = 0;
                return File(pdfile, "application/pdf", $"{id}.pdf");
            }


        }
        // DELETE: api/Vouchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(string id)
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }

            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Vouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVoucher()
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            return await _context.Vouchers.OrderByDescending(c => c.OnDate).ToListAsync();
        }

        // GET: api/Vouchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucher(string id)
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            var voucher = await _context.Vouchers.FindAsync(id);

            if (voucher == null)
            {
                return NotFound();
            }

            return voucher;
        }

        // GET: api/Vouchers
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVoucherByStore(string storeid)
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            // int year = DateTime.Now.Year - 2;
            return await _context.Vouchers.Where(c => c.StoreId == storeid && c.OnDate.Year >= (DateTime.Today.Year - 1)).OrderByDescending(c => c.OnDate).ToListAsync();
            //return x;
        }
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<VoucherDTO>>> GetVoucherByStoreDTO(string storeid)
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            // int year = DateTime.Now.Year - 2;
            return await _context.Vouchers.Include(c => c.Store).Include(c => c.Party).Include(c => c.Employee)
            .Where(c => c.StoreId == storeid && c.OnDate.Year >= (DateTime.Today.Year - 1)).OrderByDescending(c => c.OnDate)
                .ProjectTo<VoucherDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            //return x;
        }

        // POST: api/Vouchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(Voucher voucher)
        {
            if (_context.Vouchers == null)
            {
                return Problem("Entity set 'ARDBContext.Voucher'  is null.");
            }
            // Adding VoucherNumber
            voucher.VoucherNumber = AccountHelper.VoucherNumberGenerator(_context, voucher.VoucherType, voucher.StoreId, voucher.OnDate);
            if (voucher.PaymentMode == PaymentMode.Cash) voucher.AccountId = string.Empty;
            _context.Vouchers.Add(voucher);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoucherExists(voucher.VoucherNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVoucher", new { id = voucher.VoucherNumber }, voucher);
        }

        // PUT: api/Vouchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucher(string id, Voucher voucher)
        {
            if (id != voucher.VoucherNumber)
            {
                return BadRequest();
            }

            _context.Entry(voucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool VoucherExists(string id)
        {
            return (_context.Vouchers?.Any(e => e.VoucherNumber == id)).GetValueOrDefault();
        }
    }
}