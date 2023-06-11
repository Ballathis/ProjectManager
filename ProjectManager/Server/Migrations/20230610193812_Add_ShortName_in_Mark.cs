using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_ShortName_in_Mark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Marks");
        }
    }
}
