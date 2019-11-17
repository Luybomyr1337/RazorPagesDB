using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesGrades.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Acronym = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Acronym);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SubjectAcronym = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectAcronym",
                        column: x => x.SubjectAcronym,
                        principalTable: "Subjects",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Acronym", "Name" },
                values: new object[,]
                {
                    { "MAT", "Matematika" },
                    { "PRG", "Programování" },
                    { "WEB", "Webové aplikace" },
                    { "TEV", "Tělocvik" },
                    { "CJL", "Český jazyk a literatura" },
                    { "ANJ", "Anglický jazyk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectAcronym",
                table: "Grades",
                column: "SubjectAcronym");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
