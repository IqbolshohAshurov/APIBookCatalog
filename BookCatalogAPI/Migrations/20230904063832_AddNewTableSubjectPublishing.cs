using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableSubjectPublishing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Publishings_PublishingId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_PublishingId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "PublishingId",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "SubjectPublishings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PublishingId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectPublishing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectPublishings_Publishings_PublishingId",
                        column: x => x.PublishingId,
                        principalTable: "Publishings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectPublishings_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectPublishings_PublishingId",
                table: "SubjectPublishings",
                column: "PublishingId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectPublishings_SubjectId",
                table: "SubjectPublishings",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectPublishings");

            migrationBuilder.AddColumn<Guid>(
                name: "PublishingId",
                table: "Subjects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PublishingId",
                table: "Subjects",
                column: "PublishingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Publishings_PublishingId",
                table: "Subjects",
                column: "PublishingId",
                principalTable: "Publishings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
