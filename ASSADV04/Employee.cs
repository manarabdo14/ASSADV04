using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSADV04
{
    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        public int EmployeeID { get; set; }
        public DateTime BirthDate { get; set; }
        public int VacationStock { get; set; }

        public bool RequestVacation(DateTime From, DateTime To)
        {
            // Implement logic to check if the vacation request can be fulfilled
            // and update VacationStock accordingly.
            throw new NotImplementedException();
        }

        public void EndOfYearOperation()
        {
            EmployeeLayOffEventArgs args = null;

            if (VacationStock < 0)
            {
                args = new EmployeeLayOffEventArgs { Cause = LayOffCause.VacationStockNegative };
            }
            else if (DateTime.Now.Year - BirthDate.Year > 60)
            {
                args = new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeOverSixty };
            }

            if (args != null)
            {
                OnEmployeeLayOff(args);
            }
        }

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
    }

}
