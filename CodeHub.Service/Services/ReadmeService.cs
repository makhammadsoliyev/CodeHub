using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Readmes;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class ReadmeService : IReadmeService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Readme> repository;

    public ReadmeService(IMapper mapper, IGenericRepository<Readme> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<ReadmeViewModel> CreateAsync(ReadmeCreateModel readme)
    {
        var createdReadme = await repository.InsertAsync(mapper.Map<Readme>(readme));
        await repository.SaveAsync();

        return mapper.Map<ReadmeViewModel>(createdReadme);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existReadme = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Readme file not found");

        await repository.DeleteAsync(existReadme);
        await repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<ReadmeViewModel>> GetAllAsync()
    {
        var readmes = await repository.SelectAsQueryable().ToListAsync();
        return mapper.Map<IEnumerable<ReadmeViewModel>>(readmes);
    }

    public async Task<ReadmeViewModel> GetByIdAsync(long id)
    {
        var existReadme = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Readme file not found");

        return mapper.Map<ReadmeViewModel>(existReadme);
    }

    public async Task<ReadmeViewModel> UpdateAsync(long id, ReadmeUpdateModel readme)
    {
        var existReadme = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Readme file not found");

        var mappedReadme = mapper.Map(readme, existReadme);
        var updatedReadme = await repository.UpdateAsync(mappedReadme);
        await repository.SaveAsync();

        return mapper.Map<ReadmeViewModel>(updatedReadme);
    }
}
