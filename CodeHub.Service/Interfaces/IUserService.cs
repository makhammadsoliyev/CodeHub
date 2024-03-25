using CodeHub.Model.Users;

namespace CodeHub.Service.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Create new user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UserViewModel> CreateAsync(UserCreateModel user);

    /// <summary>
    /// Update exist user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user);

    /// <summary>
    /// Delete exist user via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// Get exist user via ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Get list of exist users
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}
