using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutorials.Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_Student_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeacherId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Levels_LevelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_TeacherId1",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomStudent_AspNetUsers_studentsId",
                table: "RoomStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomStudent",
                table: "RoomStudent");

            migrationBuilder.DropIndex(
                name: "IX_RoomStudent_studentsId",
                table: "RoomStudent");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_TeacherId1",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LevelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Student_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeacherId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "studentsId",
                table: "RoomStudent");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Secretary_TeacherId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Student_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "studentsStudentId",
                table: "RoomStudent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomStudent",
                table: "RoomStudent",
                columns: new[] { "RoomsId", "studentsStudentId" });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teachers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomStudent_studentsStudentId",
                table: "RoomStudent",
                column: "studentsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TeacherId",
                table: "Rooms",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeacherId",
                table: "AspNetUsers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_LevelId",
                table: "Students",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AddressId",
                table: "Teachers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teachers_TeacherId",
                table: "AspNetUsers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Teachers_TeacherId",
                table: "Rooms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomStudent_Students_studentsStudentId",
                table: "RoomStudent",
                column: "studentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teachers_TeacherId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Teachers_TeacherId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomStudent_Students_studentsStudentId",
                table: "RoomStudent");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomStudent",
                table: "RoomStudent");

            migrationBuilder.DropIndex(
                name: "IX_RoomStudent_studentsStudentId",
                table: "RoomStudent");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_TeacherId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeacherId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "studentsStudentId",
                table: "RoomStudent");

            migrationBuilder.AddColumn<string>(
                name: "studentsId",
                table: "RoomStudent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId1",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Secretary_TeacherId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Student_AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId1",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomStudent",
                table: "RoomStudent",
                columns: new[] { "RoomsId", "studentsId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomStudent_studentsId",
                table: "RoomStudent",
                column: "studentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TeacherId1",
                table: "Rooms",
                column: "TeacherId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LevelId",
                table: "AspNetUsers",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Student_AddressId",
                table: "AspNetUsers",
                column: "Student_AddressId",
                unique: true,
                filter: "[Student_AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeacherId1",
                table: "AspNetUsers",
                column: "TeacherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_Student_AddressId",
                table: "AspNetUsers",
                column: "Student_AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeacherId1",
                table: "AspNetUsers",
                column: "TeacherId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Levels_LevelId",
                table: "AspNetUsers",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_TeacherId1",
                table: "Rooms",
                column: "TeacherId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomStudent_AspNetUsers_studentsId",
                table: "RoomStudent",
                column: "studentsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
