using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterArt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AmendAicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AicId",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AicId",
                table: "Artworks");
        }
    }
}
