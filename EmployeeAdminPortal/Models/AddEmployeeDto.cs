using System.ComponentModel.DataAnnotations;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto
    {
       
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
        public string? AdressLine { get; set; }
        public string? SubDistrict { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public long? Pincode { get; set; }

    }


}
