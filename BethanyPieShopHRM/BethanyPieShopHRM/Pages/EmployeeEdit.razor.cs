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

    [Parameter]
    public string? EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    public List<Country> Countries { get; set; } = new List<Country>();

    protected async override Task OnInitializedAsync()
    {
        Countries = (await CountryService.GetAllCountriesAsync()).ToList();
        Employee = await EmployeeDataService.GetEmployeeDetailsAsync(int.Parse(EmployeeId));
    }
}
