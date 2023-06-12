using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class add_DocumentationCounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentationsCounter",
                columns: table => new
                {
                    IdDesignObject = table.Column<int>(type: "int", nullable: false),
                    DocumentationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentationsCounter_IdDesignObject",
                table: "DocumentationsCounter",
                column: "IdDesignObject",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentationsCounter");
        }
    }
}
