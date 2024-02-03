using BethanyPieShopHRM.Services;
using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRM.Pages;

public partial class EmployeeOverview
{
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    public List<Employee>? Employees { get; set; } = default;

    private Employee? _selectedEmployee;

    private string Title = "Employee Overview";
    protected override async Task OnInitializedAsync()
    {
        Employees = (await EmployeeDataService.GetAllEmployeesAsync()).ToList();
    }

    public void ShowQuickViewPopup(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}
