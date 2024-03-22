using AutoMapper;
using CodeHub.Domain.Entities;
using CodeHub.Model.BranchRepositories;
using CodeHub.Model.Commits;
using CodeHub.Model.File;
using CodeHub.Model.Follow;
using CodeHub.Model.GitIgnore;
using CodeHub.Model.IssueAssignments;
using CodeHub.Model.Issues;
using CodeHub.Model.Licenses;
using CodeHub.Model.Models.Folders;
using CodeHub.Model.Readme;
using CodeHub.Model.Repositories;
using CodeHub.Model.RepositoryStar;
using CodeHub.Model.RepositroyForks;
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

        CreateMap<File, FileViewModel>().ReverseMap();
        CreateMap<File, FileUpdateModel>().ReverseMap();
        CreateMap<File, FileCreateModel>().ReverseMap();

        CreateMap<Folder, FolderViewModel>().ReverseMap();
        CreateMap<Folder, FolderCreateModel>().ReverseMap();
        CreateMap<Folder, FolderCreateModel>().ReverseMap();

        CreateMap<RepositoryFork, RepositoryForkViewModel>().ReverseMap();
        CreateMap<RepositoryFork, RepositoryForkUpdateModel>().ReverseMap();
        CreateMap<RepositoryFork, RepositoryForkCreateModel>().ReverseMap();

        CreateMap<Commit, CommitViewModel>().ReverseMap();
        CreateMap<Commit, CommitUpdateModel>().ReverseMap();
        CreateMap<Commit, CommitCreateModel>().ReverseMap();

        CreateMap<GitIgnore, GitIgnoreViewModel>().ReverseMap();
        CreateMap<GitIgnore, GitIgnoreUpdateModel>().ReverseMap();
        CreateMap<GitIgnore, GitIgnoreCreateModel>().ReverseMap();

        CreateMap<License, LicenseViewModel>().ReverseMap();
        CreateMap<License, LicenseUpdateModel>().ReverseMap();
        CreateMap<License, LicenseCreateModel>().ReverseMap();

        CreateMap<Readme, ReadmeViewModel>().ReverseMap();
        CreateMap<Readme, ReadmeUpdateModel>().ReverseMap();
        CreateMap<Readme, ReadmeCreateModel>().ReverseMap();

        CreateMap<RepositoryStar, RepositoryStarViewModel>().ReverseMap();
        CreateMap<RepositoryStar, RepositoryStarUpdateModel>().ReverseMap();
        CreateMap<RepositoryStar, RepositoryStarCreateModel>().ReverseMap();

        CreateMap<Follow, FollowViewModel>().ReverseMap().ReverseMap();
        CreateMap<Follow, FollowUpdateModel>().ReverseMap().ReverseMap();
        CreateMap<Follow, FollowCreateModel>().ReverseMap().ReverseMap();
    }
}
