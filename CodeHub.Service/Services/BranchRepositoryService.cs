using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.BranchRepositories;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class BranchRepositoryService : IBranchRepositoryService
{
    private IMapper mapper;
    private IGenericRepository<BranchRepository> Repository;
    private IUserService userService;
    private IRepositoryService repositoryService;



    public BranchRepositoryService(IMapper mapper, IGenericRepository<BranchRepository> Repository, IUserService userService, IRepositoryService repositoryService)
    {
        this.mapper = mapper;
        this.Repository = Repository;
        this.userService = userService;
        this.repositoryService = repositoryService;
    }

    public async Task<BranchRepositoryViewModel> CreateAsync(BranchRepositoryCreateModel branchRepository)
    {
        var existUser = await userService.GetByIdAsync(branchRepository.UserId);
        var existRepository = await repositoryService.GetByIdAsync(branchRepository.RepositoryId);

        var existBranchRepository = Repository
            .SelectAsQueryable()
            .Where(br => br.RepositoryId == branchRepository.RepositoryId)
            .FirstOrDefault(br => br.BranchName == branchRepository.BranchName);

        if (existUser is not null)
            throw new CustomException(409, "Branch is already exists with this name");

        var createdBranchRepository = await Repository.InsertAsync(mapper.Map<BranchRepository>(branchRepository));
        await Repository.SaveAsync();

        return mapper.Map<BranchRepositoryViewModel>(createdBranchRepository);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var existBranchRepository = await Repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        await Repository.DeleteAsync(existBranchRepository);
        await Repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<BranchRepositoryViewModel>> GetAllAsync()
    {
        var existBranchRepositories = await Repository
            .SelectAsQueryable(new string[] { "User", "Repository", "Readme", "GitIgnore", "License" })
            .ToListAsync();

        return mapper.Map<IEnumerable<BranchRepositoryViewModel>>(existBranchRepositories);
    }


    public async Task<BranchRepositoryViewModel> GetByIdAsync(long id)
    {
        var existBranchRepository = await Repository.SelectByIdAsync(id, new string[] { "User", "Repository", "Readme", "GitIgnore", "License" })
            ?? throw new CustomException(404, "Not found");

        return mapper.Map<BranchRepositoryViewModel>(existBranchRepository);
    }


    public async Task<BranchRepositoryViewModel> UpdateAsync(long id, BranchRepositoryUpdateModel branchRepository)
    {
        var existUser = await userService.GetByIdAsync(branchRepository.UserId);
        var existRepository = await repositoryService.GetByIdAsync(branchRepository.RepositoryId);

        var existBranchRepository = await Repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        var mappedBranchRepository = mapper.Map(branchRepository, existBranchRepository);
        var updatedBranchRepository = await Repository.UpdateAsync(mapper.Map<BranchRepository>(mappedBranchRepository));
        await Repository.SaveAsync();

        return mapper.Map<BranchRepositoryViewModel>(updatedBranchRepository);
    }
}
