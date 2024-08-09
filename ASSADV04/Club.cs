using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSADV04
{
    public class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        private List<Employee> Members = new List<Employee>();

        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
        }

        private void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee && e.Cause == LayOffCause.VacationStockNegative)
            {
                Members.Remove(employee);
                employee.EmployeeLayOff -= RemoveMember;
            }
        }
    }
}
