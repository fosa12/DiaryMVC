using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaryMVC.Infrastructure.Migrations
{
    public partial class AddNewPropIsDeletedInUniversitySubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UniversitySubjects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UniversitySubjects");
        }
    }
}
