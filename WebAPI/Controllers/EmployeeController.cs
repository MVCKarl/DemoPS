using Application.Models;
using Application.Validation;
using Helper;
using Infrastructure.Powershell;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeValidator _employeeValidator;
        private readonly IPowerShellOperations _powerShellOperations;
        private readonly IEmployeeStringify _employeeStringify;

        public EmployeeController(
            IEmployeeValidator employeeValidator, 
            IPowerShellOperations powerShellOperations,
            IEmployeeStringify employeeStringify)
        {
            _employeeValidator = employeeValidator;
            _powerShellOperations = powerShellOperations;
            _employeeStringify = employeeStringify;
        }

        [HttpGet(Name = "GetEmployeePermissions")]
        public IActionResult GetEmployeePermissions(Employee employee, string authorisation)
        {
            try
            {
                var validatorResult = _employeeValidator.IsValid(employee);
                if (!validatorResult.IsValid)
                    return UnprocessableEntity("Some specific error message from the validator object"); 
                    // They want 422 status for validation errors

                return Ok(_powerShellOperations.ExecuteScript("GetEmployeePermisions.ps1", _employeeStringify.GetEmployee(employee, authorisation)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}