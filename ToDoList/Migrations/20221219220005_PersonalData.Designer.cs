﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Data;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221219220005_PersonalData")]
    partial class PersonalData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("ToDoList.Models.Database.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ToDoID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ToDoID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ToDoList.Models.Database.PersonalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PersonalData");
                });

            modelBuilder.Entity("ToDoList.Models.Database.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CompletedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TopicID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TopicID");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("ToDoList.Models.Database.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("ToDoList.Models.Database.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonalDataID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonalDataID");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("ToDoList.Models.Database.Comment", b =>
                {
                    b.HasOne("ToDoList.Models.Database.ToDo", "ToDo")
                        .WithMany()
                        .HasForeignKey("ToDoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDo");
                });

            modelBuilder.Entity("ToDoList.Models.Database.ToDo", b =>
                {
                    b.HasOne("ToDoList.Models.Database.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("ToDoList.Models.Database.UserData", b =>
                {
                    b.HasOne("ToDoList.Models.Database.PersonalData", "PersonalData")
                        .WithMany()
                        .HasForeignKey("PersonalDataID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalData");
                });
#pragma warning restore 612, 618
        }
    }
}
