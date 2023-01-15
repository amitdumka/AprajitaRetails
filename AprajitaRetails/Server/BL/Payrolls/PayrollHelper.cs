namespace AprajitaRetails.Server.BL.Payrolls
{
    public class PayrollHelper
    {
        public static string AttendanceIdGenerator(string empId, DateTime ondate)
        {
            return $"{ondate.Year}-{ondate.Month}-{ondate.Day}-{empId}";

        }


        public static string EmployeeIdGenerator(string storeid, int year, EmpType cat)
        {
            string id = $"{storeid}-{year}-";
            switch (cat)
            {
                case EmpType.Salesman:
                    id += "SLM";
                    break;

                case EmpType.StoreManager:
                    id += "SM";
                    break;

                case EmpType.HouseKeeping:
                    id += "HK";
                    break;

                case EmpType.Owner:
                    id += "OWN";
                    break;

                case EmpType.Accounts:
                    id += "ACC";
                    break;

                case EmpType.TailorMaster:
                    id += "TM";
                    break;

                case EmpType.Tailors:
                    id += "TLS";
                    break;

                case EmpType.TailoringAssistance:
                    id += "TLA";
                    break;

                case EmpType.Others:
                    id += "OTH";
                    break;

                default:
                    break;
            }
            return id;
        }


        //public static string SalaryPaymentIdGenerator(string storeid, string empId, DateTime ondate)
        //{
        //    return $"SP-{empId}-{ondate.Year}-{ondate.Month}-{ondate.Day}";

        //}
        public static string GenerateMonthlyAttendance(DateTime on, string empid)
        {
            string id = $"{on.Year}-{on.Month}-{empid}";
            return id;
        }
        public static string GenerateSalaryPayment(DateTime on, string storeid, int count)
        {
            string c = "";
            if (++count < 10) c = "000" + count;
            else if (count > 9) c = "00" + count;
            else if (count > 99) c = "0" + count; else c = count + "";
            return $"SP-{storeid}-{on.Year}-{on.Month}-{on.Day}-{c}";
        }
    }
}

