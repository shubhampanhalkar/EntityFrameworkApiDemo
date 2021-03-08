using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApi.Models
{
    public class Address
    {
        [Key, ForeignKey("Employee")]
        public int EmpID { get; set; }
        public string EmpAddress { get; set; }

        //Navigation property Returns the Employee object
        [JsonIgnore]
        public Employee Employee { get; set; }
    }
}