using CodeHub.Model.Readme;

namespace CodeHub.Service.Interfaces;

public interface IReadmeService
{
    Task<ReadmeViewModel> CreateAsync(ReadmeCreateModel readme);
    Task<ReadmeViewModel> UpdateAsync(long id, ReadmeUpdateModel readme);
    Task<bool> DeleteAsync(long id);
    Task<ReadmeViewModel> GetByIdAsync(long id);
    Task<IEnumerable<ReadmeViewModel>> GetAllAsync();
}
