using BethanysPieShopHRM.Shared.Domain;
using System.Text.Json;

namespace BethanyPieShopHRM.Services;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly HttpClient _httpClient;

    public EmployeeDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Employee> AddEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(int employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
            await _httpClient.GetStreamAsync($"api/employee"),
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
    }

    public async Task<Employee> GetEmployeeDetailsAsync(int employeeId)
    {
         return await JsonSerializer.DeserializeAsync<Employee>(
            await _httpClient.GetStreamAsync($"api/employee/{employeeId}"),
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
    }

    public Task UpdateEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }
}
