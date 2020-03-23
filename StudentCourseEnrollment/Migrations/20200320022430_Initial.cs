using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentCourseEnrollment.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registeration",
                columns: table => new
                {
                    RegID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CourseCode = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegId", x => x.RegID);
                });

            migrationBuilder.CreateTable(
                name: "CoursesDetails",
                columns: table => new
                {
                    CourseCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseStartDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    CourseFee = table.Column<decimal>(nullable: false),
                    Grade = table.Column<string>(maxLength: 1, nullable: true),
                    RegisterationRegID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCode", x => x.CourseCode);
                    table.ForeignKey(
                        name: "FK_CoursesDetails_Registeration_RegisterationRegID",
                        column: x => x.RegisterationRegID,
                        principalTable: "Registeration",
                        principalColumn: "RegID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudName = table.Column<string>(nullable: false),
                    StudDOB = table.Column<DateTime>(nullable: false),
                    StudGender = table.Column<int>(nullable: false),
                    StudEmailAdd = table.Column<string>(maxLength: 50, nullable: false),
                    StudAddress = table.Column<string>(nullable: true),
                    StudphNum = table.Column<long>(maxLength: 10, nullable: false),
                    RegisterationRegID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudenID", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Registeration_RegisterationRegID",
                        column: x => x.RegisterationRegID,
                        principalTable: "Registeration",
                        principalColumn: "RegID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesDetails_RegisterationRegID",
                table: "CoursesDetails",
                column: "RegisterationRegID");

            migrationBuilder.CreateIndex(
                name: "IX_Registeration_CourseCode",
                table: "Registeration",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Registeration_StudentId",
                table: "Registeration",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_RegisterationRegID",
                table: "StudentDetails",
                column: "RegisterationRegID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registeration_CoursesDetails_CourseCode",
                table: "Registeration",
                column: "CourseCode",
                principalTable: "CoursesDetails",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registeration_StudentDetails_StudentId",
                table: "Registeration",
                column: "StudentId",
                principalTable: "StudentDetails",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesDetails_Registeration_RegisterationRegID",
                table: "CoursesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_Registeration_RegisterationRegID",
                table: "StudentDetails");

            migrationBuilder.DropTable(
                name: "Registeration");

            migrationBuilder.DropTable(
                name: "CoursesDetails");

            migrationBuilder.DropTable(
                name: "StudentDetails");
        }
    }
}
