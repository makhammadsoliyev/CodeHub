using CodeHub.Api.Middlewares;
using CodeHub.DataAccess.Contexts;
using CodeHub.DataAccess.Repositories;
using CodeHub.Service.Interfaces;
using CodeHub.Service.Mappers;
using CodeHub.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILicenseService, LicenseService>();
builder.Services.AddScoped<IGitIgnoreService, GitIgnoreService>();
builder.Services.AddScoped<IRepositoryService, RepositoryService>();
builder.Services.AddScoped<IReadmeService, ReadmeService>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<IIssueAssignmentService, IssueAssignmentService>();
builder.Services.AddScoped<IBranchRepositoryService, BranchRepositoryService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IRepositoryStarService, RepositoryStarService>();
builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<IFolderService, FolderService>();
builder.Services.AddScoped<ICommitService, CommitService>();
builder.Services.AddScoped<IRepositoryForkService, RepositoryForkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
