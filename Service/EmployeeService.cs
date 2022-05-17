using Application2.Models;
using Application2.Validation;
using Infrastructure2.Powershell;
using Service.Helper;

namespace Service
{
    public interface IEmployeeService
    {
        public ServiceResult GetEmployeePermissions(Employee employee, string authorisation);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeValidator _employeeValidator;
        private readonly IPowerShellOperations _powerShellOperations;
        private readonly IEmployeeStringify _employeeStringify;

        public EmployeeService(
            EmployeeValidator employeeValidator, 
            IPowerShellOperations powerShellOperations, 
            IEmployeeStringify employeeStringify)
        {
            _employeeValidator = employeeValidator;
            _powerShellOperations = powerShellOperations;
            _employeeStringify = employeeStringify;
        }

        public ServiceResult GetEmployeePermissions(Employee employee, string authorisation)
        {
            var validatorResult = _employeeValidator.IsValid(employee);
            if (!validatorResult.IsValid)
                return new ValidationError(validatorResult.ErrorMessage);

            return new SuccessfulService(_powerShellOperations.ExecuteScript("GetEmployeePermisions.ps1", _employeeStringify.GetEmployee(employee, authorisation)));
        }
    }
}
