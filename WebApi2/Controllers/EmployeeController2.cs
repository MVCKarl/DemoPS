
using Application2.Models;
using Application2.Validation;
using Infrastructure2.Powershell;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController2 : ControllerBase
    {
        private readonly IEmployeeValidator _employeeValidator;
        private readonly IPowerShellOperations _powerShellOperations;
        private readonly IEmployeeService _employeeService;

        public EmployeeController2(IEmployeeValidator employeeValidator, IPowerShellOperations powerShellOperations, IEmployeeService employeeService)
        {
            _employeeValidator = employeeValidator;
            _powerShellOperations = powerShellOperations;
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployeePermissions")]
        public IActionResult GetEmployeePermissions(Employee employee, string authorisation)
        {
            try
            {
                var serviceResult = _employeeService.GetEmployeePermissions(employee, authorisation);

                if (!serviceResult.Successful)
                    return UnprocessableEntity(serviceResult.ValidationErrorMessage);

                return Ok(serviceResult.PowerShellResultMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}