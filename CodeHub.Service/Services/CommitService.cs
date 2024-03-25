using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Commits;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class CommitService : ICommitService
{
    private IGenericRepository<Commit> Repository;
    private IUserService userService;
    private IRepositoryService repositoryService;
    private IMapper mapper;


    public CommitService(IGenericRepository<Commit> Repository, IMapper mapper, IUserService userService, IRepositoryService repositoryService)
    {
        this.Repository = Repository;
        this.mapper = mapper;
        this.userService = userService;
        this.repositoryService = repositoryService;
    }


    public async Task<CommitViewModel> CreateAsync(CommitCreateModel commit)
    {
        var existUser = await userService.GetByIdAsync(commit.UserId);
        var existRepository = await repositoryService.GetByIdAsync(commit.RepositoryId);

        var createdCommit = await Repository.InsertAsync(mapper.Map<Commit>(commit));
        await Repository.SaveAsync();

        return mapper.Map<CommitViewModel>(createdCommit);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var existCommit = await Repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        await Repository.DeleteAsync(existCommit);
        await Repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<CommitViewModel>> GetAllAsync()
    {
        var Commits = await Repository.
            SelectAsQueryable(new string[] { "User", "Repository", "BranchRepository" })
            .ToListAsync();

        return mapper.Map<IEnumerable<CommitViewModel>>(Commits);
    }


    public async Task<CommitViewModel> GetByIdAsync(long id)
    {
        var Commits = await Repository.SelectByIdAsync(id, new string[] { "User", "Repository", "BranchRepository" })
            ?? throw new CustomException(404, "Not found");

        return mapper.Map<CommitViewModel>(Commits);
    }
}
