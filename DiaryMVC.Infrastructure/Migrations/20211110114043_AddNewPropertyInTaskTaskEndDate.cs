using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaryMVC.Infrastructure.Migrations
{
    public partial class AddNewPropertyInTaskTaskEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TaskEndDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskEndDate",
                table: "Tasks");
        }
    }
}
