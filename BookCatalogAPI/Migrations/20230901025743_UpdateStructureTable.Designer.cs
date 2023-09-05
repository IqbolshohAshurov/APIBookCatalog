﻿// <auto-generated />
using System;
using BookCatalogAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookCatalogAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230901025743_UpdateStructureTable")]
    partial class UpdateStructureTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookCatalogAPI.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(8)
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("text")
                        .HasColumnName("forename");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("UpdatedAt")
                        .HasPrecision(8)
                        .HasColumnType("date");

                    b.HasKey("Id")
                        .HasName("PK_AuthorID");

                    b.HasIndex("FirstName", "LastName")
                        .HasDatabaseName("Key_Forename");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<int>("CountPage")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(8)
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte>("Edition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((byte)1);

                    b.Property<string>("Isbn")
                        .HasMaxLength(13)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<Guid>("PublishingId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SubjectId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasPrecision(8)
                        .HasColumnType("date");

                    b.Property<string>("YearOfPublication")
                        .HasPrecision(4)
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_BookID");

                    b.HasIndex("Isbn")
                        .IsUnique()
                        .HasDatabaseName("UniqueKey_ISBN");

                    b.HasIndex("Name")
                        .HasDatabaseName("Key_BookName");

                    b.HasIndex("PublishingId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.BookAuthor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_BookAuthorID");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors", (string)null);
                });

            modelBuilder.Entity("BookCatalogAPI.Models.BookLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_BookLanguageID");

                    b.HasIndex("BookId");

                    b.HasIndex("LanguageId");

                    b.ToTable("BookLanguage", (string)null);
                });

            modelBuilder.Entity("BookCatalogAPI.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(70)
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("PK_CityID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("Key_CityName");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("PK_LanguageID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("Key_LanguageName");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Publishing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("PK_PublishingID");

                    b.HasIndex("CityId");

                    b.HasIndex("Name")
                        .HasDatabaseName("Key_PublishingName");

                    b.ToTable("Publishings");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PublishingId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("PK_GenreID");

                    b.HasIndex("PublishingId");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasDatabaseName("Key_TitleGenre");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Book", b =>
                {
                    b.HasOne("BookCatalogAPI.Models.Publishing", "Publishing")
                        .WithMany()
                        .HasForeignKey("PublishingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCatalogAPI.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishing");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.BookAuthor", b =>
                {
                    b.HasOne("BookCatalogAPI.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCatalogAPI.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.BookLanguage", b =>
                {
                    b.HasOne("BookCatalogAPI.Models.Book", "Book")
                        .WithMany("BookLanguages")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCatalogAPI.Models.Language", "Language")
                        .WithMany("BookLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Publishing", b =>
                {
                    b.HasOne("BookCatalogAPI.Models.City", "City")
                        .WithMany("Publishings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Subject", b =>
                {
                    b.HasOne("BookCatalogAPI.Models.Publishing", "Publishing")
                        .WithMany("Subjects")
                        .HasForeignKey("PublishingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishing");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookLanguages");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.City", b =>
                {
                    b.Navigation("Publishings");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Language", b =>
                {
                    b.Navigation("BookLanguages");
                });

            modelBuilder.Entity("BookCatalogAPI.Models.Publishing", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
