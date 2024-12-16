using System.Security.Cryptography.X509Certificates;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.RTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    //localhost:xxxx/api/employees
    [Route("api/emplyee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //private readonly ApplicationDbcontext dbcontext;


        private readonly ApplicationDbcontext _dbcontext;

        public EmployeesController(ApplicationDbcontext dbcontext)
        {

            _dbcontext = dbcontext;
            //this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Employee[]>> GetAllEmployees()

        {
            var allEmployees = await _dbcontext.Employees.ToArrayAsync();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("/all")]
        public async Task<ActionResult<EmployeeRto>> AllEmployees()

        {
            var Employees = await _dbcontext.Employees
                .Include(f => f.Address)
                .Select(f => new EmployeeRto
                {

                    Name = f.Name,
                    Email = f.Email,
                    Salary = f.Salary,
                    Phone = f.Phone,
                    AdressLine = f.Address.AdressLine,
                    SubDistrict = f.Address.SubDistrict,
                    District = f.Address.District,

                })
            .ToListAsync();
            return Ok(Employees);
        }

            [HttpGet]
            [Route("getby/{id}")]
            public async Task<ActionResult<Employee>> GETEmployeeById(int id)
            {
                var employee = await _dbcontext.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }

            [HttpPost]
            [Route("add")]
            public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
            {
                var employeeEntity = new Employee()
                {
                    Id = addEmployeeDto.Id,
                    Name = addEmployeeDto.Name,
                    Email = addEmployeeDto.Email,
                    Phone = addEmployeeDto.Phone,
                    Salary = addEmployeeDto.Salary
                };

                _dbcontext.Add(employeeEntity);
                _dbcontext.SaveChanges();


                return Ok();


            }

            [HttpPut]
            [Route("update/{id}")]
            public IActionResult UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
            {
                var employee = _dbcontext.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.Name = updateEmployeeDto.Name;
                employee.Phone = updateEmployeeDto.Phone;
                employee.Email = updateEmployeeDto.Email;
                employee.Salary = updateEmployeeDto.Salary;

                _dbcontext.SaveChanges();
                return Ok(employee);
            }

            [HttpPut]
            [Route("{id}/remove")]
            public IActionResult RemoveEmployee(int id)
            {
                var employee = _dbcontext.Employees.Find(id);
                if (employee != null)
                {
                    _dbcontext.Remove(employee);
                    _dbcontext.SaveChanges();
                    return Ok("Employee Remove Succesefull");

                }
                else
                {
                    return NotFound($"{id} Emplyee Not Found");
                }
            }


            //Add Employee with Address

            [HttpPost]
            [Route("add/EmployeeAddress")]
            public IActionResult AddEmployeeAddress([FromBody] AddEmployeeDto addEmployeeDto)
            {
                var employeeEntity = new Employee
                {
                    Id = addEmployeeDto.Id,
                    Name = addEmployeeDto.Name,
                    Email = addEmployeeDto.Email,
                    Phone = addEmployeeDto.Phone,
                    Salary = addEmployeeDto.Salary,
                    Address = new Address
                    {
                        AdressLine = addEmployeeDto.AdressLine,
                        Pincode = addEmployeeDto.Pincode,
                        SubDistrict = addEmployeeDto.SubDistrict,
                        State = addEmployeeDto.State,
                        Country = addEmployeeDto.Country,
                        District = addEmployeeDto.District

                    }
                };



                _dbcontext.Add(employeeEntity);
                _dbcontext.SaveChanges();


                return Ok($"Employee Created Sucessfully");
            }
        }
    }

