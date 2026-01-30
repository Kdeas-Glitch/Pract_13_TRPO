using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pract_12.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarUri",
                table: "UserProfiles",
                newName: "AvatarUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarUrl",
                table: "UserProfiles",
                newName: "AvatarUri");
        }
    }
}
