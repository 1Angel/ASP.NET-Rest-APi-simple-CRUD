using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCrudAsp.Migrations
{
    /// <inheritdoc />
    public partial class someschangess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Comments",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_postId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
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
    }
}
