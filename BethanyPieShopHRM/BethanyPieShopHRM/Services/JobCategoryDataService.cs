using BethanysPieShopHRM.Shared.Domain;
using System.Text.Json;

namespace BethanyPieShopHRM.Services;

public class JobCategoryDataService : IJobCategoryDataService
{
    private readonly HttpClient _httpClient = default!;

    public JobCategoryDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<JobCategory>> GetJobCategoriesAsync()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<JobCategory> GetJobCategoryAsync(int jobCategoryId)
    {
        return await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}
