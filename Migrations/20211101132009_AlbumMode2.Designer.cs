﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project2_Images.Data;

namespace Project2_Images.Migrations
{
    [DbContext(typeof(Project2_ImagesContext))]
    [Migration("20211101132009_AlbumMode2")]
    partial class AlbumMode2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImageUser", b =>
                {
                    b.Property<int>("CollectionID")
                        .HasColumnType("int");

                    b.Property<int>("GrantedAccessId")
                        .HasColumnType("int");

                    b.HasKey("CollectionID", "GrantedAccessId");

                    b.HasIndex("GrantedAccessId");

                    b.ToTable("ImageUser");
                });

            modelBuilder.Entity("Project2_Images.Models.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GrantedAcessId")
                        .HasColumnType("int");

                    b.Property<string>("Uploader")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GrantedAcessId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Project2_Images.Models.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeoTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uploader")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Project2_Images.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ImageUser", b =>
                {
                    b.HasOne("Project2_Images.Models.Image", null)
                        .WithMany()
                        .HasForeignKey("CollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2_Images.Models.User", null)
                        .WithMany()
                        .HasForeignKey("GrantedAccessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project2_Images.Models.Album", b =>
                {
                    b.HasOne("Project2_Images.Models.User", "GrantedAcess")
                        .WithMany()
                        .HasForeignKey("GrantedAcessId");

                    b.Navigation("GrantedAcess");
                });

            modelBuilder.Entity("Project2_Images.Models.Image", b =>
                {
                    b.HasOne("Project2_Images.Models.Album", null)
                        .WithMany("AlbumContents")
                        .HasForeignKey("AlbumID");
                });

            modelBuilder.Entity("Project2_Images.Models.User", b =>
                {
                    b.HasOne("Project2_Images.Models.Album", null)
                        .WithMany("GrantedAccess")
                        .HasForeignKey("AlbumID");
                });

            modelBuilder.Entity("Project2_Images.Models.Album", b =>
                {
                    b.Navigation("AlbumContents");

                    b.Navigation("GrantedAccess");
                });
#pragma warning restore 612, 618
        }
    }
}