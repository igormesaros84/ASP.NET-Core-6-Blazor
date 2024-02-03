﻿using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopHRM.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeDetailsAsync(int employeeId);
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
}
