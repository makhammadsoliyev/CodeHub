using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Repositories;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class RepositoryService : IRepositoryService
{
    private IMapper mapper;
    private IGenericRepository<Repository> repository;
    private IUserService userService;


    public RepositoryService(IMapper mapper, IGenericRepository<Repository> genericRepository, IUserService userService)
    {
        this.mapper = mapper;
        this.repository = genericRepository;
        this.userService = userService;
    }

    public async Task<RepositoryViewModel> CreateAsync(RepositoryCreateModel repositoryModel)
    {
        var existUser = await userService.GetByIdAsync(repositoryModel.UserId);

        var existRepository = repository
            .SelectAsQueryable()
            .Where(r => r.UserId == repositoryModel.UserId)
            .FirstOrDefault(r => r.Name == repositoryModel.Name);

        if (existRepository is not null)
            throw new CustomException(409, "Repository is already exist");

        var createdRepository = await repository.InsertAsync(mapper.Map<Repository>(repositoryModel));
        await repository.SaveAsync();

        return mapper.Map<RepositoryViewModel>(createdRepository);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var existRepository = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        await repository.DeleteAsync(existRepository);
        await repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<RepositoryViewModel>> GetAllAsync()
    {
        var Repositories = await repository
            .SelectAsQueryable(new string[] { "Readme", "GitIgnore", "License", "Parent" }).ToListAsync();

        return mapper.Map<IEnumerable<RepositoryViewModel>>(Repositories);
    }


    public async Task<RepositoryViewModel> GetByIdAsync(long id)
    {
        var existRepository = await repository.SelectByIdAsync(id, new string[] { "Readme", "GitIgnore", "License", "Parent" })
            ?? throw new CustomException(404, "Repository is not found");

        return mapper.Map<RepositoryViewModel>(existRepository);
    }

    public async Task<RepositoryViewModel> UpdateAsync(long id, RepositoryUpdateModel repositoryModel)
    {
        var existUser = await userService.GetByIdAsync(repositoryModel.UserId);

        var existRepository = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        var mappedRepository = mapper.Map(repositoryModel, existRepository);
        var updateRepository = await repository.UpdateAsync(mappedRepository);
        await repository.SaveAsync();

        return mapper.Map<RepositoryViewModel>(mappedRepository);
    }
}
