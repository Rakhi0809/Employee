using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name{ get; set; }
        public string? Email{ get; set; }
        public  string? Phone{ get; set; }
        public decimal Salary{ get; set; }

        //foreign key
        public int? AddressId { get; set; }  // Nullable foreign key
        public Address? Address { get; set; }
        //public int? AddressId { get; set; }
        ////navigation property
        //public Address? Address { get; set; }
        


    }
}
