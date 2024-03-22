using CodeHub.Model.Users;

namespace CodeHub.Service.Interfaces;

public interface IUserService
{
    Task<UserViewModel> CreateAsync(UserCreateModel user);
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user);
    Task<bool> DeleteAsync(long id);
    Task<UserViewModel> GetByIdAsync(long id);
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}
