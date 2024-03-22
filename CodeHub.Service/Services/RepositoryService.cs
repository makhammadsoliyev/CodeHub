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
    private GenericRepository<Repository> Repository;
    public RepositoryService(IMapper mapper, GenericRepository<Repository> genericRepository)
    {
        this.mapper = mapper;
        this.Repository = genericRepository;
    }

    public async Task<RepositoryViewModel> CreateAsync(RepositoryCreateModel repository)
    {
        var existRepository = Repository
            .SelectAsQueryableAsync()
            .Where
            (r => r.UserId == repository.UserId)
            .FirstOrDefault
            (r => r.Name == repository.Name);

        if (existRepository is not null)
            throw new CustomException(409, "Repository is already exist");

        var createdUser = await Repository.InsertAsync(mapper.Map<Repository>(repository));
        await Repository.UpdateAsync(createdUser);

        return mapper.Map<RepositoryViewModel>(createdUser);
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var existRepository = await Repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        await Repository.DeleteAsync(existRepository);
        await Repository.SaveAsync();

        return true;
    }
    public async Task<IEnumerable<RepositoryViewModel>> GetAllAsync()
    {
        var Repositories = await Repository
            .SelectAsQueryableAsync
            (
                new string[] { "Readme", "GitIgnore", "License", "Parent" }).ToListAsync();


        return mapper.Map<IEnumerable<RepositoryViewModel>>(Repositories);
    }
    public async Task<RepositoryViewModel> GetByIdAsync(long id)
    {
        var existRepository = await Repository.SelectByIdAsync(id, new string[] { "Readme", "GitIgnore", "License", "Parent" })
            ?? throw new CustomException(404, "Repository is not found");

        return mapper.Map<RepositoryViewModel>(existRepository);
    }
    public async Task<RepositoryViewModel> UpdateAsync(long id, RepositoryUpdateModel repository)
    {
        var existRepository = await Repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        var mappedRepository = mapper.Map<Repository>(repository);
        var updateRepository = await Repository.UpdateAsync(mappedRepository);
        await Repository.SaveAsync();

        return mapper.Map<RepositoryViewModel>(mappedRepository);
    }
}
