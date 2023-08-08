using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutorials.Data.Migrations
{
    public partial class addleveltosubjectteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects");

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Teacher_Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects",
                columns: new[] { "TeacherId", "SubjectId", "LevelId", "CenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Subjects_CenterId",
                table: "Teacher_Subjects",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Subjects_Centers_CenterId",
                table: "Teacher_Subjects",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Subjects_Centers_CenterId",
                table: "Teacher_Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_Subjects_CenterId",
                table: "Teacher_Subjects");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Teacher_Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher_Subjects",
                table: "Teacher_Subjects",
                columns: new[] { "TeacherId", "SubjectId", "LevelId" });
        }
    }
}
