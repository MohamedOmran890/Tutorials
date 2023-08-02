using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutorials.Data.Migrations
{
    public partial class add_level_in_SubjectTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Subjects_SubjectId",
                table: "Levels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Levels_SubjectId",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Levels");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Teacher_Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects",
                columns: new[] { "TeacherId", "SubjectId", "LevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Subjects_LevelId",
                table: "Teacher_Subjects",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Subjects_Levels_LevelId",
                table: "Teacher_Subjects",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Subjects_Levels_LevelId",
                table: "Teacher_Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_Subjects_LevelId",
                table: "Teacher_Subjects");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Teacher_Subjects");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Levels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects",
                columns: new[] { "TeacherId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Levels_SubjectId",
                table: "Levels",
                column: "SubjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_Subjects_SubjectId",
                table: "Levels",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
