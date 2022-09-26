using BlazorWithGraphQL.Server.Interfaces;
using BlazorWithGraphQL.Server.Models;

namespace BlazorWithGraphQL.Server.GraphQL
{
    public class EmployeeMutationResolver
    {
        public record AddEmployeePayload(Employee employee);

        readonly IEmployee _employeeService;

        public EmployeeMutationResolver(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [GraphQLDescription("Add a new employee data.")]
        public AddEmployeePayload AddEmployee(Employee employee)
        {
            _employeeService.AddEmployee(employee);

            return new AddEmployeePayload(employee);
        }

        [GraphQLDescription("Edit an existing employee data.")]
        public async Task<AddEmployeePayload> EditEmployee(Employee employee)
        {
            await _employeeService.UpdateEmployee(employee);

            return new AddEmployeePayload(employee);
        }

        [GraphQLDescription("Delete an employee data.")]
        public async Task<int> DeleteEmployee(int employeeId)
        {
            await _employeeService.DeleteEmployee(employeeId);

            return employeeId;
        }
    }
}
