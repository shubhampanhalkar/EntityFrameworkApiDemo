using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string Name { get; set; }
     
        //Navigational Property
        public virtual ICollection<EmployeesInProject> EmployeesInProject { get; set; }

    }
}
