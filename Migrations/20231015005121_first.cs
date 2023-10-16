using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewFormsProject.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantsFroms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Github_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedIn_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ITI_Graduate = table.Column<bool>(type: "bit", nullable: false),
                    year_Of_Graduation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graduation_Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Current_Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Current_Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expected_Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Interested_Working_In_Cairo = table.Column<bool>(type: "bit", nullable: false),
                    Mobile_Apps_Experience = table.Column<bool>(type: "bit", nullable: false),
                    E_Commerce_Apps_Experience = table.Column<bool>(type: "bit", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsFroms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantsFroms_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantsFroms_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantsFroms_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsFroms_FacultyId",
                table: "ApplicantsFroms",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsFroms_GovernorateId",
                table: "ApplicantsFroms",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsFroms_UniversityId",
                table: "ApplicantsFroms",
                column: "UniversityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantsFroms");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
