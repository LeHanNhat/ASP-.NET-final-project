using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookingflightmvcUI.Migrations
{
    /// <inheritdoc />
    public partial class newinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Flight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
