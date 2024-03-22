using CodeHub.Model.Licenses;

namespace CodeHub.Service.Interfaces;

public interface ILicenseService
{
    Task<LicenseViewModel> CreateAsync(LicenseCreateModell license);
    Task<LicenseViewModel> UpdateAsync(long id, LicenseUpdateModel license);
    Task<bool> DeleteAsync(long id);
    Task<LicenseViewModel> GetByIdAsync(long id);
    Task<IEnumerable<LicenseViewModel>> GetAllAsync();
}
