using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Users;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<User> repository;

    public UserService(IMapper mapper, IGenericRepository<User> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<UserViewModel> CreateAsync(UserCreateModel user)
    {
        var existUser = repository
            .SelectAsQueryable()
            .FirstOrDefault
            (u => u.Email.ToLower() == user.Email.ToLower() || u.UserName.ToLower() == user.UserName.ToLower());

        if (existUser is not null)
            throw new CustomException(409, "User already exist");

        var createdUser = await repository.InsertAsync(mapper.Map<User>(user));
        await repository.SaveAsync();

        return mapper.Map<UserViewModel>(createdUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "User not found");

        await repository.DeleteAsync(existUser);
        await repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await repository
            .SelectAsQueryable(
                new string[] { "Repositories" }).ToListAsync();

        return mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var existUser = await repository.SelectByIdAsync(id, new string[] { "Repositories" })
            ?? throw new CustomException(404, "User not found");

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user)
    {
        var existUser = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "User not found");

        var mappedUser = mapper.Map(user, existUser);
        var updatedUser = await repository.UpdateAsync(mappedUser);
        await repository.SaveAsync();

        return mapper.Map<UserViewModel>(updatedUser);
    }
}
