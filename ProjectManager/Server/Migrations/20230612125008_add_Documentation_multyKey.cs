using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class add_Documentation_multyKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documentations_IdDesignObject_IdMark_Number",
                table: "Documentations",
                columns: new[] { "IdDesignObject", "IdMark", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesignObjects_IdProject",
                table: "DesignObjects",
                column: "IdProject");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignObjects_Projects_IdProject",
                table: "DesignObjects",
                column: "IdProject",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documentations_DesignObjects_IdDesignObject",
                table: "Documentations",
                column: "IdDesignObject",
                principalTable: "DesignObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignObjects_Projects_IdProject",
                table: "DesignObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Documentations_DesignObjects_IdDesignObject",
                table: "Documentations");

            migrationBuilder.DropIndex(
                name: "IX_Documentations_IdDesignObject_IdMark_Number",
                table: "Documentations");

            migrationBuilder.DropIndex(
                name: "IX_DesignObjects_IdProject",
                table: "DesignObjects");
        }
    }
}
