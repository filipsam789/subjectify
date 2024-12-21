using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Reviews",
                newName: "PositiveComment");

            migrationBuilder.AddColumn<string>(
                name: "NegativeComment",
                table: "Reviews",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegativeComment",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "PositiveComment",
                table: "Reviews",
                newName: "Comment");
        }
    }
}
