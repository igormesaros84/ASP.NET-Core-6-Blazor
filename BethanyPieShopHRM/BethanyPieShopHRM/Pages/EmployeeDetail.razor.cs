using BethanyPieShopHRM.Services;
using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRM.Pages;

public partial class EmployeeDetail
{
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Parameter]
    public string EmployeeId {get; set; }

    public Employee? Employee { get; set; } = new Employee();

    protected override async Task OnInitializedAsync()
    {
        Employee = (await EmployeeDataService.GetEmployeeDetailsAsync(int.Parse(EmployeeId)));
    }
}
