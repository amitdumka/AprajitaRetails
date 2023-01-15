using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Importer
{
    public class IDChanger
    {
        ARDBContext db;
        public IDChanger(ARDBContext aa) => db = aa;

        public async Task<bool> ChangeID()
        {
            //First Employee
            var employee = await db.EmployeeDetails.Include(c => c.Employee).ToListAsync();
            foreach (var emp in employee)
            {
                emp.Employee.EmployeeId = emp.EmployeeId = emp.EmployeeId.Replace("/", "-");

            }
            var attds = await db.Attendances.ToListAsync();
            foreach (var emp in attds)
            {
                emp.EmployeeId = emp.EmployeeId.Replace("/", "-");

            }

            int x = db.SaveChanges();
            return x > 0;
        }
    }
}

