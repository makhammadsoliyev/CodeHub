using CodeHub.Model.Follows;

namespace CodeHub.Service.Interfaces;

public interface IFollowService
{
    Task<FollowViewModel> CreateAsync(FollowCreateModel follow);
    Task<bool> DeleteAsync(long id);
    Task<FollowViewModel> GetByIdAsync(long id);
    Task<IEnumerable<FollowViewModel>> GetAllAsync();
}
