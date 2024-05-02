using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheaterAdmin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pulep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Puleb",
                table: "Managers",
                newName: "Pulep");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pulep",
                table: "Managers",
                newName: "Puleb");
        }
    }
}
