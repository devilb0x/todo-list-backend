using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todolistapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ListItem",
                table: "ListItem");

            migrationBuilder.RenameTable(
                name: "ListItem",
                newName: "ListItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems");

            migrationBuilder.RenameTable(
                name: "ListItems",
                newName: "ListItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListItem",
                table: "ListItem",
                column: "Id");
        }
    }
}
