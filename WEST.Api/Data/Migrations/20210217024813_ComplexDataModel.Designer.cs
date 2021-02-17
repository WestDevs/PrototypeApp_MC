﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEST.Api.Data;

namespace WEST.Api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210217024813_ComplexDataModel")]
    partial class ComplexDataModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WEST.Api.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("TypeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WEST.Api.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("IconPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("WEST.Api.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("WEST.Api.Entities.Learner", b =>
                {
                    b.Property<int>("LearnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LearnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Learner");
                });

            modelBuilder.Entity("WEST.Api.Entities.LearnerCourse", b =>
                {
                    b.Property<int>("LearnerId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("LearnerId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("LearnerCourse");
                });

            modelBuilder.Entity("WEST.Api.Entities.LearnerGroup", b =>
                {
                    b.Property<int>("LearnerId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("LearnerId", "GroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("LearnerId")
                        .IsUnique();

                    b.ToTable("LearnerGroup");
                });

            modelBuilder.Entity("WEST.Api.Entities.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("WEST.Api.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("WEST.Api.Entities.AppUser", b =>
                {
                    b.HasOne("WEST.Api.Entities.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEST.Api.Entities.UserType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("WEST.Api.Entities.Learner", b =>
                {
                    b.HasOne("WEST.Api.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WEST.Api.Entities.LearnerCourse", b =>
                {
                    b.HasOne("WEST.Api.Entities.Course", "Course")
                        .WithMany("LearnerCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEST.Api.Entities.Learner", "Learner")
                        .WithMany("LearnerCourses")
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("WEST.Api.Entities.LearnerGroup", b =>
                {
                    b.HasOne("WEST.Api.Entities.Group", "Group")
                        .WithMany("LearnerGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEST.Api.Entities.Learner", "Learner")
                        .WithOne("LearnerGroup")
                        .HasForeignKey("WEST.Api.Entities.LearnerGroup", "LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("WEST.Api.Entities.Course", b =>
                {
                    b.Navigation("LearnerCourses");
                });

            modelBuilder.Entity("WEST.Api.Entities.Group", b =>
                {
                    b.Navigation("LearnerGroups");
                });

            modelBuilder.Entity("WEST.Api.Entities.Learner", b =>
                {
                    b.Navigation("LearnerCourses");

                    b.Navigation("LearnerGroup");
                });
#pragma warning restore 612, 618
        }
    }
}