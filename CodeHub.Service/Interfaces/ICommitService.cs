using CodeHub.Model.Commits;

namespace CodeHub.Service.Interfaces;

public interface ICommitService
{
    Task<CommitViewModel> CreateAsync(CommitCreateModel commit);
    Task<bool> DeleteAsync(long id);
    Task<CommitViewModel> GetByIdAsync(long id);
    Task<IEnumerable<CommitViewModel>> GetAllAsync();
}
