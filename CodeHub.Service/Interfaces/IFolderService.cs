using CodeHub.Model.Folders;

namespace CodeHub.Service.Interfaces;

public interface IFolderService
{
    Task<FolderViewModel> CreateAsync(FolderCreateModel folder);
    Task<FolderViewModel> UpdateAsync(long id, FolderUpdateModel folder);
    Task<bool> DeleteAsync(long id);
    Task<FolderViewModel> GetByIdAsync(long id);
    Task<IEnumerable<FolderViewModel>> GetAllAsync();
}
