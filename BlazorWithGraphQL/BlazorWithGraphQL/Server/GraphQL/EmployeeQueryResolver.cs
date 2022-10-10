using BlazorWithGraphQL.Server.Interfaces;
using BlazorWithGraphQL.Server.Models;

namespace BlazorWithGraphQL.Server.GraphQL
{
    public class EmployeeQueryResolver
    {
        [GraphQLDescription("Gets the list of movies.")]
        [UseFiltering]
        public async Task<IQueryable<Employee>> GetEmployeeList(IEmployee _employeeService)
        {
            List<Employee> availableEmployees = await _employeeService.GetAllEmployee();
            return availableEmployees.AsQueryable();
        }

        [GraphQLDescription("Gets the list of cities.")]
        public async Task<List<City>> GetCityList(IEmployee _employeeService)
        {
            return await _employeeService.GetCity();
        }
    }
}
