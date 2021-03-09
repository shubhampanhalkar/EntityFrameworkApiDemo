using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        //
        //Navigation property Returns the Employee Address
        public virtual Address Address { get; set; }
        
        
         public virtual ICollection<EmployeesInProject> EmployeesInProject { get; set; }


    }
}
