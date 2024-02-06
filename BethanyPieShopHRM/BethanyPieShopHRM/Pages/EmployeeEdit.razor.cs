using BethanyPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BethanyPieShopHRM.Pages;

public partial class EmployeeEdit
{
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Inject]
    public ICountryService? CountryService { get; set; }

    [Inject]
    public IJobCategoryDataService? JobCategoryDataService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string? EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    public List<Country> Countries { get; set; } = new List<Country>();
    public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected async override Task OnInitializedAsync()
    {
        Saved = false;
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

    protected async Task HandleValidSubmit()
    {
        Saved = false;

        if (Employee.EmployeeId == 0) //new
        {
            //image adding
            if (selectedFile != null)
            {
                var file = selectedFile;
                Stream stream = file.OpenReadStream();
                MemoryStream ms = new();
                await stream.CopyToAsync(ms);
                stream.Close();

                Employee.ImageName = file.Name;
                Employee.ImageContent = ms.ToArray();
            }

            var addedEmployee = await EmployeeDataService.AddEmployeeAsync(Employee);
            if (addedEmployee != null)
            {
                StatusClass = "alert-success";
                Message = "New employee added successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong adding the new employee. Please try again.";
                Saved = false;
            }
        }
        else
        {
            await EmployeeDataService.UpdateEmployeeAsync(Employee);
            StatusClass = "alert-success";
            Message = "Employee updated successfully.";
            Saved = true;
        }
    }

    protected async Task HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeleteEmployee()
    {
        await EmployeeDataService.DeleteEmployeeAsync(Employee.EmployeeId);

        StatusClass = "alert-success";
        Message = "Deleted successfully";

        Saved = true;
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/employeeoverview");
    }

    private IBrowserFile selectedFile;
    private void OnInputFileChanged(InputFileChangeEventArgs e)
    {
        selectedFile = e.File;
        StateHasChanged();
    }

}
