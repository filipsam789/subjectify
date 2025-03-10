﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data;

#nullable disable

namespace Subjectify.Domain.DomainModels.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("CategorySubject", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriesId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("CategorySubject");
                });

            modelBuilder.Entity("Domain.DomainModels.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Domain.DomainModels.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2465616e-4c3e-4b8b-ab30-6ca5c9b5e415"),
                            Name = "Frontend"
                        },
                        new
                        {
                            Id = new Guid("c7a12c23-ac69-4cef-b52f-77a744afe96f"),
                            Name = "Backend"
                        },
                        new
                        {
                            Id = new Guid("904efdea-fc65-48d9-9547-4a053cb684a6"),
                            Name = "Artificial Intelligence"
                        },
                        new
                        {
                            Id = new Guid("3e752dd9-a938-4c7c-a7eb-b88742670ae8"),
                            Name = "Networks"
                        },
                        new
                        {
                            Id = new Guid("c3de1407-89f7-4b7a-9d0d-acf585c8cdd4"),
                            Name = "Data Science"
                        },
                        new
                        {
                            Id = new Guid("ec2d623f-3fb8-49e5-bcb9-44e0ca1def8b"),
                            Name = "Cybersecurity"
                        },
                        new
                        {
                            Id = new Guid("c9d9e0e8-b548-4e86-a0c8-07240f363a66"),
                            Name = "DevOps"
                        },
                        new
                        {
                            Id = new Guid("a7c8aae2-0baa-4c24-94b5-7dd27fb46051"),
                            Name = "Cloud Computing"
                        },
                        new
                        {
                            Id = new Guid("29c4638e-420a-4e2b-8366-f823b2830096"),
                            Name = "Game Development"
                        },
                        new
                        {
                            Id = new Guid("a6169928-f023-4c03-9f98-ed71bf69a1c7"),
                            Name = "Mobile Development"
                        },
                        new
                        {
                            Id = new Guid("0455586d-7051-4bdb-b9bd-1876aebeafa6"),
                            Name = "Embedded Systems"
                        });
                });

            modelBuilder.Entity("Domain.DomainModels.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Domain.DomainModels.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Domain.DomainModels.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NegativeComment")
                        .HasColumnType("TEXT");

                    b.Property<string>("PositiveComment")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.DomainModels.ReviewRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReviewId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("ReviewRequests");
                });

            modelBuilder.Entity("Domain.DomainModels.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.DomainModels.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("StudentId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Domain.DomainModels.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Domain.IdentityModels.SubjectifyUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("StudentId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProfessorSubject", b =>
                {
                    b.Property<Guid>("ProfessorsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProfessorsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("ProfessorSubject");
                });

            modelBuilder.Entity("CategorySubject", b =>
                {
                    b.HasOne("Domain.DomainModels.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DomainModels.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.DomainModels.Faculty", b =>
                {
                    b.HasOne("Domain.DomainModels.University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.DomainModels.Professor", b =>
                {
                    b.HasOne("Domain.DomainModels.Faculty", "Faculty")
                        .WithMany("Professors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Domain.DomainModels.Review", b =>
                {
                    b.HasOne("Domain.DomainModels.Student", "Student")
                        .WithMany("Reviews")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DomainModels.Subject", "Subject")
                        .WithMany("Reviews")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Domain.DomainModels.ReviewRequest", b =>
                {
                    b.HasOne("Domain.DomainModels.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Domain.DomainModels.Student", b =>
                {
                    b.HasOne("Domain.DomainModels.Faculty", "Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Domain.DomainModels.Subject", b =>
                {
                    b.HasOne("Domain.DomainModels.Faculty", "Faculty")
                        .WithMany("Subjects")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DomainModels.Student", null)
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Domain.IdentityModels.SubjectifyUser", b =>
                {
                    b.HasOne("Domain.DomainModels.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.HasOne("Domain.DomainModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Admin");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.IdentityModels.SubjectifyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.IdentityModels.SubjectifyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.IdentityModels.SubjectifyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.IdentityModels.SubjectifyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfessorSubject", b =>
                {
                    b.HasOne("Domain.DomainModels.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DomainModels.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.DomainModels.Faculty", b =>
                {
                    b.Navigation("Professors");

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Domain.DomainModels.Student", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Domain.DomainModels.Subject", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.DomainModels.University", b =>
                {
                    b.Navigation("Faculties");
                });
#pragma warning restore 612, 618
        }
    }
}
