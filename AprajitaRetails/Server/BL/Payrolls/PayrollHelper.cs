using System;
using AprajitaRetails.BL.Vouchers;
using AprajitaRetails.Server.Data;

namespace AprajitaRetails.Server.BL.Payrolls
{
	public class PayrollHelper
	{
        public static string AttendanceIdGenerator(string empId, DateTime ondate)
        {
            return $"{ondate.Year}-{ondate.Month}-{ondate.Day}-{empId}";

        }
    }
}

