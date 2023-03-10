using System;

namespace AprajitaRetails.Data
{
    internal class Salary
    {
        public int ID { get; set; }
        public double BasicSalary { get; set; }
        public double ExtraSalary { get; set; }
        public Incentive IncentiveID { get; set; }
    }

    internal class Incentive
    {
        public int ID { get; set; }
        public double IncentivePercentage { get; set; }
        public double TargetAmount { get; set; }
    }

    internal class PaySlip
    {
        public int ID { get; set; }
        public int EmpCode { get; set; }
        public EmployeeType EmpTyee { get; set; }
        public int NoOfWorkingDay { get; set; }
        public int Attendence { get; set; }
        public int Leaves { get; set; }
        public int NoofPaidLeave { get; set; }
        public int MedicalLeaves { get; set; }
        public int CasualLeave { get; set; }
        public Salary SalaryID { get; set; }
        public double BasicSalary { get; set; }
        public double Incentive { get; set; }
        public string StandDeducationDetails { get; set; }
        public double StandardDeducation { get; set; }
        public double NetSalary { get; set; }
        public double AspireBonus { get; set; }
        public string OtherDeducationsDetails { get; set; }
        public double OtherDeducations { get; set; }
        public double FinalPayment { get; set; }
    }

    internal class Advances
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public DateTime DateOfAdvance { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; }
    }

    internal class Dues
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EMPCode { get; set; }
        public double DuesAmount { get; set; }
    }

    internal class DuesPayment
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public int AdvanceID { get; set; }
        public double Amount { get; set; }
        public int ReciptNo { get; set; }
        public DateTime DateOfRecipt { get; set; }
    }
}