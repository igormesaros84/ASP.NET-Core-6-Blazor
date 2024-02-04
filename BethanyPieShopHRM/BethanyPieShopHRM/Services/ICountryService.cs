using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopHRM.Services;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    Task<Country> GetCountryByIdAsync(int countryId);
}
