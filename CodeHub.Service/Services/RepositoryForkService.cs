using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.RepositroyForks;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class RepositoryForkService : IRepositoryForkService
{
    private IMapper mapper;
    private IUserService userService;
    private IRepositoryService repositoryService;
    private IGenericRepository<RepositoryFork> Repository;

    public RepositoryForkService(IGenericRepository<RepositoryFork> repository, IUserService userService, IRepositoryService repositoryService, IMapper mapper)
    {
        this.mapper = mapper;
        Repository = repository;
        this.userService = userService;
        this.repositoryService = repositoryService;
    }

    public async Task<RepositoryForkViewModel> CreateAsync(RepositoryForkCreateModel fork)
    {
        var existUser = await userService.GetByIdAsync(fork.UserId);
        var existRepository = await repositoryService.GetByIdAsync(fork.RepositoryId);

        var existFork = Repository.SelectAsQueryable()
            .Where(f => f.RepositoryId == fork.RepositoryId)
            .FirstOrDefault(f => f.UserId == fork.UserId);

        if (existFork != null)
            throw new CustomException(409, "Fork is already exists");

        var createdFork = await Repository.InsertAsync(mapper.Map<RepositoryFork>(fork));
        await Repository.SaveAsync();

        return mapper.Map<RepositoryForkViewModel>(createdFork);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var existFork = await Repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        await Repository.DeleteAsync(existFork);
        await Repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<RepositoryForkViewModel>> GetAllAsync()
    {
        var Forks = await Repository
            .SelectAsQueryable(new string[] { "User", "Repository" })
            .ToListAsync();

        return mapper.Map<IEnumerable<RepositoryForkViewModel>>(Forks);
    }


    public async Task<RepositoryForkViewModel> GetByIdAsync(long id)
    {
        var existFork = await Repository.SelectByIdAsync(id, new string[] { "User", "Repository" })
             ?? throw new CustomException(404, "Repository is not found");

        return mapper.Map<RepositoryForkViewModel>(existFork);
    }
}
