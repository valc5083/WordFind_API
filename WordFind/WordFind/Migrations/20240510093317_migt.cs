using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordFind.Migrations
{
    /// <inheritdoc />
    public partial class migt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthTokens_Users_UseritemUserId",
                table: "AuthTokens");

            migrationBuilder.RenameColumn(
                name: "UseritemUserId",
                table: "AuthTokens",
                newName: "UserItemUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthTokens_UseritemUserId",
                table: "AuthTokens",
                newName: "IX_AuthTokens_UserItemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthTokens_Users_UserItemUserId",
                table: "AuthTokens",
                column: "UserItemUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthTokens_Users_UserItemUserId",
                table: "AuthTokens");

            migrationBuilder.RenameColumn(
                name: "UserItemUserId",
                table: "AuthTokens",
                newName: "UseritemUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthTokens_UserItemUserId",
                table: "AuthTokens",
                newName: "IX_AuthTokens_UseritemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthTokens_Users_UseritemUserId",
                table: "AuthTokens",
                column: "UseritemUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
