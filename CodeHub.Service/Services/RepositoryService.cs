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


    public RepositoryService(IMapper mapper, IGenericRepository<Repository> genericRepository)
    {
        this.mapper = mapper;
        this.repository = genericRepository;
    }

    public async Task<RepositoryViewModel> CreateAsync(RepositoryCreateModel Repository)
    {
        var existRepository = repository
            .SelectAsQueryableAsync()
            .Where(r => r.UserId == Repository.UserId)
            .FirstOrDefault(r => r.Name == Repository.Name);

        if (existRepository is not null)
            throw new CustomException(409, "Repository is already exist");

        var createdRepository = await repository.InsertAsync(mapper.Map<Repository>(Repository));
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
            .SelectAsQueryableAsync
            (new string[] { "Readme", "GitIgnore", "License", "Parent" }).ToListAsync();

        return mapper.Map<IEnumerable<RepositoryViewModel>>(Repositories);
    }


    public async Task<RepositoryViewModel> GetByIdAsync(long id)
    {
        var existRepository = await repository.SelectByIdAsync(id, new string[] { "Readme", "GitIgnore", "License", "Parent" })
            ?? throw new CustomException(404, "Repository is not found");

        return mapper.Map<RepositoryViewModel>(existRepository);
    }


    public async Task<RepositoryViewModel> UpdateAsync(long id, RepositoryUpdateModel Repository)
    {
        var existRepository = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Not found");

        var mappedRepository = mapper.Map<Repository>(repository);
        var updateRepository = await repository.UpdateAsync(mappedRepository);
        await repository.SaveAsync();

        return mapper.Map<RepositoryViewModel>(mappedRepository);
    }
}
