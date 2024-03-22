using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Follow;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class FollowService : IFollowService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Follow> repository;
    private readonly IUserService userService;

    public FollowService(IMapper mapper, IGenericRepository<Follow> repository, IUserService userService)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.userService = userService;
    }

    public async Task<FollowViewModel> CreateAsync(FollowCreateModel follow)
    {
        if (follow.FollowerId == follow.FollowingId)
            throw new CustomException(400, "You can't follow yourself");

        var existFollower = await userService.GetByIdAsync(follow.FollowerId)
            ?? throw new CustomException(404, "User not found");

        var existFollowing = await userService.GetByIdAsync(follow.FollowingId)
            ?? throw new CustomException(404, "User not found");

        var existFollow = repository
            .SelectAsQueryable()
            .FirstOrDefault(f => f.FollowerId == follow.FollowerId && f.FollowingId == follow.FollowingId);

        if (existFollow != null)
            await DeleteAsync(existFollow.Id);

        var createdFollow = await repository.InsertAsync(mapper.Map<Follow>(follow));
        await repository.SaveAsync();

        return mapper.Map<FollowViewModel>(createdFollow);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existFollow = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        await repository.DeleteAsync(existFollow);
        await repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<FollowViewModel>> GetAllAsync()
    {
        var follows = await repository
            .SelectAsQueryable(new string[] { "Follower", "Following" }).ToListAsync();

        return mapper.Map<IEnumerable<FollowViewModel>>(follows);   
    }


    public async Task<FollowViewModel> GetByIdAsync(long id)
    {
        var existFollow = await repository.SelectByIdAsync(id, new string[] { "Follower", "Following" })
           ?? throw new CustomException(404, "Not found");

        return mapper.Map<FollowViewModel>(existFollow);
    }
}
