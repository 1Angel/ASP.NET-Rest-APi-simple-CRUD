using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCrudAsp.Migrations
{
    /// <inheritdoc />
    public partial class relationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_BlogId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Comments",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                newName: "IX_Comments_postId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Comments",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_postId",
                table: "Comments",
                newName: "IX_Comments_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
