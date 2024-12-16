namespace EmployeeAdminPortal.Models.RTO
{
    public class EmployeeRto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
        public string? AdressLine { get; set; }
        public string? SubDistrict { get; set; }
        public string? District { get; set; }
    }
}
