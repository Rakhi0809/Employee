using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Address
    {
        [Key]
        public int  Id { get; set; }
        public string? AdressLine { get; set; }
        public string? SubDistrict  { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public long? Pincode { get; set; }

        //public Employee? Employee { get; set; }
        //public int Id { get; set; }
        public Employee Employee { get; set; } = null!;


    }
}
