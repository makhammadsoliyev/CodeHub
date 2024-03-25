using CodeHub.Model.Files;

namespace CodeHub.Service.Interfaces;

public interface IFileService
{
    Task<FileViewModel> CreateAsync(FileCreateModel file);
    Task<FileViewModel> UpdateAsync(long id, FileUpdateModel file);
    Task<bool> DeleteAsync(long id);
    Task<FileViewModel> GetByIdAsync(long id);
    Task<IEnumerable<FileViewModel>> GetAllAsync();
}
