using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApi.Models
{
    public class EmployeesInProject
{
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }


        [JsonIgnore]
        public Project Project { get; set; }
    }
}
