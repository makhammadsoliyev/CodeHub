using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.IssueAssignments;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;
public class IssueAssignmentService : IIssueAssignmentService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<IssueAssignment> repository;
    private IIssueService issueService;
    private IUserService userService;


    public IssueAssignmentService(IMapper mapper, IGenericRepository<IssueAssignment> repository, IssueService issueService, IUserService userService)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.issueService = issueService;
        this.userService = userService;
    }


    public async Task<IssueAssignmentViewModel> CreateAsync(IssueAssignmentCreateModel issue)
    {
        var existUser = await userService.GetByIdAsync(issue.AssignessId);
        var existIssue = await issueService.GetByIdAsync(issue.IssueId);

        var existIssueAssignment = await repository
            .SelectAsQueryable()
            .Where(r => r.AssigneesId == issue.AssignessId)
            .FirstOrDefaultAsync(r => r.Id == issue.IssueId);

        if (existIssue is not null)
            throw new CustomException(409, "Issue Assignment is already exist with this id");
        var createdIssue = await repository.InsertAsync(existIssueAssignment);
        await repository.SaveAsync();

        return mapper.Map<IssueAssignmentViewModel>(createdIssue);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var existIssue = await repository.SelectByIdAsync(id)
             ?? throw new CustomException(404, "Issue Assignment not found");

        await repository.DeleteAsync(existIssue);
        await repository.SaveAsync();

        return true;
    }


    public async Task<IEnumerable<IssueAssignmentViewModel>> GetAllAsync()
    {
        var issues = await repository
         .SelectAsQueryable(new string[] { "Issue", "User" })
         .ToListAsync();

        return mapper.Map<IEnumerable<IssueAssignmentViewModel>>(issues);
    }


    public async Task<IssueAssignmentViewModel> GetByIdAsync(long id)
    {
        var existIssue = await repository.SelectByIdAsync(id, new string[] { "Issue", "User" })
             ?? throw new CustomException(404, "Issue Assignment not found");

        return mapper.Map<IssueAssignmentViewModel>(existIssue);
    }


    public async Task<IssueAssignmentViewModel> UpdateAsync(long id, IssueAssignmentUpdateModel issue)
    {
        var existUser = await userService.GetByIdAsync(issue.AssignessId);
        var existIssue = await issueService.GetByIdAsync(issue.IssueId);

        var existIssueAssignment = await repository.SelectByIdAsync(id)
           ?? throw new CustomException(404, "Issue Assignment not found");

        var mappedIssue = mapper.Map<IssueAssignment>(existIssueAssignment);
        var updatedIssue = await repository.UpdateAsync(mappedIssue);
        await repository.SaveAsync();

        return mapper.Map<IssueAssignmentViewModel>(updatedIssue);
    }
}