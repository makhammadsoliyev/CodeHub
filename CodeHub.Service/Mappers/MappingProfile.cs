using AutoMapper;
using CodeHub.Domain.Entities;
using CodeHub.Model.BranchRepositories;
using CodeHub.Model.IssueAssignments;
using CodeHub.Model.Issues;
using CodeHub.Model.Repositories;
using CodeHub.Model.Users;

namespace CodeHub.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();

        CreateMap<Issue, IssueViewModel>().ReverseMap();
        CreateMap<Issue, IssueUpdateModel>().ReverseMap();
        CreateMap<Issue, IssueCreateModel>().ReverseMap();

        CreateMap<Repository, RepositoryViewModel>().ReverseMap();
        CreateMap<Repository, RepositoryUpdateModel>().ReverseMap();
        CreateMap<Repository, RepositoryCreateModel>().ReverseMap();

        CreateMap<IssueAssignment, IssueAssignmentViewModel>().ReverseMap();
        CreateMap<IssueAssignment, IssueAssignmentUpdateModel>().ReverseMap();
        CreateMap<IssueAssignment, IssueAssignmentCreateModel>().ReverseMap();

        CreateMap<BranchRepository, BranchRepositoryViewModel>().ReverseMap();
        CreateMap<BranchRepository, BranchRepositoryUpdateModel>().ReverseMap();
        CreateMap<BranchRepository, BranchRepositoryCreateModel>().ReverseMap();
    }
}
