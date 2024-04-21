using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSender.DataAccess.Migrations
{
    public partial class AddLaterField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Later",
                table: "Tasks",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Later",
                table: "Tasks");
        }
    }
}
