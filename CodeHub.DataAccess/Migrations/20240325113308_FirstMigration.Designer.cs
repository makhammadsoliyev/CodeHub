﻿// <auto-generated />
using System;
using CodeHub.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeHub.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240325113308_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodeHub.Domain.Entities.BranchRepository", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("BranchName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("GitIgnoreId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LicenseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReadmeId")
                        .HasColumnType("bigint");

                    b.Property<long>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GitIgnoreId");

                    b.HasIndex("LicenseId");

                    b.HasIndex("ReadmeId");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("UserId");

                    b.ToTable("BranchRepositories");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Commit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("BranchRepositoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<long?>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BranchRepositoryId");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.File", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Extension")
                        .HasColumnType("text");

                    b.Property<long?>("FolderId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Folder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Follow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("FollowerId")
                        .HasColumnType("bigint");

                    b.Property<long>("FollowingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.GitIgnore", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("GitIgnores");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<long>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.IssueAssignment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AssigneesId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AssigneesId");

                    b.HasIndex("IssueId");

                    b.ToTable("IssueAssignments");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.License", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Readme", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Readmes");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Repository", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("BranchName")
                        .HasColumnType("text");

                    b.Property<string>("CloneUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<long?>("GitIgnoreId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LicenseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("ParentRepositoryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReadmeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Visibility")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GitIgnoreId");

                    b.HasIndex("LicenseId");

                    b.HasIndex("ParentRepositoryId");

                    b.HasIndex("ReadmeId");

                    b.HasIndex("UserId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.RepositoryFork", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("UserId");

                    b.ToTable("RepositoryForks");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.RepositoryStar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("UserId");

                    b.ToTable("RepositoryStars");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.BranchRepository", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.GitIgnore", "GitIgnore")
                        .WithMany()
                        .HasForeignKey("GitIgnoreId");

                    b.HasOne("CodeHub.Domain.Entities.License", "License")
                        .WithMany()
                        .HasForeignKey("LicenseId");

                    b.HasOne("CodeHub.Domain.Entities.Readme", "Readme")
                        .WithMany()
                        .HasForeignKey("ReadmeId");

                    b.HasOne("CodeHub.Domain.Entities.Repository", "Repository")
                        .WithMany("BranchRepositories")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeHub.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GitIgnore");

                    b.Navigation("License");

                    b.Navigation("Readme");

                    b.Navigation("Repository");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Commit", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.BranchRepository", "BranchRepository")
                        .WithMany()
                        .HasForeignKey("BranchRepositoryId");

                    b.HasOne("CodeHub.Domain.Entities.Repository", "Repository")
                        .WithMany("Commits")
                        .HasForeignKey("RepositoryId");

                    b.HasOne("CodeHub.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BranchRepository");

                    b.Navigation("Repository");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.File", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.Folder", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId");

                    b.HasOne("CodeHub.Domain.Entities.Repository", "Repository")
                        .WithMany()
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Folder", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.Folder", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("CodeHub.Domain.Entities.Repository", "Repository")
                        .WithMany("Folders")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Follow", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.User", "Follower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeHub.Domain.Entities.User", "Following")
                        .WithMany("Followings")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Issue", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeHub.Domain.Entities.Repository", "Repository")
                        .WithMany("Issues")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.IssueAssignment", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.User", "Assignees")
                        .WithMany()
                        .HasForeignKey("AssigneesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeHub.Domain.Entities.Issue", "Issue")
                        .WithMany("IssueAssignees")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignees");

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Repository", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.GitIgnore", "GitIgnore")
                        .WithMany()
                        .HasForeignKey("GitIgnoreId");

                    b.HasOne("CodeHub.Domain.Entities.License", "License")
                        .WithMany()
                        .HasForeignKey("LicenseId");

                    b.HasOne("CodeHub.Domain.Entities.Repository", "ParentRepository")
                        .WithMany()
                        .HasForeignKey("ParentRepositoryId");

                    b.HasOne("CodeHub.Domain.Entities.Readme", "Readme")
                        .WithMany()
                        .HasForeignKey("ReadmeId");

                    b.HasOne("CodeHub.Domain.Entities.User", "User")
                        .WithMany("Repositories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GitIgnore");

                    b.Navigation("License");

                    b.Navigation("ParentRepository");

                    b.Navigation("Readme");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.RepositoryFork", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.Repository", "Repository")
                        .WithMany()
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeHub.Domain.Entities.User", "User")
                        .WithMany("Forks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repository");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.RepositoryStar", b =>
                {
                    b.HasOne("CodeHub.Domain.Entities.Repository", "Repository")
                        .WithMany("Stars")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeHub.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repository");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Folder", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Issue", b =>
                {
                    b.Navigation("IssueAssignees");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.Repository", b =>
                {
                    b.Navigation("BranchRepositories");

                    b.Navigation("Commits");

                    b.Navigation("Folders");

                    b.Navigation("Issues");

                    b.Navigation("Stars");
                });

            modelBuilder.Entity("CodeHub.Domain.Entities.User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Followings");

                    b.Navigation("Forks");

                    b.Navigation("Repositories");
                });
#pragma warning restore 612, 618
        }
    }
}
