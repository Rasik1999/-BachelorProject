﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkingWithProjects.API.Models;

namespace WorkingWithProjects.API.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20210504111226_Added_Many_To_Many")]
    partial class Added_Many_To_Many
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkingWithProjects.DATA.Hashtag", b =>
                {
                    b.Property<int>("HashtagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HashtagId");

                    b.ToTable("Hashtags");

                    b.HasData(
                        new
                        {
                            HashtagId = 1,
                            Name = "HashtagName1"
                        },
                        new
                        {
                            HashtagId = 2,
                            Name = "HashtagName2"
                        },
                        new
                        {
                            HashtagId = 3,
                            Name = "HashtagName3"
                        });
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.KindOfProject", b =>
                {
                    b.Property<int>("KindOfProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KindOfProjectId");

                    b.ToTable("KindsOfProject");

                    b.HasData(
                        new
                        {
                            KindOfProjectId = 1,
                            Name = "TestName1"
                        },
                        new
                        {
                            KindOfProjectId = 2,
                            Name = "TestName2"
                        },
                        new
                        {
                            KindOfProjectId = 3,
                            Name = "TestName3"
                        });
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.KindOfProjectRole", b =>
                {
                    b.Property<int>("KindId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("KindId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("KindOfProjectRole");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.Progress", b =>
                {
                    b.Property<int>("ProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DesiredValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentageOfCompletion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProgressId");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Progresses");

                    b.HasData(
                        new
                        {
                            ProgressId = 1,
                            DesiredValue = 5430m,
                            PercentageOfCompletion = 0m,
                            ProjectId = 1,
                            Value = 4000m
                        },
                        new
                        {
                            ProgressId = 2,
                            DesiredValue = 6000m,
                            PercentageOfCompletion = 0m,
                            ProjectId = 2,
                            Value = 2000m
                        });
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashtagIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KindOfProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("KindOfProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Description = "Description1",
                            HashtagIds = "1,2",
                            KindOfProjectId = 1,
                            Title = "Title1",
                            UserId = 1
                        },
                        new
                        {
                            ProjectId = 2,
                            Description = "Description2",
                            HashtagIds = "2,3",
                            KindOfProjectId = 2,
                            Title = "Title2",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Student"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Don",
                            LastName = "Yagon",
                            RolesId = 1
                        },
                        new
                        {
                            UserId = 2,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lava",
                            LastName = "Yasha",
                            RolesId = 2
                        });
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.KindOfProjectRole", b =>
                {
                    b.HasOne("WorkingWithProjects.DATA.KindOfProject", "KindOfProject")
                        .WithMany("KindOfProjectRoles")
                        .HasForeignKey("KindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkingWithProjects.DATA.Role", "Role")
                        .WithMany("KindOfProjectRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KindOfProject");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.Progress", b =>
                {
                    b.HasOne("WorkingWithProjects.DATA.Project", "Project")
                        .WithOne("Progress")
                        .HasForeignKey("WorkingWithProjects.DATA.Progress", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.Project", b =>
                {
                    b.HasOne("WorkingWithProjects.DATA.KindOfProject", "KindOfProject")
                        .WithMany("Projects")
                        .HasForeignKey("KindOfProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkingWithProjects.DATA.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KindOfProject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.User", b =>
                {
                    b.HasOne("WorkingWithProjects.DATA.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.KindOfProject", b =>
                {
                    b.Navigation("KindOfProjectRoles");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.Project", b =>
                {
                    b.Navigation("Progress");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.Role", b =>
                {
                    b.Navigation("KindOfProjectRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WorkingWithProjects.DATA.User", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
