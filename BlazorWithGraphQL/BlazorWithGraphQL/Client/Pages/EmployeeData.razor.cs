using BlazorWithGraphQL.Client.GraphQLAPIClient;
using BlazorWithGraphQL.Server.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWithGraphQL.Client.Pages
{
    public class EmployeeDataBase : ComponentBase
    {
        [Inject]
        EmployeeClient EmployeeClient { get; set; } = default!;

        protected List<Employee>? lstEmployee = default!;
        protected List<Employee>? searchEmployeeData = new();
        protected Employee employee = new();
        protected string SearchString { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetEmployeeList();
        }

        async Task GetEmployeeList()
        {
            var results = await EmployeeClient.FetchEmployeeList.ExecuteAsync();

            if (results.Data is not null)
            {
                lstEmployee = results.Data.EmployeeList.Select(employee => new Employee
                {
                    EmployeeId = employee.EmployeeId,
                    Name = employee.Name,
                    Gender = employee.Gender,
                    Department = employee.Department,
                    City = employee.City,
                }).ToList();
            }

            searchEmployeeData = lstEmployee;
        }

        protected void FilterEmployee()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstEmployee = searchEmployeeData?.Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                lstEmployee = searchEmployeeData;
            }
        }

        protected void DeleteConfirm(int empID)
        {
            if (lstEmployee is not null)
            {
                employee = lstEmployee?.FirstOrDefault(x => x.EmployeeId == empID);
            }

        }

        protected async Task DeleteEmployee(int empID)
        {
            var response = await EmployeeClient.DeleteMovieData.ExecuteAsync(empID);

            if (response.Data is not null)
            {
                await GetEmployeeList();
            }
        }
        public void ResetSearch()
        {
            SearchString = string.Empty;
            lstEmployee = searchEmployeeData;
        }
    }
}
