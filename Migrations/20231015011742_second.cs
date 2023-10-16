using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewFormsProject.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "ApplicantsFroms");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "ApplicantsFroms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsFroms_SpecialityId",
                table: "ApplicantsFroms",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantsFroms_Specialities_SpecialityId",
                table: "ApplicantsFroms",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantsFroms_Specialities_SpecialityId",
                table: "ApplicantsFroms");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantsFroms_SpecialityId",
                table: "ApplicantsFroms");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "ApplicantsFroms");

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "ApplicantsFroms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
