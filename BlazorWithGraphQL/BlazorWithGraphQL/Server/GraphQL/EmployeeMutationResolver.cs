using BlazorWithGraphQL.Server.Interfaces;
using BlazorWithGraphQL.Server.Models;

namespace BlazorWithGraphQL.Server.GraphQL
{
    public class EmployeeMutationResolver
    {
        public record AddEmployeePayload(Employee employee);

        [GraphQLDescription("Add a new employee data.")]
        public AddEmployeePayload AddEmployee(Employee employee, IEmployee _employeeService)
        {
            _employeeService.AddEmployee(employee);

            return new AddEmployeePayload(employee);
        }

        [GraphQLDescription("Edit an existing employee data.")]
        public async Task<AddEmployeePayload> EditEmployee(Employee employee, IEmployee _employeeService)
        {
            await _employeeService.UpdateEmployee(employee);

            return new AddEmployeePayload(employee);
        }

        [GraphQLDescription("Delete an employee data.")]
        public async Task<int> DeleteEmployee(int employeeId, IEmployee _employeeService)
        {
            await _employeeService.DeleteEmployee(employeeId);

            return employeeId;
        }
    }
}
