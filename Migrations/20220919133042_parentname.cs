using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courseapp.Migrations
{
    public partial class parentname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Emial = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Parent_Id = table.Column<int>(type: "int", nullable: true),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Category_Id",
                        column: x => x.Parent_Id,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CourseModelView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descriptoin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModelView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Course_Lesson",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Lesson", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Lesson_Category_Id",
                        column: x => x.Course_Id,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CategoryModelView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseModelViewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModelView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryModelView_CourseModelView_CourseModelViewId",
                        column: x => x.CourseModelViewId,
                        principalTable: "CourseModelView",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Descriptoin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Trainer_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Course_Trainer_Id",
                        column: x => x.Trainer_Id,
                        principalTable: "Trainer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Trainee_Courses",
                columns: table => new
                {
                    Trainee_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Registration_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee_Courses", x => new { x.Trainee_Id, x.Course_Id });
                    table.ForeignKey(
                        name: "FK_Trainee_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Course",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Trainee_Courses_Trainee_Id",
                        column: x => x.Trainee_Id,
                        principalTable: "Trainee",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Parent_Id",
                table: "Category",
                column: "Parent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelView_CourseModelViewId",
                table: "CategoryModelView",
                column: "CourseModelViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Category_Id",
                table: "Course",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Trainer_Id",
                table: "Course",
                column: "Trainer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Lesson_Course_Id",
                table: "Course_Lesson",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_Courses_Course_Id",
                table: "Trainee_Courses",
                column: "Course_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CategoryModelView");

            migrationBuilder.DropTable(
                name: "Course_Lesson");

            migrationBuilder.DropTable(
                name: "Trainee_Courses");

            migrationBuilder.DropTable(
                name: "CourseModelView");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
