using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pract_12.Migrations
{
    /// <inheritdoc />
    public partial class CreatePeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Students",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "Login");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Students",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
