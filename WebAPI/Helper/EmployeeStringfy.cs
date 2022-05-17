using Application.Models;

namespace Helper
{
    public interface IEmployeeStringify
    {
        public string GetEmployee(Employee employee, string authorisation);
    }

    public class EmployeeStringify : IEmployeeStringify
    {
        // Need to manually create a json object as they come from different objects and sometimes can be 20 properties 
        public string GetEmployee(Employee employee, string authorisation)
        {
            return $@"{{ 
                        'name': '{employee.Name}',
                        'authorisation': '{authorisation}'
                      }}";
        }
    }
}
