using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class add_DocumentationCounter_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DocumentationsCounter",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentationsCounter",
                table: "DocumentationsCounter",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentationsCounter",
                table: "DocumentationsCounter");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DocumentationsCounter");
        }
    }
}
