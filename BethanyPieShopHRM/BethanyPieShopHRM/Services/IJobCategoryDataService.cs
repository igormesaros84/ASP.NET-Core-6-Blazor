using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopHRM.Services;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetJobCategoriesAsync();
    Task<JobCategory> GetJobCategoryAsync(int jobCategoryId);
}
