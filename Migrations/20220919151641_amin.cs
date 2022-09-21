using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courseapp.Migrations
{
    public partial class amin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryModelView");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryModelView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseModelViewId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelView_CourseModelViewId",
                table: "CategoryModelView",
                column: "CourseModelViewId");
        }
    }
}
