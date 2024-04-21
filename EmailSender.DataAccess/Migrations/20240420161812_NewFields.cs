using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSender.DataAccess.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Server",
                table: "Senders",
                newName: "ServerSMTP");

            migrationBuilder.RenameColumn(
                name: "Port",
                table: "Senders",
                newName: "ServerIMAP");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSender",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Tasks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PortIMAP",
                table: "Senders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PortSMTP",
                table: "Senders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSender",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PortIMAP",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "PortSMTP",
                table: "Senders");

            migrationBuilder.RenameColumn(
                name: "ServerSMTP",
                table: "Senders",
                newName: "Server");

            migrationBuilder.RenameColumn(
                name: "ServerIMAP",
                table: "Senders",
                newName: "Port");
        }
    }
}
