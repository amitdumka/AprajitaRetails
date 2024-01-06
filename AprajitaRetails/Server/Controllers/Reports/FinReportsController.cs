using AprajitaRetails.Server.BL.Reports.Fins;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AprajitaRetails.Server.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinReportsController : ControllerBase
    {
        private readonly ARDBContext _context;

        private readonly IMapper _mapper;

        public FinReportsController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        [HttpPost("DayBook")]
        public DayBookReturn GetDayBook(DayBookRequest req)
        {
            return FinReports.GetDayView(_context, req.OnDate, req.StoreCode, req.CashVoucher);
        }

        // GET: api/<FinReportsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/<FinReportsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<FinReportsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<FinReportsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FinReportsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
