using CodeHub.Model.GitIgnores;

namespace CodeHub.Service.Interfaces;

public interface IGitIgnoreService
{
    Task<GitIgnoreViewModel> CreateAsync(GitIgnoreCreateModel gitIgnore);
    Task<GitIgnoreViewModel> UpdateAsync(long id, GitIgnoreUpdateModel gitIgnore);
    Task<bool> DeleteAsync(long id);
    Task<GitIgnoreViewModel> GetByIdAsync(long id);
    Task<IEnumerable<GitIgnoreViewModel>> GetAllAsync();
}
