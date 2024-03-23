using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Issues;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;
public class IssueService : IIssueService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Issue> repository;
    private IRepositoryService repositoryService;
    private IUserService userService;


    public IssueService(IMapper mapper, IGenericRepository<Issue> repository, IRepositoryService repositoryService, IUserService userService)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.repositoryService = repositoryService;
        this.userService = userService;
    }

    public async Task<IssueViewModel> CreateAsync(IssueCreateModel issue)
    {
        var existUser = await userService.GetByIdAsync(issue.UserId);
        var existRepository = await repositoryService.GetByIdAsync(issue.RepositoryId);

        var createdIssue = await repository.InsertAsync(mapper.Map<Issue>(issue));
        await repository.SaveAsync();

        return mapper.Map<IssueViewModel>(createdIssue);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var existIssue = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Issue not found");

        await repository.DeleteAsync(existIssue);
        await repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<IssueViewModel>> GetAllAsync()
    {
        var issues = await repository
          .SelectAsQueryable(new string[] { "Repository", "User" })
          .ToListAsync();

        return mapper.Map<IEnumerable<IssueViewModel>>(issues);
    }


    public async Task<IssueViewModel> GetByIdAsync(long id)
    {
        var existIssue = await repository.SelectByIdAsync(id, new string[] { "Repositories" })
            ?? throw new CustomException(404, "Issue not found");

        return mapper.Map<IssueViewModel>(existIssue);
    }


    public async Task<IssueViewModel> UpdateAsync(long id, IssueUpdateModel issue)
    {
        var existUser = await userService.GetByIdAsync(issue.UserId);
        var existRepository = await repositoryService.GetByIdAsync(issue.RepositoryId);

        var existIssue = await repository.SelectByIdAsync(id)
           ?? throw new CustomException(404, "Issue not found");

        var mappedIssue = mapper.Map(issue, existIssue);
        var updatedIssue = await repository.UpdateAsync(mappedIssue);
        await repository.SaveAsync();

        return mapper.Map<IssueViewModel>(updatedIssue);
    }
}
