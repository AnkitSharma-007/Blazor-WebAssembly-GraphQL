using BlazorWithGraphQL.Client.GraphQLAPIClient;
using BlazorWithGraphQL.Server.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWithGraphQL.Client.Pages
{
    public class AddEditEmployeeBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        EmployeeClient EmployeeClient { get; set; } = default!;

        [Parameter]
        public int EmpID { get; set; }

        protected string Title = "Add";
        protected Employee employee = new();
        protected List<City>? lstCity = new();

        protected override async Task OnInitializedAsync()
        {
            await GetCityList();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (EmpID != 0)
            {
                Title = "Edit";

                EmployeeFilterInput employeeFilterInput = new()
                {
                    EmployeeId = new()
                    {
                        Eq = EmpID
                    }
                };

                var response = await EmployeeClient.FilterEmployeeByID.ExecuteAsync(employeeFilterInput);
                var employeeData = response?.Data?.EmployeeList[0];

                if (employeeData is not null)
                {
                    employee.EmployeeId = employeeData.EmployeeId;
                    employee.Name = employeeData.Name;
                    employee.Gender = employeeData.Gender;
                    employee.Department = employeeData.Department;
                    employee.City = employeeData.City;
                }
            }
        }

        protected async Task SaveEmployee()
        {
            EmployeeInput employeeData = new()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Gender = employee.Gender,
                Department = employee.Department,
                City = employee.City,
            };

            Console.WriteLine(employeeData.EmployeeId);

            if (employeeData.EmployeeId != 0)
            {
                await EmployeeClient.EditEmployeeData.ExecuteAsync(employeeData);
            }
            else
            {
                await EmployeeClient.AddEmployeeData.ExecuteAsync(employeeData);
            }

            NavigateToHome();
        }

        protected void NavigateToHome()
        {
            NavigationManager?.NavigateTo("/fetchemployee");
        }

        async Task GetCityList()
        {
            var results = await EmployeeClient.FetchCityList.ExecuteAsync();

            if (results.Data is not null)
            {
                lstCity = results.Data.CityList.Select(city => new City
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                }).ToList();
            }
        }
    }
}
