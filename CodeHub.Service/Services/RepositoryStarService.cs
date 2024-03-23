using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.RepositoryStar;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class RepositoryStarService : IRepositoryStarService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<RepositoryStar> repository;

    public RepositoryStarService(IMapper mapper, IGenericRepository<RepositoryStar> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }


    public async Task<RepositoryStarViewModel> CreateAsync(RepositoryStarCreateModel repositoryStar)
    {
        var existStar = repository
            .SelectAsQueryable()
            .Where(rs => rs.RepositoryId == repositoryStar.RepositoryId)
            .FirstOrDefault(rs => rs.UserId == repositoryStar.UserId);

        if (existStar is not null)
            await DeleteAsync(existStar.Id);

        var createdRepositoryStar = await repository.InsertAsync(mapper.Map<RepositoryStar>(repositoryStar));
        await repository.SaveAsync();

        return mapper.Map<RepositoryStarViewModel>(createdRepositoryStar);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existStar = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "RepositoryStar is not found");

        await repository.DeleteAsync(existStar);
        await repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<RepositoryStarViewModel>> GetAllAsync()
    {
        var respotoryStars = await repository
            .SelectAsQueryable(new string[] { "Repository", "User" })
            .ToListAsync();

        return mapper.Map<IEnumerable<RepositoryStarViewModel>>(respotoryStars);
    }

    public async Task<RepositoryStarViewModel> GetByIdAsync(long id)
    {
        var existStar = await repository.SelectByIdAsync(id, new string[] { "Repository", "User" })
            ?? throw new CustomException(404, "RepositoryStar is not found");

        return mapper.Map<RepositoryStarViewModel>(existStar);
    }
}
