using Application2.Models;

namespace Application2.Validation
{
    public interface IEmployeeValidator
    {
        public ValidatorResult IsValid(Employee employee);
    }

    public class EmployeeValidator : IEmployeeValidator
    {
        public ValidatorResult IsValid(Employee employee)
        {
            // Contrived example to show it isn't simple validation
            // however fluent validation should be used
            if (employee.Name.Contains("Z"))
                return new FailedValidatorResult("Validation Message");

            return new SuccessfulValidatorResult();
        }
    }
}
