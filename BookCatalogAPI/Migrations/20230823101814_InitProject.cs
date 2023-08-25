using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    forename = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", precision: 8, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "date", precision: 8, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PublishingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    PublishingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Publishings_PublishingId",
                        column: x => x.PublishingId,
                        principalTable: "Publishings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    CountPage = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    YearOfPublication = table.Column<DateTime>(type: "date", precision: 4, nullable: false),
                    Isbn = table.Column<string>(type: "text", maxLength: 13, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    Edition = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    SubjectId = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false),
                    PublishingId = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", precision: 8, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "date", precision: 8, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishings_PublishingId",
                        column: x => x.PublishingId,
                        principalTable: "Publishings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLanguageID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLanguage_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Key_Forename",
                table: "Authors",
                columns: new[] { "name", "forename" });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLanguage_BookId",
                table: "BookLanguage",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLanguage_LanguageId",
                table: "BookLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishingId",
                table: "Books",
                column: "PublishingId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubjectId",
                table: "Books",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "Key_BookName",
                table: "Books",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "UniqueKey_ISBN",
                table: "Books",
                column: "Isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Key_CityName",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Key_LanguageName",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishings_CityId",
                table: "Publishings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "Key_PublishingName",
                table: "Publishings",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PublishingId",
                table: "Subjects",
                column: "PublishingId");

            migrationBuilder.CreateIndex(
                name: "Key_TitleGenre",
                table: "Subjects",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookLanguage");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Publishings");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
