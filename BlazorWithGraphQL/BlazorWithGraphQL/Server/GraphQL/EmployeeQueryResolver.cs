using BlazorWithGraphQL.Server.Interfaces;
using BlazorWithGraphQL.Server.Models;

namespace BlazorWithGraphQL.Server.GraphQL
{
    public class EmployeeQueryResolver
    {
        readonly IEmployee _employeeService;

        public EmployeeQueryResolver(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [GraphQLDescription("Gets the list of movies.")]
        [UseFiltering]
        public async Task<IQueryable<Employee>> GetEmployeeList()
        {
            List<Employee> availableEmployees = await _employeeService.GetAllEmployee();
            return availableEmployees.AsQueryable();
        }

        [GraphQLDescription("Gets the list of cities.")]
        public async Task<List<City>> GetCityList()
        {
            return await _employeeService.GetCity();
        }
    }
}
