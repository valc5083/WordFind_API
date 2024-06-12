using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordFind.Migrations
{
    /// <inheritdoc />
    public partial class MyMIGRA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthTokens_Users_UserItemUserId",
                table: "AuthTokens");

            migrationBuilder.DropIndex(
                name: "IX_AuthTokens_UserItemUserId",
                table: "AuthTokens");

            migrationBuilder.DropColumn(
                name: "UserItemUserId",
                table: "AuthTokens");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AuthTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_UserId",
                table: "AuthTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthTokens_Users_UserId",
                table: "AuthTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthTokens_Users_UserId",
                table: "AuthTokens");

            migrationBuilder.DropIndex(
                name: "IX_AuthTokens_UserId",
                table: "AuthTokens");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AuthTokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserItemUserId",
                table: "AuthTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_UserItemUserId",
                table: "AuthTokens",
                column: "UserItemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthTokens_Users_UserItemUserId",
                table: "AuthTokens",
                column: "UserItemUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
