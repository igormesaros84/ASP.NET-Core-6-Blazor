using BethanyPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRM.Pages;

public partial class EmployeeEdit
{
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Inject]
    public ICountryService? CountryService { get; set; }

    [Inject]
    public IJobCategoryDataService? JobCategoryDataService { get; set; }

    [Parameter]
    public string? EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    public List<Country> Countries { get; set; } = new List<Country>();
    public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

    protected async override Task OnInitializedAsync()
    {
        JobCategories = (await JobCategoryDataService.GetJobCategoriesAsync()).ToList();
        Countries = (await CountryService.GetAllCountriesAsync()).ToList();

        if (int.TryParse(EmployeeId, out var employeeId))
        {
            Employee = await EmployeeDataService.GetEmployeeDetailsAsync(employeeId);
        }
        else
        {
            Employee = new Employee {CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now};
        }
    }
}
