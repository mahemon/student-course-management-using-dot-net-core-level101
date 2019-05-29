using Microsoft.EntityFrameworkCore.Migrations;

namespace CST.Migrations
{
    public partial class secound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollCourses_Course_CourseId",
                table: "StudentEnrollCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollCourses_Students_StudentId",
                table: "StudentEnrollCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEnrollCourses_Course_CourseId",
                table: "TeacherEnrollCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEnrollCourses_Teachers_TeacherId",
                table: "TeacherEnrollCourses");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherEnrollCourses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "TeacherEnrollCourses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentEnrollCourses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentEnrollCourses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollCourses_Course_CourseId",
                table: "StudentEnrollCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollCourses_Students_StudentId",
                table: "StudentEnrollCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEnrollCourses_Course_CourseId",
                table: "TeacherEnrollCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEnrollCourses_Teachers_TeacherId",
                table: "TeacherEnrollCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollCourses_Course_CourseId",
                table: "StudentEnrollCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollCourses_Students_StudentId",
                table: "StudentEnrollCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEnrollCourses_Course_CourseId",
                table: "TeacherEnrollCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEnrollCourses_Teachers_TeacherId",
                table: "TeacherEnrollCourses");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherEnrollCourses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "TeacherEnrollCourses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentEnrollCourses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentEnrollCourses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollCourses_Course_CourseId",
                table: "StudentEnrollCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollCourses_Students_StudentId",
                table: "StudentEnrollCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEnrollCourses_Course_CourseId",
                table: "TeacherEnrollCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEnrollCourses_Teachers_TeacherId",
                table: "TeacherEnrollCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
