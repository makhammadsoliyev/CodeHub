using AutoMapper;
using CodeHub.Domain.Entities;
using CodeHub.Model.BranchRepositories;
using CodeHub.Model.Files;
using CodeHub.Model.Folders;
using CodeHub.Model.Follows;
using CodeHub.Model.GitIgnores;
using CodeHub.Model.IssueAssignments;
using CodeHub.Model.Issues;
using CodeHub.Model.Readmes;
using CodeHub.Model.Repositories;
using CodeHub.Model.RepositoryStars;
using CodeHub.Model.Users;
using File = CodeHub.Domain.Entities.File;

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

        CreateMap<Follow, FollowViewModel>().ReverseMap();
        CreateMap<Follow, FollowUpdateModel>().ReverseMap();
        CreateMap<Follow, FollowCreateModel>().ReverseMap();

        CreateMap<ReadmeModel, ReadmeViewModel>().ReverseMap();
        CreateMap<ReadmeModel, ReadmeUpdateModel>().ReverseMap();
        CreateMap<ReadmeModel, ReadmeCreateModel>().ReverseMap();

        CreateMap<GitIgnore, GitIgnoreViewModel>().ReverseMap();
        CreateMap<GitIgnore, GitIgnoreUpdateModel>().ReverseMap();
        CreateMap<GitIgnore, GitIgnoreCreateModel>().ReverseMap();

        CreateMap<RepositoryStar, RepositoryStarViewModel>().ReverseMap();
        CreateMap<RepositoryStar, RepositoryStarUpdateModel>().ReverseMap();
        CreateMap<RepositoryStar, RepositoryStarCreateModel>().ReverseMap();

        CreateMap<Folder, FolderViewModel>().ReverseMap();
        CreateMap<Folder, FolderUpdateModel>().ReverseMap();
        CreateMap<Folder, FolderCreateModel>().ReverseMap();

        CreateMap<File, FileViewModel>().ReverseMap();
        CreateMap<File, FileUpdateModel>().ReverseMap();
        CreateMap<File, FileCreateModel>().ReverseMap();
    }
}
