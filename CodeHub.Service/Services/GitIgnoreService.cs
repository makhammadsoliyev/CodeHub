using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.GitIgnores;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class GitIgnoreService : IGitIgnoreService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<GitIgnore> repository;

    public GitIgnoreService(IMapper mapper, IGenericRepository<GitIgnore> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }


    public async Task<GitIgnoreViewModel> CreateAsync(GitIgnoreCreateModel gitIgnore)
    {
        var gitIgnores = repository.SelectAsQueryable().FirstOrDefault(g => g.Name.ToLower() == gitIgnore.Name.ToLower());

        if (gitIgnores == null)
            throw new CustomException(409, "GitIgnore is already exist");

        var createdGitIgnore = await repository.InsertAsync(mapper.Map<GitIgnore>(gitIgnore));
        await repository.SaveAsync();

        return mapper.Map<GitIgnoreViewModel>(createdGitIgnore);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var existGitIgnore = await repository.SelectByIdAsync(id)
             ?? throw new CustomException(404, "GitIgnore file not found");

        await repository.DeleteAsync(existGitIgnore);
        await repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<GitIgnoreViewModel>> GetAllAsync()
    {
        var gitIgnores = await repository.SelectAsQueryable().ToListAsync();
        return mapper.Map<IEnumerable<GitIgnoreViewModel>>(gitIgnores);
    }


    public async Task<GitIgnoreViewModel> GetByIdAsync(long id)
    {
        var existGitIgnore = await repository.SelectByIdAsync(id)
             ?? throw new CustomException(404, "GitIgnore file not found");

        return mapper.Map<GitIgnoreViewModel>(existGitIgnore);
    }


    public async Task<GitIgnoreViewModel> UpdateAsync(long id, GitIgnoreUpdateModel gitIgnore)
    {
        var existGitIgnore = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "GitIgnore file not found");

        var mappedIgnore = mapper.Map(gitIgnore, existGitIgnore);
        var updateGitIgnore = await repository.UpdateAsync(mappedIgnore);
        await repository.SaveAsync();

        return mapper.Map<GitIgnoreViewModel>(updateGitIgnore);
    }
}
